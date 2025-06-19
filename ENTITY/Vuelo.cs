using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Vuelo
    {
        public int IdVuelo { get; set; }
        public DateTime Fecha{ get; set; }
        public Instructor? Instructor { get; set; }
        public Cliente Cliente { get; set; }
        public Aeronave Aeronave { get; set; }
        public Finalidad Finalidad { get; set; }
        public TimeOnly HoraPM { get; set; }
        public TimeOnly HoraCorte { get; set; }
        public decimal TV => CalculateTv();

        public decimal HubInicial { get; set; }

        public decimal HubFinal { get; set; }

        public decimal HubDiff => HubFinal - HubInicial;

        public bool Liquidado { get; set; }

        public string Origen { get; set; }
        public string Destino { get; set; }


        private decimal CalculateTv()
        {
            // Calcular la diferencia de tiempo considerando la posibilidad de cambio de día
            var horaCorteTimeSpan = HoraCorte.ToTimeSpan();
            var horaPmTimeSpan = HoraPM.ToTimeSpan();
            var diferenciaMinutos = (horaCorteTimeSpan - horaPmTimeSpan).TotalMinutes;

            if (diferenciaMinutos < 0) // Si la hora de corte es el día siguiente
            {
                diferenciaMinutos += TimeSpan.FromDays(1).TotalMinutes;
            }

            var horasCompletas = (int)diferenciaMinutos / 60;
            var minutosResiduales = (int)diferenciaMinutos % 60;

            var ajuste = minutosResiduales switch
            {
                <= 2 => 0m,
                <= 8 => 0.1m,
                <= 14 => 0.2m,
                <= 20 => 0.3m,
                <= 26 => 0.4m,
                <= 33 => 0.5m,
                <= 39 => 0.6m,
                <= 45 => 0.7m,
                <= 51 => 0.8m,
                <= 57 => 0.9m,
                _ => 1m
            };

            return horasCompletas + ajuste;
        }

    }
}
