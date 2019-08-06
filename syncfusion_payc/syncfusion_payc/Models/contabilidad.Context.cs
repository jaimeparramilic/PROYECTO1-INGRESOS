﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace syncfusion_payc.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class test_payc_contabilidadEntities : DbContext
    {
        public test_payc_contabilidadEntities()
            : base("name=test_payc_contabilidadEntities")
        {
    	this.Configuration.ProxyCreationEnabled = false; 
    	this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CONTRATO_PROYECTO> CONTRATO_PROYECTO { get; set; }
        public virtual DbSet<ACUERDOS_PAGO_ENTREGAB> ACUERDOS_PAGO_ENTREGAB { get; set; }
        public virtual DbSet<ASIGNACION_CARTERA> ASIGNACION_CARTERA { get; set; }
        public virtual DbSet<CARGOS> CARGOS { get; set; }
        public virtual DbSet<CARTERA> CARTERA { get; set; }
        public virtual DbSet<CAUSA_ESTADO> CAUSA_ESTADO { get; set; }
        public virtual DbSet<CENTROS_COSTOS> CENTROS_COSTOS { get; set; }
        public virtual DbSet<CLIENTES> CLIENTES { get; set; }
        public virtual DbSet<COLABORADORES> COLABORADORES { get; set; }
        public virtual DbSet<COMPROMISOS_ENTREGABLES> COMPROMISOS_ENTREGABLES { get; set; }
        public virtual DbSet<COMPROMISOS_PAGOS> COMPROMISOS_PAGOS { get; set; }
        public virtual DbSet<CONCEPTOS> CONCEPTOS { get; set; }
        public virtual DbSet<CONTRATO_COLABORADOR> CONTRATO_COLABORADOR { get; set; }
        public virtual DbSet<CONTRATO_ROL_CARGO> CONTRATO_ROL_CARGO { get; set; }
        public virtual DbSet<CONTRATOS> CONTRATOS { get; set; }
        public virtual DbSet<CONTRATOS_CONDICIONES> CONTRATOS_CONDICIONES { get; set; }
        public virtual DbSet<CONTRATOS_PROYECCION> CONTRATOS_PROYECCION { get; set; }
        public virtual DbSet<CONTRATOS_ROL> CONTRATOS_ROL { get; set; }
        public virtual DbSet<DEBUG> DEBUG { get; set; }
        public virtual DbSet<DETALLE_FACTURA_ADJUNTO_ITEM> DETALLE_FACTURA_ADJUNTO_ITEM { get; set; }
        public virtual DbSet<DETALLE_FACTURA_PERS> DETALLE_FACTURA_PERS { get; set; }
        public virtual DbSet<EMAIL_CLIENTES> EMAIL_CLIENTES { get; set; }
        public virtual DbSet<ENTREGABLES> ENTREGABLES { get; set; }
        public virtual DbSet<ESTADO_COLABORADOR> ESTADO_COLABORADOR { get; set; }
        public virtual DbSet<ESTADOS_ACUER_PAG_ENTREG> ESTADOS_ACUER_PAG_ENTREG { get; set; }
        public virtual DbSet<ESTADOS_CARTERA> ESTADOS_CARTERA { get; set; }
        public virtual DbSet<ESTADOS_CECO> ESTADOS_CECO { get; set; }
        public virtual DbSet<ESTADOS_DETALLE> ESTADOS_DETALLE { get; set; }
        public virtual DbSet<ESTADOS_FACTURAS> ESTADOS_FACTURAS { get; set; }
        public virtual DbSet<ESTADOS_ORDEN_SERVICIO> ESTADOS_ORDEN_SERVICIO { get; set; }
        public virtual DbSet<ESTUDIOS_COLABORADOR> ESTUDIOS_COLABORADOR { get; set; }
        public virtual DbSet<FACTORES_REALES> FACTORES_REALES { get; set; }
        public virtual DbSet<FACTURAS> FACTURAS { get; set; }
        public virtual DbSet<FLUJO_INGRESOS_ITEMS> FLUJO_INGRESOS_ITEMS { get; set; }
        public virtual DbSet<FLUJO_INGRESOS_ROL> FLUJO_INGRESOS_ROL { get; set; }
        public virtual DbSet<FORMAS_PAGO> FORMAS_PAGO { get; set; }
        public virtual DbSet<FORMAS_PAGO_FECHAS> FORMAS_PAGO_FECHAS { get; set; }
        public virtual DbSet<GENEROS> GENEROS { get; set; }
        public virtual DbSet<GESTION_CARTERA> GESTION_CARTERA { get; set; }
        public virtual DbSet<GESTION_ENTREGABLES> GESTION_ENTREGABLES { get; set; }
        public virtual DbSet<GRUPOS_CECOS> GRUPOS_CECOS { get; set; }
        public virtual DbSet<GRUPOS_FACTURA> GRUPOS_FACTURA { get; set; }
        public virtual DbSet<GRUPOS_PROBABILIDADES> GRUPOS_PROBABILIDADES { get; set; }
        public virtual DbSet<INCREMENTO_ORDEN> INCREMENTO_ORDEN { get; set; }
        public virtual DbSet<INCREMENTO_SALARIAL> INCREMENTO_SALARIAL { get; set; }
        public virtual DbSet<ITEMS> ITEMS { get; set; }
        public virtual DbSet<ITEMS_CONTRATO> ITEMS_CONTRATO { get; set; }
        public virtual DbSet<ITEMS_ROLES> ITEMS_ROLES { get; set; }
        public virtual DbSet<PROYECTOS> PROYECTOS { get; set; }
        public virtual DbSet<REGISTRO_ITEMS_OTROS_COSTOS> REGISTRO_ITEMS_OTROS_COSTOS { get; set; }
        public virtual DbSet<REGISTRO_NOVEDADES> REGISTRO_NOVEDADES { get; set; }
        public virtual DbSet<REGISTRO_NOVEDADES_TRABAJO> REGISTRO_NOVEDADES_TRABAJO { get; set; }
        public virtual DbSet<ROL_CARGO_ORDEN> ROL_CARGO_ORDEN { get; set; }
        public virtual DbSet<ROLES> ROLES { get; set; }
        public virtual DbSet<SIMULACION_PAGOS> SIMULACION_PAGOS { get; set; }
        public virtual DbSet<SINO> SINO { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TAG_ORDEN> TAG_ORDEN { get; set; }
        public virtual DbSet<TIPO_CONDICION_CONTRACTUAL> TIPO_CONDICION_CONTRACTUAL { get; set; }
        public virtual DbSet<TIPO_CONTRATO> TIPO_CONTRATO { get; set; }
        public virtual DbSet<TIPOS_ACUERDO> TIPOS_ACUERDO { get; set; }
        public virtual DbSet<TIPOS_GESTION> TIPOS_GESTION { get; set; }
        public virtual DbSet<TIPOS_NOVEDAD> TIPOS_NOVEDAD { get; set; }
        public virtual DbSet<TIPOS_NOVEDAD_CONDICION> TIPOS_NOVEDAD_CONDICION { get; set; }
        public virtual DbSet<TIPOS_OBRA> TIPOS_OBRA { get; set; }
        public virtual DbSet<TIPOS_REEMBOLSO> TIPOS_REEMBOLSO { get; set; }
        public virtual DbSet<TIPOS_SERVICIOS> TIPOS_SERVICIOS { get; set; }
        public virtual DbSet<TIPOS_TRIBUTACION> TIPOS_TRIBUTACION { get; set; }
        public virtual DbSet<TRUEFALSE> TRUEFALSE { get; set; }
        public virtual DbSet<xTEMPO> xTEMPO { get; set; }
        public virtual DbSet<COMBINACIONES_GASTOS_ADMINISTRATIVOS> COMBINACIONES_GASTOS_ADMINISTRATIVOS { get; set; }
        public virtual DbSet<CONTRATOS_ROL_TEMP> CONTRATOS_ROL_TEMP { get; set; }
        public virtual DbSet<DETALLE_FACTURA_ADJUNTO_PERS_TEMP> DETALLE_FACTURA_ADJUNTO_PERS_TEMP { get; set; }
        public virtual DbSet<DETALLE_FACTURA_ITEM_TEMP> DETALLE_FACTURA_ITEM_TEMP { get; set; }
        public virtual DbSet<DETALLE_FACTURA_PERS_TEMP> DETALLE_FACTURA_PERS_TEMP { get; set; }
        public virtual DbSet<ESTUDIOS_COLABORADOR_TEMP> ESTUDIOS_COLABORADOR_TEMP { get; set; }
        public virtual DbSet<FLUJO_INGRESOS_ITEMS_TEMP> FLUJO_INGRESOS_ITEMS_TEMP { get; set; }
        public virtual DbSet<FLUJO_INGRESOS_ROL_TEMP> FLUJO_INGRESOS_ROL_TEMP { get; set; }
        public virtual DbSet<INCREMENTO_SALARIAL_TEMP> INCREMENTO_SALARIAL_TEMP { get; set; }
        public virtual DbSet<ITEMS_CONTRATO_TEMP> ITEMS_CONTRATO_TEMP { get; set; }
        public virtual DbSet<REGISTRO_NOVEDADES_TEMP> REGISTRO_NOVEDADES_TEMP { get; set; }
        public virtual DbSet<ReportsTable> ReportsTable { get; set; }
        public virtual DbSet<TRAZA_FACTURA_PSL_PRODUCTIVO> TRAZA_FACTURA_PSL_PRODUCTIVO { get; set; }
        public virtual DbSet<TRAZA_FACTURA_PSL_PRUEBAS> TRAZA_FACTURA_PSL_PRUEBAS { get; set; }
        public virtual DbSet<CHECK_COLABORADOR_MES> CHECK_COLABORADOR_MES { get; set; }
        public virtual DbSet<COLABORADORES_CONTAR_ESTUDIOS> COLABORADORES_CONTAR_ESTUDIOS { get; set; }
        public virtual DbSet<COLARADORES_CONCAT_ESTUDIOS> COLARADORES_CONCAT_ESTUDIOS { get; set; }
        public virtual DbSet<CONTRATO_COLABORADOR_COMERCIAL> CONTRATO_COLABORADOR_COMERCIAL { get; set; }
        public virtual DbSet<CONTRATO_COLABORADOR_INDEX> CONTRATO_COLABORADOR_INDEX { get; set; }
        public virtual DbSet<CONTRATO_PROYECTO_DESCRIPCION> CONTRATO_PROYECTO_DESCRIPCION { get; set; }
        public virtual DbSet<CONTRATO_PROYECTO_DESCRIPCION_ESTADOS> CONTRATO_PROYECTO_DESCRIPCION_ESTADOS { get; set; }
        public virtual DbSet<CONTRATO_ROL_DESCRIPCION> CONTRATO_ROL_DESCRIPCION { get; set; }
        public virtual DbSet<CONTRATOS_CONDICIONES_VISTA> CONTRATOS_CONDICIONES_VISTA { get; set; }
        public virtual DbSet<DATOS_VERIFICAR_FACTURA> DATOS_VERIFICAR_FACTURA { get; set; }
        public virtual DbSet<FLUJO_INGRESOS_ITEM> FLUJO_INGRESOS_ITEM { get; set; }
        public virtual DbSet<FLUJO_INGRESOS_ROLES> FLUJO_INGRESOS_ROLES { get; set; }
        public virtual DbSet<GENERACION_COLABORADORES_PENDIENTES> GENERACION_COLABORADORES_PENDIENTES { get; set; }
        public virtual DbSet<GENERACION_FLUJOS_ITEM> GENERACION_FLUJOS_ITEM { get; set; }
        public virtual DbSet<GENERACION_FLUJOS_ITEM_TEMP> GENERACION_FLUJOS_ITEM_TEMP { get; set; }
        public virtual DbSet<GENERACION_FLUJOS_ITEM_TEMP2> GENERACION_FLUJOS_ITEM_TEMP2 { get; set; }
        public virtual DbSet<GENERACION_FLUJOS_ITEM_TEMP3> GENERACION_FLUJOS_ITEM_TEMP3 { get; set; }
        public virtual DbSet<GENERACION_FLUJOS_ITEM2> GENERACION_FLUJOS_ITEM2 { get; set; }
        public virtual DbSet<GENERACION_FLUJOS_ITEM3> GENERACION_FLUJOS_ITEM3 { get; set; }
        public virtual DbSet<GENERACION_FLUJOS_ROL> GENERACION_FLUJOS_ROL { get; set; }
        public virtual DbSet<GENERACION_FLUJOS_ROL_TEMP> GENERACION_FLUJOS_ROL_TEMP { get; set; }
        public virtual DbSet<GENERACION_FLUJOS_ROL_TEMP2> GENERACION_FLUJOS_ROL_TEMP2 { get; set; }
        public virtual DbSet<GENERACION_FLUJOS_ROL_TEMP3> GENERACION_FLUJOS_ROL_TEMP3 { get; set; }
        public virtual DbSet<GENERACION_FLUJOS_ROL2> GENERACION_FLUJOS_ROL2 { get; set; }
        public virtual DbSet<GENERACION_FLUJOS_ROL3> GENERACION_FLUJOS_ROL3 { get; set; }
        public virtual DbSet<ITEMS_CONTRATO_DESCRIPCION> ITEMS_CONTRATO_DESCRIPCION { get; set; }
        public virtual DbSet<ORDEN_SERVICIO_ROLES_PERIODO> ORDEN_SERVICIO_ROLES_PERIODO { get; set; }
        public virtual DbSet<ORDENES_SERVICIO_INDEX> ORDENES_SERVICIO_INDEX { get; set; }
        public virtual DbSet<ORDENES_SERVICIO_ROLES_COLABORADOR> ORDENES_SERVICIO_ROLES_COLABORADOR { get; set; }
        public virtual DbSet<PENDIENTES> PENDIENTES { get; set; }
        public virtual DbSet<PENDIENTES_REPORTE> PENDIENTES_REPORTE { get; set; }
        public virtual DbSet<REGISTRO_NOVEDADES_FECHAS> REGISTRO_NOVEDADES_FECHAS { get; set; }
        public virtual DbSet<REGISTRO_NOVEDADES_FECHAS_SABADOS> REGISTRO_NOVEDADES_FECHAS_SABADOS { get; set; }
        public virtual DbSet<REGISTRO_NOVEDADES_FECHAS_TEMP> REGISTRO_NOVEDADES_FECHAS_TEMP { get; set; }
        public virtual DbSet<TEST_VISTA_FLUJOS_CORREGIDOS> TEST_VISTA_FLUJOS_CORREGIDOS { get; set; }
        public virtual DbSet<VISTA_AGREGACION_ITEMS_DEPENDIENTES> VISTA_AGREGACION_ITEMS_DEPENDIENTES { get; set; }
        public virtual DbSet<VISTA_CARTERA_INDEX> VISTA_CARTERA_INDEX { get; set; }
        public virtual DbSet<VISTA_CARTERA_INDEX1> VISTA_CARTERA_INDEX1 { get; set; }
        public virtual DbSet<VISTA_COMPARACION_DETALLES> VISTA_COMPARACION_DETALLES { get; set; }
        public virtual DbSet<VISTA_CONTRATO_PROYECTO_FACTURAS> VISTA_CONTRATO_PROYECTO_FACTURAS { get; set; }
        public virtual DbSet<VISTA_CONTRATO_PROYECTO_FACTURAS1> VISTA_CONTRATO_PROYECTO_FACTURAS1 { get; set; }
        public virtual DbSet<VISTA_CONTRATOS_ROL_DESCRIPCION> VISTA_CONTRATOS_ROL_DESCRIPCION { get; set; }
        public virtual DbSet<VISTA_COSTOS_FLUJO_INGR> VISTA_COSTOS_FLUJO_INGR { get; set; }
        public virtual DbSet<VISTA_COSTOS_FLUJO_INGR_TEMP> VISTA_COSTOS_FLUJO_INGR_TEMP { get; set; }
        public virtual DbSet<VISTA_COSTOS_FLUJO_INGR_TEMP2> VISTA_COSTOS_FLUJO_INGR_TEMP2 { get; set; }
        public virtual DbSet<VISTA_DETALLE_ADJUNTOS_PERS> VISTA_DETALLE_ADJUNTOS_PERS { get; set; }
        public virtual DbSet<VISTA_DETALLE_FACTURA_ITEM_REPORTE> VISTA_DETALLE_FACTURA_ITEM_REPORTE { get; set; }
        public virtual DbSet<VISTA_DETALLE_FACTURA_ITEM_REPORTE_PSL> VISTA_DETALLE_FACTURA_ITEM_REPORTE_PSL { get; set; }
        public virtual DbSet<VISTA_DETALLE_FACTURA_PERS_REPORTE> VISTA_DETALLE_FACTURA_PERS_REPORTE { get; set; }
        public virtual DbSet<VISTA_DETALLE_FACTURA_PERS_REPORTE_PSL> VISTA_DETALLE_FACTURA_PERS_REPORTE_PSL { get; set; }
        public virtual DbSet<VISTA_DETALLE_FACTURAS_REPORTE> VISTA_DETALLE_FACTURAS_REPORTE { get; set; }
        public virtual DbSet<VISTA_DETALLE_POR_FACTURA> VISTA_DETALLE_POR_FACTURA { get; set; }
        public virtual DbSet<VISTA_DETALLES_FACTURAS_ANTES_PSL> VISTA_DETALLES_FACTURAS_ANTES_PSL { get; set; }
        public virtual DbSet<VISTA_DETDOCVTAENTRA> VISTA_DETDOCVTAENTRA { get; set; }
        public virtual DbSet<VISTA_DETDOCVTAENTRA_MULTIPLES_FACTURAS> VISTA_DETDOCVTAENTRA_MULTIPLES_FACTURAS { get; set; }
        public virtual DbSet<VISTA_DETDOCVTAENTRA_MULTIPLES_FACTURAS_PRODUCTIVO> VISTA_DETDOCVTAENTRA_MULTIPLES_FACTURAS_PRODUCTIVO { get; set; }
        public virtual DbSet<VISTA_DETDOCVTAENTRA_MULTIPLES_FACTURAS_PRUEBAS> VISTA_DETDOCVTAENTRA_MULTIPLES_FACTURAS_PRUEBAS { get; set; }
        public virtual DbSet<VISTA_ENCDOCVTAENTRA> VISTA_ENCDOCVTAENTRA { get; set; }
        public virtual DbSet<VISTA_ENCDOCVTAENTRA_MULTIPLES_FACTURAS> VISTA_ENCDOCVTAENTRA_MULTIPLES_FACTURAS { get; set; }
        public virtual DbSet<VISTA_ENCDOCVTAENTRA_MULTIPLES_FACTURAS_PRODUCTIVO> VISTA_ENCDOCVTAENTRA_MULTIPLES_FACTURAS_PRODUCTIVO { get; set; }
        public virtual DbSet<VISTA_ENCDOCVTAENTRA_MULTIPLES_FACTURAS_PRUEBAS> VISTA_ENCDOCVTAENTRA_MULTIPLES_FACTURAS_PRUEBAS { get; set; }
        public virtual DbSet<VISTA_ESTADOS_FINANCIEROS_PRUEBA1> VISTA_ESTADOS_FINANCIEROS_PRUEBA1 { get; set; }
        public virtual DbSet<VISTA_FACTURACION_ADJUNTO_PERS> VISTA_FACTURACION_ADJUNTO_PERS { get; set; }
        public virtual DbSet<VISTA_FACTURAS_CARTERA> VISTA_FACTURAS_CARTERA { get; set; }
        public virtual DbSet<VISTA_FACTURAS_FECHA_PERIODO_FACTURACION> VISTA_FACTURAS_FECHA_PERIODO_FACTURACION { get; set; }
        public virtual DbSet<VISTA_FACTURAS_PAGOS> VISTA_FACTURAS_PAGOS { get; set; }
        public virtual DbSet<VISTA_FACTURAS_TRAZA_PSL> VISTA_FACTURAS_TRAZA_PSL { get; set; }
        public virtual DbSet<VISTA_FINANCIERA> VISTA_FINANCIERA { get; set; }
        public virtual DbSet<VISTA_FLUJO_INGRESOS> VISTA_FLUJO_INGRESOS { get; set; }
        public virtual DbSet<VISTA_FLUJO_INGRESOS_ITEM_TEMP> VISTA_FLUJO_INGRESOS_ITEM_TEMP { get; set; }
        public virtual DbSet<VISTA_FLUJO_INGRESOS_ITEMS> VISTA_FLUJO_INGRESOS_ITEMS { get; set; }
        public virtual DbSet<VISTA_FLUJO_INGRESOS_ROL_CORREGIDA_REALIDAD> VISTA_FLUJO_INGRESOS_ROL_CORREGIDA_REALIDAD { get; set; }
        public virtual DbSet<VISTA_GENERACION_DATOS_REGISTRO_NOVEDADES> VISTA_GENERACION_DATOS_REGISTRO_NOVEDADES { get; set; }
        public virtual DbSet<VISTA_GENERACION_PAGADO_COLABORADOR> VISTA_GENERACION_PAGADO_COLABORADOR { get; set; }
        public virtual DbSet<VISTA_GESTION_CARTERA> VISTA_GESTION_CARTERA { get; set; }
        public virtual DbSet<VISTA_GRUPOS_CECOS> VISTA_GRUPOS_CECOS { get; set; }
        public virtual DbSet<VISTA_INDICADORES_PROYECCION_PAGOS> VISTA_INDICADORES_PROYECCION_PAGOS { get; set; }
        public virtual DbSet<VISTA_INGEELIMP> VISTA_INGEELIMP { get; set; }
        public virtual DbSet<VISTA_ITEMS_CONTRATO> VISTA_ITEMS_CONTRATO { get; set; }
        public virtual DbSet<VISTA_ITEMS_CONTRATO_DESCRIPCION> VISTA_ITEMS_CONTRATO_DESCRIPCION { get; set; }
        public virtual DbSet<VISTA_ITEMS_VARIABLES> VISTA_ITEMS_VARIABLES { get; set; }
        public virtual DbSet<VISTA_ORDENES_CENTRO_COSTOS> VISTA_ORDENES_CENTRO_COSTOS { get; set; }
        public virtual DbSet<VISTA_ORDENES_ROL_CARGO> VISTA_ORDENES_ROL_CARGO { get; set; }
        public virtual DbSet<VISTA_PENDIENTES_FACTURA> VISTA_PENDIENTES_FACTURA { get; set; }
        public virtual DbSet<VISTA_PENDIENTES_RETIRO> VISTA_PENDIENTES_RETIRO { get; set; }
        public virtual DbSet<VISTA_PRUEBA_DECIMALES> VISTA_PRUEBA_DECIMALES { get; set; }
        public virtual DbSet<VISTA_PRUEBA_PARA_R> VISTA_PRUEBA_PARA_R { get; set; }
        public virtual DbSet<VISTA_PRUEBAS_JPM> VISTA_PRUEBAS_JPM { get; set; }
        public virtual DbSet<VISTA_REGISTRO_NOVEDADES> VISTA_REGISTRO_NOVEDADES { get; set; }
        public virtual DbSet<VISTA_REGISTRO_NOVEDADES_DESCRIPCION> VISTA_REGISTRO_NOVEDADES_DESCRIPCION { get; set; }
        public virtual DbSet<VISTA_REGISTRO_NOVEDADES_DIASLAB> VISTA_REGISTRO_NOVEDADES_DIASLAB { get; set; }
        public virtual DbSet<VISTA_REGISTRO_NOVEDADES_TEMP> VISTA_REGISTRO_NOVEDADES_TEMP { get; set; }
        public virtual DbSet<VISTA_REPORTE_CARTERA> VISTA_REPORTE_CARTERA { get; set; }
        public virtual DbSet<VISTA_RESUMEN_FACTURACION> VISTA_RESUMEN_FACTURACION { get; set; }
        public virtual DbSet<VISTA_RESUMEN_GESTION_CARTERA> VISTA_RESUMEN_GESTION_CARTERA { get; set; }
        public virtual DbSet<VISTA_RESUMEN_GESTION_FACTURAS> VISTA_RESUMEN_GESTION_FACTURAS { get; set; }
        public virtual DbSet<VISTA_SALARIO_COMERCIAL_INCREMENTOS> VISTA_SALARIO_COMERCIAL_INCREMENTOS { get; set; }
        public virtual DbSet<VISTA_SALARIO_INCREMENTOS_TEMP> VISTA_SALARIO_INCREMENTOS_TEMP { get; set; }
        public virtual DbSet<VISTA_TEMP> VISTA_TEMP { get; set; }
        public virtual DbSet<VISTA_TOTALES_GRUPOS_FACTURAS_SECUENCIA> VISTA_TOTALES_GRUPOS_FACTURAS_SECUENCIA { get; set; }
        public virtual DbSet<VISTA_TOTALES_GRUPOS_FACTURAS_SECUENCIA_PRODUCTIVO> VISTA_TOTALES_GRUPOS_FACTURAS_SECUENCIA_PRODUCTIVO { get; set; }
        public virtual DbSet<VISTA_USUARIOS_AttendanceDB> VISTA_USUARIOS_AttendanceDB { get; set; }
        public virtual DbSet<VISTA_NOVEDADES_DETALLE_ADJUNTO_PERS> VISTA_NOVEDADES_DETALLE_ADJUNTO_PERS { get; set; }
        public virtual DbSet<DETALLE_FACTURA_ITEMPERS> DETALLE_FACTURA_ITEMPERS { get; set; }
        public virtual DbSet<DETALLE_FACTURA_ADJUNTO_PERS> DETALLE_FACTURA_ADJUNTO_PERS { get; set; }
        public virtual DbSet<DETALLE_FACTURA_ITEM> DETALLE_FACTURA_ITEM { get; set; }
        public virtual DbSet<VISTA_PRUEBA_ESTADOS_CECO> VISTA_PRUEBA_ESTADOS_CECO { get; set; }
    
        public virtual ObjectResult<sp_actualizar_estado_centro_costo_Result> sp_actualizar_estado_centro_costo(ObjectParameter ret, ObjectParameter error, Nullable<int> cont)
        {
            var contParameter = cont.HasValue ?
                new ObjectParameter("cont", cont) :
                new ObjectParameter("cont", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_actualizar_estado_centro_costo_Result>("sp_actualizar_estado_centro_costo", ret, error, contParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
