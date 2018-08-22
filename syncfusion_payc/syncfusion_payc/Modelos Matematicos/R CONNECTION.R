setwd("F:/REPOSITORIO2")
#CONEXIÓN Y EXTRACCIÓN DE LA INFORMACIÓN DE LA BASE DE DATOS---------------
library(DBI)
#CREACION DE LA CONEXION A BASE DE DATOS
con <- dbConnect(odbc::odbc(),"PAYC_FACTURACION", uid="sa", pwd="1234JAMS*")
#EXTRACCION DE LA INFORMACION IMPORTANTE
INGRESOS_PERSONAS<-dbGetQuery(con, "SELECT * FROM FLUJO_INGRESOS_ROL")
INGRESOS_ITEMS<-dbGetQuery(con, "SELECT * FROM FLUJO_INGRESOS_ITEMS")

#CALCULO DE LOS VALORES TOTALES HISTORICOS A FACTURAR POR PERSONA E ITEM------------
TOTAL_PERSONAS<-aggregate(VALOR_CON_PRESTACIONES~ COD_FORMAS_PAGO_FECHAS+
                            COD_CONTRATO_PROYECTO+COD_ROL, data=INGRESOS_PERSONAS, sum)
TOTAL_ITEMS<-aggregate(VALOR_TOTAL~ COD_FORMAS_PAGO_FECHAS+COD_CONTRATO_PROYECTO
                       +COD_ITEM, data=INGRESOS_ITEMS, sum)

#CALCULO DEL VALOR TOTAL A FACTURAR POR CADA PROYECTO/MES
library(data.table)
FACTURADO<-rbindlist(list(TOTAL_ITEMS, TOTAL_PERSONAS))[, lapply(.SD, sum, na.rm = TRUE), 
                    by = c("COD_FORMAS_PAGO_FECHAS", "COD_CONTRATO_PROYECTO")]
FACTURADO<-FACTURADO[FACTURADO$VALOR_TOTAL>0]

#CÓDIGO PARA INSERTAR ARCHIVOS PLANOS A TABLAS DE SQL, (LA TABLA TIENE QUE ESTAR EN EL MISMO SERVIDOR) (EFICIENCIA ALTA)-----------
#before = Sys.time()
#tabla<-write.table(TOTAL_PERSONAS, 'TOTAL_PERSONAS.CSV',col.names = F,row.names = F, sep = '\t')
#query = paste0("BULK INSERT [dbo].[DETALLE_FACTURA_PERS_TEMP] FROM",tabla)
#dbSendStatement(con, query)
#time_infile = Sys.time() - before 

#CÓDIGO PARA INSERTAR LÍNEA POR LÍNEA EN LA BASE DE DATOS (MUY INEFICIENTE PARA MUCHOS DATOS)----------
#query<-paste0("INSERT INTO [dbo].[DETALLE_FACTURA_PERS_TEMP]([COD_DETALLE_FACTURA_PERS],[COD_CONTRATO_PROYECTO],[COD_ROL],[COD_FORMAS_PAGO_FECHAS],[VALOR_SIN_IMPUESTOS]) VALUES(",1:length(TOTAL_PERSONAS$COD_FORMAS_PAGO_FECHAS),",",TOTAL_PERSONAS$COD_CONTRATO_PROYECTO,",",TOTAL_PERSONAS$COD_ROL,",",TOTAL_PERSONAS$COD_FORMAS_PAGO_FECHAS,",",TOTAL_PERSONAS$VALOR_CON_PRESTACIONES,")")
#before = Sys.time()
#for (i in 1:length(TOTAL_PERSONAS$COD_FORMAS_PAGO_FECHAS)) {
#  dbExecute(con,query[i])
#}
#time_chunked = Sys.time() - before 

#CÓDIGO PARA INSERTAR MUCHAS LÍNEAS DE DATOS EN LA BASE DE DATOS (EFICIENCIA MEDIA)-----------
before=Sys.time()
chunksize = 1000 # arbitrary chunk size
for (i in 1:ceiling(nrow(TOTAL_PERSONAS)/chunksize)) {
  query = paste0("INSERT INTO [dbo].[DETALLE_FACTURA_PERS_TEMP] ([COD_DETALLE_FACTURA_PERS],[COD_CONTRATO_PROYECTO],[COD_ROL],[COD_FORMAS_PAGO_FECHAS],[VALOR_SIN_IMPUESTOS]) VALUES")
  vals = NULL
  for (j in 1:chunksize) {
    k = (i-1)*chunksize+j
    if (k <= nrow(TOTAL_PERSONAS)) {
      vals[j] = paste0('(', paste0(k,",",TOTAL_PERSONAS$COD_CONTRATO_PROYECTO[k],",",TOTAL_PERSONAS$COD_ROL[k],",",TOTAL_PERSONAS$COD_FORMAS_PAGO_FECHAS[k],",",TOTAL_PERSONAS$VALOR_CON_PRESTACIONES[k],")"),collapse = ',')
    }
  }
  query = paste0(query, paste0(vals,collapse=','))
  dbExecute(con, query)
  }
