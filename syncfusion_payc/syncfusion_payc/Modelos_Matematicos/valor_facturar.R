factura <- function(cod_factura) {
  library(DBI)
  
  #CONEXIÓN Y EXTRACCIÓN DE LA INFORMACIÓN DE LA BASE DE DATOS---------------
  #CONEXIÓN A LA BASE DE DATOS
  
  con <- dbConnect(odbc::odbc(), "PAYC_FACTURACION", uid = "sa", pwd = "1234JAMS*")
  #cod_factura = 10163
  #EXTRACCION DE LA INFORMACION IMPORTANTE DE LA BASE DE DATOS
  fact <- paste0("SELECT * FROM FACTURAS WHERE COD_FACTURA=", cod_factura)
  FACTURAS <- dbGetQuery(con, fact)
  
  fecha <- FACTURAS$COD_FORMAS_PAGO_FECHAS
  proyecto <- FACTURAS$COD_CONTRATO_PROYECTO
  estado <- FACTURAS$COD_ESTADO_FACTURA
  personas <- paste0("SELECT * FROM VISTA_FLUJO_INGRESOS_ROL_CORREGIDA_REALIDAD
                     WHERE COD_CONTRATO_PROYECTO=", proyecto, "
                     AND COD_FORMAS_PAGO_FECHAS=", fecha, "
                     AND ESTADO='SI'")
  fijos <- paste0("SELECT DISTINCT FLUJO_INGRESOS_ITEMS.*, ITEMS_CONTRATO.COD_TIPO_REEMBOLSO
                  FROM FLUJO_INGRESOS_ITEMS, ITEMS_CONTRATO 
                  WHERE ITEMS_CONTRATO.COD_TIPO_REEMBOLSO=1 
                  AND FLUJO_INGRESOS_ITEMS.ESTADO='SI'
                  AND FLUJO_INGRESOS_ITEMS.COD_CONTRATO_PROYECTO=", proyecto, "
                  AND FLUJO_INGRESOS_ITEMS.COD_FORMAS_PAGO_FECHAS=", fecha,
                  "	AND ITEMS_CONTRATO.COD_ITEM_CONTRATO=FLUJO_INGRESOS_ITEMS.COD_ITEM_CONTRATO")
  variables <- paste0("SELECT DISTINCT REGISTRO_ITEMS_OTROS_COSTOS.*, ITEMS_CONTRATO.COD_TIPO_REEMBOLSO
                      FROM REGISTRO_ITEMS_OTROS_COSTOS, ITEMS_CONTRATO 
                      WHERE ITEMS_CONTRATO.COD_TIPO_REEMBOLSO=2
                      AND REGISTRO_ITEMS_OTROS_COSTOS.COD_CONTRATO_PROYECTO=", proyecto, "
                      AND REGISTRO_ITEMS_OTROS_COSTOS.COD_FORMAS_PAGO_FECHAS=", fecha,
                      "AND ITEMS_CONTRATO.COD_ITEM_CONTRATO=REGISTRO_ITEMS_OTROS_COSTOS.COD_ITEM_CONTRATO")
  items <- paste0("SELECT * FROM ITEMS_CONTRATO
                  WHERE COD_CONTRATO_PROYECTO=", proyecto)
  contrato <- paste0("SELECT COD_TIPO_CONDICION
                     FROM CONTRATOS_CONDICIONES
                     WHERE COD_CONTRATO_PROYECTO=", proyecto)
  adicion <- paste0("SELECT *
                    FROM VISTA_REGISTRO_NOVEDADES
                    WHERE COD_CONTRATO_PROYECTO=", proyecto, "
                    AND COD_FORMAS_PAGO_FECHAS=", fecha, " 
                    AND COD_TIPO_NOVEDAD BETWEEN 2 AND 5")
  descuento <- paste0("SELECT *
                      FROM VISTA_REGISTRO_NOVEDADES
                      WHERE COD_CONTRATO_PROYECTO=", proyecto, "
                      AND COD_FORMAS_PAGO_FECHAS=", fecha, " 
                      AND COD_TIPO_NOVEDAD IN (7,8,11,12)")
  salario <- paste0("SELECT *
                    FROM [test_payc_contabilidad].[dbo].[VISTA_SALARIO_INCREMENTOS_TEMP]
                    WHERE COD_CONTRATO_PROYECTO=", proyecto,
                    "AND COD_FORMAS_PAGO_FECHAS=", fecha)
  
  INGRESOS_PERSONAS <- dbGetQuery(con, personas)
  ITEMS_CONTRATO <- dbGetQuery(con, items)
  ITEMS_FIJOS <- dbGetQuery(con, fijos)
  ITEMS_VARIABLES <- dbGetQuery(con, variables)
  CONDICIONES_CONTRATO <- dbGetQuery(con, contrato)
  NOVEDADES_ADICION <- dbGetQuery(con, adicion)
  NOVEDADES_DESCUENTO <- dbGetQuery(con, descuento)
  SALARIO_COMERCIAL <- dbGetQuery(con, salario)
  
  #CÁLCULO DEL NÚMERO DE HORAS EXTRA O DE VACACIONES QUE SE DEBEN COBRAR
  if (any(CONDICIONES_CONTRATO$COD_TIPO_CONDICION == 3) && nrow(NOVEDADES_ADICION) != 0) {
    NOVEDADES_ADICION$HORAS <- difftime(NOVEDADES_ADICION$FECHA_FIN_NOVEDAD, NOVEDADES_ADICION$FECHA_INICIO_NOVEDAD, units = "hours")
    for (i in 1:nrow(NOVEDADES_ADICION)) {
      if (NOVEDADES_ADICION$COD_TIPO_NOVEDAD[i] == 2) {
        NOVEDADES_ADICION$FACTOR[i] <- 1.25
      } else if (NOVEDADES_ADICION$COD_TIPO_NOVEDAD[i] == 3) {
        NOVEDADES_ADICION$FACTOR[i] <- 1.75
      } else if (NOVEDADES_ADICION$COD_TIPO_NOVEDAD[i] == 4) {
        NOVEDADES_ADICION$FACTOR[i] <- 2
      } else if (NOVEDADES_ADICION$COD_TIPO_NOVEDAD[i] == 5) {
        NOVEDADES_ADICION$FACTOR[i] <- 2.5
      }
    }
  }
  
  if (any(CONDICIONES_CONTRATO$COD_TIPO_CONDICION == 4) && nrow(NOVEDADES_DESCUENTO) != 0) {
    NOVEDADES_DESCUENTO$HORAS <- difftime(NOVEDADES_DESCUENTO$FECHA_FIN_NOVEDAD, NOVEDADES_DESCUENTO$FECHA_INICIO_NOVEDAD, units = "hours")
  }
  
  NOVEDADES_ADICION$ADICION <- (NOVEDADES_ADICION$SALARIO_COMERCIAL / 240) * as.double(NOVEDADES_ADICION$HORAS) * NOVEDADES_ADICION$FACTOR
  NOVEDADES_DESCUENTO$DESCUENTO <- (-NOVEDADES_DESCUENTO$SALARIO_COMERCIAL / 240) * as.double(NOVEDADES_DESCUENTO$HORAS)
  
  
  #CALCULO DE LOS VALORES TOTALES HISTORICOS A FACTURAR POR PERSONA E ITEM------------
  if (nrow(INGRESOS_PERSONAS) != 0) {
    TOTAL_PERSONAS <- aggregate(VALOR_FACTOR_MULTIPLICADOR ~ COD_FORMAS_PAGO_FECHAS +
                                  COD_CONTRATO_PROYECTO + COD_ROL, data = INGRESOS_PERSONAS, sum)
  } else {
    TOTAL_PERSONAS <- cbind(TOTAL_PERSONAS, replicate(0))
  }
  
  if (nrow(ITEMS_FIJOS) != 0) {
    TOTAL_ITEMS_FIJOS <- aggregate(VALOR_TOTAL ~ COD_FORMAS_PAGO_FECHAS + COD_CONTRATO_PROYECTO
                                   + COD_ITEM_CONTRATO, data = ITEMS_FIJOS, sum)
  } else {
    TOTAL_ITEMS_FIJOS <- cbind(ITEMS_FIJOS, replicate(0))
  }
  
  if (nrow(ITEMS_VARIABLES) != 0) {
    TOTAL_ITEMS_VARIABLES <- aggregate(VALOR_COMERCIAL ~ COD_FORMAS_PAGO_FECHAS + COD_CONTRATO_PROYECTO
                                       + COD_ITEM_CONTRATO, data = ITEMS_VARIABLES, sum)
  } else {
    TOTAL_ITEMS_VARIABLES <- cbind(ITEMS_VARIABLES, replicate(0))
  }
  
  if (nrow(NOVEDADES_ADICION) != 0) {
    TOTAL_NOVEDADES_ADICION <- aggregate(ADICION ~ COD_ROL, data = NOVEDADES_ADICION, sum)
    TOTAL_PERSONAS <- merge(TOTAL_PERSONAS, TOTAL_NOVEDADES_ADICION, by.x = c("COD_ROL"), by.y = c("COD_ROL"), all.x = T, all.y = T, na.action)
  } else {
    TOTAL_PERSONAS$ADICION <- NA
  }
  
  if (nrow(NOVEDADES_DESCUENTO) != 0) {
    TOTAL_NOVEDADES_DESCUENTO <- aggregate(DESCUENTO ~ COD_ROL, data = NOVEDADES_DESCUENTO, sum)
    TOTAL_PERSONAS <- merge(TOTAL_PERSONAS, TOTAL_NOVEDADES_DESCUENTO, by.x = c("COD_ROL"), by.y = c("COD_ROL"), all.x = T, all.y = T, na.action)
  } else {
    TOTAL_PERSONAS$DESCUENTO <- NA
  }
  
  TOTAL_PERSONAS$FINAL <- as.double(rowSums(TOTAL_PERSONAS[, c("VALOR_FACTOR_MULTIPLICADOR", "ADICION", "DESCUENTO")], na.rm = T))
  
  #ELIMINAR LOS DATOS REPETIDOS DEL PROYECTO QUE SE ESTÁ CONSULTANDO
  eliminar <- paste0("DELETE FROM [dbo].[DETALLE_FACTURA_PERS] WHERE [COD_CONTRATO_PROYECTO] =", proyecto, "AND COD_FORMAS_PAGO_FECHAS=", fecha)
  dbExecute(con, eliminar)
  eliminar <- paste0("DELETE FROM [dbo].[DETALLE_FACTURA_ITEM] WHERE [COD_CONTRATO_PROYECTO] =", proyecto, "AND COD_FORMAS_PAGO_FECHAS=", fecha)
  dbExecute(con, eliminar)
  
  
  #CÁLCULO E INSERCIÓN DE LA INFORMACIÓN EN LAS TABLAS
  chunksize = 1000 # arbitrary chunk size
  if (nrow(TOTAL_PERSONAS) != 0) {
    TABLA_TEMPORAL <- TOTAL_PERSONAS[TOTAL_PERSONAS$COD_FORMAS_PAGO_FECHAS == fecha & TOTAL_PERSONAS$COD_CONTRATO_PROYECTO == proyecto,]
    for (i in 1:ceiling(nrow(TABLA_TEMPORAL) / chunksize)) {
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
                     ,[COD_CONCEPTO_PSL]
                     ,[COD_ESTADO_DETALLE]) 
                     VALUES")
      vals = NULL
      for (j in 1:chunksize) {
        k = (i - 1) * chunksize + j
        if (k <= nrow(TABLA_TEMPORAL)) {
          vals[j] = paste0('(', paste0(TABLA_TEMPORAL$COD_CONTRATO_PROYECTO[k], ",",
                                       TABLA_TEMPORAL$COD_ROL[k], ",",
                                       TABLA_TEMPORAL$COD_FORMAS_PAGO_FECHAS[k], ",",
                                       TABLA_TEMPORAL$FINAL[k], ",'",
                                       Sys.time(), "','GENERADO','",
                                       estado, "',1,'',", cod_factura, ",1026,1)"), collapse = ',')
        }
      }
      query = paste0(query, paste0(vals, collapse = ','))
      dbExecute(con, query)
    }
  }
  
  if (nrow(TOTAL_ITEMS_FIJOS) != 0) {
    for (i in 1:ceiling(nrow(TOTAL_ITEMS_FIJOS) / chunksize)) {
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
                     ,[COD_CONCEPTO_PSL]
                     ,[COD_ESTADO_DETALLE])
                     VALUES")
      vals = NULL
      for (j in 1:chunksize) {
        k = (i - 1) * chunksize + j
        if (k <= nrow(TOTAL_ITEMS_FIJOS)) {
          vals[j] = paste0('(', paste0(TOTAL_ITEMS_FIJOS$COD_CONTRATO_PROYECTO[k], ",",
                                       TOTAL_ITEMS_FIJOS$COD_ITEM_CONTRATO[k], ",",
                                       TOTAL_ITEMS_FIJOS$COD_FORMAS_PAGO_FECHAS[k], ",",
                                       TOTAL_ITEMS_FIJOS$VALOR_TOTAL[k], ",'",
                                       Sys.time(), "','GENERADO','",
                                       estado, "',1,'',", cod_factura, ",1027,1)"), collapse = ',')
        }
      }
      query = paste0(query, paste0(vals, collapse = ','))
      dbExecute(con, query)
    }
  }
  
  if (nrow(ITEMS_VARIABLES) != 0) {
    for (i in 1:ceiling(nrow(TOTAL_ITEMS_VARIABLES) / chunksize)) {
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
                     ,[COD_CONCEPTO_PSL]
                     ,[COD_ESTADO_DETALLE])
                     VALUES")
      vals = NULL
      for (j in 1:chunksize) {
        k = (i - 1) * chunksize + j
        if (k <= nrow(TOTAL_ITEMS_VARIABLES)) {
          vals[j] = paste0('(', paste0(TOTAL_ITEMS_VARIABLES$COD_CONTRATO_PROYECTO[k], ",",
                                       TOTAL_ITEMS_VARIABLES$COD_ITEM_CONTRATO[k], ",",
                                       TOTAL_ITEMS_VARIABLES$COD_FORMAS_PAGO_FECHAS[k], ",",
                                       TOTAL_ITEMS_VARIABLES$VALOR_COMERCIAL[k], ",'",
                                       Sys.time(), "','GENERADO','",
                                       estado, "',1,'',", cod_factura, ",1027,1)"), collapse = ',')
        }
      }
      query = paste0(query, paste0(vals, collapse = ','))
      dbExecute(con, query)
    }
  }
  
  dbDisconnect(con)
  
  VALOR_FACTURAR <- sum(TOTAL_ITEMS_FIJOS$VALOR_TOTAL, na.rm = T) + sum(TOTAL_PERSONAS$FINAL, na.rm = T) + sum(TOTAL_ITEMS_VARIABLES$VALOR_COMERCIAL, na.rm = T)
  
  #sum(TOTAL_ITEMS_FIJOS$VALOR_TOTAL, na.rm = T) 
  #sum(TOTAL_PERSONAS$VALOR_FACTOR_MULTIPLICADOR,na.rm = T)
  #sum(TOTAL_ITEMS_VARIABLES$VALOR_COMERCIAL,na.rm = T)
  #sum(NOVEDADES_ADICION$TOTAL,na.rm=T)
  #VALOR_FACTURAR
  return(VALOR_FACTURAR)
}

