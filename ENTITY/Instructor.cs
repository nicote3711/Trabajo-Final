using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Instructor : Persona
    {
        public int IdInstructor { get; set; }
        public string Licencia { get; set; }
        public bool Activo { get; set; }
        
    }
}
