
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
    
public partial class FORMAS_PAGO_FECHAS
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public FORMAS_PAGO_FECHAS()
    {

        this.DETALLE_FACTURA_ITEM = new HashSet<DETALLE_FACTURA_ITEM>();

        this.DETALLE_FACTURA_PERS = new HashSet<DETALLE_FACTURA_PERS>();

        this.FLUJO_INGRESOS_ITEMS = new HashSet<FLUJO_INGRESOS_ITEMS>();

        this.INCREMENTO_SALARIAL = new HashSet<INCREMENTO_SALARIAL>();

        this.REGISTRO_ITEMS_OTROS_COSTOS = new HashSet<REGISTRO_ITEMS_OTROS_COSTOS>();

        this.DETALLE_FACTURA_ADJUNTO_PERS = new HashSet<DETALLE_FACTURA_ADJUNTO_PERS>();

        this.REGISTRO_NOVEDADES = new HashSet<REGISTRO_NOVEDADES>();

        this.FACTURAS = new HashSet<FACTURAS>();

    }


    public long COD_FORMAS_PAGO_FECHAS { get; set; }

    public Nullable<long> COD_FORMA_PAGO { get; set; }

    public Nullable<System.DateTime> FECHA_FORMA_PAGO { get; set; }

    public Nullable<System.DateTime> FECHA_INICIO { get; set; }

    public Nullable<System.DateTime> FECHA_FIN { get; set; }

    public string PERIODO_TEXTO { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<DETALLE_FACTURA_ITEM> DETALLE_FACTURA_ITEM { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<DETALLE_FACTURA_PERS> DETALLE_FACTURA_PERS { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<FLUJO_INGRESOS_ITEMS> FLUJO_INGRESOS_ITEMS { get; set; }

    public virtual FORMAS_PAGO FORMAS_PAGO { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<INCREMENTO_SALARIAL> INCREMENTO_SALARIAL { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<REGISTRO_ITEMS_OTROS_COSTOS> REGISTRO_ITEMS_OTROS_COSTOS { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<DETALLE_FACTURA_ADJUNTO_PERS> DETALLE_FACTURA_ADJUNTO_PERS { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<REGISTRO_NOVEDADES> REGISTRO_NOVEDADES { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	[System.Runtime.Serialization.IgnoreDataMember]
	[Newtonsoft.Json.JsonIgnore]

    public virtual ICollection<FACTURAS> FACTURAS { get; set; }

}

}
