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
            Cliente cliente = new Cliente();

            cliente.Nombre = "Flight MRB";
            cliente.Apellido = string.Empty;
            cliente.CuitCuil = "3013549875";
            return cliente;
        }

        public override Persona DatosEmisor()
        {
            Empresa emisor = new Empresa();
            emisor.Nombre = Mantenimiento.Mecanico.Nombre;
            emisor.Apellido = Mantenimiento.Mecanico.Apellido;
            emisor.CuitCuil = Mantenimiento.Mecanico.CuitCuil;
            return emisor;
        }

        public override List<LiquidacionDetalle> FacturaDetalles()
        {
            List<LiquidacionDetalle> liquidacionMantenimiento = new List<LiquidacionDetalle>();

            liquidacionMantenimiento.Add(new LiquidacionDetalle(Mantenimiento.Fecha,Mantenimiento.Detalle,1,MontoTotal));

            return liquidacionMantenimiento;
        }

    }
}
