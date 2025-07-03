using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FormaPagoBLL
    {
        FormaPagoDAL FormaPagoDAO= new FormaPagoDAL();   
        public List<FormaPago> ObtenerTodos()
        {
            try
            {
                List<FormaPago> LFormaPagos = FormaPagoDAO.ObtenerTodos();

                return LFormaPagos;
            }
            catch (Exception ex)
            {

                throw new Exception("BLL FormaPago error al obtener todos: "+ex.Message,ex);
            }
        }

        public FormaPago BuscarFormaPagoPorId(int IdFormaPago)
        {
            try
            {
                FormaPago  formaPago = FormaPagoDAO.BuscarPorId(IdFormaPago);
                if (formaPago == null) throw new Exception($"no se encontro la forma de pago con id {IdFormaPago}");

                return formaPago;   
            }
            catch (Exception ex)
            {

                throw new Exception("BLL forma pago error al buscar forma pago por id: "+ex.Message,ex);
            }
        }
    }
}
