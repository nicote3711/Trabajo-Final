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
    }
}
