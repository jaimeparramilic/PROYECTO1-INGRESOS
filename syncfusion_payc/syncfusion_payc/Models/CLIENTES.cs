
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
    
public partial class CLIENTES
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public CLIENTES()
    {

        this.CONTRATOS = new HashSet<CONTRATOS>();

        this.EMAIL_CLIENTES = new HashSet<EMAIL_CLIENTES>();

    }


    public long COD_CLIENTE { get; set; }

    public string DESCRIPCION { get; set; }

    public string NIT { get; set; }

    public string DIRECCION_CLIENTE { get; set; }

    public string DIRECCION_FACTURACION { get; set; }

    public string CONTACTO_CONTRATANTE { get; set; }

    public string CONTACTO_FACTURACION { get; set; }

    public string TELEFONO_CLIENTE { get; set; }

    public string TELEFONO_FACTURACION { get; set; }

    public string CORREO_CLIENTE { get; set; }

    public string CORREO_FACTURACION { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<CONTRATOS> CONTRATOS { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<EMAIL_CLIENTES> EMAIL_CLIENTES { get; set; }

}

}
