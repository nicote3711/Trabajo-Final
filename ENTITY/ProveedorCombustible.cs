using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class ProveedorCombustible
    {
        public int IdProveedorCombustible { get; set; }
        public string NombreEmpresa { get; set; }

        public string Cuit { get; set; }

        public string TelefonoContacto { get; set; }

        public string DomicilioFiscal { get; set; }

        public bool Activo { get; set; }

    }
}
