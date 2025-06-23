using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public abstract class LiquidacionServicio
    {
        public int IdLiquidacionServicio { get; set; }
        public DateTime Periodo { get; set; }
        public decimal CantHoras { get; set; }
        public decimal MontoTotal { get; set; }

        public Servicio Servicio { get; set; } // Contiene Descripcion y Precio 
        public int IdPersona { get; set; } // FK a Persona, puede ser Instructor o Dueño    
        public Persona Persona { get; set; }   // Instructor o Dueño tendra que verificarse en algun lado en la especializacion
        public int? IdFactura { get; set; } // FK opcional, se completa al facturar nose si solo el Id alcanza o necesito el objeto factura

        public abstract List<string> ObtenerDetalle(); // comportamiento específico
    }
}
