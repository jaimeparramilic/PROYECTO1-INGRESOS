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
    
    public partial class CONTRATO_ROL_DESCRIPCION
    {
        public long COD_CONTRATO_ROL { get; set; }
        public Nullable<long> COD_ROL { get; set; }
        public Nullable<long> COD_CONTRATO_PROYECTO { get; set; }
        public Nullable<System.DateTime> FECHA_INI { get; set; }
        public Nullable<long> MESES { get; set; }
        public Nullable<float> VALOR_MENSUAL_SIN_PRESTACIONES { get; set; }
        public Nullable<float> PRESTACIONES { get; set; }
        public Nullable<float> VALOR_MENSUAL_PRESTACIONES { get; set; }
        public Nullable<float> FACTOR_MULTIPLICADOR { get; set; }
        public Nullable<float> VALOR_MENSUAL_PRESTACIONES_MULTIPLICADOR { get; set; }
        public Nullable<float> DEDICACION { get; set; }
        public string OBSERVACIONES { get; set; }
        public string DESCRIPCION { get; set; }
        public string TIPO_TRIBUTACION { get; set; }
    }
}