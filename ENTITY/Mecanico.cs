using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Mecanico : Persona
    {
        public int IdMecanico { get; set; }
        public string MatriculaTecnica { get; set; }
        public string DireccionTaller { get; set; }
        public bool Activo { get; set; }
        
        public List<TipoMantenimiento> TiposDeMantenimiento { get; set; } = new List<TipoMantenimiento>();  
    }
}
