
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
    
public partial class FORMAS_PAGO
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public FORMAS_PAGO()
    {

        this.CONTRATO_PROYECTO = new HashSet<CONTRATO_PROYECTO>();

        this.FORMAS_PAGO_FECHAS = new HashSet<FORMAS_PAGO_FECHAS>();

    }


    public long COD_FORMA_PAGO { get; set; }

    public string DESCRIPCION { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<CONTRATO_PROYECTO> CONTRATO_PROYECTO { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<FORMAS_PAGO_FECHAS> FORMAS_PAGO_FECHAS { get; set; }

}

}
