using ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class FacturaCombustible :Factura
    {
        public FacturaCombustible()
        {
            this.TipoFactura = new TipoFactura() { IdTipoFactura = (int)EnumTiposFactura.FacturaRecargaCombustible };
        }

        public RecargaCombustible RecargaCombu { get; set; }

        public override Persona DatosCliente()
        {
            Cliente cliente = new Cliente();

            return cliente;
        }

        public override Persona DatosEmisor()
        {
            Empresa emisor = new Empresa();
            return emisor;
        }

        public override List<LiquidacionDetalle> FacturaDetalles()
        {
            List<LiquidacionDetalle> facturaDetalles = new List<LiquidacionDetalle>();

            return facturaDetalles;
        }
    }
}
