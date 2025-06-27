using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Mantenimiento
    {
        public int IdMantenimiento { get; set; }
        public DateTime Fecha { get; set; }

        public string Detalle { get; set; }
        Aeronave Aeronave { get; set; }
        Mecanico Mecanico { get; set; }

        FacturaMantenimiento FacturaMantenimientio { get; set; }
        
        TipoMantenimiento TipoMantenimiento { get; set; }   
    }
}
