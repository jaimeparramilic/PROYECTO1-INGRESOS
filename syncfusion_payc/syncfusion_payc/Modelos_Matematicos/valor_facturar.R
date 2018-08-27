factura <- function(cod_factura) {
  #CONEXIÓN Y EXTRACCIÓN DE LA INFORMACIÓN DE LA BASE DE DATOS---------------
  library(DBI)
  #CREACION DE LA CONEXION A BASE DE DATOS
  con <- dbConnect(odbc::odbc(), "PAYC_FACTURACION", uid = "sa", pwd = "1234JAMS*")
  query<-paste0("SELECT * FROM FACTURAS WHERE COD_FACTURA=",cod_factura)
  FACTURAS<-dbGetQuery(con, query)
  fecha<-FACTURAS$COD_FORMAS_PAGO_FECHAS
  proyecto<-FACTURAS$COD_CONTRATO_PROYECTO
  estado<-FACTURAS$COD_ESTADO_FACTURA
  #EXTRACCION DE LA INFORMACION IMPORTANTE
  INGRESOS_PERSONAS <- dbGetQuery(con, "SELECT * FROM FLUJO_INGRESOS_ROL")
  ITEMS_CONTRATO <- dbGetQuery(con, "SELECT * FROM ITEMS_CONTRATO")
  fijos<- paste0("SELECT DISTINCT FLUJO_INGRESOS_ITEMS.*, ITEMS_CONTRATO.COD_TIPO_REEMBOLSO
                 FROM FLUJO_INGRESOS_ITEMS, ITEMS_CONTRATO 
                 WHERE ITEMS_CONTRATO.COD_TIPO_REEMBOLSO=1 
                 AND FLUJO_INGRESOS_ITEMS.ESTADO='SI'
                 AND FLUJO_INGRESOS_ITEMS.COD_CONTRATO_PROYECTO=",proyecto,"
                 AND FLUJO_INGRESOS_ITEMS.COD_FORMAS_PAGO_FECHAS=",fecha)
  variables<-paste0("SELECT DISTINCT REGISTRO_ITEMS_OTROS_COSTOS.*, ITEMS_CONTRATO.COD_TIPO_REEMBOLSO
                    FROM REGISTRO_ITEMS_OTROS_COSTOS, ITEMS_CONTRATO 
                    WHERE ITEMS_CONTRATO.COD_TIPO_REEMBOLSO=2
                    AND REGISTRO_ITEMS_OTROS_COSTOS.COD_CONTRATO_PROYECTO=",proyecto,"
                    AND REGISTRO_ITEMS_OTROS_COSTOS.COD_FORMAS_PAGO_FECHAS=",fecha)
  ITEMS_FIJOS <- dbGetQuery(con, fijos)
  ITEMS_VARIABLES<-dbGetQuery(con, variables)
  
  #CALCULO DE LOS VALORES TOTALES HISTORICOS A FACTURAR POR PERSONA E ITEM------------
  TOTAL_PERSONAS <- aggregate(VALOR_CON_PRESTACIONES ~ COD_FORMAS_PAGO_FECHAS +
                                COD_CONTRATO_PROYECTO + COD_ROL, data = INGRESOS_PERSONAS, sum)
  TOTAL_ITEMS_FIJOS <- aggregate(VALOR_TOTAL ~ COD_FORMAS_PAGO_FECHAS + COD_CONTRATO_PROYECTO
                                 + COD_ITEM, data = ITEMS_FIJOS, sum)
  if (nrow(ITEMS_VARIABLES)!=0){
    TOTAL_ITEMS_VARIABLES <- aggregate(VALOR_COMERCIAL ~ COD_FORMAS_PAGO_FECHAS + COD_CONTRATO_PROYECTO
                                       + COD_ITEM, data = ITEMS_VARIABLES, sum)
  }
  
  #ELIMINAR LOS DATOS REPETIDOS DEL PROYECTO QUE SE ESTÁ CONSULTANDO
  eliminar<-paste0("DELETE FROM [dbo].[DETALLE_FACTURA_PERS] WHERE [COD_CONTRATO_PROYECTO] =", proyecto, "AND COD_FORMAS_PAGO_FECHAS=",fecha)
  dbExecute(con, eliminar)
  eliminar<-paste0("DELETE FROM [dbo].[DETALLE_FACTURA_ITEM] WHERE [COD_CONTRATO_PROYECTO] =", proyecto, "AND COD_FORMAS_PAGO_FECHAS=",fecha)
  dbExecute(con, eliminar)
  
  #CÁLCULO E INSERCIÓN DE LA INFORMACIÓN EN LAS TABLAS
  chunksize = 1000 # arbitrary chunk size
  TABLA_TEMPORAL<-TOTAL_PERSONAS[TOTAL_PERSONAS$COD_FORMAS_PAGO_FECHAS==fecha & TOTAL_PERSONAS$COD_CONTRATO_PROYECTO==proyecto,]
  for (i in 1:ceiling(nrow(TABLA_TEMPORAL)/chunksize)) {
    query = paste0("INSERT INTO [dbo].[DETALLE_FACTURA_PERS] 
                   ([COD_CONTRATO_PROYECTO]
                   ,[COD_ROL]
                   ,[COD_FORMAS_PAGO_FECHAS]
                   ,[VALOR_SIN_IMPUESTOS]
                   ,[FECHA_REGISTRO]
                   ,[USUARIO]
                   ,[COD_ESTADO_FACTURA]
                   ,[COD_CAUSA_ESTADO]
                   ,[OBSERVACIONES]
                   ,[COD_FACTURA]
                   ,[COD_ESTADO_DETALLE]) 
                   VALUES")
    vals = NULL
    for (j in 1:chunksize) {
      k = (i-1)*chunksize+j
      if (k <= nrow(TABLA_TEMPORAL)) {
        vals[j] = paste0('(', paste0(TABLA_TEMPORAL$COD_CONTRATO_PROYECTO[k],",",
                                     TABLA_TEMPORAL$COD_ROL[k],",",
                                     TABLA_TEMPORAL$COD_FORMAS_PAGO_FECHAS[k],",",
                                     TABLA_TEMPORAL$VALOR_CON_PRESTACIONES[k],",'",
                                     Sys.time(),"','GENERADO','",
                                     estado,"',1,'',",cod_factura,",1)"),collapse = ',')
      }
    }
    query = paste0(query, paste0(vals,collapse=','))
    dbExecute(con, query)
  }
  
  for (i in 1:ceiling(nrow(TOTAL_ITEMS_FIJOS)/chunksize)) {
    query = paste0("INSERT INTO [dbo].[DETALLE_FACTURA_ITEM]
                   ([COD_CONTRATO_PROYECTO]
                   ,[COD_ITEM]
                   ,[COD_FORMAS_PAGO_FECHAS]
                   ,[VALOR_SIN_IMPUESTOS]
                   ,[FECHA_REGISTRO]
                   ,[USUARIO]
                   ,[COD_ESTADO_FACTURA]
                   ,[COD_CAUSA_ESTADO]
                   ,[OBSERVACIONES]
                   ,[COD_FACTURA]
                   ,[COD_ESTADO_DETALLE])
                   VALUES") 
    vals = NULL
    for (j in 1:chunksize) {
      k = (i-1)*chunksize+j
      if (k <= nrow(TOTAL_ITEMS_FIJOS)) {
        vals[j] = paste0('(', paste0(TOTAL_ITEMS_FIJOS$COD_CONTRATO_PROYECTO[k],",",
                                     TOTAL_ITEMS_FIJOS$COD_ITEM[k],",",
                                     TOTAL_ITEMS_FIJOS$COD_FORMAS_PAGO_FECHAS[k],",",
                                     TOTAL_ITEMS_FIJOS$VALOR_TOTAL[k],",'",
                                     Sys.time(),"','GENERADO','",
                                     estado,"',1,'',",cod_factura,",1)"),collapse = ',')
      }
    }
    query = paste0(query, paste0(vals,collapse=','))
    dbExecute(con, query)
  }
  
  if (nrow(ITEMS_VARIABLES)!=0) {
    for (i in 1:ceiling(nrow(TOTAL_ITEMS_VARIABLES)/chunksize)) {
      query = paste0("INSERT INTO [dbo].[DETALLE_FACTURA_ITEM]
                     ([COD_CONTRATO_PROYECTO]
                     ,[COD_ITEM]
                     ,[COD_FORMAS_PAGO_FECHAS]
                     ,[VALOR_SIN_IMPUESTOS]
                     ,[FECHA_REGISTRO]
                     ,[USUARIO]
                     ,[COD_ESTADO_FACTURA]
                     ,[COD_CAUSA_ESTADO]
                     ,[OBSERVACIONES]
                     ,[COD_FACTURA]
                     ,[COD_ESTADO_DETALLE])
                     VALUES") 
      vals = NULL
      for (j in 1:chunksize) {
        k = (i-1)*chunksize+j
        if (k <= nrow(TOTAL_ITEMS_VARIABLES)) {
          vals[j] = paste0('(', paste0(TOTAL_ITEMS_VARIABLES$COD_CONTRATO_PROYECTO[k],",",
                                       TOTAL_ITEMS_VARIABLES$COD_ITEM[k],",",
                                       TOTAL_ITEMS_VARIABLES$COD_FORMAS_PAGO_FECHAS[k],",",
                                       TOTAL_ITEMS_VARIABLES$VALOR_COMERCIAL[k],",'",
                                       Sys.time(),"','GENERADO','",
                                       estado,"',1,'',",cod_factura,",1)"),collapse = ',')
        }
      }
      query = paste0(query, paste0(vals,collapse=','))
      dbExecute(con, query)
    } }
  
  
  
  dbDisconnect(con)
}