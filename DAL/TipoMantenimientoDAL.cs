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
    public class TipoMantenimientoDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();

        public List<TipoMantenimiento> ObtenerTipos()
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("Archivo XML no encontrado.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Tipo_Mantenimiento"];
                if (tabla == null) throw new Exception("No se encontró la tabla Tipo_Mantenimiento.");

                List<TipoMantenimiento> listaTipoMantenimiento = new List<TipoMantenimiento>();
                foreach (DataRow row in tabla.Rows)
                {
                    TipoMantenimiento tipo = new TipoMantenimiento();
                    TipoMantenimientoMAP.MapearTipoMantenimientoDesdeDB(tipo, row);
                    listaTipoMantenimiento.Add(tipo);
                }

                return listaTipoMantenimiento;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL TipoMantenimiento error al obtener tipos: " + ex.Message, ex);
            }

        }

        public TipoMantenimiento BuscarPorId(int id)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("Archivo XML no encontrado.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Tipo_Mantenimiento"];
                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => r.Field<int>("Id_Tipo_Mantenimiento").Equals(id));
                if (row == null) return null;

                TipoMantenimiento tipoMantenimiento = new TipoMantenimiento();
                TipoMantenimientoMAP.MapearTipoMantenimientoDesdeDB(tipoMantenimiento, row);
                return tipoMantenimiento;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL TipoMantenimiento error al buscar por ID: " + ex.Message, ex);
            }
         
        }
    }
}
