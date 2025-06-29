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
    public class MantenimientoDAL
    {


        private readonly string rutaXml = HelperD.ObtenerConexionXMl();

        public List<Mantenimiento> ObtenerTodos()
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Mantenimiento"];
                if (tabla == null) throw new Exception("No se encontró la tabla Mantenimiento.");

                List<Mantenimiento> listaMantenimientos = new List<Mantenimiento>();
                foreach (DataRow row in tabla.Rows)
                {
                    Mantenimiento mantenimiento = new Mantenimiento();
                    MantenimientoMAP.MapearDesdeDB(mantenimiento, row); 
                    listaMantenimientos.Add(mantenimiento);
                }

                return listaMantenimientos;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Mantenimiento error al obtener todos: " + ex.Message, ex);
            }
        }

        public void AltaMantenimiento(Mantenimiento mantenimiento)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Mantenimiento"];
                if (tabla == null) throw new Exception("No se encontró la tabla Mantenimiento.");

                mantenimiento.IdMantenimiento = HelperD.ObtenerProximoID(tabla, "Id_Mantenimiento");

                DataRow row = tabla.NewRow();
                MantenimientoMAP.MapearHaciaDB(mantenimiento, row);
                tabla.Rows.Add(row);

                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Mantenimiento error al registrar: " + ex.Message, ex);
            }
        }

        public void AsignarMecanico(int idMantenimiento, int idMecanico)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("Archivo XML no encontrado.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Mantenimiento"];
                if (tabla == null) throw new Exception("No se encontró la tabla Mantenimiento.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Id_Mantenimiento"]) == idMantenimiento);

                if (row == null) throw new Exception($"No se encontró mantenimiento con ID {idMantenimiento}.");

                row["Id_Mecanico"] = idMecanico;
                row["Id_Estado_Mantenimiento"] = (int)EnumEstadoMantenimiento.EnMantenimiento; //deberia validarlo antes

                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Mantenimiento error al asignar mecánico: " + ex.Message, ex);
            }
        }
        public void RegistrarMantenimiento(int idMantenimiento, int idFactura)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("Archivo XML no encontrado.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Mantenimiento"];
                if (tabla == null) throw new Exception("No se encontró la tabla Mantenimiento.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Id_Mantenimiento"]) == idMantenimiento);

                if (row == null) throw new Exception($"No se encontró mantenimiento con ID {idMantenimiento}.");

                row["Id_Factura"] = idFactura;
                row["Id_Estado_Mantenimiento"] = (int)EnumEstadoMantenimiento.Finalizado; // deberia validarlo antes

                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Mantenimiento error al asignar factura: " + ex.Message, ex);
            }
        }

        public Mantenimiento BuscarPorId(int Id)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Mantenimiento"];
                if (tabla == null) throw new Exception("No se encontró la tabla Mantenimiento.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Id_Mantenimiento"]).Equals(Id));
                if (row == null) return null;

                Mantenimiento mantenimiento = new Mantenimiento();
                MantenimientoMAP.MapearDesdeDB(mantenimiento, row);
                return mantenimiento;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Mantenimiento error al buscar por ID: " + ex.Message, ex);
            }
        }

        public List<Mantenimiento> BuscarMantenimientosPorIdAeronave(int IdAeronave)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Mantenimiento"];
                if (tabla == null) throw new Exception("No se encontró la tabla Mantenimiento.");

                List<DataRow> rows = tabla.AsEnumerable().Where(r => Convert.ToInt32(r["Id_Aeronave"]).Equals(IdAeronave)).ToList();
                List<Mantenimiento> LMantenimientos = new List<Mantenimiento>();

                foreach (DataRow row in rows)
                {
                    Mantenimiento mantenimiento = new Mantenimiento();
                    MantenimientoMAP.MapearDesdeDB(mantenimiento, row);
                    LMantenimientos.Add( mantenimiento );   
                }
                
                return LMantenimientos;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Mantenimiento error al buscar  mantenimientos por Id Aeronave: " + ex.Message, ex);
            }
        }

    }
}
