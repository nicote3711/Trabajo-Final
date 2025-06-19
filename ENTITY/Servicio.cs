using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Servicio
    {
        public int IdServicio { get; set; }         // 1: Dueño, 2: Instructor
        public string Descripcion { get; set; }     // Ej: "Instructor" o "Dueño
        public decimal Precio { get; set; }         // Ej: 120000
    }
}
