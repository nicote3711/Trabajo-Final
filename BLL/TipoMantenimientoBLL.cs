using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TipoMantenimientoBLL
    {
		TipoMantenimientoDAL TipoMantenimientoDAO = new TipoMantenimientoDAL();
        public List<TipoMantenimiento> ObtenerTiposMantenimiento()
        {
			try
			{
				return TipoMantenimientoDAO.ObtenerTipos();
            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
