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
    
    public partial class TAG_ORDEN
    {
        public long COD_TAG_ORDEN { get; set; }
        public Nullable<long> COD_CONTRATO_PROYECTO { get; set; }
        public string TAG { get; set; }
    
        public virtual CONTRATO_PROYECTO CONTRATO_PROYECTO { get; set; }
    }
}
