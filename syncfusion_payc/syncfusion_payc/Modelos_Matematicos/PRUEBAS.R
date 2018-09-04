factura <- function(cod_factura) {
  #FUNCIÓN QUE CÁLCULA EL NÚMERO DE HORAS DE ADICIÓN O DESCUENTO, DE ACUERDO CON EL REGISTRO DE NOVEDADES -----
  funcion<-function(tabla,fecha_ini, fecha_fin){
    library(lubridate)
    if (nrow(tabla) != 0) {
      if (day(fecha_ini)<day(fecha_fin)){
        dias<-as.numeric(difftime(fecha_fin,fecha_ini,units = "days"))
        horas<- (dias%%1)*24
        Total<-floor(dias)*9+horas
        return(Total)
      } else {
        return(difftime(fecha_fin,fecha_ini,units = "hours"))
      } } }    
  
  #CONEXIÓN Y EXTRACCIÓN DE LA INFORMACIÓN DE LA BASE DE DATOS---------------
  #CONEXIÓN A LA BASE DE DATOS
  library(DBI)
  #cod_factura=1
  con <- dbConnect(odbc::odbc(), "PAYC_FACTURACION", uid = "sa", pwd = "1234JAMS*")
  cod_factura=4
  #EXTRACCION DE LA INFORMACION IMPORTANTE DE LA BASE DE DATOS
  fact<-paste0("SELECT * FROM FACTURAS WHERE COD_FACTURA=",cod_factura)
  FACTURAS<-dbGetQuery(con, fact)
  
  fecha<-FACTURAS$COD_FORMAS_PAGO_FECHAS
  proyecto<-FACTURAS$COD_CONTRATO_PROYECTO
  estado<-FACTURAS$COD_ESTADO_FACTURA
  personas<-paste0("SELECT * FROM FLUJO_INGRESOS_ROL
                 WHERE COD_CONTRATO_PROYECTO=",proyecto,"
                   AND COD_FORMAS_PAGO_FECHAS=",fecha)  
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
  items<-paste0("SELECT * FROM ITEMS_CONTRATO
                WHERE COD_CONTRATO_PROYECTO=",proyecto)
  contrato<-paste0("SELECT COD_TIPO_CONDICION
                    FROM CONTRATOS_CONDICIONES
                   WHERE COD_CONTRATO_PROYECTO=",proyecto)
  adicion<-paste0("SELECT *
                  FROM VISTA_REGISTRO_NOVEDADES
                  WHERE COD_CONTRATO_PROYECTO=",proyecto,"
                  AND COD_TIPO_NOVEDAD BETWEEN 2 AND 5")
  descuento<-paste0("SELECT *
                    FROM VISTA_REGISTRO_NOVEDADES
                    WHERE COD_CONTRATO_PROYECTO=",proyecto,"
                    AND COD_TIPO_NOVEDAD IN (7,8,11,12)")
  salario<-paste0("SELECT *
                  FROM [test_payc_contabilidad].[dbo].[VISTA_SALARIO_INCREMENTOS_TEMP]
                  WHERE COD_CONTRATO_PROYECTO=",proyecto,
                  "AND COD_FORMAS_PAGO_FECHAS=",fecha)
  
  INGRESOS_PERSONAS <- dbGetQuery(con, personas)
  ITEMS_CONTRATO <- dbGetQuery(con, items)
  ITEMS_FIJOS <- dbGetQuery(con, fijos)
  ITEMS_VARIABLES <- dbGetQuery(con, variables)
  CONDICIONES_CONTRATO<-dbGetQuery(con, contrato)
  NOVEDADES_ADICION<-dbGetQuery(con, adicion)
  NOVEDADES_DESCUENTO<-dbGetQuery(con, descuento)
  for (i in 1:nrow(NOVEDADES_ADICION)) {NOVEDADES_ADICION$HORAS[i]<-funcion(NOVEDADES_ADICION,NOVEDADES_ADICION$FECHA_INICIO_NOVEDAD[i],NOVEDADES_ADICION$FECHA_FIN_NOVEDAD[i]) }
  for (i in 1:nrow(NOVEDADES_DESCUENTO)) {NOVEDADES_DESCUENTO$HORAS[i]<-  funcion(NOVEDADES_DESCUENTO,NOVEDADES_DESCUENTO$FECHA_INICIO_NOVEDAD[i],NOVEDADES_DESCUENTO$FECHA_FIN_NOVEDAD[i]) }  
  SALARIO_COMERCIAL<-dbGetQuery(con, salario)
  
  #NOVEDADES_ADICION<-merge(NOVEDADES_ADICION[,c(NOVEDADES_ADICION$COD_ROL,NOVEDADES_ADICION$HORAS )],SALARIO_COMERCIAL[,SALARIO_COMERCIAL$COD_ROL])
  #CALCULO DE LOS VALORES TOTALES HISTORICOS A FACTURAR POR PERSONA E ITEM------------
  if (nrow(INGRESOS_PERSONAS)!=0) {
    TOTAL_PERSONAS <- aggregate(VALOR_CON_PRESTACIONES ~ COD_FORMAS_PAGO_FECHAS +
                                  COD_CONTRATO_PROYECTO + COD_ROL, data = INGRESOS_PERSONAS, sum)
}
  if (nrow(ITEMS_FIJOS)!=0){
  TOTAL_ITEMS_FIJOS <- aggregate(VALOR_TOTAL ~ COD_FORMAS_PAGO_FECHAS + COD_CONTRATO_PROYECTO
                                + COD_ITEM_CONTRATO, data = ITEMS_FIJOS, sum)
    }
  if (nrow(ITEMS_VARIABLES)!=0){
    TOTAL_ITEMS_VARIABLES <- aggregate(VALOR_COMERCIAL ~ COD_FORMAS_PAGO_FECHAS + COD_CONTRATO_PROYECTO
                                + COD_ITEM_CONTRATO, data = ITEMS_VARIABLES, sum)
    }
  PRUEBA<-merge(NOVEDADES_ADICION,SALARIO_COMERCIAL,by.x = c("COD_ROL","COD_CONTRATO_PROYECTO"), by.y = c("COD_ROL","COD_CONTRATO_PROYECTO"), all.x = T,all.y = T)
  
  #TOTAL_PERSONAS$VALOR_TOTAL<-TOTAL_PERSONAS$VALOR_CON_PRESTACIONES+NOVEDADES_ADICION$
  
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
                   ,[COD_ITEM_CONTRATO]
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
                                     TOTAL_ITEMS_FIJOS$COD_ITEM_CONTRATO[k],",",
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
                     ,[COD_ITEM_CONTRATO]
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
                                       TOTAL_ITEMS_VARIABLES$COD_ITEM_CONTRATO[k],",",
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

factura(3)
