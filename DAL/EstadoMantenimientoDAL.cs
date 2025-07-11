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
    public class EstadoMantenimientoDAL
    {

        private readonly string rutaXml = HelperD.ObtenerConexionXMl();


        public List<EstadoMantenimiento> ObtenerTodos()
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Estado_Mantenimiento"];
                if (tabla == null) throw new Exception("No se encontró la tabla Estado_Mantenimiento.");

                List<EstadoMantenimiento> LEstadosMantenimiento = new List<EstadoMantenimiento>();
                foreach (DataRow row in tabla.Rows)
                {
                    EstadoMantenimiento estado = new EstadoMantenimiento();
                    EstadoMantenimientoMAP.MapearDesdeDB(estado, row);
                    LEstadosMantenimiento.Add(estado);
                }

                return LEstadosMantenimiento;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL EstadoMantenimiento error al obtener todos los estados: " + ex.Message, ex);
            }
        }

        public EstadoMantenimiento BuscarPorId(int idEstado)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Estado_Mantenimiento"];
                if (tabla == null) throw new Exception("No se encontró la tabla Estado_Mantenimiento.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Id_Estado_Mantenimiento"]).Equals(idEstado));
                if (row == null) return null;

                EstadoMantenimiento estado = new EstadoMantenimiento();
                EstadoMantenimientoMAP.MapearDesdeDB(estado, row);
                return estado;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL EstadoMantenimiento error al buscar por ID: " + ex.Message, ex);
            }
        }

        public EstadoMantenimiento BuscarPorDescripcion(string descripcion)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Estado_Mantenimiento"];
                if (tabla == null) throw new Exception("No se encontró la tabla Estado_Mantenimiento.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => r["Descripcion"].ToString().Equals(descripcion, StringComparison.OrdinalIgnoreCase));
                if (row == null) return null;

                EstadoMantenimiento estado = new EstadoMantenimiento();
                EstadoMantenimientoMAP.MapearDesdeDB(estado, row);
                return estado;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL EstadoMantenimiento error al buscar por descripción: " + ex.Message, ex);
            }
        }
    }
}
