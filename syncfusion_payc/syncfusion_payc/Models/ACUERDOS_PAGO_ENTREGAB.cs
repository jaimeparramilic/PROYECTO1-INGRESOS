
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
    
public partial class ACUERDOS_PAGO_ENTREGAB
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public ACUERDOS_PAGO_ENTREGAB()
    {

        this.GESTION_ENTREGABLES = new HashSet<GESTION_ENTREGABLES>();

    }


    public long COD_ACUERDO_PAGO { get; set; }

    public Nullable<long> COD_TIPO_ACUERDO { get; set; }

    public Nullable<long> COD_CARTERA { get; set; }

    public string UserName { get; set; }

    public string DESCRIPCION { get; set; }

    public Nullable<long> COD_ESTADO_ACUERDO { get; set; }

    public Nullable<System.DateTime> FECHA_REGISTRO { get; set; }

    public Nullable<System.DateTime> FECHA_ACUERDO { get; set; }

    public string APROBADO { get; set; }

    public string COMENTARIOS { get; set; }

    public Nullable<long> VALOR { get; set; }



    public virtual CARTERA CARTERA { get; set; }

    public virtual ESTADOS_ACUER_PAG_ENTREG ESTADOS_ACUER_PAG_ENTREG { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<GESTION_ENTREGABLES> GESTION_ENTREGABLES { get; set; }

    public virtual TIPOS_ACUERDO TIPOS_ACUERDO { get; set; }

}

}
