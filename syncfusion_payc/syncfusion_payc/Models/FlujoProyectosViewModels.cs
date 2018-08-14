using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace syncfusion_payc.Models
{
    public class FlujoProyectosViewModels
    {
        
        public PROYECTOS PROYECTO { get; set; }
        public CONTRATOS CONTRATO { get; set; }
        public CLIENTES CLIENTE { get; set; }
        public virtual ICollection<CONTRATOS_CONDICIONES> CONTRATO_CONDICIONES { get; set; }
        public virtual ICollection<CONTRATOS_ROL> CONTRATO_ROL{ get; set; }
        public FORMAS_PAGO FORMA_PAGO{ get; set; }
        public virtual ICollection<ITEMS_CONTRATO> ITEM_CONTRATO { get; set; }
    }
}
