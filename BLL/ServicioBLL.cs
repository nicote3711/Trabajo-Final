using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicioBLL
    {
        private readonly ServicioDAL ServicioDAO = new ServicioDAL();
        public Servicio BuscarServicioPorID(int idServicio)
        {
            return ServicioDAO.BuscarServicioPorId(idServicio);
        }
    }
}
