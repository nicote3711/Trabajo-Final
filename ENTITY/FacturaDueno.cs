using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class FacturaDueno:Factura
    {
        public FacturaDueno() 
        { 
            this.TipoFactura = new TipoFactura() { IdTipoFactura = (int)EnumTiposFactura.FacturaDueño };
            
        }

        public List<LiquidacionDueno> ListaLiquidaciones { get; set; }
    }
}
