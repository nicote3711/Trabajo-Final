using ENTITY;
using Helper;
using MAPPER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FormaPagoDAL
    {
        private string rutaXml = HelperD.ObtenerConexionXMl();


        public List<FormaPago> ObtenerTodos()
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Forma_Pago"];
                if (tabla == null) throw new Exception("No se encontró la tabla Forma_Pago.");

                List<FormaPago> LFormasPago = new List<FormaPago>();
                foreach (DataRow row in tabla.Rows)
                {
                    FormaPago formaPago = new FormaPago();
                    FormaPagoMAP.MapearDesdeDB(formaPago, row);
                    LFormasPago.Add(formaPago);
                }

                return LFormasPago;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL FormaPago error al obtener todos: " + ex.Message, ex);
            }
        }
    

        public FormaPago BuscarPorId(int IdFormaPago)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Forma_Pago"];
                if (tabla == null) throw new Exception("No se encontró la tabla Forma_Pago.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(fp => fp["Id_Forma_Pago"].Equals(IdFormaPago));
                if (row == null) return null;

                FormaPago formaPago = new FormaPago();
                FormaPagoMAP.MapearDesdeDB(formaPago, row);

                return formaPago;

            }
            catch (Exception ex)
            {

                throw new Exception("DAL FormaPago error al buscar pago por id: " + ex.Message, ex);
            }
        }
    }
}

