using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public class FormaPagoMAP
    {
        public static void MapearDesdeDB(FormaPago formaPago, DataRow row)
        {
            try
            {
                formaPago.IdFormaPago = Convert.ToInt32(row["Id_Forma_Pago"]);
                formaPago.Descripcion = row["Descripcion"].ToString();
                formaPago.PorcentajeDescuentoRecargo = Convert.ToDecimal(row["Porcentaje_Descuento_Recargo"]);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public static void MapearHaciaDB(FormaPago formaPago, DataRow row)
        {
            try
            {
                row["Id_Forma_Pago"] = formaPago.IdFormaPago;
                row["Descripcion"] = formaPago.Descripcion;
                row["Porcentaje_Descuento_Recargo"] = formaPago.PorcentajeDescuentoRecargo;
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}
