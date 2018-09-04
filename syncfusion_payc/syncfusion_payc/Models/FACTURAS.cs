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
    
    public partial class FACTURAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FACTURAS()
        {
            this.DETALLE_FACTURA_PERS = new HashSet<DETALLE_FACTURA_PERS>();
            this.DETALLE_FACTURA_ITEM = new HashSet<DETALLE_FACTURA_ITEM>();
        }
    
        public long COD_FACTURA { get; set; }
        public Nullable<long> COD_CONTRATO_PROYECTO { get; set; }
        public Nullable<long> COD_FORMAS_PAGO_FECHAS { get; set; }
        public string NUMERO_FACTURA { get; set; }
        public Nullable<System.DateTime> FECHA_FACTURA { get; set; }
        public Nullable<long> COD_ESTADO_FACTURA { get; set; }
        public Nullable<float> VALOR_SIN_IMPUESTOS { get; set; }
        public Nullable<float> VALOR_CON_IMPUESTOS { get; set; }
        public string RANKING { get; set; }
    
        public virtual CONTRATO_PROYECTO CONTRATO_PROYECTO { get; set; }
        public virtual FORMAS_PAGO_FECHAS FORMAS_PAGO_FECHAS { get; set; }
        public virtual ESTADOS_FACTURAS ESTADOS_FACTURAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<DETALLE_FACTURA_PERS> DETALLE_FACTURA_PERS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<DETALLE_FACTURA_ITEM> DETALLE_FACTURA_ITEM { get; set; }
    }
}
