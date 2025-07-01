using ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class FacturaMantenimiento :Factura
    {
        public FacturaMantenimiento() { this.TipoFactura = new TipoFactura() { IdTipoFactura = (int)EnumTiposFactura.FacturaMantenimiento }; }

        public Mantenimiento Mantenimiento { get; set; }

        public override Persona DatosCliente()
        {
            throw new NotImplementedException();
        }

        public override Persona DatosEmisor()
        {
            throw new NotImplementedException();
        }

        public override List<LiquidacionDetalle> FacturaDetalles()
        {
            throw new NotImplementedException();
        }
    }
}
