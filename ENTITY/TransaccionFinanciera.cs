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
        public Factura Factura { get; set; } // Dependencia obligatoria, ya que es una composicion de factura con Transaccion Financiera, esta no existe sin la factura.
    }
}
