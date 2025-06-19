using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Aeronave
    {
        public int IdAeronave { get; set; }
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public decimal Revision100Hs { get; set; }

        public DateTime RevisionAnual { get; set; }

        public EstadoAeronave Estado { get; set; }

        public Dueno? Dueno { get; set; }

        public override string ToString()
        {
            return $"{Matricula} - {Marca} {Modelo}";
        }

    }
}
