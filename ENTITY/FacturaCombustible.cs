using Helper;
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
    }
}
