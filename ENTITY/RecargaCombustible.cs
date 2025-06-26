using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class RecargaCombustible
    {
        public int IdRecargaCombustible { get; set; }
        public DateTime Fecha { get; set; }
        public decimal CantidadLitros { get; set; }
        public decimal PrecioLitros { get; set; }


        public DepositoCombustible DepositoCombu { get; set; }
        public ProveedorCombustible ProveedorCombu { get; set; }
        public FacturaCombustible FacturaCombu { get; set; }
    }
}
