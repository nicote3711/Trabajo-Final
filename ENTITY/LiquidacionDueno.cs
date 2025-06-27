using ENTITY.Enum;
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
            Persona = new Dueno();
        }
        public List<Vuelo> Vuelos { get; set; }

        public override List<LiquidacionDetalle> ObtenerDetalle()
        {
            List<LiquidacionDetalle> liquidacionDetalles = new List<LiquidacionDetalle>();
            decimal tiempoVuelo = 0;
            foreach (Vuelo v in Vuelos)
            {
                tiempoVuelo += v.TV;
            }

            var detalles = new List<string>();

            liquidacionDetalles.Add(new LiquidacionDetalle(Periodo, "Total de horas de Vuelo (" + Vuelos.Count + " vuelos)", tiempoVuelo, this.Servicio.Precio));

            return liquidacionDetalles;
        }
    }
}
