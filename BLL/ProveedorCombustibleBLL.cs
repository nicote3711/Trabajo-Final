using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProveedorCombustibleBLL
    {
        ProveedorCombustibleDAL ProveedorCombustibleDAO =new ProveedorCombustibleDAL();



        public List<ProveedorCombustible> ObtenerProveedores()
        {
            try
            {

                return ProveedorCombustibleDAO.ObtenerTodos();
            }
            catch (Exception ex)
            {

                throw new Exception("BLL ProveedorCombustible error al obtener Proveedores: "+ex.Message,ex);
            }
        }

        internal ProveedorCombustible BuscarProveedorPorId(int idProveedorCombustible)
        {
            try
            {
               ProveedorCombustible proveedorCombustible = ProveedorCombustibleDAO.BuscarPorId(idProveedorCombustible);
               if (proveedorCombustible == null) throw new Exception("proveedor no encontrado");

               return proveedorCombustible;
            }
            catch (Exception ex)
            {

                throw new Exception("BLL ProveedorCombustible error al buscar proveedor por id: "+ex.Message,ex);
            }
        }
    }
}
