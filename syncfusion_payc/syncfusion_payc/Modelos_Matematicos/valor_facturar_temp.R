factura <- function(fecha, proyecto) {
    #CONEXIÓN Y EXTRACCIÓN DE LA INFORMACIÓN DE LA BASE DE DATOS---------------
    library(DBI)
    #CREACION DE LA CONEXION A BASE DE DATOS
    
    con <- dbConnect(odbc::odbc(), "PAYC_FACTURACION", uid = "sa", pwd = "1234JAMS*")
    #EXTRACCION DE LA INFORMACION IMPORTANTE
    INGRESOS_PERSONAS <- dbGetQuery(con, "SELECT * FROM FLUJO_INGRESOS_ROL")
    INGRESOS_ITEMS <- dbGetQuery(con, "SELECT * FROM FLUJO_INGRESOS_ITEMS")

    #CALCULO DE LOS VALORES TOTALES HISTORICOS A FACTURAR POR PERSONA E ITEM------------
    TOTAL_PERSONAS <- aggregate(VALOR_CON_PRESTACIONES ~ COD_FORMAS_PAGO_FECHAS +
                            COD_CONTRATO_PROYECTO + COD_ROL, data = INGRESOS_PERSONAS, sum)
    TOTAL_ITEMS <- aggregate(VALOR_TOTAL ~ COD_FORMAS_PAGO_FECHAS + COD_CONTRATO_PROYECTO
                       + COD_ITEM, data = INGRESOS_ITEMS, sum)

    #CALCULO DEL VALOR TOTAL A FACTURAR POR CADA PROYECTO/MES
    library(data.table)
    FACTURADO <- rbindlist(list(TOTAL_ITEMS, TOTAL_PERSONAS))[, lapply(.SD, sum, na.rm = TRUE),
                    by = c("COD_FORMAS_PAGO_FECHAS", "COD_CONTRATO_PROYECTO")]
    FACTURADO <- FACTURADO[FACTURADO$VALOR_TOTAL > 0]
  eliminar<-paste0("DELETE FROM [dbo].[DETALLE_FACTURA_PERS] WHERE [COD_CONTRATO_PROYECTO] =", proyecto, "AND COD_FORMAS_PAGO_FECHAS=",fecha)
  dbExecute(con, eliminar)
  chunksize = 1000 # arbitrary chunk size
  TABLA_TEMPORAL<-TOTAL_PERSONAS[TOTAL_PERSONAS$COD_FORMAS_PAGO_FECHAS==fecha & TOTAL_PERSONAS$COD_CONTRATO_PROYECTO==proyecto,]
  for (i in 1:ceiling(nrow(TABLA_TEMPORAL)/chunksize)) {
    query = paste0("INSERT INTO [dbo].[DETALLE_FACTURA_PERS] ([COD_CONTRATO_PROYECTO],[COD_ROL],[COD_FORMAS_PAGO_FECHAS],[VALOR_SIN_IMPUESTOS]) VALUES")
    vals = NULL
    for (j in 1:chunksize) {
      k = (i-1)*chunksize+j
      if (k <= nrow(TABLA_TEMPORAL)) {
        vals[j] = paste0('(', paste0(TABLA_TEMPORAL$COD_CONTRATO_PROYECTO[k],",",TABLA_TEMPORAL$COD_ROL[k],",",TABLA_TEMPORAL$COD_FORMAS_PAGO_FECHAS[k],",",TABLA_TEMPORAL$VALOR_CON_PRESTACIONES[k],")"),collapse = ',')
      }
    }
    query = paste0(query, paste0(vals,collapse=','))
    dbExecute(con, query)
  }
    dbDisconnect(con)
}


factura(210, 134)
