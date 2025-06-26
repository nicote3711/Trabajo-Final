using ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static ENTITY.FacturaDetalle;

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

        public override FacturaDetalle FacturaDetalles()
        {
            FacturaDetalle detalleFactura = new FacturaDetalle();
            detalleFactura.TipoItemFactura = typeof(SolicitudHoras).AssemblyQualifiedName;
            detalleFactura.ItemsFactura.Add(Solicitud);
            detalleFactura.FacturaDetalleItems.Add(new FacturaDetalleItem() { Cabecera = "Solicitud",ItemProperty = "IdSolicitudHoras" });
            detalleFactura.FacturaDetalleItems.Add(new FacturaDetalleItem() { Cabecera = "Fecha Solicitud", ItemProperty = "FechaSolicitud" });
            detalleFactura.FacturaDetalleItems.Add(new FacturaDetalleItem() { Cabecera = "Horas de vuelo", ItemProperty = "CantidadHorasVuelo" });
            detalleFactura.FacturaDetalleItems.Add(new FacturaDetalleItem() { Cabecera = "Horas Simulador", ItemProperty = "CantidadHorasSimulador" });
            detalleFactura.FacturaDetalleItems.Add(new FacturaDetalleItem() { Cabecera = "Precio Vuelo", ItemProperty = "ValorHoraVuelo" }); 
            detalleFactura.FacturaDetalleItems.Add(new FacturaDetalleItem() { Cabecera = "Precio Simulador", ItemProperty = "ValorHoraSimulador" });
            
            return detalleFactura;
        }
    }
}
