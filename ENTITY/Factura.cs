using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ENTITY
{
    public abstract class Factura
    {
        public int IdFactura { get; set; }
        public int NroFactura { get; set; }

        public string CuilEmisor { get; set; }  
        public DateTime FechaFactura { get; set; }
        public decimal MontoTotal { get; set; }
        public string Detalle { get; set; } // definir que quiero mostrar tal vez hacer un metodo como con 
        public TipoFactura TipoFactura { get; set; }
        // public int IdTipoFactura { get; set; } // FK a TipoFactura no lo necesito porque tengo la clase TipoFactura como propiedad.
        public TransaccionFinanciera? Transaccion { get; set; } // null hasta que se registre
       
        

       
    }
}
