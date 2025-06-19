using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Bitacora
{
    public class Bitacora
    {
        public int IdBitacora { get; set; }
        public string Descripcion { get; set; } 
        public DateTime FechaRegistro { get; set; }

        public int  Id_Usuario { get; set; } // Se podria poner Usuario Usuario { get; set; } si se desea relacionar con la entidad Usuario en este caso no se considera necesario.
    }
}
