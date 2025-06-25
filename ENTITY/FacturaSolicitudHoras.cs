using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class FacturaSolicitudHoras :Factura
    {
        public FacturaSolicitudHoras()
        {
            this.TipoFactura = new TipoFactura()
            {
                IdTipoFactura = (int)EnumTiposFactura.FacturaSolicitudHoras
                               
            };
           
        }
        public SolicitudHoras Solicitud { get; set; }
    }
}
