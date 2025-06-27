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
            cliente.Nombre = "Flight MRB";
            cliente.Apellido = string.Empty;
            cliente.CuitCuil = "3013549875";
            return cliente;
        }

        public override Persona DatosEmisor()
        {
            Empresa emisor = new Empresa();
            emisor.CuitCuil = RecargaCombu.ProveedorCombu.Cuit;
            emisor.Nombre = RecargaCombu.ProveedorCombu.NombreEmpresa;
            return emisor;
        }

        public override List<LiquidacionDetalle> FacturaDetalles()
        {
            List<LiquidacionDetalle> facturaDetalles = new List<LiquidacionDetalle>();
            facturaDetalles.Add(new LiquidacionDetalle(RecargaCombu.Fecha,"Recarga de combustible en litros",RecargaCombu.CantidadLitros,RecargaCombu.PrecioLitros));
            return facturaDetalles;
        }
    }
}
