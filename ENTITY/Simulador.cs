using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Simulador
    {
        public int IdSimulador { get; set; }
        public DateTime Fecha { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
        public decimal TS => CalculateTs();
        public Instructor Instructor { get; set; } // no puede ser null
        public Cliente Cliente { get; set; }
        public LiquidacionServicio? Liquidacion { get; set; } // FK a la Liquidación que lo contiene



        private decimal CalculateTs()
        {
            // Calcular la diferencia de tiempo considerando la posibilidad de cambio de día
            var horaCorteTimeSpan = HoraInicio.ToTimeSpan();
            var horaPmTimeSpan = HoraFin.ToTimeSpan();
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
