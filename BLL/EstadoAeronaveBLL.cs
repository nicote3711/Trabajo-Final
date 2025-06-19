using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EstadoAeronaveBLL
    {
        private readonly EstadoAeronaveDAL EstadoAeronaveDAO = new EstadoAeronaveDAL();


        public List<EstadoAeronave> ObtenerTodos()
        {
            try
            {
                return EstadoAeronaveDAO.ObtenerEstadosAeronave();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EstadoAeronave BuscarPorId(int id)
        {
            try
            {
                return EstadoAeronaveDAO.BuscarEstadoPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EstadoAeronave BuscarPorDescripcion(string descripcion)
        {
            try
            {
                List<EstadoAeronave> listEstados = EstadoAeronaveDAO.ObtenerEstadosAeronave();
                return listEstados.FirstOrDefault(e => e.Descripcion.Equals(descripcion, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
