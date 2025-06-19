using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class TipoTransaccion
    {
        public int IdTipoTransaccion { get; set; }
        public string Descripcion { get; set; } // Ej: "Pago Instructor, Pago Dueño, Cobro Solictud, Pago Mantenimiento o Mecanico, Pago Combustible"

    }
}
