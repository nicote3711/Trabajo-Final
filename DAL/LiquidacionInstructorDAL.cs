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

        public void AsignarIdFacturaALiquidacion(int idLiquidacionServicio, int? idFactura)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Liquidacion_Servicio"];
                if (tabla == null) throw new Exception("No se encontró la tabla Liquidacion Servicio.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => r["Id_Liquidacion_Servicio"].Equals(idLiquidacionServicio));
                if (row == null) throw new Exception("No se encontro la liquidacion");
                if (idFactura == null) throw new Exception("El id de factura es null");
                row["Id_Factura"] = idFactura.ToString();

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL LiquidacionInstructor error al asignar id factura a liquidacion: "+ex.Message,ex);
            }
        }

        public List<LiquidacionInstructor> BuscarLiquidacionesPorIdFactura(int idFactura)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Liquidacion_Servicio"];
                if (tabla == null) throw new Exception("No se encontró la tabla Liquidacion Servicio.");

                DataTable tablaRelacion = ds.Tables["Liquidacion_Servicio_Vuelo"];
                if (tablaRelacion == null) throw new Exception("No se encontro la tabla de vuelos-liquidaciones");

                List<DataRow> rowsLiquidaciones = tabla.AsEnumerable().Where(r => r["Id_Factura"].Equals(idFactura)).ToList();
                List<LiquidacionInstructor> LLiquidacionInstructor = new List<LiquidacionInstructor>();
                foreach(DataRow row in rowsLiquidaciones)
                {
                    LiquidacionInstructor liquidacionInstructor = new LiquidacionInstructor();
                    LiquidacionServicioMAP.MapearDesdeDB(liquidacionInstructor, row);

                    List<DataRow> rowsVuelos = tablaRelacion.AsEnumerable().Where(r => row["Id_Liquidacion_Servicio"].Equals(liquidacionInstructor.IdLiquidacionServicio)).ToList();
                    liquidacionInstructor.Vuelos = new List<Vuelo>();
                    foreach (DataRow rowVuelo in rowsVuelos)
                    {
                        Vuelo vuelo = new Vuelo() { IdVuelo = Convert.ToInt32(rowVuelo["Id_Vuelo"]) };
                        liquidacionInstructor.Vuelos.Add(vuelo);
                    }

                   


                    LLiquidacionInstructor.Add(liquidacionInstructor);
                }

                return LLiquidacionInstructor;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL LiquidacionInstructor error al buscar liquidaciones por id Factura: "+ex.Message,ex);
            }
        }

        public void GenerarLiquidacionI(LiquidacionInstructor liquidacionI)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

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

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
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
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Liquidacion_Servicio"];
                if (tabla == null) throw new Exception("No se encontró la tabla liquidacion servicio.");

                DataTable tablaRelacion = ds.Tables["Liquidacion_Servicio_Vuelo"];
                if (tablaRelacion == null) throw new Exception("No se encontro la tabla de vuelos-liquidaciones");

                DataTable tablaSimu = ds.Tables["Simulador"];
                if (tablaSimu == null) throw new Exception("No se econtro la tabla de simuladores");

                DataTable tablaVuelos = ds.Tables["Vuelo"];
                if (tablaVuelos == null) throw new Exception("No se encontro la tabla vuelos");
                List<LiquidacionInstructor> ListaLiquidacionesI = new List<LiquidacionInstructor>();
                List<DataRow> rows = tabla.AsEnumerable().Where(r => r.Field<int>("Id_Persona").Equals(idPersona) && r.Field<int>("Id_Servicio").Equals((int)EnumServicios.Instructor)).ToList();

                if (rows.Count == 0) return ListaLiquidacionesI; // Si no hay liquidaciones, retornar lista vacía
                foreach (DataRow row in rows)
                {
                    LiquidacionInstructor liquidacion = new LiquidacionInstructor();
                    LiquidacionServicioMAP.MapearDesdeDB(liquidacion, row);

                    
                    List<DataRow> rowSimus = tablaSimu.AsEnumerable().Where(r => r["Id_Liquidacion"].Equals(liquidacion.IdLiquidacionServicio)).ToList();
                    liquidacion.Simuladores = new List<Simulador>();
                    foreach (DataRow rowSimu in rowSimus)
                    {
                       Simulador simulador = new Simulador();
                       SimuladorMAP.MapearDesdeDB(simulador, rowSimu);
                       liquidacion.Simuladores.Add(simulador);
                    }

                    List<DataRow> rowsVuelos = tablaRelacion.AsEnumerable().Where(r => r["Id_Liquidacion_Servicio"].Equals(liquidacion.IdLiquidacionServicio)).ToList();
                    liquidacion.Vuelos = new List<Vuelo>();
                    foreach(DataRow rowVuelo in rowsVuelos)
                    {
                        DataRow rVuelo = tablaVuelos.AsEnumerable().FirstOrDefault(r => r["Id_Vuelo"].Equals(rowVuelo["Id_Vuelo"]));
                        if (rVuelo == null) throw new Exception("no se encontro un vuelo de la liquidacion");
                        Vuelo vuelo = new Vuelo();  
                        VueloMAP.MapearDesdeDB(vuelo, rVuelo);
                        liquidacion.Vuelos.Add(vuelo);
                    }

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
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

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

        public void QuitarIdFacturaALiquidacion(int idLiquidacionServicio)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Liquidacion_Servicio"];
                if (tabla == null) throw new Exception("No se encontró la tabla Liquidacion Servicio.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => r["Id_Liquidacion_Servicio"].Equals(idLiquidacionServicio));
                if (row == null) throw new Exception("No se encontro la liquidacion");

                row["Id_Factura"] = DBNull.Value;

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL LiquidacionInstructor error al quitar id factura a liquidacion: "+ex.Message,ex);
            }
        }
    }
}
