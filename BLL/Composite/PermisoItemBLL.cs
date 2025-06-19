using DAL.Composite;
using ENTITY.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Composite
{
    public class PermisoItemBLL
    {
        private readonly PermisoItemDAL permisoItemDAO = new PermisoItemDAL();

        public List<PermisoItem> ObtenerTodos()
        {
            try
            {
                return permisoItemDAO.ObtenerPermisosItem();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public PermisoItem BuscarPorId(int id)
        {
            try
            {
                return permisoItemDAO.BuscarPermisoItemPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PermisoItem BuscarPorNombre(string nombre)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre))throw new ArgumentException("El nombre no puede estar vacío.");

                return permisoItemDAO.BuscarPermisoItemPorNombre(nombre);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Alta(PermisoItem item)
        {
            try
            {
                if (item == null)throw new ArgumentNullException(nameof(item));
                if (string.IsNullOrWhiteSpace(item.NombreComponente))throw new ArgumentException("El nombre del permiso item no puede estar vacío.");
                if(permisoItemDAO.BuscarPermisoItemPorNombre(item.NombreComponente) != null)throw new Exception("Ya existe un permiso item con ese nombre.");
                permisoItemDAO.AltaPermisoItem(item);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
