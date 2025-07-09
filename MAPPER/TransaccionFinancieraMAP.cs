using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public class TransaccionFinancieraMAP
    {
        public static void MapearDesdeDB(TransaccionFinanciera transaccion, DataRow row)
        {
            try
            {
                transaccion.IdTransaccionFinanciera = Convert.ToInt32(row["Id_Transaccion_Financiera"]);
                transaccion.FechaTransaccion = DateTime.Parse(row["Fecha_Transaccion"].ToString());
                transaccion.MontoTransaccion = Convert.ToDecimal(row["Monto_Transaccion"]);

                // Cargar solo los IDs para luego resolver en BLL
                transaccion.TipoTransaccion = new TipoTransaccion{IdTipoTransaccion = Convert.ToInt32(row["Id_Tipo_Transaccion"])};

                transaccion.FormaPago = new FormaPago {IdFormaPago = Convert.ToInt32(row["Id_Forma_Pago"])};

                transaccion.ReferenciaExterna = row.IsNull("Referencia_Externa")? null:Convert.ToInt32(row["Referencia_Externa"]);

                transaccion.IdFactura = Convert.ToInt32(row["Id_Factura"]);

            }
            catch (Exception ex )
            {

                throw new Exception("MAP TransaccionFinanciera error: "+ex.Message,ex);
            }
          
        }

        public static void MapearHaciaDB(TransaccionFinanciera transaccion, DataRow row)
        {
            try
            {
                row["Id_Transaccion_Financiera"] = transaccion.IdTransaccionFinanciera;
                row["Fecha_Transaccion"] = transaccion.FechaTransaccion.ToString("dd/MM/yyyy");
                row["Monto_Transaccion"] = transaccion.MontoTransaccion;

                row["Id_Tipo_Transaccion"] = transaccion.TipoTransaccion.IdTipoTransaccion;
                row["Id_Forma_Pago"] = transaccion.FormaPago.IdFormaPago;
                row["Referencia_Externa"] = transaccion.ReferenciaExterna == null ? DBNull.Value : transaccion.ReferenciaExterna;
                row["Id_Factura"] = transaccion.Factura.IdFactura;
            }
            catch (Exception ex)
            {

                throw new Exception("MAP TransaccionFinanciera error: " + ex.Message, ex);
            }
        
        }
    }
}
