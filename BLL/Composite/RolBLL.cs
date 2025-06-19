using DAL.Composite;
using ENTITY.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Composite
{
    public class RolBLL
    {
        private RolDAL RolDAO = new RolDAL();
        private PermisoBLL PermisoBLO = new PermisoBLL();

        public List<Rol> ObtenerTodos()
        {
            try
            {
                return RolDAO.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los roles", ex);
            }
        }

        public Rol BuscarPorId(int idRol)
        {
            try
            {
                return RolDAO.BuscarPorId(idRol);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar el rol con ID {idRol}", ex);
            }
        }

        public void Alta(Rol rol)
        {
            try
            {
                if (rol == null) throw new ArgumentNullException(nameof(rol), "El rol no puede ser nulo.");
                if(RolDAO.ObtenerTodos().Any(r => r.NombreComponente == rol.NombreComponente)) 
                {
                    throw new InvalidOperationException($"Ya existe un rol con el nombre {rol.NombreComponente}.");
                }
                //TODO :esto deberia ser un metodo buscar por Nombre en la Dal. En vez de todos
                RolDAO.Alta(rol);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el rol", ex);
            }
        }

        public void Baja(int idRol)
        {
            try
            {
                RolDAO.Baja(idRol);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al dar de baja el rol con ID {idRol}", ex);
            }
        }

        public void AgregarPermiso(int idRol, int idPermiso)
        {
            try
            {
               
                RolDAO.AgregarPermisoALRol(idRol, idPermiso);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar el permiso ID {idPermiso} al rol ID {idRol}", ex);
            }
        }

        public void QuitarPermiso(int idRol, int idPermiso)
        {
            try
            {
                RolDAO.QuitarPermiso(idRol, idPermiso);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al quitar el permiso ID {idPermiso} del rol ID {idRol}", ex);
            }
        }

        public List<Componente> ObtenerPermisosDeRol(int idRol)
        {
            try
            {
                Rol rol = RolDAO.BuscarPorId(idRol);
                return rol?.ObtenerHijos().ToList() ?? new List<Componente>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener permisos del rol con ID {idRol}", ex);
            }
        }

        public void AgregarPermisoARol(int idRol, int idPermiso)
        {
            try
            {
                List<int> IdAncestros = PermisoBLO.ObtenerIdAncestros(idPermiso);
                if (IdAncestros.Count > 0)
                {
                    foreach (int idAncestro in IdAncestros)
                    {   
                      RolDAO.AgregarPermisoALRol(idRol, idAncestro); // Agrega los ancestros si no existen   
                    }
                }
                RolDAO.AgregarPermisoALRol(idRol,idPermiso);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void QuitarPermisoARol(int IdRol, int IdPermiso)
        {
            try
            {
                Componente permiso=PermisoBLO.BuscarPorId(IdPermiso); // Verifica que el permiso exista
                if(permiso==null) throw new ArgumentException($"El permiso con ID {IdPermiso} no existe.");
                             
                if(permiso.EsHoja() == false) // Verifica si el permiso es una hoja
                {
                    List<int> idDescendientes = PermisoBLO.ObtenerIdDescendientes(IdPermiso);
                    if (idDescendientes.Count > 0)
                    {
                        foreach (int idDescendiente in idDescendientes)
                        {
                            RolDAO.QuitarPermiso(IdRol, idDescendiente); // Quita los descendientes si existen
                        }
                    }
                } 

                RolDAO.QuitarPermiso(IdRol, IdPermiso);
            }
            catch (Exception )
            {

                throw;
            }
        }
    }
}
