using ENTITY;
using Helper;
using MAPPER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL
{
    public class TransaccionFinancieraDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();
        public void RegistrarTransaccion(TransaccionFinanciera transaccionFinanciera)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Transaccion_Financiera"];
                if (tabla == null)throw new Exception("No se encontró la tabla Transaccion_Financiera.");

                transaccionFinanciera.IdTransaccionFinanciera = HelperD.ObtenerProximoID(tabla, "Id_Transaccion_Financiera");

                DataRow row = tabla.NewRow();
                TransaccionFinancieraMAP.MapearHaciaDB(transaccionFinanciera, row);
                tabla.Rows.Add(row);
               
                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception("DAL TransaccionFinanciera error al registrar transacción: " + ex.Message, ex);
            }
        }

        public TransaccionFinanciera BuscarTransaccionPorIdFactura(int idFactura)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Transaccion_Financiera"];
                if (tabla == null) throw new Exception("No se encontró la tabla Transaccion_Financiera.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Id_Factura"]).Equals(idFactura));

                if (row == null) return null;

                TransaccionFinanciera transaccion = new TransaccionFinanciera();
                TransaccionFinancieraMAP.MapearDesdeDB(transaccion, row);
                return transaccion;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL TransaccionFinanciera error al buscar por Id_Factura: " + ex.Message, ex);
            }
        }

        public List<TransaccionFinanciera> ObtenerTodas()
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Transaccion_Financiera"];
                if (tabla == null) throw new Exception("No se encontró la tabla Transaccion_Financiera.");

                List<TransaccionFinanciera> LTransaccionesF = new List<TransaccionFinanciera>();

                foreach(DataRow row in tabla.Rows)
                {
                    TransaccionFinanciera transaccion = new TransaccionFinanciera();
                    TransaccionFinancieraMAP.MapearDesdeDB(transaccion,row);
                    LTransaccionesF.Add(transaccion);
                }

                return LTransaccionesF;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Transaccion Financiera error al obtener todas: "+ex.Message,ex);
            }
        }
    }
}
