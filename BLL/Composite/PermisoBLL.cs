using DAL.Composite;
using ENTITY.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Composite
{
    public class PermisoBLL
    {
        private PermisoDAL PermisoDAO = new PermisoDAL();

        public List<Componente> ObtenerArbol()
        {
            try
            {
                return PermisoDAO.ObtenerArbolDePermisos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el árbol de permisos", ex);
            }
        }

        public List<Componente> ObtenerTodos()
        {
            try
            {
                return PermisoDAO.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los permisos", ex);
            }
        }

        public List<Componente> ObtenerPermisosHoja()
        {
            try
            {
                List<Componente> permisos = PermisoDAO.ObtenerTodos();
                return permisos.Where(p => p.EsHoja()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los permisos hoja", ex);
            }
        }

        public Componente BuscarPorId(int id)
        {
            try
            {
                return PermisoDAO.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar el permiso con ID {id}", ex);
            }
        }

        internal List<int> ObtenerIdAncestros(int idPermiso)
        {
            try
            {
                return PermisoDAO.ObtenerIdAncestros(idPermiso);
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<int> ObtenerIdDescendientes(int idPermiso)
        {
            try
            {
                List<int> idDescendientes = new List<int>();
                List<Componente> arbol = PermisoDAO.ObtenerArbolDePermisos();
                Componente permiso = arbol.FirstOrDefault(p => p.IdComponente == idPermiso);
                if (permiso ==null) throw new Exception ("No se encontró el permiso con el ID especificado.");
                
                ObtenerDescientesRecursivos(permiso, idDescendientes);

                return idDescendientes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ObtenerDescientesRecursivos(Componente permiso, List<int> idDescendientes)
        {
            try
            {
                foreach(Componente hijo in permiso.ObtenerHijos())
                {
                    idDescendientes.Add(hijo.IdComponente);
                    ObtenerDescientesRecursivos(hijo, idDescendientes);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
