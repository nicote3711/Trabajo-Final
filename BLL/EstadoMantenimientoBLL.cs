using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EstadoMantenimientoBLL
    {
		EstadoMantenimientoDAL EstadoMantenimientoDAO = new EstadoMantenimientoDAL();
        public EstadoMantenimiento BuscarEstadoMantenimientoPorId(int pendiente)
        {
			try
			{
				EstadoMantenimiento estadoMantenimiento = EstadoMantenimientoDAO.BuscarPorId(pendiente);
				if (estadoMantenimiento == null) throw new Exception($"no se encontro el estado mantemiento id {pendiente}");

				return estadoMantenimiento;	

			}
			catch (Exception ex)
			{

				throw new Exception("BLL EstadoMantenimiento error al buscar mantenimiento por id: "+ex.Message,ex);
			}
        }
    }
}
