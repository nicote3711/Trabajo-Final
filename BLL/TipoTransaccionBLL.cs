using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public  class TipoTransaccionBLL
    {
        TipoTransaccionDAL TipoTransaccionDAO = new TipoTransaccionDAL();

        public List<TipoTransaccion> ObtenerTodos() // no se usa de momento
        {
            try
            {
                List<TipoTransaccion> LTipoTransacciones = TipoTransaccionDAO.ObtenerTodos();
                return LTipoTransacciones;
            }
            catch (Exception ex)
            {
                throw new Exception("BLL TipoTransaccion error al obtener todos: " + ex.Message, ex);
            }
        }

        public TipoTransaccion BuscarPorId(int idTipoTransaccion)
        {
            try
            {
               TipoTransaccion tipo = TipoTransaccionDAO.BuscarPorId(idTipoTransaccion);
                if (tipo == null) throw new Exception($"No se encontró el tipo de transacción con ID {idTipoTransaccion}"); // puedo devolver o no el null

                return tipo;
            }
            catch (Exception ex)
            {
                throw new Exception("BLL TipoTransaccion error al buscar por ID: " + ex.Message, ex);
            }
        }
    }
}
