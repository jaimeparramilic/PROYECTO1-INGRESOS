
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
    
public partial class COMPROMISOS_ENTREGABLES
{

    public long COD_COMPROMISO { get; set; }

    public Nullable<long> COD_CARTERA { get; set; }

    public Nullable<long> COD_ENTREGABLE { get; set; }

    public string ESTADO_COMPROMISO { get; set; }

    public Nullable<System.DateTime> FECHA_COMPROMISO { get; set; }

    public string RUTA_ENTREGABLE { get; set; }



    public virtual ENTREGABLES ENTREGABLES { get; set; }

}

}
