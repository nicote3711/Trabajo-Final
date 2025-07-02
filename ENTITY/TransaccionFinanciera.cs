using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class TransaccionFinanciera
    {
        public int IdTransaccionFinanciera { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public decimal MontoTransaccion { get; set; }
        public TipoTransaccion TipoTransaccion { get; set; }
        public FormaPago FormaPago { get; set; }

        public int? ReferenciaExterna { get; set; }
        public int IdFactura { get; set; } // como factura es abastracta y no la voy a poder instaciar primero me traigo id Id hasta saber el tipo 
        public Factura Factura { get; set; } // Dependencia obligatoria, ya que es una composicion de factura con Transaccion Financiera, esta no existe sin la factura.
    }
}
