using Helper;
using MAPPER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class ServicioDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();


        public List<Servicio> ObtenerTodos()
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Servicio"];
                if (tabla == null) throw new Exception("No se encontró la tabla Servicio.");

                List<Servicio> LServicios = new List<Servicio>();
                foreach (DataRow row in ds.Tables["Servicio"].Rows)
                {
                    Servicio servicio = new Servicio();
                    ServicioMAP.MapearDesdeDB(servicio, row);
                    LServicios.Add(servicio);
                }
                return LServicios;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Servicio error al obtener servicios: " + ex.Message, ex);
            }
        }
        public Servicio BuscarServicioPorId(int idServicio)
        {

            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Servicio"];
                if (tabla == null) throw new Exception("No se encontró la tabla Simulador.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(s => s.Field<int>("Id_Servicio") == idServicio);
                if (row == null) return null;
                Servicio servicio = new Servicio();
                ServicioMAP.MapearDesdeDB(servicio, row);
                return servicio;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Servicio error al buscar servicio por Id " + ex.Message, ex);

            }
        }
    }
}
