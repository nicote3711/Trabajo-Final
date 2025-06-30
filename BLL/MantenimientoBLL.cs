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

        public List<Mantenimiento> ObtenerTodos()
        {
            try
            {
                List<Mantenimiento> LMantenimientos = MantenimientoDAO.ObtenerTodos();

                foreach(Mantenimiento mantenimiento in LMantenimientos)
                {

                    AeronaveBLL AeronaveBLO = new AeronaveBLL();                   
                    TipoMantenimientoBLL TipoMantenimientoBLO = new TipoMantenimientoBLL();
                    EstadoMantenimientoBLL EstadoMantenimientoBLO = new EstadoMantenimientoBLL();

                    mantenimiento.Aeronave = AeronaveBLO.BuscarAeronavePorId(mantenimiento.Aeronave.IdAeronave);
                    mantenimiento.TipoMantenimiento = TipoMantenimientoBLO.BuscarTipoMantenimientoPorId(mantenimiento.TipoMantenimiento.IdTipoMantenimiento);
                    mantenimiento.EstadoMantenimiento = EstadoMantenimientoBLO.BuscarEstadoMantenimientoPorId(mantenimiento.EstadoMantenimiento.IdEstadoMantenimiento);

                    if(mantenimiento.Mecanico!=null && mantenimiento.Mecanico.IdMecanico>0)
                    {
                        MecanicoBLL MecanicoBLO = new MecanicoBLL();
                        mantenimiento.Mecanico = MecanicoBLO.BuscarMecanicoPorId(mantenimiento.Mecanico.IdMecanico); //falta implementar
                    }
                    if(mantenimiento.FacturaMantenimiento!=null && mantenimiento.FacturaMantenimiento.IdFactura>0)
                    {
                        FacturaMantenimientoBLL FacturaMantenimientoBLO = new FacturaMantenimientoBLL();
                        mantenimiento.FacturaMantenimiento = FacturaMantenimientoBLO.BuscarFacturaMPorId(mantenimiento.FacturaMantenimiento.IdFactura);
                    }
                    
                }
                return LMantenimientos;
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Mantenimiento error al obtener todos: "+ex.Message,ex);
            }
        }
		public void AltaMantenimiento(Mantenimiento mantenimiento)
		{
			try
			{
				ValidarCondicionesAlta(mantenimiento);


				// Dar Alta 
				MantenimientoDAO.AltaMantenimiento(mantenimiento);
                AeronaveBLL AeronaveBLO = new AeronaveBLL();
                EstadoAeronaveBLL EstadoAeronaveBLO = new EstadoAeronaveBLL();
                EstadoAeronave estado = EstadoAeronaveBLO.BuscarPorId((int)EnumEstadoEaronave.Mantenimiento);
                if (estado == null) throw new Exception("no se encontro el estado mantenimiento para la aernonave");
                //Actualizar la aeronave a en mantenimiento
                AeronaveBLO.ActualizarEstadoAeronave(mantenimiento.Aeronave.IdAeronave, estado);

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

            if (mantenimientoAux != null) throw new Exception($"La aeronave id {mantenimiento.Aeronave.IdAeronave} ya tiene un mantenimiento pendiente o en curso con id {mantenimientoAux.IdMantenimiento}");

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

        public void AsignarMecanico(Mantenimiento mantenimiento, Mecanico mecanico)
        {
            try
            {
                if (mantenimiento.TipoMantenimiento.IdTipoMantenimiento.Equals((int)EnumTipoMantenimiento.Extraordinario)) throw new Exception($"A los mantenimientos de tipo extraordinario con id {mantenimiento.TipoMantenimiento.IdTipoMantenimiento} no se les puede asignar un mecanico");
                if (mecanico == null || mecanico.IdMecanico <= 0) throw new Exception("Mecanico nulo o con id invalido");
                Mantenimiento mantAux = MantenimientoDAO.BuscarPorId(mantenimiento.IdMantenimiento);
                if (mantAux == null) throw new Exception("No se encontro el mantenimiento en la base de datos");
                if (mantenimiento.Mecanico != null) throw new Exception("El mantenimiento no debe tener ya un mecanico asignado");

                EstadoMantenimientoBLL EstadoMantenimientoBLO = new EstadoMantenimientoBLL();
                EstadoMantenimiento estadoEnMant = EstadoMantenimientoBLO.BuscarEstadoMantenimientoPorId((int)EnumEstadoMantenimiento.EnMantenimiento);
                if (estadoEnMant == null) throw new Exception("no se encontro el estado en mantenimiento en la base de datos");

                mantenimiento.EstadoMantenimiento = estadoEnMant;
                mantenimiento.Mecanico = mecanico;

                MantenimientoDAO.AsignarMecanico(mantenimiento);

            }
            catch (Exception ex)
            {

                throw new Exception("BLL Mantenimiento error al asignar Mecanico a mantenimiento: "+ex.Message,ex);
            }
        }

        public void EliminarMantenimiento(Mantenimiento mantenimiento)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw new Exception ("Error al eliminar mantenimiento: "+ex.Message,ex);
            }
        }

        public void DesAsignarMecanico(Mantenimiento mantenimiento)
        {
            try
            {
                if (mantenimiento.TipoMantenimiento.IdTipoMantenimiento.Equals((int)EnumTipoMantenimiento.Extraordinario)) throw new Exception($"A los mantenimientos de tipo extraordinario con id {mantenimiento.TipoMantenimiento.IdTipoMantenimiento} no se les puede des-asignar un mecanico");
                if (mantenimiento.Mecanico == null) throw new Exception("El mantenimiento no debe tener ya un mecanico asignado");
                if (mantenimiento.Mecanico.IdMecanico <= 0) throw new Exception("Mecanico con id invalido");
                Mantenimiento mantAux = MantenimientoDAO.BuscarPorId(mantenimiento.IdMantenimiento);
                if (mantAux == null) throw new Exception("No se encontro el mantenimiento en la base de datos");
              

                EstadoMantenimientoBLL EstadoMantenimientoBLO = new EstadoMantenimientoBLL();
                EstadoMantenimiento estadoPendiente = EstadoMantenimientoBLO.BuscarEstadoMantenimientoPorId((int)EnumEstadoMantenimiento.Pendiente);
                if (estadoPendiente == null) throw new Exception("no se encontro el estado pendiente en la base de datos");

                mantenimiento.EstadoMantenimiento = estadoPendiente;
                mantenimiento.Mecanico = null;

                MantenimientoDAO.DesAsignarMecanico(mantenimiento);
            }
            catch (Exception ex )
            {

                throw new Exception("Error al desasignar mecanico: "+ex.Message,ex);
            }
        }
    }
}
