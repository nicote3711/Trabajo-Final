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
	public class MantenimientoBLL
	{
		MantenimientoDAL MantenimientoDAO = new MantenimientoDAL();
		public void AltaMantenimiento(Mantenimiento mantenimiento)
		{
			try
			{
				ValidarCondicionesAlta(mantenimiento);


				// Dar Alta 
				MantenimientoDAO.AltaMantenimiento(mantenimiento);

			}
			catch (Exception ex)
			{

				throw new Exception("BLL Mantenimiento error al dar alta mantenimiento");
			}
		}

		public void ValidarCondicionesAlta(Mantenimiento mantenimiento)
		{
            //Verificaciones Para alta 
            //Si tiene algun otro mantenimiento no finalizado first or default
            if (mantenimiento.TipoMantenimiento == null || mantenimiento.TipoMantenimiento.IdTipoMantenimiento <= 0) throw new Exception("el tipo de mantenimiento es nulo o su id invalido");
            if (mantenimiento.EstadoMantenimiento == null || mantenimiento.EstadoMantenimiento.IdEstadoMantenimiento <= 0) throw new Exception(" estado del mantenimiento nulo o con id invalido");
            if (mantenimiento.Aeronave == null || mantenimiento.Aeronave.IdAeronave <= 0) throw new Exception("Aeronave del mantenimiento nula o con id invalido");
            if (string.IsNullOrEmpty(mantenimiento.Detalle)) throw new Exception("El mantenimiento debe contener un detalle");
            if (mantenimiento.Fecha.Date > DateTime.Now.Date) throw new Exception("La fecha del mantenimiento al alta no puede ser superior a la fecha del hoy");


            Mantenimiento mantenimientoAux = MantenimientoDAO.BuscarMantenimientosPorIdAeronave(mantenimiento.Aeronave.IdAeronave).FirstOrDefault(m => m.Aeronave.IdAeronave.Equals(mantenimiento.Aeronave.IdAeronave) &&
                                                                                                                                                         m.EstadoMantenimiento.IdEstadoMantenimiento != (int)EnumEstadoMantenimiento.Finalizado);
            //Vale la pena hacer un metodo en DAL( equivalente a una query)? ya puedo sacar el filtrado por Id aeronave ahora que no busco todos 

            if (mantenimientoAux != null) throw new Exception($"La aeronave id {mantenimiento.Aeronave.IdAeronave} ya tiene un mantenimiento pendiente o en curso");

            switch ((EnumTipoMantenimiento)mantenimiento.TipoMantenimiento.IdTipoMantenimiento)
            {
                case EnumTipoMantenimiento.Hs100:
                    if (mantenimiento.Aeronave.Revision100Hs < 100)
                        throw new Exception("No se puede registrar mantenimiento de 100 horas: la aeronave no superó las 100 horas.");
                    break;

                case EnumTipoMantenimiento.Anual:
                    if (mantenimiento.Aeronave.RevisionAnual >= DateTime.Now.Date)
                        throw new Exception("No se puede registrar mantenimiento anual: la fecha de revisión anual aún no está vencida.");
                    break;

                case EnumTipoMantenimiento.Extraordinario:
                    if (mantenimiento.Mecanico == null || mantenimiento.Mecanico.IdMecanico <= 0) throw new Exception("No se puede registrar un mantenimiento extraordinario sin mecanico o con id nulo");
                    if (mantenimiento.Mecanico.TiposDeMantenimiento == null || !mantenimiento.Mecanico.TiposDeMantenimiento.Any(tm => tm.IdTipoMantenimiento.Equals((int)EnumTipoMantenimiento.Extraordinario)))
                        throw new Exception("El mecánico asignado no está autorizado para realizar mantenimientos extraordinarios.");
                        break;

                default:
                    throw new Exception("Tipo de mantenimiento no reconocido.");
            }
        }
	}
}
