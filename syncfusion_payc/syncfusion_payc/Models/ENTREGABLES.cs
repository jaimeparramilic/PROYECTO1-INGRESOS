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
    
    public partial class ENTREGABLES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ENTREGABLES()
        {
            this.COMPROMISOS_ENTREGABLES = new HashSet<COMPROMISOS_ENTREGABLES>();
        }
    
        public long COD_ENTREGABLE { get; set; }
        public Nullable<long> COD_CONTRATO_CONDICION { get; set; }
        public Nullable<long> COD_COLABORADOR { get; set; }
        public string DESCRIPCION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[System.Runtime.Serialization.IgnoreDataMember]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<COMPROMISOS_ENTREGABLES> COMPROMISOS_ENTREGABLES { get; set; }
        public virtual CONTRATOS_CONDICIONES CONTRATOS_CONDICIONES { get; set; }
        public virtual COLABORADORES COLABORADORES { get; set; }
    }
}
