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
    
    public partial class TIPOS_REEMBOLSO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPOS_REEMBOLSO()
        {
            this.ITEMS_CONTRATO = new HashSet<ITEMS_CONTRATO>();
        }
    
        public long COD_TIPO_REEMBOLSO { get; set; }
        public string DESCRIPCION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<ITEMS_CONTRATO> ITEMS_CONTRATO { get; set; }
    }
}
