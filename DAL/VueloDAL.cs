using ENTITY;
using Helper;
using iText.Kernel.Actions.Events;
using MAPPER;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class VueloDAL
    {
        private readonly string archivoXml = HelperD.ObtenerConexionXMl();

        public List<Vuelo> ObtenerVuelos()
        {
            try
            {
                //if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;

                //ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);
                List<Vuelo> listaVuelos = new List<Vuelo>();
                DataTable tabla = ds.Tables["Vuelo"];   
                if (tabla == null) throw new Exception("No se encontró la tabla Vuelo en el archivo XML."); 
                foreach (DataRow r in tabla.Rows)
                {
                    Vuelo vuelo = new Vuelo();
                    VueloMAP.MapearDesdeDB(vuelo, r);
                    listaVuelos.Add(vuelo);
                }

                return listaVuelos;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Error al obtener los vuelos: " + ex.Message, ex);
            }
        }
        public void RegistrarVuelo(Vuelo vuelo)
        {
            try
            {
                //if (vuelo == null) throw new ArgumentNullException(nameof(vuelo));

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Vuelo"];
                if (tabla == null) throw new Exception("No se encontró la tabla Vuelo en el archivo XML.");

                int nuevoId = HelperD.ObtenerProximoID(tabla, "Id_Vuelo");
                vuelo.IdVuelo = nuevoId;

                DataRow row = tabla.NewRow();
                VueloMAP.MapearHaciaDB(vuelo, row);
                tabla.Rows.Add(row);

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(archivoXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception(" DAL Error al registrar el vuelo: " + ex.Message, ex);
            }
        }

        public List<Vuelo> BuscarVuelosPorCliente(int idCliente)
        {
            try
            {
                List<Vuelo> LVuelos = new List<Vuelo>();

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Vuelo"];
                if (tabla == null) throw new Exception("No se encontró la tabla Vuelo en el XML.");

                foreach (DataRow row in tabla.Select($"Id_Cliente = {idCliente}"))
                {
                    Vuelo vuelo = new Vuelo();
                    VueloMAP.MapearDesdeDB(vuelo, row);
                    LVuelos.Add(vuelo);
                }

                return LVuelos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar vuelos por cliente: " + ex.Message, ex);
            }
        }

        public List<Vuelo> BuscarVuelosPorInstructor(int idInstructor) // no se usa de momento
        {
            try
            {
                List<Vuelo> LVuelos = new List<Vuelo>();

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Vuelo"];
                if (tabla == null) throw new Exception("No se encontró la tabla Vuelo en el XML.");

                foreach (DataRow row in tabla.Select($"Id_Instructor = {idInstructor}"))
                {
                    Vuelo vuelo = new Vuelo();
                    VueloMAP.MapearDesdeDB(vuelo, row);
                    LVuelos.Add(vuelo);
                }

                return LVuelos;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Error al buscar vuelos por instructor: " + ex.Message, ex);
            }
        }

        public List<Vuelo> BuscarVuelosPorAeronave(int idAeronave) // no se usa de momento
        {
            try
            {
                List<Vuelo> LAeronave = new List<Vuelo>();

                //if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Vuelo"];
                if (tabla == null) throw new Exception("No se encontró la tabla Vuelo en el XML.");

                foreach (DataRow row in tabla.Select($"Id_Aeronave = {idAeronave}"))
                {
                    Vuelo vuelo = new Vuelo();
                    VueloMAP.MapearDesdeDB(vuelo, row);
                    LAeronave.Add(vuelo);
                }

                return LAeronave;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Error al buscar vuelos por aeronave: " + ex.Message, ex);
            }

        }

        public void EliminarVuelo(Vuelo vuelo)
        {
            try
            {
                //if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Vuelo"];
                if (tabla == null) throw new Exception("No se encontró la tabla Vuelo en el archivo XML."); 

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Id_Vuelo"]) == vuelo.IdVuelo);
                if (row == null) throw new Exception("Vuelo no encontrado.");

                tabla.Rows.Remove(row);

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(archivoXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Error al eliminarVuelo" + ex.Message, ex);
            }
        }

        public Vuelo BuscarVueloPorId(int idVuelo)
        {
            try
            {
                //if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Vuelo"];
                if (tabla == null) throw new Exception("No se encontró la tabla Vuelo en el archivo XML.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Id_Vuelo"]) == idVuelo);
                if (row == null) throw new Exception("Vuelo no encontrado.");

                Vuelo vuelo = new Vuelo();
                VueloMAP.MapearDesdeDB(vuelo, row); 
                return vuelo;

            }
            catch (Exception ex)
            {

                throw new Exception("DAL Vuelo error al buscar vuelo por id: "+ex.Message,ex);
            }
        }

        public Dictionary<string, int> BuscarVuelosFiltroMensual(int Anio)
        {
            Dictionary<string, int> vuelosFiltrados = new Dictionary<string, int>();
            List<Vuelo> vuelos = new List<Vuelo>();

            try
            {
                //if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Vuelo"];
                if (tabla == null) throw new Exception("No se encontró la tabla Vuelo en el archivo XML.");

                var rows = tabla.AsEnumerable().Where(r => Convert.ToDateTime(r["Fecha"]).Year.Equals(Anio) ); //filtro los vuelos por Anio
                if (rows == null) throw new Exception("Vuelo no encontrado.");

                foreach (var row in rows) 
                {
                    Vuelo vuelo = new Vuelo();
                    VueloMAP.MapearDesdeDB(vuelo, row);
                    vuelos.Add(vuelo);
                }
                CultureInfo currentCulture = CultureInfo.CurrentCulture;

                vuelosFiltrados = vuelos.OrderBy(v => v.Fecha.Month).GroupBy(v => v.Fecha.ToString("MMMM", currentCulture)).ToDictionary(g => g.Key, g => g.Count()); //Agrupo los vuelos por Mes

                return vuelosFiltrados;

            }
            catch (Exception ex)
            {

                throw new Exception("DAL Vuelo error al buscar vuelo mensual: " + ex.Message, ex);
            }
        }

        public Dictionary<string, int> BuscarVuelosFiltroSemanal(int Anio, int Mes)
        {
            Dictionary<string, int> vuelosFiltrados = new Dictionary<string, int>();
            List<Vuelo> vuelos = new List<Vuelo>();

            try
            {
                //if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Vuelo"];
                if (tabla == null) throw new Exception("No se encontró la tabla Vuelo en el archivo XML.");

                var rows = tabla.AsEnumerable().Where(r => Convert.ToDateTime(r["Fecha"]).Year.Equals(Anio) && Convert.ToDateTime(r["Fecha"]).Month.Equals(Mes));
                if (rows == null) throw new Exception("Vuelo no encontrado.");

                List<Vuelo> vuelosSemana1 = new List<Vuelo>();
                List<Vuelo> vuelosSemana2 = new List<Vuelo>();
                List<Vuelo> vuelosSemana3 = new List<Vuelo>();
                List<Vuelo> vuelosSemana4 = new List<Vuelo>();

                foreach (var row in rows)
                {
                    Vuelo vuelo = new Vuelo();
                    VueloMAP.MapearDesdeDB(vuelo, row);
                    int semana = ObtenerSemanaDelMes(vuelo.Fecha);
                    switch (semana)
                    {
                        case 1: vuelosSemana1.Add(vuelo); break;
                        case 2: vuelosSemana2.Add(vuelo); break;
                        case 3: vuelosSemana3.Add(vuelo); break;
                        case 4: vuelosSemana4.Add(vuelo); break;
                        default: break;
                    }
                }

                vuelosFiltrados.Add("Semana 1", vuelosSemana1.Count);
                vuelosFiltrados.Add("Semana 2", vuelosSemana2.Count);
                vuelosFiltrados.Add("Semana 3", vuelosSemana3.Count);
                vuelosFiltrados.Add("Semana 4", vuelosSemana4.Count);

                return vuelosFiltrados;

            }
            catch (Exception ex)
            {

                throw new Exception("DAL Vuelo error al buscar vuelo mensual: " + ex.Message, ex);
            }
        }

        public Dictionary<string,int> BuscarVuelosFiltroDiario(int Anio, int Mes, int semana)
        {
            Dictionary<string, int> vuelosFiltrados = new Dictionary<string, int>();
            List<Vuelo> vuelos = new List<Vuelo>();
            try
            {
                //if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Vuelo"];
                if (tabla == null) throw new Exception("No se encontró la tabla Vuelo en el archivo XML.");

                var rows = tabla.AsEnumerable().Where(r => Convert.ToDateTime(r["Fecha"]).Year.Equals(Anio) && Convert.ToDateTime(r["Fecha"]).Month.Equals(Mes));
                if (rows == null) throw new Exception("Vuelo no encontrado.");

                foreach (var row in rows)
                {
                    Vuelo vuelo = new Vuelo();
                    VueloMAP.MapearDesdeDB(vuelo, row);
                    vuelos.Add(vuelo);
                }
                CalendarWeekRule weekRule = CalendarWeekRule.FirstFourDayWeek;
                DayOfWeek firstDayOfWeek = DayOfWeek.Sunday;

                vuelos = vuelos.Where(v => ObtenerSemanaDelMes(v.Fecha).Equals(semana)).ToList();
                vuelosFiltrados = vuelos.GroupBy(v => v.Fecha.ToString("dddd", CultureInfo.CurrentCulture)).ToDictionary(g => g.Key, g => g.Count());
                return vuelosFiltrados;

            }
            catch (Exception ex)
            {

                throw new Exception("DAL Vuelo error al buscar vuelo mensual: " + ex.Message, ex);
            }
        }

        private static int ObtenerSemanaDelMes(DateTime date)
        {
            try
            {
                // Calcula el día del mes
                int diaDelMes = date.Day;

                int semana = (diaDelMes - 1) / 7 + 1;
          
                // Las fechas en la 5ta semana (días 29-31) no cumplirán el filtro si weekOfMonth es 1-4.
                return semana <= 4 ? semana : 0; // Devuelvo 0 para indicar que está fuera de las 4 primeras semanas.
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Vuelo error al obtener semana del mes");
            }
  
        }

        public void LiquidarVuelo(int idVuelo)
        {
            try
            {
                //if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Vuelo"];
                if (tabla == null) throw new Exception("No se encontró la tabla Vuelo en el archivo XML.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Id_Vuelo"]) == idVuelo);
                if (row == null) throw new Exception("Vuelo no encontrado.");

                row["Liquidado"]= true; // Marcar el vuelo como liquidado

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(archivoXml, XmlWriteMode.WriteSchema);

            }
            catch (Exception ex)
            {

                throw new Exception("DAL Vuelo error al liquidar vuelo: " + ex.Message,ex);
            }
        }

        public List<Vuelo> BuscarVuelosEnFecha(DateTime fecha)
        {
            try
            {
                //if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Vuelo"];
                if (tabla == null) throw new Exception("No se encontró la tabla Vuelo en el archivo XML.");

                List<Vuelo> LVuelosEnFecha = new List<Vuelo>();

                foreach (DataRow row in tabla.Rows)
                {
                    DateTime fechaVuelo = Convert.ToDateTime(row["Fecha"]);

                    if (fechaVuelo.Date == fecha.Date) // Comparación solo por fecha, sin hora
                    {
                        Vuelo vuelo = new Vuelo();
                        VueloMAP.MapearDesdeDB(vuelo, row);
                        LVuelosEnFecha.Add(vuelo);
                    }
                }

                return LVuelosEnFecha;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Vuelo error al buscar vuelos en fecha: "+ex.Message,ex);
            }
        }
    }
}
