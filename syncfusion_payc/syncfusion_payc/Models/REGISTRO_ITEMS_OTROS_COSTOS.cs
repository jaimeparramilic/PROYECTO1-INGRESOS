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
    
    public partial class REGISTRO_ITEMS_OTROS_COSTOS
    {
        public long COD_REGISTRO_ITEMS { get; set; }
        public Nullable<long> COD_ITEM_CONTRATO { get; set; }
        public Nullable<long> COD_CONTRATO_PROYECTO { get; set; }
        public Nullable<long> COD_FORMAS_PAGO_FECHAS { get; set; }
        public Nullable<float> VALOR_COMERCIAL { get; set; }
        public Nullable<float> CANTIDAD { get; set; }
        public string PARAMETRO1 { get; set; }
        public string PARAMETRO2 { get; set; }
        public string PARAMETRO3 { get; set; }
        public string PARAMETRO4 { get; set; }
        public string PARAMETRON { get; set; }
    
        public virtual CONTRATO_PROYECTO CONTRATO_PROYECTO { get; set; }
        public virtual FORMAS_PAGO_FECHAS FORMAS_PAGO_FECHAS { get; set; }
        public virtual ITEMS_CONTRATO ITEMS_CONTRATO { get; set; }
    }
}
