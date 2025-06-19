using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public abstract class Persona
    {
        public int IDPersona { get; set; }  
        public string CuitCuil { get; set; }
        public long DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public string Identificar { get { return $"{DNI} - {Apellido}, {Nombre}"; }  }

        public override string ToString()
        {
            return Identificar;
        }


    }
}
