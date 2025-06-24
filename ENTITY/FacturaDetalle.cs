using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class FacturaDetalle
    {
        public List<FacturaDetalleItem> FacturaDetalleItems { get; set; }
        public List<object> ItemsFactura   { get; set; }
        public string TipoItemFactura { get; set; }

        public FacturaDetalle() 
        {
            ItemsFactura = new List<object>();
            FacturaDetalleItems = new List<FacturaDetalleItem>();
        }

        public class FacturaDetalleItem
        {
            public string Cabecera { get; set; }
            public string ItemProperty { get; set; }
        }
    }
}
