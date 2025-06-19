using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Cliente :Persona
    {
        public int IDCliente { get; set; }
        public decimal SaldoHorasVuelo { get; set; }
        public decimal SaldoHorasSimulador { get; set; }
        public string Licencia { get; set; } 
        public bool Activo { get; set; }
      
    }
}
