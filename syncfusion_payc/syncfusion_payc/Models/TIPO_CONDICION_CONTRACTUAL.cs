
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
    
public partial class TIPO_CONDICION_CONTRACTUAL
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public TIPO_CONDICION_CONTRACTUAL()
    {

        this.CONTRATOS_CONDICIONES = new HashSet<CONTRATOS_CONDICIONES>();

        this.TIPOS_NOVEDAD_CONDICION = new HashSet<TIPOS_NOVEDAD_CONDICION>();

    }


    public long COD_TIPO_CONDICION { get; set; }

    public string DESCRIPCION { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<CONTRATOS_CONDICIONES> CONTRATOS_CONDICIONES { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<TIPOS_NOVEDAD_CONDICION> TIPOS_NOVEDAD_CONDICION { get; set; }

}

}
