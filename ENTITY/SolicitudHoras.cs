using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class SolicitudHoras
    {
        public int IdSolicitudHoras { get; set; }
      
        public DateTime FechaSolicitud { get; set; } // formato : dd/MM/yyyy    
        public Cliente Cliente { get; set; } // Relación con Cliente
        public decimal CantidadHorasVuelo { get; set; }  // puede ser 0
        public decimal CantidadHorasSimulador { get; set; } // puede ser 0

        public decimal ValorHoraVuelo { get; set; } // Valor por hora de vuelo  
        public decimal ValorHoraSimulador { get; set; } // Valor por hora de simulador

         // public int IdFactura { get; set; } // ID del instructor asignado, puede ser 0 si no se asigna    
        public FacturaSolicitudHoras Factura { get; set; } // Relación con Liquidación de Servicio, puede ser null si no se ha liquidado aún
    }
}
