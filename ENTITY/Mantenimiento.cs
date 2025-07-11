﻿using System;
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
        public Aeronave Aeronave { get; set; }
        public Mecanico Mecanico { get; set; }

        public FacturaMantenimiento FacturaMantenimientio { get; set; }
        
        public TipoMantenimiento TipoMantenimiento { get; set; } 
        
        public EstadoMantenimiento EstadoMantenimiento{ get; set; }
    }
}
