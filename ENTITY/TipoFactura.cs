using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class TipoFactura
    {
        public int IdTipoFactura { get; set; }
        public string Descripcion { get; set; } // Ej: "Factura Instructor, Factura Dueño, Factura Mantenimiento, Factura Solicitud Horas, Factura Recarga Combustible"
    }
}
