using DAL.Composite;
using ENTITY.Composite;
using ENTITY.Enum;
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
                throw new Exception("BLL Rol error al obtener todos los roles"+ex.Message, ex);
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
                throw new Exception($"BLL Rol error al buscar el rol con ID {idRol}"+ex.Message, ex);
            }
        }

        public void Alta(Rol rol)
        {
            try
            {
                if (rol == null) throw new ArgumentNullException(nameof(rol), "El rol no puede ser nulo.");
                if(RolDAO.ObtenerTodos().Any(r => r.NombreComponente.Equals(rol.NombreComponente)))throw new InvalidOperationException($"Ya existe un rol con el nombre {rol.NombreComponente}.");  // se puede llevar a metodo en la dal para no obtener todos. 

                
                RolDAO.Alta(rol);
            }
            catch (Exception ex)
            {
                throw new Exception("BLL Rol error al dar de alta el rol"+ex.Message, ex);
            }
        }

        public void Baja(int idRol)
        {
            try
            {
                Rol rol = RolDAO.BuscarPorId(idRol);
                if (rol == null) throw new Exception("no se encontro el rol a eliminar");
                if (rol.IdComponente.Equals((int)EnumRolesPermanentes.Administrador)) throw new Exception("no se puede eliminar el rol admin");
                RolDAO.Baja(idRol);
            }
            catch (Exception ex)
            {
                throw new Exception($"BLL Rol error al dar de baja el rol con ID {idRol}" + ex.Message, ex);
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
                throw new Exception($"BLL rol error al obtener permisos del rol con ID {idRol}" + ex.Message, ex);
            }
        }

        public void AgregarPermisoARol(int idRol, int idPermiso)
        {
            try
            {

                if (RolDAO.ExistePermisoEnRol(idRol, idPermiso)) throw new Exception("el permiso que intenta agregar ya existe en el rol");
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
            catch (Exception ex)
            {

                throw new Exception("BLL Rol error al agregar permiso a rol: " + ex.Message,ex);
            }
        }

        public void QuitarPermisoARol(int IdRol, int IdPermiso)
        {
            try
            {
                if (IdRol.Equals((int)EnumRolesPermanentes.Administrador)) throw new Exception("no se puede quitar permisos del rol admin");
                if (!RolDAO.ExistePermisoEnRol(IdRol,IdPermiso)) throw new Exception("el permiso que intenta quitar no existe en el rol"); // no pincha porque borro de los seleccionados pero no esta demas
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
            catch (Exception ex )
            {
                throw new Exception("BLL Rol error al quitar permiso a rol: " + ex.Message, ex);
            }
        }
    }
}
