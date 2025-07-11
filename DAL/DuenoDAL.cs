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
    public class DuenoDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();

        public List<Dueno> ObtenerDuenos()
        {
            try
            {
                // if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML de datos.");

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
               // ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaDuenos = ds.Tables["Dueno"];
                var tablaPersonas = ds.Tables["Persona"];

                if (tablaDuenos == null || tablaPersonas == null) throw new Exception("No se encontraron las tablas requeridas en el XML.");

                List<Dueno> lista = new List<Dueno>();

                foreach (DataRow rowDueno in tablaDuenos.Rows)
                {
                    int idPersona = Convert.ToInt32(rowDueno["Id_Persona"]);
                    DataRow rowPersona = tablaPersonas.Select($"Id_Persona = {idPersona}").FirstOrDefault();
                    if (rowPersona == null) continue;

                    Dueno dueno = new Dueno();
                    DuenoMAP.MapearDuenoDesdeDB(dueno, rowDueno);
                    PersonaMap.MapearPesonaDesdeDB(dueno, rowPersona);

                    lista.Add(dueno);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Dueño error al obtener dueños: "+ex.Message,ex);
            }
        }

        public void AltaDueno(Dueno dueno)
        {
            try
            {
                if (dueno == null) throw new ArgumentNullException(nameof(dueno));
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("El archivo XML no fue encontrado.");

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
               // ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaPersonas = ds.Tables["Persona"];
                var tablaDuenos = ds.Tables["Dueno"];

                if (tablaPersonas == null || tablaDuenos == null)throw new Exception("No se encontraron las tablas necesarias en el XML.");

                DataRow personaExistente = tablaPersonas.AsEnumerable().FirstOrDefault(row => row.Field<long>("DNI") == dueno.DNI);

                if (personaExistente != null)
                {
                    // si ya existe una persona con el mismo DNI, asigno su ID al dueño
                    dueno.IDPersona = Convert.ToInt32(personaExistente["Id_Persona"]);
                }
                else
                {
                    int proximoIdPersona = HelperD.ObtenerProximoID(tablaPersonas, "Id_Persona");
                    dueno.IDPersona = proximoIdPersona;
                    DataRow rowPersona = tablaPersonas.NewRow();
                    PersonaMap.MapearPersonaHaciaDB(dueno, rowPersona);
                    tablaPersonas.Rows.Add(rowPersona);
                }

                int proximoIdDueno = HelperD.ObtenerProximoID(tablaDuenos, "Id_Dueno");
                dueno.IdDueno = proximoIdDueno;

                DataRow rowDueno = tablaDuenos.NewRow();
                DuenoMAP.MapearDuenoHaciaDB(dueno, rowDueno);
                tablaDuenos.Rows.Add(rowDueno);

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Dueño error al dar alta dueño: "+ex.Message,ex);
            }
        }

        public Dueno BuscarDuenoPorDNI(long dni)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new Exception("No se encuentra el archivo de datos");

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaPersonas = ds.Tables["Persona"];
                var tablaDuenos = ds.Tables["Dueno"];

                var personaRow = tablaPersonas.AsEnumerable().FirstOrDefault(p => Convert.ToInt64(p["Dni"]) == dni);
                if (personaRow == null) return null;

                int idPersona = Convert.ToInt32(personaRow["Id_Persona"]);
                var duenoRow = tablaDuenos.AsEnumerable().FirstOrDefault(d => Convert.ToInt32(d["Id_Persona"]) == idPersona);
                if (duenoRow == null) return null;

                Dueno dueno = new Dueno();
                DuenoMAP.MapearDuenoDesdeDB(dueno, duenoRow);
                PersonaMap.MapearPesonaDesdeDB(dueno, personaRow);
                return dueno;
            }
            catch (Exception ex) 
            {
                throw new Exception("DAL Dueño error al buscar dueño por dni: "+ex.Message);
            }
        }

        public Dueno BuscarDuenoPorId(int idDueno)
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
               // ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaDuenos = ds.Tables["Dueno"];
                var tablaPersonas = ds.Tables["Persona"];

                var duenoRow = tablaDuenos.AsEnumerable().FirstOrDefault(d => d.Field<int>("Id_Dueno") == idDueno);
                if (duenoRow == null) return null;

                int idPersona = duenoRow.Field<int>("Id_Persona");
                var personaRow = tablaPersonas.AsEnumerable().FirstOrDefault(p => p.Field<int>("Id_Persona") == idPersona);
                if (personaRow == null) return null;

                Dueno dueno = new Dueno();
                DuenoMAP.MapearDuenoDesdeDB(dueno, duenoRow);
                PersonaMap.MapearPesonaDesdeDB(dueno, personaRow);
                return dueno;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Dueño error al buscar dueño por id: "+ex.Message,ex);
            }
        }

        public void ModificarDueno(Dueno dueno)
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                // ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaDuenos = ds.Tables["Dueno"];
                var tablaPersonas = ds.Tables["Persona"];

                var rowPersona = tablaPersonas.Select($"Id_Persona = {dueno.IDPersona}").FirstOrDefault();
                var rowDueno = tablaDuenos.Select($"Id_Dueno = {dueno.IdDueno}").FirstOrDefault();

                if (rowPersona == null || rowDueno == null) throw new Exception("No se encontró el dueño o la persona asociada.");

                PersonaMap.MapearPersonaHaciaDB(dueno, rowPersona);
                DuenoMAP.MapearDuenoHaciaDB(dueno, rowDueno);

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Dueño error al modificar dueño: "+ex.Message,ex);
            }
        }

        public void BajaDueno(int idDueno)
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                // ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaDuenos = ds.Tables["Dueno"];
                var rowDueno = tablaDuenos.AsEnumerable().FirstOrDefault(d => d.Field<int>("Id_Dueno") == idDueno);

                if (rowDueno == null)
                    throw new Exception("No se encontró el dueño a dar de baja.");

                rowDueno["Activo"] = false;

                XmlDataSetHelper.GuardarCambios();
                // ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Dueño error al dar baja dueño: "+ex.Message,ex);
            }
        }

        public void ModificarPersonaExistente(Persona persona)
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tabla = ds.Tables["Persona"];
                var row = tabla.Select($"Id_Persona = {persona.IDPersona}").FirstOrDefault();
                if (row == null) throw new Exception("No se encontró la persona a modificar.");
                PersonaMap.MapearPersonaHaciaDB(persona, row);

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Dueño error al modificar persona existente: "+ex.Message,ex);
            }

        }

        public Dueno BuscarPersonaPorDNI(long dni)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("Archivo XML no encontrado");

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaPersonas = ds.Tables["Persona"];
                var row = tablaPersonas?.AsEnumerable().FirstOrDefault(p => Convert.ToInt64(p["Dni"]) == dni);
                if (row == null) return null;

                Dueno persona = new Dueno();
                PersonaMap.MapearPesonaDesdeDB(persona, row);
                return persona;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Dueño error al buscar persona por dni: "+ex.Message,ex);
            }
           
        }

        public Dueno BuscarDuenoPorIdPersona(int iDPersona)
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaDuenos = ds.Tables["Dueno"];
                var tablaPersonas = ds.Tables["Persona"];

                var personaRow = tablaPersonas.AsEnumerable().FirstOrDefault(p => p.Field<int>("Id_Persona") == iDPersona);
                if (personaRow == null) return null;


                var duenoRow = tablaDuenos.AsEnumerable().FirstOrDefault(d => d.Field<int>("Id_Persona") == iDPersona);
                if (duenoRow == null) return null;

                Dueno dueno = new Dueno();
                DuenoMAP.MapearDuenoDesdeDB(dueno, duenoRow);
                PersonaMap.MapearPesonaDesdeDB(dueno, personaRow);
                return dueno;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Dueno error al buscar dueño por Id Persona:"+ ex.Message, ex);
            }
        }

        public Dueno BuscarDuenoPorCuit(string cuit)
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaDuenos = ds.Tables["Dueno"];
                var tablaPersonas = ds.Tables["Persona"];

                var personaRow = tablaPersonas.AsEnumerable().FirstOrDefault(p => p.Field<string>("Cuit_Cuil") == cuit);
                if (personaRow == null) return null;


                var duenoRow = tablaDuenos.AsEnumerable().FirstOrDefault(d => d.Field<int>("Id_Persona") == personaRow.Field<int>("Id_Persona"));
                if (duenoRow == null) return null;

                Dueno dueno = new Dueno();
                DuenoMAP.MapearDuenoDesdeDB(dueno, duenoRow);
                PersonaMap.MapearPesonaDesdeDB(dueno, personaRow);
                return dueno;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Dueno error al buscar dueño por cuit: " + ex.Message, ex);
            }
        }
    }
}

