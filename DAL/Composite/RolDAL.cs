using ENTITY.Composite;
using Helper;
using MAPPER.Composite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Composite
{
    public class RolDAL
    {
        private static string rutaXML = HelperD.ObtenerConexionXMl();

        public List<Rol> ObtenerTodos()       // agrega permisos pero con jerarquia de arbol
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
               // ds.ReadXml(rutaXML, XmlReadMode.ReadSchema);

                DataTable tablaRol = ds.Tables["Rol"];
                List<Rol> LRoles = new List<Rol>();

                foreach (DataRow row in tablaRol.Rows)
                {
                    Rol rol = new Rol();
                    RolMAP.MapearDesdeDB(rol, row);

                    // Cargar permisos del rol
                    DataTable tablaRP = ds.Tables["Rol_Permiso"];
                    DataTable tablaPermiso = ds.Tables["Permiso"];
                    DataTable tablaComposicion = ds.Tables["Permiso_Composicion"];

                    Dictionary<int, Componente> dicPermisos = new Dictionary<int, Componente>();
                    foreach (DataRow pRow in tablaPermiso.Rows)
                    {
                        Componente comp = PermisoMAP.MapearDesdeDB(pRow);
                        dicPermisos[comp.IdComponente] = comp;
                    }

                    // Armar jerarquía
                    foreach (DataRow compRow in tablaComposicion.Rows)
                    {
                        int idPadre = Convert.ToInt32(compRow["Id_Permiso_Padre"]);
                        int idHijo = Convert.ToInt32(compRow["Id_Permiso_Hijo"]);

                        if (dicPermisos.ContainsKey(idPadre) && dicPermisos.ContainsKey(idHijo))
                        {
                            dicPermisos[idPadre].AgregarHijo(dicPermisos[idHijo]);
                        }
                    }

                    // Asignar permisos al rol
                    var relaciones = tablaRP.AsEnumerable().Where(r => Convert.ToInt32(r["Id_Rol"]) == rol.IdComponente);
                    foreach (var rel in relaciones)
                    {
                        int idPermiso = Convert.ToInt32(rel["Id_Permiso"]);
                        if (dicPermisos.ContainsKey(idPermiso))
                        {
                            rol.AgregarHijo(dicPermisos[idPermiso]);
                        }
                    }

                    LRoles.Add(rol);
                }

                return LRoles;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Rol error al obtener todos los roles" + ex.Message, ex);
            }
        }

        public Rol BuscarPorId(int idRol) // agrega permisos planos. sin jerarquia de arbol
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXML, XmlReadMode.ReadSchema);

                DataRow row = ds.Tables["Rol"].AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Id_Rol"]) == idRol);

                if (row == null) return null;

                Rol rol = new Rol();
                RolMAP.MapearDesdeDB(rol, row);

                DataTable tablaRP = ds.Tables["Rol_Permiso"];
                DataTable tablaPermiso = ds.Tables["Permiso"];

                foreach (DataRow rel in tablaRP.AsEnumerable().Where(r => Convert.ToInt32(r["Id_Rol"])==idRol))
                {
                    int idPermiso = Convert.ToInt32(rel["Id_Permiso"]);
                    DataRow permisoRow = tablaPermiso.AsEnumerable().FirstOrDefault(p => Convert.ToInt32(p["Id_Permiso"]) == idPermiso);

                    if (permisoRow != null)
                    {
                        Componente permiso = PermisoMAP.MapearDesdeDB(permisoRow);
                        rol.AgregarHijo(permiso);
                    }
                }

                return rol;
            }
            catch (Exception ex)
            {
                throw new Exception($"DAL Rol error al buscar el rol con ID {idRol}"+ex.Message, ex);
            }
        }

        public void Alta(Rol rol)
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXML, XmlReadMode.ReadSchema);

                DataTable tablaRol = ds.Tables["Rol"];
                DataTable tablaRP = ds.Tables["Rol_Permiso"];

                int nuevoId = HelperD.ObtenerProximoID(tablaRol, "Id_Rol");
                rol.IdComponente = nuevoId;
                // Crear nuevo row
                DataRow row = tablaRol.NewRow();
                RolMAP.MapearHaciaDB(rol, row);
                tablaRol.Rows.Add(row);

                // Agregar relaciones a Rol_Permiso 
                foreach (var permiso in rol.ObtenerHijos())
                {
                    DataRow rel = tablaRP.NewRow();
                    rel["Id_Rol"] = rol.IdComponente;
                    rel["Id_Permiso"] = permiso.IdComponente;
                    tablaRP.Rows.Add(rel);
                }

                XmlDataSetHelper.GuardarCambios();
               // ds.WriteXml(rutaXML, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Rol error al dar de alta el rol"+ex.Message, ex);
            }
        }

        public void Baja(int idRol)
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXML, XmlReadMode.ReadSchema);

                var tablaRol = ds.Tables["Rol"];
                var tablaRP = ds.Tables["Rol_Permiso"];
                var tablaUR = ds.Tables["Usuario_Rol"];

                // Eliminar rol
                DataRow rowRol = tablaRol.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Id_Rol"]) == idRol);
                if (rowRol != null)
                {
                    rowRol.Delete();
                } 
                // Eliminar todas sus relaciones
                var filasRelacion = tablaRP.AsEnumerable().Where(r=> Convert.ToInt32(r["Id_Rol"]) == idRol).ToList() ;
                foreach (DataRow fila in filasRelacion)
                {
                    fila.Delete();
                }
                var filasUR = tablaUR.AsEnumerable().Where(r => Convert.ToInt32(r["Id_Rol"]) == idRol).ToList();
                foreach (DataRow fila in filasUR)
                {
                    fila.Delete();
                }

                XmlDataSetHelper.GuardarCambios();
                //ds.WriteXml(rutaXML, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception($"DAL Rol error al eliminar el rol con ID {idRol}"+ex.Message, ex);
            }
        }

        public void AgregarPermisoALRol(int idRol, int idPermiso)
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXML, XmlReadMode.ReadSchema);

                DataTable tablaRP = ds.Tables["Rol_Permiso"];

                // Verificar que no exista, evito duplicados
                bool yaExiste = tablaRP.AsEnumerable().Any(r => Convert.ToInt32(r["Id_Rol"]) == idRol && Convert.ToInt32(r["Id_Permiso"]) == idPermiso);

                if (!yaExiste)
                {
                    DataRow nueva = tablaRP.NewRow();
                    nueva["Id_Rol"] = idRol;
                    nueva["Id_Permiso"] = idPermiso;
                    tablaRP.Rows.Add(nueva);

                    XmlDataSetHelper.GuardarCambios();
                    // ds.WriteXml(rutaXML, XmlWriteMode.WriteSchema);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"DAL Rol error al agregar el permiso ID {idPermiso} al rol ID {idRol}"+ ex.Message,ex);
            }
        }

        public void QuitarPermiso(int idRol, int idPermiso)
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXML, XmlReadMode.ReadSchema);

                DataTable tablaRP = ds.Tables["Rol_Permiso"];

                DataRow row = tablaRP.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Id_Rol"]) == idRol &&Convert.ToInt32(r["Id_Permiso"]) == idPermiso);
                if (row != null)
                {
                    row.Delete();

                    XmlDataSetHelper.GuardarCambios();
                    //ds.WriteXml(rutaXML, XmlWriteMode.WriteSchema);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"DAL Rol error al quitar el permiso ID {idPermiso} del rol ID {idRol}" + ex.Message, ex);
            }
        }

        public bool ExistePermisoEnRol(int idRol, int idPermiso)
        {
            try
            {
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXML, XmlReadMode.ReadSchema);

                DataTable tablaRP = ds.Tables["Rol_Permiso"];

                
                bool yaExiste = tablaRP.AsEnumerable().Any(r => Convert.ToInt32(r["Id_Rol"]) == idRol && Convert.ToInt32(r["Id_Permiso"]) == idPermiso);

                return yaExiste;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Rol error al ver si existe permiso en rol: "+ex.Message,ex);
            }
        }
    }
}
