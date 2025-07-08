using ENTITY;
using Helper;
using MAPPER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SimuladorDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();
        public List<Simulador> ObtenerTodos()
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Simulador"];
                if (tabla == null) throw new Exception("No se encontró la tabla Simulador.");

                List<Simulador> LSimuladores = new List<Simulador>();

                foreach (DataRow row in ds.Tables["Simulador"].Rows)
                {
                    Simulador simulador = new Simulador();
                    SimuladorMAP.MapearDesdeDB(simulador, row);
                    LSimuladores.Add(simulador);
                }

                return LSimuladores;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL error al obtener simuladores:" +ex.Message,ex);
            }

        }
        public Dictionary<string, int> BuscarSimuladoresFiltroMensual(int Anio)
        {
            Dictionary<string, int> simulacionesFiltradas = new Dictionary<string, int>();
            List<Simulador> simuladores = new List<Simulador>();

            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Simulador"];
                if (tabla == null) throw new Exception("No se encontró la tabla simulador en el archivo XML.");

                var rows = tabla.AsEnumerable().Where(r => Convert.ToDateTime(r["Fecha"]).Year.Equals(Anio)); //filtro los vuelos por Anio
                if (rows == null) throw new Exception("Simulador no encontrado.");

                foreach (var row in rows)
                {
                    Simulador simulador = new Simulador();
                    SimuladorMAP.MapearDesdeDB(simulador, row);
                    simuladores.Add(simulador);
                }
                CultureInfo currentCulture = CultureInfo.CurrentCulture;

                simulacionesFiltradas = simuladores.OrderBy(v => v.Fecha.Month).GroupBy(v => v.Fecha.ToString("MMMM", currentCulture)).ToDictionary(g => g.Key, g => g.Count()); //Agrupo los vuelos por Mes

                return simulacionesFiltradas;

            }
            catch (Exception ex)
            {

                throw new Exception("DAL Simulador error al buscar simuladores mensual: " + ex.Message, ex);
            }
        }

        public Dictionary<string, int> BuscarSimuladoresFiltroSemanal(int Anio, int Mes)
        {
            Dictionary<string, int> simuladoresFiltrados = new Dictionary<string, int>();

            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Simulador"];
                if (tabla == null) throw new Exception("No se encontró la tabla Simuladores en el archivo XML.");

                var rows = tabla.AsEnumerable().Where(r => Convert.ToDateTime(r["Fecha"]).Year.Equals(Anio) && Convert.ToDateTime(r["Fecha"]).Month.Equals(Mes));
                if (rows == null) throw new Exception("Simulador no encontrado.");

                List<Simulador> simuladorSemana1 = new List<Simulador>();
                List<Simulador> simuladorSemana2 = new List<Simulador>();
                List<Simulador> simuladorSemana3 = new List<Simulador>();
                List<Simulador> simuladorSemana4 = new List<Simulador>();

                foreach (var row in rows)
                {
                    Simulador simulador = new Simulador();
                    SimuladorMAP.MapearDesdeDB(simulador, row);
                    int semana = ObtenerSemanaDelMes(simulador.Fecha);
                    switch (semana)
                    {
                        case 1: simuladorSemana1.Add(simulador); break;
                        case 2: simuladorSemana2.Add(simulador); break;
                        case 3: simuladorSemana3.Add(simulador); break;
                        case 4: simuladorSemana4.Add(simulador); break;
                        default: break;
                    }
                }

                simuladoresFiltrados.Add("Semana 1", simuladorSemana1.Count);
                simuladoresFiltrados.Add("Semana 2", simuladorSemana2.Count);
                simuladoresFiltrados.Add("Semana 3", simuladorSemana3.Count);
                simuladoresFiltrados.Add("Semana 4", simuladorSemana4.Count);

                return simuladoresFiltrados;

            }
            catch (Exception ex)
            {

                throw new Exception("DAL Simulador error al buscar simuladores mensual: " + ex.Message, ex);
            }
        }

        public Dictionary<string, int> BuscarSimuladoresFiltroDiario(int Anio, int Mes, int semana)
        {
            Dictionary<string, int> simuladoresFiltrados = new Dictionary<string, int>();
            List<Simulador> simuladores = new List<Simulador>();
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Simulador"];
                if (tabla == null) throw new Exception("No se encontró la tabla Simuladores en el archivo XML.");

                var rows = tabla.AsEnumerable().Where(r => Convert.ToDateTime(r["Fecha"]).Year.Equals(Anio) && Convert.ToDateTime(r["Fecha"]).Month.Equals(Mes));
                if (rows == null) throw new Exception("Simulador no encontrado.");

                foreach (var row in rows)
                {
                    Simulador simulador = new Simulador();
                    SimuladorMAP.MapearDesdeDB(simulador, row);
                    simuladores.Add(simulador);
                }
                CalendarWeekRule weekRule = CalendarWeekRule.FirstFourDayWeek;
                DayOfWeek firstDayOfWeek = DayOfWeek.Sunday;

                simuladores = simuladores.Where(v => ObtenerSemanaDelMes(v.Fecha).Equals(semana)).ToList();
                simuladoresFiltrados = simuladores.GroupBy(v => v.Fecha.ToString("dddd", CultureInfo.CurrentCulture)).ToDictionary(g => g.Key, g => g.Count());
                return simuladoresFiltrados;

            }
            catch (Exception ex)
            {

                throw new Exception("DAL Simuladores error al buscar simulador mensual: " + ex.Message, ex);
            }
        }

        public void RegistrarSimulador(Simulador simulador)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Simulador"];
                if (tabla == null) throw new Exception("No se encontró la tabla Simulador.");

                int nuevoId = HelperD.ObtenerProximoID(tabla, "Id_Simulador");
                simulador.IdSimulador = nuevoId;

                DataRow row = tabla.NewRow();
                SimuladorMAP.MapearHaciaDB(simulador, row);
                tabla.Rows.Add(row);

                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Error al registrar Simulador: " + ex.Message, ex);
            }
        }
        private static int ObtenerSemanaDelMes(DateTime date)
        {
            // Calcula el día del mes
            int diaDelMes = date.Day;

            int semana = (diaDelMes - 1) / 7 + 1;

            // Limitar a las 4 primeras semanas, como solicitaste.
            // Las fechas en la 5ta semana (días 29-31) no cumplirán el filtro si weekOfMonth es 1-4.
            return semana <= 4 ? semana : 0; // Devolvemos 0 para indicar que está fuera de las 4 primeras semanas.
        }

        public Simulador BuscarPorId(int idSimulador)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Simulador"];
                if (tabla == null) throw new Exception("No se encontró la tabla Simulador.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(s => s.Field<int>("Id_Simulador") == idSimulador);
                if (row == null) return null;

                Simulador simulador = new Simulador();
                SimuladorMAP.MapearDesdeDB(simulador, row);
                return simulador;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Error al buscar Simulador por ID: " + ex.Message, ex);
            }
        }

        public void EliminarSimulador(int idSimulador)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Simulador"];
                if (tabla == null) throw new Exception("No se encontró la tabla Simulador.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(s => s.Field<int>("Id_Simulador") == idSimulador);
                if (row == null) throw new Exception("No se encontró el Simulador con el ID especificado.");
                
                row.Delete();
                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
                
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Error al eliminar Simulador: " + ex.Message, ex);
            }
        }

        public void AsignarLiquidacionASimulador(int idSimulador, int? idLiquidacion)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Simulador"];
                if (tabla == null) throw new Exception("No se encontró la tabla Simulador.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(s => s.Field<int>("Id_Simulador") == idSimulador);
                if (row == null) throw new Exception("No se encontró el Simulador con el ID especificado.");
                if(idLiquidacion == null || idLiquidacion <= 0)throw new ArgumentException("El ID de liquidación debe ser un valor positivo.");
                
                row["Id_Liquidacion"] = idLiquidacion;
                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);

            }
            catch (Exception ex)
            {

                throw new Exception("DAL Simulador error al asignar liquidacion: "+ex.Message,ex);
            }
        }

        public List<Simulador> ObtenerSimuladoresPorIdLiquidacion(int idLiquidacionServicio)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Simulador"];
                if (tabla == null) throw new Exception("No se encontró la tabla Simulador.");

                List<DataRow> rows = tabla.AsEnumerable().Where(r => r["Id_Liquidacion"].Equals(idLiquidacionServicio)).ToList(); 
                List<Simulador> LSimuladores = new List<Simulador>();

                foreach (DataRow row in rows)
                {
                    Simulador simulador = new Simulador();
                    SimuladorMAP.MapearDesdeDB(simulador, row);
                    LSimuladores.Add(simulador);
                }

                return LSimuladores;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Simulador error al obtener simuladores por IdLiquidacion: "+ex.Message,ex);
            }
        }
    }
}
