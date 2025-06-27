using ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class FacturaSolicitudHoras : Factura
    {
        public FacturaSolicitudHoras()
        {
            this.TipoFactura = new TipoFactura()
            {
                IdTipoFactura = (int)EnumTiposFactura.FacturaSolicitudHoras
            };
           
        }
        public SolicitudHoras Solicitud { get; set; }

        public override Persona DatosCliente()
        {
            return Solicitud.Cliente;
        }

        public override Persona DatosEmisor()
        {
            Empresa emisor = new Empresa();

            emisor.Nombre = "Flight MRB";
            emisor.Apellido = string.Empty;
            emisor.CuitCuil = "3013549875";

            return emisor;
        }

        public override List<LiquidacionDetalle> FacturaDetalles()
        {
            List<LiquidacionDetalle> detalleLiq = new List<LiquidacionDetalle>();
            if(Solicitud.CantidadHorasVuelo > 0)
                detalleLiq.Add(new LiquidacionDetalle(Solicitud.FechaSolicitud, "Solicitud de horas de Vuelo", Solicitud.CantidadHorasVuelo, Solicitud.ValorHoraVuelo));
            if (Solicitud.CantidadHorasSimulador > 0)
                detalleLiq.Add(new LiquidacionDetalle(Solicitud.FechaSolicitud,"Solicitud de horas de Simulador", Solicitud.CantidadHorasSimulador,Solicitud.ValorHoraSimulador));
            
            return detalleLiq;
        }
    }
}
