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
    public class FinalidadDAL
    {
        private readonly string archivoXml = HelperD.ObtenerConexionXMl();

        public List<Finalidad> ObtenerTodos()
        {
            try
            {
                //if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                List<Finalidad> LFinalidad = new List<Finalidad>();
                if (ds.Tables.Contains("Finalidad"))
                {
                    foreach (DataRow row in ds.Tables["Finalidad"].Rows)
                    {
                        Finalidad finalidad = new Finalidad();
                        FinalidadMAP.MapearDesdeDB(finalidad, row);
                        LFinalidad.Add(finalidad);
                    }
                }
                return LFinalidad;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public Finalidad ObtenerPorId(int id)
        {
            try
            {
                //if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Finalidad"];
                if (tabla == null)throw new Exception("No se encontró la tabla Finalidad en el XML.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => r.Field<int>("Id_Finalidad") == id);
                if (row == null) return null;
                Finalidad finalidad = new Finalidad();
                FinalidadMAP.MapearDesdeDB(finalidad, row);
                return finalidad;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public Finalidad ObtenerPorDescripcion(string descripcion)
        {
            try
            {
                //if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Finalidad"];
                if (tabla == null) throw new Exception("No se encontró la tabla Finalidad en el XML.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => string.Equals(r.Field<string>("Descripcion"),descripcion,StringComparison.OrdinalIgnoreCase));
                if (row == null) return null;

                Finalidad finalidad = new Finalidad();
                FinalidadMAP.MapearDesdeDB(finalidad, row);
                return finalidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
