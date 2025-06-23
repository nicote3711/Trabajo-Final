using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class LiquidacionDueno : LiquidacionServicio
    {

        public LiquidacionDueno()
        {
            Servicio = new Servicio();
            Servicio.IdServicio = (int)EnumServicios.Dueño;
            Vuelos = new List<Vuelo>(); 
        }
        public List<Vuelo> Vuelos { get; set; }

        public override List<string> ObtenerDetalle()
        {
            decimal tiempoVuelo = 0;
            foreach (Vuelo v in Vuelos)
            {
                tiempoVuelo += v.TV;
            }
            var detalles = new List<string>();
            detalles.Add($"Vuelos: {Vuelos.Count}");
            detalles.Add($"Tiempo Vuelo: {tiempoVuelo}");
            return detalles;
        }
    }
}
