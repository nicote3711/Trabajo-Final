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
    public class LiquidacionDuenoDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();

        public void AsginarIdFacturaALiquidacion(int idLiquidacionServicio, int? idFactura)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Liquidacion_Servicio"];
                if (tabla == null) throw new Exception("No se encontró la tabla Liquidacion Servicio.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => r["Id_Liquidacion_Servicio"].Equals(idLiquidacionServicio));
                if (row == null) throw new Exception("No se encontro la liquidacion");
                if (idFactura == null) throw new Exception("El id de factura es null");
                row["Id_Factura"]= idFactura.ToString();                

                ds.WriteXml(rutaXml,XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception ("DAL LiquidacionDueno error al Asginar Id factura a liquidacion: "+ex.Message,ex);
            }
        }

        public List<LiquidacionDueno> BuscarLiquidacionesPorIdFacturacion(int idFactura)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Liquidacion_Servicio"];
                if (tabla == null) throw new Exception("No se encontró la tabla Liquidacion Servicio.");

                List<DataRow> rowsLiquidaciones = tabla.AsEnumerable().Where(r => r["Id_Factura"].Equals(idFactura)).ToList();
                List<LiquidacionDueno> LLiquidacion = new List<LiquidacionDueno>();
                foreach(DataRow row in rowsLiquidaciones)
                {
                    LiquidacionDueno liquidacion = new LiquidacionDueno();
                    LiquidacionServicioMAP.MapearDesdeDB(liquidacion, row);
                    LLiquidacion.Add(liquidacion);  
                }
                return LLiquidacion;    
            }
            catch (Exception ex)
            {

                throw new Exception("DAL LiquidacionesDueño error al buscar Liquidaciones por id factura: "+ex.Message,ex);
            }
        }

        public void GenerarLiquidacionD(LiquidacionDueno liquidacionD)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Liquidacion_Servicio"];
                if (tabla == null) throw new Exception("No se encontró la tabla Simulador.");

                DataTable tablaRelacion = ds.Tables["Liquidacion_Servicio_Vuelo"];
                if (tablaRelacion == null) throw new Exception("No se encontró la tabla Liquidacion_Servicio_Vuelo.");

                int nuevoId = HelperD.ObtenerProximoID(tabla, "Id_Liquidacion_Servicio");
                liquidacionD.IdLiquidacionServicio = nuevoId;
               

                DataRow row = tabla.NewRow();
                LiquidacionServicioMAP.MapearHaciaDB(liquidacionD, row);
                tabla.Rows.Add(row);

                // Escribir tabla puente de vuelo dueño
                foreach (Vuelo vuelo in liquidacionD.Vuelos)
                {
                    DataRow rowRelacion = tablaRelacion.NewRow();
                    rowRelacion["Id_Liquidacion_Servicio"] = liquidacionD.IdLiquidacionServicio;
                    rowRelacion["Id_Vuelo"] = vuelo.IdVuelo;
                    tablaRelacion.Rows.Add(rowRelacion);
                }

                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL LiquidacionDueno error al generar liquidacion dueño: "+ex.Message,ex);
            }
        }

        public List<LiquidacionDueno> ObtenerLiquidacionesDPorIdPersonaDueño(int idPersona)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Liquidacion_Servicio"];
                if (tabla == null) throw new Exception("No se encontró la tabla Simulador.");

                DataTable tablaRelacion = ds.Tables["Liquidacion_Servicio_Vuelo"];
                if (tablaRelacion == null) throw new Exception("No se encontro la tabla de vuelos-liquidaciones");


                List<LiquidacionDueno> ListaLiquidacionesD = new List<LiquidacionDueno>();
                List<DataRow> rows = tabla.AsEnumerable().Where(r => r.Field<int>("Id_Persona").Equals(idPersona) && r.Field<int>("Id_Servicio").Equals((int)EnumServicios.Dueño)).ToList();

                if (rows.Count == 0) return ListaLiquidacionesD; // Si no hay liquidaciones, retornar lista vacía
                foreach (DataRow row in rows)
                {
                    LiquidacionDueno liquidacion = new LiquidacionDueno();
                    LiquidacionServicioMAP.MapearDesdeDB(liquidacion, row);
                    liquidacion.Vuelos = new List<Vuelo>();

                    List<DataRow> rowsVuelos = tablaRelacion.AsEnumerable().Where(rv => rv.Field<int>("Id_Liquidacion_Servicio").Equals(liquidacion.IdLiquidacionServicio)).ToList();
                    if (rowsVuelos.Count <= 0) throw new Exception("La liquidacion no encontro sus vuelos asosciados");
                    foreach(DataRow rowVuelo in rowsVuelos)
                    {
                        Vuelo vuelo = new Vuelo() { IdVuelo = Convert.ToInt32(rowVuelo["Id_Vuelo"]) };
                        liquidacion.Vuelos.Add(vuelo);
                    }

                    ListaLiquidacionesD.Add(liquidacion);

                }
                return ListaLiquidacionesD;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL LiquidacionDueño error al obtener liquidaciones por id Persona Dueño:" + ex.Message, ex);
            }
        }

        public List<LiquidacionDueno> ObtenerLiquidacionesDPorPeriodo(DateTime periodo)
        {
			try
			{
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Liquidacion_Servicio"];
                if (tabla == null) throw new Exception("No se encontró la tabla Simulador.");


                string periodoString = periodo.ToString("MM/yyyy");
                List<LiquidacionDueno> ListaLiquidacionesD = new List<LiquidacionDueno>();
                List<DataRow> rows = tabla.AsEnumerable().Where(r => r.Field<string>("Periodo").Equals(periodoString) && r.Field<int>("Id_Servicio").Equals((int)EnumServicios.Dueño)).ToList();

                if (rows.Count == 0) return ListaLiquidacionesD; // Si no hay liquidaciones, retornar lista vacía
                foreach (DataRow row in rows)
                {
                    LiquidacionDueno liquidacion = new LiquidacionDueno();
                    LiquidacionServicioMAP.MapearDesdeDB(liquidacion, row);
                    ListaLiquidacionesD.Add(liquidacion);
                }
                return ListaLiquidacionesD;

            }
			catch (Exception ex)
			{

				throw new Exception("DAL LiquidacionDueño error al obtener liquidaciones por periodo:"+ ex.Message,ex);
			}
        }

        public void QuitarIdFacturaALiquidacion(int idLiquidacionServicio)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Liquidacion_Servicio"];
                if (tabla == null) throw new Exception("No se encontró la tabla Liquidacion Servicio.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => r["Id_Liquidacion_Servicio"].Equals(idLiquidacionServicio));
                if (row == null) throw new Exception("No se encontro la liquidacion");

                row["Id_Factura"] = DBNull.Value;

                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);

            }
            catch (Exception ex)
            {

                throw new Exception("DAL LiquidacionDueño error al quitar id de factura a liquidacion: "+ex.Message,ex);
            }
        }
    }
}
