
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
    
public partial class ESTADO_COLABORADOR
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public ESTADO_COLABORADOR()
    {

        this.COLABORADORES = new HashSet<COLABORADORES>();

    }


    public long COD_ESTADO_COLABORADOR { get; set; }

    public string DESCRIPCION { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<COLABORADORES> COLABORADORES { get; set; }

}

}
