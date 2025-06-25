using Helper;
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

        public override List<string> ObtenerDetalle()
        {
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
            
            var detalles = new List<string>();
            detalles.Add($"Vuelos: {Vuelos.Count}");
            detalles.Add($"Tiempo Vuelo: {tiempoVuelo}");
            detalles.Add($"Simuladores: {Simuladores.Count}");
            detalles.Add($"Tiempo Simulador: {tiempoSimu}");

            return detalles;
        }
    }
}
