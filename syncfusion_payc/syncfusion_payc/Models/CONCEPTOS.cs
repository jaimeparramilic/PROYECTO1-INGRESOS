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
    
    public partial class CONCEPTOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONCEPTOS()
        {
            this.CONTRATOS_ROL = new HashSet<CONTRATOS_ROL>();
            this.DETALLE_FACTURA_ADJUNTO_ITEM = new HashSet<DETALLE_FACTURA_ADJUNTO_ITEM>();
            this.DETALLE_FACTURA_ADJUNTO_PERS = new HashSet<DETALLE_FACTURA_ADJUNTO_PERS>();
            this.DETALLE_FACTURA_ITEM = new HashSet<DETALLE_FACTURA_ITEM>();
            this.DETALLE_FACTURA_PERS = new HashSet<DETALLE_FACTURA_PERS>();
            this.FACTURAS = new HashSet<FACTURAS>();
            this.ITEMS_CONTRATO = new HashSet<ITEMS_CONTRATO>();
        }
    
        public long COD_CONCEPTO_PSL { get; set; }
        public string CODIGO_EN_PSL { get; set; }
        public string TEXTO_EN_PSL { get; set; }
    
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
        public virtual ICollection<DETALLE_FACTURA_ADJUNTO_PERS> DETALLE_FACTURA_ADJUNTO_PERS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<DETALLE_FACTURA_ITEM> DETALLE_FACTURA_ITEM { get; set; }
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
        public virtual ICollection<ITEMS_CONTRATO> ITEMS_CONTRATO { get; set; }
    }
}
