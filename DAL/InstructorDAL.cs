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
    public class InstructorDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();

        public List<Instructor> ObtenerInstructores()
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML de datos.");

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaInstructores = ds.Tables["Instructor"];
                var tablaPersonas = ds.Tables["Persona"];

                if (tablaInstructores == null || tablaPersonas == null) throw new Exception("No se encontraron las tablas requeridas en el XML.");

                List<Instructor> lista = new List<Instructor>();

                foreach (DataRow rowInstructor in tablaInstructores.Rows)
                {
                    int idPersona = Convert.ToInt32(rowInstructor["Id_Persona"]);
                    DataRow rowPersona = tablaPersonas.Select($"Id_Persona = {idPersona}").FirstOrDefault();
                    if (rowPersona == null) continue;

                    Instructor instructor = new Instructor();
                    InstructorMAP.MapearInstructorDesdeDB(instructor, rowInstructor);
                    PersonaMap.MapearPesonaDesdeDB(instructor, rowPersona);

                    lista.Add(instructor);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Instructor error al obtener instructores: "+ex.Message,ex) ;
            }
        }

        public void AltaInstructor(Instructor instructor)
        {
            try
            {
                if (instructor == null) throw new ArgumentNullException(nameof(instructor));

                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("El archivo XML no fue encontrado.");
                DataSet ds =XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaPersonas = ds.Tables["Persona"];
                var tablaInstructores = ds.Tables["Instructor"];

                if (tablaPersonas == null || tablaInstructores == null) throw new Exception("No se encontraron las tablas necesarias en el XML.");



                DataRow personaExistente = tablaPersonas.AsEnumerable().FirstOrDefault(row => row.Field<long>("DNI") == instructor.DNI);
                if (personaExistente != null)
                {
                    // Si ya existe una persona con ese DNI, asignamos su ID al instructor
                    instructor.IDPersona = Convert.ToInt32(personaExistente["Id_Persona"]);
                    // PersonaMap.MapearPersonaHaciaDB(instructor, personaExistente); No porque lo hago desde modificar instructor
                    //TO DO: consultarle al usuario si quiere o no actualizar los datos
                }
                else
                {
                    int proximoIdPersona = HelperD.ObtenerProximoID(tablaPersonas, "Id_Persona");
                    instructor.IDPersona = proximoIdPersona;
                    DataRow rowPersona = tablaPersonas.NewRow();
                    PersonaMap.MapearPersonaHaciaDB(instructor, rowPersona);
                    tablaPersonas.Rows.Add(rowPersona);
                    //TO DO : ver de actualizar la licencia del cliente si ya existe.
                }

                int proximoIdInstructor = HelperD.ObtenerProximoID(tablaInstructores, "Id_Instructor");
                instructor.IdInstructor = proximoIdInstructor;
                DataRow rowInstructor = tablaInstructores.NewRow();
                InstructorMAP.MapearInstructorHaciaDB(instructor, rowInstructor);
                tablaInstructores.Rows.Add(rowInstructor);

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Instructor error al dar alta instructor: "+ex.Message,ex);
            }
          
        }

        public Instructor BuscarInstructorPorDNI(long dNI)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new Exception("No se encuentra el archivo de datos");

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaInstructores = ds.Tables["Instructor"];
                var tablaPersonas = ds.Tables["Persona"];

                var personaRow = tablaPersonas.AsEnumerable().FirstOrDefault(row => row.Field<long>("DNI") == dNI);
                if (personaRow == null) return null; // No se encontró la persona con ese DNI
                
                int IdPersona = Convert.ToInt32(personaRow["Id_Persona"]);
                var instructorRow = tablaInstructores.AsEnumerable().FirstOrDefault(row => row.Field<int>("Id_Persona") == IdPersona);
                if (instructorRow == null) return null; // No se encontró el instructor asociado a esa persona    

                Instructor instructor = new Instructor();
                InstructorMAP.MapearInstructorDesdeDB(instructor, instructorRow);
                PersonaMap.MapearPesonaDesdeDB(instructor, personaRow); 
                return instructor;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Instructor error al buscar instructor por dni: "+ex.Message,ex);
            }
        }

        public Instructor BuscarPersonaPorDNI(long dni)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("Archivo XML no encontrado");

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaPersonas = ds.Tables["Persona"];
                var row = tablaPersonas?.AsEnumerable().FirstOrDefault(p => Convert.ToInt64(p["Dni"]) == dni);
                if (row == null) return null;

                Instructor persona = new Instructor();
                PersonaMap.MapearPesonaDesdeDB(persona, row);
                return persona;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Instructor error al buscar persona por dni:" +ex.Message,ex);
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

                throw new Exception("DAL Instructor error al modificar persona existente: "+ex.Message,ex);
            }
           
        }

        public void ModificarInstructor(Instructor instructorAlta)
        {
            try
            {
                if (instructorAlta == null) throw new ArgumentNullException(nameof(instructorAlta));

                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("El archivo XML no fue encontrado.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaInstructores = ds.Tables["Instructor"];
                var tablaPersonas = ds.Tables["Persona"];

                var rowPersona = tablaPersonas.AsEnumerable().FirstOrDefault(p => p.Field<int>("Id_Persona") == instructorAlta.IDPersona);
                var rowInstructor = tablaInstructores.AsEnumerable().FirstOrDefault(i => i.Field<int>("Id_Instructor") == instructorAlta.IdInstructor);

                if (rowPersona ==null) throw new Exception("no se encontró la persona asociada al instructor.");
                if( rowInstructor == null) throw new Exception("No se encontró el instructor a modificar.");    

                PersonaMap.MapearPersonaHaciaDB(instructorAlta, rowPersona);
                InstructorMAP.MapearInstructorHaciaDB(instructorAlta, rowInstructor);

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);

            }
            catch (Exception ex)
            {
                
                throw new Exception("DAL Instructor error al modificar instructor:"+ex.Message,ex);

            }
       
        }

        public Instructor BuscarInstructorPorId(int idInstructorBaja)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encuentra el archivo de datos");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria; 
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaInstructores = ds.Tables["Instructor"];
                var tablaPersonas = ds.Tables["Persona"];

                var instructorRow = tablaInstructores.AsEnumerable().FirstOrDefault(row => row.Field<int>("Id_Instructor") == idInstructorBaja);    
                if (instructorRow == null) return null; // No se encontró el instructor con ese ID
                
                var personaRow = tablaPersonas.AsEnumerable().FirstOrDefault(row => row.Field<int>("Id_Persona") == instructorRow.Field<int>("Id_Persona"));
                if (personaRow == null) return null; // No se encontró la persona asociada al instructor

                Instructor instructor = new Instructor();
                InstructorMAP.MapearInstructorDesdeDB(instructor, instructorRow);
                PersonaMap.MapearPesonaDesdeDB(instructor, personaRow);
                return instructor;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Instructor error al buscar instructor por id: "+ex.Message,ex);
            }
        }

        public void BajaInstructor(int idInstructorBaja)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encuentra el archivo de datos");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaInstructores = ds.Tables["Instructor"];
                var instructorRow = tablaInstructores.AsEnumerable().FirstOrDefault(row => row.Field<int>("Id_Instructor") == idInstructorBaja);
                if (instructorRow == null) throw new Exception("No se encontró el instructor a dar de baja.");

                instructorRow["Activo"] = false; // Marcamos el instructor como inactivo    

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema); // Guardamos los cambios en el XML
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Instructor error al dar baja a instructor: "+ex.Message,ex);
            }
        }

        public Instructor BuscarInstructorPorCuit(string cuilEmisor)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encuentra el archivo de datos");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaInstructores = ds.Tables["Instructor"];
                DataTable tablaPersonas = ds.Tables["Persona"];
                if (tablaPersonas == null || tablaInstructores == null)throw new Exception("Faltan tablas requeridas en el archivo XML.");

                DataRow personaRow = tablaPersonas.AsEnumerable().FirstOrDefault(p => p.Field<string>("Cuit_Cuil") == cuilEmisor);
                if (personaRow == null) return null;


                DataRow instructorRow = tablaInstructores.AsEnumerable().FirstOrDefault(d => d.Field<int>("Id_Persona") == personaRow.Field<int>("Id_Persona"));
                if (instructorRow == null) return null;

                Instructor instructor = new Instructor();
                InstructorMAP.MapearInstructorDesdeDB(instructor, instructorRow);
                PersonaMap.MapearPesonaDesdeDB(instructor, personaRow);
                return instructor;

            }
            catch (Exception ex)
            {

                throw new Exception("DAL Instructor error al buscar instructor por cuit: "+ex.Message,ex);
            }
        }
    }
}
