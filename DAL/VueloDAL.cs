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
    public class VueloDAL
    {
        private readonly string archivoXml = HelperD.ObtenerConexionXMl();

        public List<Vuelo> ObtenerVuelos()
        {
            try
            {
                if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();

                ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);
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
                if (vuelo == null) throw new ArgumentNullException(nameof(vuelo));

                DataSet ds = new DataSet();
                ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Vuelo"];
                if (tabla == null) throw new Exception("No se encontró la tabla Vuelo en el archivo XML.");

                int nuevoId = HelperD.ObtenerProximoID(tabla, "Id_Vuelo");
                vuelo.IdVuelo = nuevoId;

                DataRow row = tabla.NewRow();
                VueloMAP.MapearHaciaDB(vuelo, row);
                tabla.Rows.Add(row);

                ds.WriteXml(archivoXml, XmlWriteMode.WriteSchema);
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
                DataSet ds = new DataSet();
                ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

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

        public List<Vuelo> BuscarVuelosPorInstructor(int idInstructor)
        {
            try
            {
                List<Vuelo> LVuelos = new List<Vuelo>();
                DataSet ds = new DataSet();
                ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

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

        public List<Vuelo> BuscarVuelosPorAeronave(int idAeronave)
        {
            try
            {
                if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                List<Vuelo> LAeronave = new List<Vuelo>();
                DataSet ds = new DataSet();
                ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

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
                if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Vuelo"];
                if (tabla == null) throw new Exception("No se encontró la tabla Vuelo en el archivo XML."); 

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Id_Vuelo"]) == vuelo.IdVuelo);
                if (row == null) throw new Exception("Vuelo no encontrado.");

                tabla.Rows.Remove(row);
                ds.WriteXml(archivoXml, XmlWriteMode.WriteSchema);
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
                if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

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

        public void LiquidarVuelo(int idVuelo)
        {
            try
            {
                if (!File.Exists(archivoXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Vuelo"];
                if (tabla == null) throw new Exception("No se encontró la tabla Vuelo en el archivo XML.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Id_Vuelo"]) == idVuelo);
                if (row == null) throw new Exception("Vuelo no encontrado.");

                row["Liquidado"]= true; // Marcar el vuelo como liquidado

                ds.WriteXml(archivoXml, XmlWriteMode.WriteSchema);

            }
            catch (Exception ex)
            {

                throw new Exception("DAL Vuelo error al liquidar vuelo: " + ex.Message,ex);
            }
        }
    }
}
