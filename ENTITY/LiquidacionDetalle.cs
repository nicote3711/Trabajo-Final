using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class LiquidacionDetalle
    {
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Valor { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaLiquidacion { get; set; }

        public LiquidacionDetalle(DateTime fecha,string descripcion, decimal cantidad, decimal valor)
        {
            this.FechaLiquidacion = fecha;
            this.Descripcion = descripcion;
            this.Valor = valor;
            this.Cantidad = cantidad;
            this.MontoTotal = valor * cantidad;
        }
    }
}
