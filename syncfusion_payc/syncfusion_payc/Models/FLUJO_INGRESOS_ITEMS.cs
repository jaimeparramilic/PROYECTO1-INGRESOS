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
    
    public partial class FLUJO_INGRESOS_ITEMS
    {
        public long COD_FLUJO_INGRESOS_ITEMS { get; set; }
        public Nullable<long> COD_FORMAS_PAGO_FECHAS { get; set; }
        public Nullable<long> COD_ITEM_CONTRATO { get; set; }
        public Nullable<long> COD_CONTRATO_PROYECTO { get; set; }
        public string ETAPA { get; set; }
        public Nullable<decimal> VALOR_FIJO { get; set; }
        public Nullable<decimal> VALOR_VARIABLE { get; set; }
        public Nullable<decimal> VALOR_TOTAL { get; set; }
        public string ESTADO { get; set; }
        public Nullable<System.DateTime> FECHA_REGISTRO { get; set; }
        public string USUARIO_REGISTRO { get; set; }
    
        public virtual FORMAS_PAGO_FECHAS FORMAS_PAGO_FECHAS { get; set; }
        public virtual ITEMS_CONTRATO ITEMS_CONTRATO { get; set; }
        public virtual CONTRATO_PROYECTO CONTRATO_PROYECTO { get; set; }
    }
}
