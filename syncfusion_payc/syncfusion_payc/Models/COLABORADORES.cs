
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
    
public partial class COLABORADORES
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public COLABORADORES()
    {

        this.CONTRATO_COLABORADOR = new HashSet<CONTRATO_COLABORADOR>();

        this.DETALLE_FACTURA_ADJUNTO_PERS = new HashSet<DETALLE_FACTURA_ADJUNTO_PERS>();

        this.ENTREGABLES = new HashSet<ENTREGABLES>();

        this.ESTUDIOS_COLABORADOR = new HashSet<ESTUDIOS_COLABORADOR>();

        this.REGISTRO_NOVEDADES = new HashSet<REGISTRO_NOVEDADES>();

        this.REGISTRO_NOVEDADES_TRABAJO = new HashSet<REGISTRO_NOVEDADES_TRABAJO>();

    }


    public long COD_COLABORADOR { get; set; }

    public Nullable<long> COD_CARGO { get; set; }

    public string DESCRIPCION { get; set; }

    public Nullable<long> CEDULA { get; set; }

    public Nullable<long> COD_GENERO { get; set; }

    public Nullable<System.DateTime> FECHA_NACIMIENTO { get; set; }

    public string CELULAR { get; set; }

    public string CORREO_ELECTRONICO { get; set; }

    public string ESTADO_CIVIL { get; set; }

    public string CENTROS_COSTOS { get; set; }

    public Nullable<System.DateTime> FECHA_INGRESO { get; set; }

    public Nullable<long> COD_TIPO_DE_CONTRATO { get; set; }

    public Nullable<long> COD_ESTADO_COLABORADOR { get; set; }

    public string NOMBRES { get; set; }

    public string APELLIDOS { get; set; }



    public virtual CARGOS CARGOS { get; set; }

    public virtual ESTADO_COLABORADOR ESTADO_COLABORADOR { get; set; }

    public virtual GENEROS GENEROS { get; set; }

    public virtual TIPO_CONTRATO TIPO_CONTRATO { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<CONTRATO_COLABORADOR> CONTRATO_COLABORADOR { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<DETALLE_FACTURA_ADJUNTO_PERS> DETALLE_FACTURA_ADJUNTO_PERS { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<ENTREGABLES> ENTREGABLES { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<ESTUDIOS_COLABORADOR> ESTUDIOS_COLABORADOR { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<REGISTRO_NOVEDADES> REGISTRO_NOVEDADES { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<REGISTRO_NOVEDADES_TRABAJO> REGISTRO_NOVEDADES_TRABAJO { get; set; }

}

}
