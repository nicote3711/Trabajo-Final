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
    public class SolicitudHorasDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();


        public List<SolicitudHoras> ObtenerSolicitudesHoras()
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaSolicitudes = ds.Tables["Solicitud_Horas"];
                if (tablaSolicitudes == null) throw new Exception("No se encontró la tabla Solicitud_Horas.");

                List<SolicitudHoras> LSolicitudes = new List<SolicitudHoras>();
                foreach (DataRow row in tablaSolicitudes.Rows)
                {
                    SolicitudHoras solicitud = new SolicitudHoras();
                    SolicitudHorasMAP.MapearDesdeDB(solicitud, row);
                    LSolicitudes.Add(solicitud);
                }
                return LSolicitudes;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL error al obtener solicitudes de horas: " + ex.Message, ex);
            }
        }   

        public void EliminarSolicitudHorasPorId(int idSolicitudHoras)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaSolicitudes = ds.Tables["Solicitud_Horas"];
                if (tablaSolicitudes == null) throw new Exception("No se encontró la tabla Solicitud_Horas.");
                
                DataRow row = tablaSolicitudes.AsEnumerable().FirstOrDefault(s => s.Field<int>("Id_Solicitud_Horas") == idSolicitudHoras);   
                if(row == null) throw new Exception($"No se encontró la solicitud de horas con ID {idSolicitudHoras}.");

                row.Delete();

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema); 

            }
            catch (Exception ex)
            {
                throw new Exception("DAL Solicitud Horas error al eliminar solicitud de horas: " + ex.Message, ex);
            }
        }
        public void AltaSolicitudHoras(SolicitudHoras solicitud)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaSolicitudes = ds.Tables["Solicitud_Horas"];
                if (tablaSolicitudes == null) throw new Exception("No se encontró la tabla Solicitud_Horas.");

                int nuevoId = HelperD.ObtenerProximoID(tablaSolicitudes, "Id_Solicitud_Horas");
                solicitud.IdSolicitudHoras = nuevoId;

                DataRow row = tablaSolicitudes.NewRow();
                SolicitudHorasMAP.MapearHaciaDB(solicitud, row);
                tablaSolicitudes.Rows.Add(row);

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception("DAL error al registrar solicitud de horas: " + ex.Message, ex);
            }
        }

        public SolicitudHoras BuscarSolicitudPorIdFactura(int idFactura)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaSolicitudes = ds.Tables["Solicitud_Horas"];
                if (tablaSolicitudes == null) throw new Exception("No se encontró la tabla Solicitud_Horas.");

                DataRow row = tablaSolicitudes.AsEnumerable().FirstOrDefault(s => s.Field<int>("Id_Factura") == idFactura);
                if(row == null) return null; // Si no se encuentra la solicitud, retornar null
                SolicitudHoras solicitud = new SolicitudHoras();
                SolicitudHorasMAP.MapearDesdeDB(solicitud, row);    

                return solicitud;

            }
            catch (Exception ex)
            {

                throw new Exception("DAL SolicitudHoras error al buscar la solicitud por id: "+ex.Message,ex);
            }
        }
    }
}
