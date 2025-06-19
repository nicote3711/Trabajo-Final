using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public string NroFactura { get; set; }

        public string CuilEmisor { get; set; }  
        public DateTime FechaFactura { get; set; }
        public decimal MontoTotal { get; set; }
        public string Detalle { get; set; } // definir que quiero mostrar tal vez hacer un metodo como con 
        public TipoFactura TipoFactura { get; set; }
        public TransaccionFinanciera? Transaccion { get; set; } // null hasta que se registre
        // deberia ser abstracta tal vez, y que haya luego una factura por tipo de objeto facturable Solicitud Horas, Liquidacion Instructor, Liquidacion Dueño, Mantenimiento, Recargar Combustible

    }
}
