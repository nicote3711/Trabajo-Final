using ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class LiquidacionInstructor : LiquidacionServicio
    {
        public LiquidacionInstructor()
        {
            Servicio = new Servicio();
            Servicio.IdServicio = (int)EnumServicios.Instructor;
            Vuelos = new List<Vuelo>();
            Simuladores = new List<Simulador>();
            Persona = new Instructor();
        }

        public List<Vuelo> Vuelos { get; set; } = new();
        public List<Simulador> Simuladores { get; set; } = new();    

        public override List<LiquidacionDetalle> ObtenerDetalle()
        {
            List<LiquidacionDetalle> liquidacionDetalles = new List<LiquidacionDetalle>();

            decimal tiempoVuelo = 0;
            decimal tiempoSimu = 0;
            foreach (Vuelo v in Vuelos)
            {
                tiempoVuelo += v.TV;
            }
            foreach(Simulador s in Simuladores)
            {
                tiempoSimu += s.TS;
            }
            
            liquidacionDetalles.Add(new LiquidacionDetalle(Periodo,"Total de horas de Vuelo (" + Vuelos.Count + " vuelos)", tiempoVuelo, this.Servicio.Precio));
            liquidacionDetalles.Add(new LiquidacionDetalle(Periodo,"Total de horas de Simulador (" + Simuladores.Count + " simuladores)", tiempoSimu, this.Servicio.Precio));

            return liquidacionDetalles;
        }
    }
}
