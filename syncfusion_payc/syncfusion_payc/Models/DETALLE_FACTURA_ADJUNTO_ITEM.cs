
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
    
public partial class DETALLE_FACTURA_ADJUNTO_ITEM
{

    public long COD_DETALLE_FACTURA_ADJUNTO_ITEM { get; set; }

    public Nullable<long> COD_CONTRATO_PROYECTO { get; set; }

    public Nullable<long> COD_ITEM_CONTRATO { get; set; }

    public Nullable<long> COD_FORMAS_PAGO_FECHAS { get; set; }

    public Nullable<decimal> VALOR_SIN_IMPUESTOS { get; set; }

    public Nullable<System.DateTime> FECHA_REGISTRO { get; set; }

    public string USUARIO { get; set; }

    public Nullable<long> COD_ESTADO_FACTURA { get; set; }

    public Nullable<long> COD_CAUSA_ESTADO { get; set; }

    public string OBSERVACIONES { get; set; }

    public Nullable<long> COD_FACTURA { get; set; }

    public Nullable<long> COD_ESTADO_DETALLE { get; set; }

    public Nullable<long> COD_CONCEPTO_PSL { get; set; }

    public Nullable<long> COD_GRUPO_FACTURA { get; set; }



    public virtual CAUSA_ESTADO CAUSA_ESTADO { get; set; }

    public virtual CONCEPTOS CONCEPTOS { get; set; }

    public virtual CONTRATO_PROYECTO CONTRATO_PROYECTO { get; set; }

    public virtual ESTADOS_FACTURAS ESTADOS_FACTURAS { get; set; }

    public virtual FORMAS_PAGO_FECHAS FORMAS_PAGO_FECHAS { get; set; }

    public virtual GRUPOS_FACTURA GRUPOS_FACTURA { get; set; }

    public virtual ITEMS_CONTRATO ITEMS_CONTRATO { get; set; }

}

}
