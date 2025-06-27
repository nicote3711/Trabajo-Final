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
    public class RecargarCombustibleDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();

       

        public List<RecargaCombustible> ObtenerTodos()
        {
            try
            {
                if (!File.Exists(rutaXml))throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Recarga_Combustible"];
                if (tabla == null)throw new Exception("No se encontró la tabla Recarga_Combustible.");

                List<RecargaCombustible> LRecargaCombustible = new List<RecargaCombustible>();

                foreach (DataRow row in tabla.Rows)
                {
                    RecargaCombustible recarga = new RecargaCombustible();
                    RecargaCombustibleMAP.MapearDesdeDB(recarga, row);

                    LRecargaCombustible.Add(recarga);
                }

                return LRecargaCombustible;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL RecargaCombustible error al obtener todas las recargas: " + ex.Message, ex);
            }
        }

        public void RegistrarRecargaCombu(RecargaCombustible recarga)
        {
            try
            {

                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Recarga_Combustible"];
                if (tabla == null) throw new Exception("No se encontró la tabla Recarga_Combustible.");

                recarga.IdRecargaCombustible = HelperD.ObtenerProximoID(tabla, "Id_Recarga_Combustible");
                DataRow row = tabla.NewRow();
                RecargaCombustibleMAP.MapearHaciaDB(recarga, row);  

                tabla.Rows.Add(row);

                ds.WriteXml(rutaXml,XmlWriteMode.WriteSchema);

            }
            catch (Exception ex)
            {

                throw new Exception("DAL RecargaCombustible error al el registrar la recarga de combustible: " + ex.Message, ex);
            }
        }

        public RecargaCombustible BuscarRecargaCombuPorId(int idRecargaCombustible)
        {

            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Recarga_Combustible"];
                if (tabla == null) throw new Exception("No se encontró la tabla Recarga_Combustible.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(rc=> rc["Id_Recarga_Combustible"].Equals(idRecargaCombustible));
                if (row == null) return null;

                RecargaCombustible recarga = new RecargaCombustible();
                RecargaCombustibleMAP.MapearDesdeDB(recarga, row);
                return recarga; 

            }
            catch (Exception ex)
            {

                throw new Exception("DAL RecargaCombustible error al buscar recarga por Id: " + ex.Message, ex);
            }
        }

        public RecargaCombustible BuscarRecargaCOmbuPorIdFactura(int idFactura)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Recarga_Combustible"];
                if (tabla == null) throw new Exception("No se encontró la tabla Recarga_Combustible.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(rc => rc["Id_Factura"].Equals(idFactura));
                if (row == null) return null;

                RecargaCombustible recarga = new RecargaCombustible();
                RecargaCombustibleMAP.MapearDesdeDB(recarga, row);
                return recarga;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL RecagarCombustible error al buscar recarga por Id Factura: "+ex.Message,ex);
            }
        }

        public void EliminarRecargarPorIdFactura(int idFactura)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Recarga_Combustible"];
                if (tabla == null) throw new Exception("No se encontró la tabla Recarga_Combustible.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(rc => rc["Id_Factura"].Equals(idFactura));
                if (row == null) throw new Exception($"no se encontro una recarga asociada a el id de Factura {idFactura}");

                row.Delete();

                ds.WriteXml(rutaXml,XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL RecargaCombustible error al eliminar recarga por id factura: "+ex.Message,ex);
            }
        }
    }
}
