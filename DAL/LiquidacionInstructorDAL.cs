using ENTITY;
using ENTITY.Enum;
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
    public class LiquidacionInstructorDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();

        public void GenerarLiquidacionI(LiquidacionInstructor liquidacionI)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Liquidacion_Servicio"];
                if (tabla == null) throw new Exception("No se encontró la tabla Simulador.");

                DataTable tablaRelacion =ds.Tables["Liquidacion_Servicio_Vuelo"];
                if (tablaRelacion == null) throw new Exception("No se encontró la tabla Liquidacion_Servicio_Vuelo.");

                int nuevoId = HelperD.ObtenerProximoID(tabla, "Id_Liquidacion_Servicio");
                liquidacionI.IdLiquidacionServicio = nuevoId;
                
                DataRow row = tabla.NewRow();
                LiquidacionServicioMAP.MapearHaciaDB(liquidacionI, row);
                tabla.Rows.Add(row);

                // escribir tabla puente de vuelo instructor
                if(liquidacionI.Vuelos.Count > 0)
                {
                    foreach (Vuelo vuelo in liquidacionI.Vuelos)
                    {
                        DataRow rowRelacion = tablaRelacion.NewRow();
                        rowRelacion["Id_Liquidacion_Servicio"] = liquidacionI.IdLiquidacionServicio;
                        rowRelacion["Id_Vuelo"] = vuelo.IdVuelo;
                        tablaRelacion.Rows.Add(rowRelacion);
                    }
                }


                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL LiquidacionInstructor error al generar la liquidacion: " + ex.Message, ex);
            }
        }

        public List<LiquidacionInstructor> ObtenerLiquidacionesIPorIdPersonaInstructor(int idPersona)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Liquidacion_Servicio"];
                if (tabla == null) throw new Exception("No se encontró la tabla Simulador.");


                List<LiquidacionInstructor> ListaLiquidacionesI = new List<LiquidacionInstructor>();
                List<DataRow> rows = tabla.AsEnumerable().Where(r => r.Field<int>("Id_Persona").Equals(idPersona) && r.Field<int>("Id_Servicio").Equals((int)EnumServicios.Instructor)).ToList();

                if (rows.Count == 0) return ListaLiquidacionesI; // Si no hay liquidaciones, retornar lista vacía
                foreach (DataRow row in rows)
                {
                    LiquidacionInstructor liquidacion = new LiquidacionInstructor();
                    LiquidacionServicioMAP.MapearDesdeDB(liquidacion, row);

                    ListaLiquidacionesI.Add(liquidacion);
                }
              
                return ListaLiquidacionesI;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL LiquidacionDueño error al obtener liquidaciones por id Persona Dueño:" + ex.Message, ex);
            }
        }

        public List<LiquidacionInstructor> ObtenerLiquidacionesIPorPeriodo(DateTime periodo)
        {
			try
			{
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Liquidacion_Servicio"];
                if (tabla == null) throw new Exception("No se encontró la tabla Simulador.");

                List<LiquidacionInstructor> ListaLiquidacionesI = new List<LiquidacionInstructor>();
                string periodoString = periodo.ToString("MM/yyyy");
                List<DataRow> rows = tabla.AsEnumerable().Where(r => r.Field<string>("Periodo").Equals(periodoString) && r.Field<int>("Id_Servicio").Equals((int)EnumServicios.Instructor)).ToList();

                if (rows.Count == 0) return ListaLiquidacionesI; // Si no hay liquidaciones, retornar lista vacía
                foreach (DataRow row in rows)
                {
                    LiquidacionInstructor liquidacion = new LiquidacionInstructor();
                    LiquidacionServicioMAP.MapearDesdeDB(liquidacion, row);
                    ListaLiquidacionesI.Add(liquidacion);
                }

                return ListaLiquidacionesI;

            }
			catch (Exception ex)
			{

				throw new Exception("DAL LiquidacionInstructor error al obtener liquidacionesIPorPeriodo:"+ ex.Message, ex);
			}
        }
    }
}