time=Sys.time()-before
#INSERT CON TODOS LOS DATOS (ERROR DE MÁXIMO NÚMERO DE FILAS (1000))----------
for (i in 1:length(TOTAL_PERSONAS$COD_FORMAS_PAGO_FECHAS)) {
    lista[i] <-(paste0("(",i,",",TOTAL_PERSONAS$COD_CONTRATO_PROYECTO[i],",",TOTAL_PERSONAS$COD_ROL[i],",",TOTAL_PERSONAS$COD_FORMAS_PAGO_FECHAS[i],",",TOTAL_PERSONAS$VALOR_CON_PRESTACIONES[i],")") )
    }

lista <-paste0(lista,collapse = ",")
query <-paste0("INSERT INTO [dbo].[DETALLE_FACTURA_PERS_TEMP] ([COD_DETALLE_FACTURA_PERS],[COD_CONTRATO_PROYECTO],[COD_ROL],[COD_FORMAS_PAGO_FECHAS],[VALOR_SIN_IMPUESTOS]) VALUES",lista ,";")     
query

length(query)
dbExecute(con,query)

dbDisconnect(con)


#FUNCIÓN DE VALOR A FACTURAR TOMANDO FECHA Y PROYECTO -----------------
factura<-function(fecha, proyecto){
  eliminar<-paste0("DELETE FROM [dbo].[DETALLE_FACTURA_PERS] WHERE [COD_CONTRATO_PROYECTO_TEMP] =", proyecto, "AND COD_FORMAS_PAGO_FECHAS=",fecha)
  dbExecute(con, eliminar)
  chunksize = 1000 # arbitrary chunk size
  TABLA_TEMPORAL<-TOTAL_PERSONAS[TOTAL_PERSONAS$COD_FORMAS_PAGO_FECHAS==fecha & TOTAL_PERSONAS$COD_CONTRATO_PROYECTO==proyecto,]
  for (i in 1:ceiling(nrow(TABLA_TEMPORAL)/chunksize)) {
    query = paste0("INSERT INTO [dbo].[DETALLE_FACTURA_PERS_TEMP] ([COD_DETALLE_FACTURA_PERS], [COD_CONTRATO_PROYECTO],[COD_ROL],[COD_FORMAS_PAGO_FECHAS],[VALOR_SIN_IMPUESTOS]) VALUES")
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
}


proyecto=228
fecha=216
chunksize = 1000 # arbitrary chunk size
TABLA_TEMPORAL<-TOTAL_PERSONAS[TOTAL_PERSONAS$COD_FORMAS_PAGO_FECHAS==fecha & TOTAL_PERSONAS$COD_CONTRATO_PROYECTO==proyecto,]
for (i in 1:ceiling(nrow(TABLA_TEMPORAL)/chunksize)) {
  query = paste0("INSERT INTO [dbo].[DETALLE_FACTURA_PERS_TEMP] ([COD_DETALLE_FACTURA_PERS], [COD_CONTRATO_PROYECTO],[COD_ROL],[COD_FORMAS_PAGO_FECHAS],[VALOR_SIN_IMPUESTOS]) VALUES")
  vals = NULL
  for (j in 1:chunksize) {
    k = (i-1)*chunksize+j
    if (k <= nrow(TABLA_TEMPORAL)) {
      vals[j] = paste0('(',k,",", paste0(TABLA_TEMPORAL$COD_CONTRATO_PROYECTO[k],",",TABLA_TEMPORAL$COD_ROL[k],",",TABLA_TEMPORAL$COD_FORMAS_PAGO_FECHAS[k],",",TABLA_TEMPORAL$VALOR_CON_PRESTACIONES[k],")"),collapse = ',')
    }
  }
  query = paste0(query, paste0(vals,collapse=','))
  dbExecute(con, query)
}

query
factura(216,228)

factura<-function(fecha, proyecto){
  eliminar<-paste0("DELETE FROM [dbo].[DETALLE_FACTURA_PERS] WHERE [COD_CONTRATO_PROYECTO] =", proyecto, "AND COD_FORMAS_PAGO_FECHAS=",fecha)
  dbExecute(con, eliminar)
  chunksize = 1000 # arbitrary chunk size
  TABLA_TEMPORAL<-TOTAL_PERSONAS[TOTAL_PERSONAS$COD_FORMAS_PAGO_FECHAS==fecha & TOTAL_PERSONAS$COD_CONTRATO_PROYECTO==proyecto,]
  for (i in 1:ceiling(nrow(TABLA_TEMPORAL)/chunksize)) {
    query = paste0("INSERT INTO [dbo].[DETALLE_FACTURA_PERS_TEMP] ([COD_CONTRATO_PROYECTO],[COD_ROL],[COD_FORMAS_PAGO_FECHAS],[VALOR_SIN_IMPUESTOS]) VALUES")
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
}

