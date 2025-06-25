using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class FacturaInstructor :Factura
    {
        public FacturaInstructor()
        {
            this.TipoFactura = new TipoFactura();   
            TipoFactura.IdTipoFactura = (int)EnumTiposFactura.FacturaInstructor;
            
        }

        public List<LiquidacionInstructor> ListaLiquidaciones { get; set; }
    }
}
