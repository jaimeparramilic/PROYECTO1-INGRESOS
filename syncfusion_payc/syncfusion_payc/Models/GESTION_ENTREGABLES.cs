
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
    
public partial class GESTION_ENTREGABLES
{

    public long COD_GEST_ENTREGABLE { get; set; }

    public long COD_ACUERDO_PAGO { get; set; }

    public string URL_ARCHIVO { get; set; }

    public System.DateTime FECHA_CARGA { get; set; }

    public string OBSERVACIONES { get; set; }



    public virtual ACUERDOS_PAGO_ENTREGAB ACUERDOS_PAGO_ENTREGAB { get; set; }

}

}
