using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FinalidadBLL
    {
        private readonly FinalidadDAL FinalidadDAO = new FinalidadDAL();

        public List<Finalidad> ObtenerTodas()
        {
            try
            {
                return FinalidadDAO.ObtenerTodos();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public Finalidad ObtenerPorId(int id)
        {
            try
            {

                return FinalidadDAO.ObtenerPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public Finalidad ObtenerPorDescripcion(string descripcion)
        {
            try
            {
                return FinalidadDAO.ObtenerPorDescripcion(descripcion);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
