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
    public class TipoTransaccionDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();


        public List<TipoTransaccion> ObtenerTodos()
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Tipo_Transaccion"];
                if (tabla == null) throw new Exception("No se encontró la tabla Tipo_Transaccion.");

                List<TipoTransaccion> LTipoTransaccion = new List<TipoTransaccion>();
                foreach (DataRow row in tabla.Rows)
                {
                    TipoTransaccion tipoTransaccion = new TipoTransaccion();
                    TipoTransaccionMAP.MapearDesdeDB(tipoTransaccion, row);
                    LTipoTransaccion.Add(tipoTransaccion);
                }

                return LTipoTransaccion;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL TipoTransaccion error al obtener todos: " + ex.Message, ex);
            }
        }


        public TipoTransaccion BuscarPorId(int IdTipoTransaccion)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Tipo_Transaccion"];
                if (tabla == null) throw new Exception("No se encontró la tabla Tipo_Transaccion.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(tt=> tt["Id_Tipo_Transaccion"].Equals(IdTipoTransaccion));
                if (row == null) return null;

                TipoTransaccion tipoTransaccion = new TipoTransaccion();
                TipoTransaccionMAP.MapearDesdeDB(tipoTransaccion, row);

                return tipoTransaccion;

            }
            catch (Exception ex)
            {

                throw new Exception("DAL TipoTransaccion error al buscar transaccion por id: " + ex.Message, ex);
            }
        }
    }
}
