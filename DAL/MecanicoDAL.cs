using ENTITY;
using Helper;
using MAPPER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MecanicoDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();
        private readonly TipoMantenimientoDAL tipoDAL = new TipoMantenimientoDAL();

        public List<Mecanico> ObtenerMecanicos()
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaMecanicos = ds.Tables["Mecanico"];
                var tablaPersonas = ds.Tables["Persona"];
                var tablaMantenimientoMecanico = ds.Tables["Tipo_Mantenimiento_Mecanico"];

                if (tablaMecanicos == null || tablaPersonas == null || tablaMantenimientoMecanico == null) throw new Exception("Faltan tablas en el XML.");

                List<Mecanico> listaMecanicos = new List<Mecanico>();

                foreach (DataRow rowMecanico in tablaMecanicos.Rows)
                {
                    int idPersona = rowMecanico.Field<int>("Id_Persona");
                    DataRow rowPersona = tablaPersonas.AsEnumerable().FirstOrDefault(p => p.Field<int>("Id_Persona") == idPersona);
                    if (rowPersona == null) continue;

                    Mecanico mecanico = new Mecanico();
                    MecanicoMAP.MapearMecanicoDesdeDB(mecanico, rowMecanico);
                    PersonaMap.MapearPesonaDesdeDB(mecanico, rowPersona);

                    // Cargar sus tipos de mantenimiento (desde tabla intermedia)
                    IEnumerable<DataRow> RelacionesTipoMantenimiento = tablaMantenimientoMecanico.AsEnumerable().Where(rel => rel.Field<int>("Id_Mecanico") == mecanico.IdMecanico);

                    foreach (DataRow rel in RelacionesTipoMantenimiento)
                    {
                        int idTipo = rel.Field<int>("Id_Tipo_Mantenimiento");
                        TipoMantenimiento tipo = tipoDAL.BuscarPorId(idTipo);
                        if (tipo != null) mecanico.TiposDeMantenimiento.Add(tipo);
                    }

                    listaMecanicos.Add(mecanico);
                }

                return listaMecanicos;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Mecanico error al obtener mecanicos: "+ex.Message,ex);
            }
        
        }

        public void AltaMecanico(Mecanico mecanico)
        {
            try
            {
                if (mecanico == null) throw new ArgumentNullException(nameof(mecanico));

                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("El archivo XML no fue encontrado.");
                DataSet ds =XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaPersonas = ds.Tables["Persona"];
                DataTable tablaMecanicos = ds.Tables["Mecanico"];
                DataTable tablaRelaciones = ds.Tables["Tipo_Mantenimiento_Mecanico"];

                if (tablaPersonas == null || tablaMecanicos == null || tablaRelaciones == null) throw new Exception("No se encontraron las tablas requeridas en el XML.");

                // Buscar persona por DNI
                DataRow rowPersonaExistente = tablaPersonas.AsEnumerable().FirstOrDefault(p => p.Field<long>("Dni") == mecanico.DNI);

                if (rowPersonaExistente != null)
                {
                    mecanico.IDPersona = rowPersonaExistente.Field<int>("Id_Persona");
                }
                else
                {
                    int nuevoIdPersona = HelperD.ObtenerProximoID(tablaPersonas, "Id_Persona");
                    mecanico.IDPersona = nuevoIdPersona;
                    DataRow nuevaPersona = tablaPersonas.NewRow();
                    PersonaMap.MapearPersonaHaciaDB(mecanico, nuevaPersona);
                    tablaPersonas.Rows.Add(nuevaPersona);
                }

                // ID de mecánico
                int nuevoIdMecanico = HelperD.ObtenerProximoID(tablaMecanicos, "Id_Mecanico");
                mecanico.IdMecanico = nuevoIdMecanico;

                DataRow rowMecanico = tablaMecanicos.NewRow();
                MecanicoMAP.MapearMecanicoHaciaDB(mecanico, rowMecanico);
                tablaMecanicos.Rows.Add(rowMecanico);

                // Cargar relaciones M:N con tipos de mantenimiento
                foreach (TipoMantenimiento tipo in mecanico.TiposDeMantenimiento)
                {
                   Dictionary<string, object> condiciones = new Dictionary<string, object>
                    {
                        { "Id_Tipo_Mantenimiento", tipo.IdTipoMantenimiento },
                        {"Id_Mecanico", mecanico.IdMecanico }
                    };
                    if(HelperD.ExisteRelacion(tablaRelaciones, condiciones)) throw new Exception("Ya existe una relacion entre ese mecanico y este matenimiento"); // Evitar duplicados

                    DataRow rowRelacion = tablaRelaciones.NewRow();

                    rowRelacion["Id_Mecanico"] = mecanico.IdMecanico;
                    rowRelacion["Id_Tipo_Mantenimiento"] = tipo.IdTipoMantenimiento;
                    tablaRelaciones.Rows.Add(rowRelacion);
                }

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Mecanico error al dar alta: "+ex.Message,ex);
            }

        }

        public Mecanico BuscarPersonaPorDNI(long dNI)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("Archivo XML no encontrado.");

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaPersonas = ds.Tables["Persona"];
                if (tablaPersonas == null) throw new Exception("No se encontró la tabla Persona.");
                var row = tablaPersonas.AsEnumerable().FirstOrDefault(p => p.Field<long>("Dni") == dNI);
                if (row == null) return null;

                Mecanico mecanico = new Mecanico();
                PersonaMap.MapearPesonaDesdeDB(mecanico, row);
                return mecanico;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Mecanico error al buscar persona por Dni: "+ex.Message,ex);
            }
          
        }

        public void ModificarPersonaExistente(Mecanico mecanico)
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tabla = ds.Tables["Persona"];
                var row = tabla.Select($"Id_Persona = {mecanico.IDPersona}").FirstOrDefault();
                if (row == null) throw new Exception("No se encontró la persona a modificar.");

                PersonaMap.MapearPersonaHaciaDB(mecanico, row);

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Mecanico error al modificar persona existente: "+ex.Message,ex);
            }
          
        }

        public Mecanico BuscarMecanicoPorDNI(long dNI)
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaPersonas = ds.Tables["Persona"];
                var tablaMecanicos = ds.Tables["Mecanico"];

                var rowPersona = tablaPersonas.AsEnumerable().FirstOrDefault(p => p.Field<long>("Dni") == dNI);
                if (rowPersona == null) return null;

                int idPersona = rowPersona.Field<int>("Id_Persona");
                var rowMecanico = tablaMecanicos.AsEnumerable().FirstOrDefault(m => m.Field<int>("Id_Persona") == idPersona);
                if (rowMecanico == null) return null;


                Mecanico mecanico = new Mecanico();
                MecanicoMAP.MapearMecanicoDesdeDB(mecanico, rowMecanico);
                PersonaMap.MapearPesonaDesdeDB(mecanico, rowPersona);
                return mecanico;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Mecanico error al buscar mecanico por dni: "+ex.Message,ex);
            }
           
        }

        public void ModificarMecanico(Mecanico mecanico)
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaPersonas = ds.Tables["Persona"];
                var tablaMecanicos = ds.Tables["Mecanico"];
                var tablaMantenimientoMecanico = ds.Tables["Tipo_Mantenimiento_Mecanico"];

                var rowPersona = tablaPersonas.Select($"Id_Persona = {mecanico.IDPersona}").FirstOrDefault();
                var rowMecanico = tablaMecanicos.Select($"Id_Mecanico = {mecanico.IdMecanico}").FirstOrDefault();
                if (rowPersona == null || rowMecanico == null) throw new Exception("No se encontró el mecánico o la persona asociada.");

                // Actualizar datos persona y mecánico
                PersonaMap.MapearPersonaHaciaDB(mecanico, rowPersona);
                MecanicoMAP.MapearMecanicoHaciaDB(mecanico, rowMecanico);

                // Eliminar relaciones previas
                List<DataRow> relacionesExistentes = tablaMantenimientoMecanico.AsEnumerable().Where(r => r.Field<int>("Id_Mecanico") == mecanico.IdMecanico).ToList();
                foreach (DataRow rel in relacionesExistentes)
                {
                    tablaMantenimientoMecanico.Rows.Remove(rel);
                }

                // Agregar relaciones nuevas
                foreach (TipoMantenimiento tipo in mecanico.TiposDeMantenimiento)
                {
                    DataRow nuevaRelacion = tablaMantenimientoMecanico.NewRow();
                    nuevaRelacion["Id_Mecanico"] = mecanico.IdMecanico;
                    nuevaRelacion["Id_Tipo_Mantenimiento"] = tipo.IdTipoMantenimiento;
                    tablaMantenimientoMecanico.Rows.Add(nuevaRelacion);
                }

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Mecanico error al modificar mecanico: "+ex.Message,ex);
            }
           
        }

        public Mecanico BuscarMecanicoPorId(int idMecanico)
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaMecanicos = ds.Tables["Mecanico"];
                var tablaPersonas = ds.Tables["Persona"];
                var tablaMantenimientoMecanico = ds.Tables["Tipo_Mantenimiento_Mecanico"];

                var rowMecanico = tablaMecanicos.AsEnumerable().FirstOrDefault(m => m.Field<int>("Id_Mecanico") == idMecanico);
                if (rowMecanico == null) return null;

                int idPersona = rowMecanico.Field<int>("Id_Persona");
                var rowPersona = tablaPersonas.AsEnumerable().FirstOrDefault(p => p.Field<int>("Id_Persona") == idPersona);
                if (rowPersona == null) return null;

                Mecanico mecanico = new Mecanico();
                MecanicoMAP.MapearMecanicoDesdeDB(mecanico, rowMecanico);
                PersonaMap.MapearPesonaDesdeDB(mecanico, rowPersona);

                IEnumerable<DataRow> RelacionesTipoMantenimiento = tablaMantenimientoMecanico.AsEnumerable().Where(rel => rel.Field<int>("Id_Mecanico") == mecanico.IdMecanico);

                foreach (DataRow rel in RelacionesTipoMantenimiento)
                {
                    int idTipo = rel.Field<int>("Id_Tipo_Mantenimiento");
                    TipoMantenimiento tipo = tipoDAL.BuscarPorId(idTipo);
                    if (tipo != null) mecanico.TiposDeMantenimiento.Add(tipo);
                }

                return mecanico;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Mecanico error al buscar Mecanico por Id: "+ex.Message,ex);
            }
         
        }

        public void BajaMecanico(int idMecanico)
        {

            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaMecanicos = ds.Tables["Mecanico"];
                var row = tablaMecanicos.AsEnumerable().FirstOrDefault(m => m.Field<int>("Id_Mecanico") == idMecanico);
                if (row == null) throw new Exception("No se encontró el mecánico a dar de baja.");

                row["Activo"] = false;

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Mecanico error al dar baja mecanico: "+ex.Message,ex);
            }
           
        }
    }
}
