
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
    
public partial class ESTADOS_ACUER_PAG_ENTREG
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public ESTADOS_ACUER_PAG_ENTREG()
    {

        this.ACUERDOS_PAGO_ENTREGAB = new HashSet<ACUERDOS_PAGO_ENTREGAB>();

    }


    public long COD_ESTADO_ACUERDO { get; set; }

    public string DESCRIPCION { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<ACUERDOS_PAGO_ENTREGAB> ACUERDOS_PAGO_ENTREGAB { get; set; }

}

}
