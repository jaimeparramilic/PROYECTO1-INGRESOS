//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class CONTRATO_PROYECTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTRATO_PROYECTO()
        {
            this.CONTRATOS_CONDICIONES = new HashSet<CONTRATOS_CONDICIONES>();
            this.CONTRATOS_ROL = new HashSet<CONTRATOS_ROL>();
            this.DETALLE_FACTURA_ADJUNTO_ITEM = new HashSet<DETALLE_FACTURA_ADJUNTO_ITEM>();
            this.DETALLE_FACTURA_PERS = new HashSet<DETALLE_FACTURA_PERS>();
            this.FACTURAS = new HashSet<FACTURAS>();
            this.FLUJO_INGRESOS_ITEMS = new HashSet<FLUJO_INGRESOS_ITEMS>();
            this.FLUJO_INGRESOS_ROL = new HashSet<FLUJO_INGRESOS_ROL>();
            this.GESTION_CARTERA = new HashSet<GESTION_CARTERA>();
            this.INCREMENTO_ORDEN = new HashSet<INCREMENTO_ORDEN>();
            this.ITEMS_CONTRATO = new HashSet<ITEMS_CONTRATO>();
            this.ITEMS_ROLES = new HashSet<ITEMS_ROLES>();
            this.REGISTRO_ITEMS_OTROS_COSTOS = new HashSet<REGISTRO_ITEMS_OTROS_COSTOS>();
            this.REGISTRO_NOVEDADES = new HashSet<REGISTRO_NOVEDADES>();
            this.REGISTRO_NOVEDADES_TRABAJO = new HashSet<REGISTRO_NOVEDADES_TRABAJO>();
            this.ROL_CARGO_ORDEN = new HashSet<ROL_CARGO_ORDEN>();
            this.TAG_ORDEN = new HashSet<TAG_ORDEN>();
            this.DETALLE_FACTURA_ADJUNTO_PERS = new HashSet<DETALLE_FACTURA_ADJUNTO_PERS>();
            this.DETALLE_FACTURA_ITEM = new HashSet<DETALLE_FACTURA_ITEM>();
        }
    
        public long COD_CONTRATO_PROYECTO { get; set; }
        public Nullable<long> COD_CONTRATO { get; set; }
        public Nullable<long> COD_PROYECTO { get; set; }
        public Nullable<long> COD_FORMA_PAGO { get; set; }
        public string COMPLETA { get; set; }
        public string MODIFICADO_POR { get; set; }
        public Nullable<System.DateTime> FECHA_ULTIMA_MODIFICACION { get; set; }
        public string CREADO_POR { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
        public string CENTRO_COSTOS { get; set; }
        public Nullable<long> COD_ESTADO_ORDEN_SERVICIO { get; set; }
        public string CORREO_RESPONSABLE { get; set; }
        public string TELEFONO_RESPONSABLE { get; set; }
        public string OBSERVACIONES { get; set; }
    
        public virtual CONTRATOS CONTRATOS { get; set; }
        public virtual ESTADOS_ORDEN_SERVICIO ESTADOS_ORDEN_SERVICIO { get; set; }
        public virtual FORMAS_PAGO FORMAS_PAGO { get; set; }
        public virtual PROYECTOS PROYECTOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<CONTRATOS_CONDICIONES> CONTRATOS_CONDICIONES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<CONTRATOS_ROL> CONTRATOS_ROL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<DETALLE_FACTURA_ADJUNTO_ITEM> DETALLE_FACTURA_ADJUNTO_ITEM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<DETALLE_FACTURA_PERS> DETALLE_FACTURA_PERS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<FACTURAS> FACTURAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<FLUJO_INGRESOS_ITEMS> FLUJO_INGRESOS_ITEMS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<FLUJO_INGRESOS_ROL> FLUJO_INGRESOS_ROL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<GESTION_CARTERA> GESTION_CARTERA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<INCREMENTO_ORDEN> INCREMENTO_ORDEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<ITEMS_CONTRATO> ITEMS_CONTRATO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<ITEMS_ROLES> ITEMS_ROLES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<REGISTRO_ITEMS_OTROS_COSTOS> REGISTRO_ITEMS_OTROS_COSTOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<REGISTRO_NOVEDADES> REGISTRO_NOVEDADES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<REGISTRO_NOVEDADES_TRABAJO> REGISTRO_NOVEDADES_TRABAJO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<ROL_CARGO_ORDEN> ROL_CARGO_ORDEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<TAG_ORDEN> TAG_ORDEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<DETALLE_FACTURA_ADJUNTO_PERS> DETALLE_FACTURA_ADJUNTO_PERS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<DETALLE_FACTURA_ITEM> DETALLE_FACTURA_ITEM { get; set; }
    }
}
