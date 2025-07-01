using DAL;
using ENTITY;
using ENTITY.Enum;
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

        public TipoMantenimiento BuscarTipoMantenimientoPorId(int IdMantenimiento)
        {
			try
			{
				TipoMantenimiento tipoBuscado = TipoMantenimientoDAO.BuscarPorId(IdMantenimiento);
				if(tipoBuscado == null)	throw new Exception($"no se encontro el mantenimiento id {IdMantenimiento}");

				return tipoBuscado;
			}
			catch (Exception ex)
			{

				throw new Exception("BLL TipoMantenimiento error al buscar el mantenimiento por Id: "+ex.Message,ex);
			}
        }
    }
}
