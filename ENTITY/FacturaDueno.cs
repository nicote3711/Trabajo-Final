using ENTITY.Enum;
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

        public override Persona DatosCliente()
        {
            throw new NotImplementedException();
        }

        public override Persona DatosEmisor()
        {
            throw new NotImplementedException();
        }

        public override FacturaDetalle FacturaDetalles()
        {
            throw new NotImplementedException();
        }
    }
}
