using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepositoCombustibleBLL
    {
        DepositoCombustibleDAL DepositoCombustibleDAO = new DepositoCombustibleDAL();   
        public List<DepositoCombustible> ObtenerDepositosCombu()
        {
            try
            {
                return DepositoCombustibleDAO.ObtenerTodos();
            }
            catch (Exception ex)
            {

                throw new Exception("BLL DepositoCombustible error al obtener depositos de combustible: "+ex.Message,ex);
            }
        }

        public DepositoCombustible BuscarDepositoCombuPorId(int idDepositoCombustible)
        {
            try
            {
                DepositoCombustible depositoCombustible = DepositoCombustibleDAO.BuscarPorId(idDepositoCombustible);
                if (depositoCombustible == null) throw new Exception("no se encontro el deposito por id y fue nulo");

                return depositoCombustible; 
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Depositov combustible error al buscar deposito por Id: "+ex.Message,ex);
            }
        }
    }
}
