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
    
    public partial class ESTADOS_ORDEN_SERVICIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESTADOS_ORDEN_SERVICIO()
        {
            this.CONTRATO_PROYECTO = new HashSet<CONTRATO_PROYECTO>();
        }
    
        public long COD_ESTADO_ORDEN_SERVICIO { get; set; }
        public string DESCRIPCION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<CONTRATO_PROYECTO> CONTRATO_PROYECTO { get; set; }
        public virtual ESTADOS_ORDEN_SERVICIO ESTADOS_ORDEN_SERVICIO1 { get; set; }
        public virtual ESTADOS_ORDEN_SERVICIO ESTADOS_ORDEN_SERVICIO2 { get; set; }
    }
}
