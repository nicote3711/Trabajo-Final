using DAL;
using ENTITY;
using ENTITY.Enum;
using Helper;
using System;
using System.Collections.Generic;
using System.Data;
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
                        // Matenimiento no MAPEA A FACTURA MANT. Asi evito ref circular. Si tiene el id pero no el objeto completo.
                        //FacturaMantenimientoBLL FacturaMantenimientoBLO = new FacturaMantenimientoBLL();
                       // mantenimiento.FacturaMantenimiento = FacturaMantenimientoBLO.BuscarFacturaMPorId(mantenimiento.FacturaMantenimiento.IdFactura);
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

				throw new Exception("BLL Mantenimiento error al dar alta mantenimiento:" +ex.Message,ex);
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
            HelperTransaccion helperTransaccion = new HelperTransaccion();
            DataSet ds = helperTransaccion.DfParaTransaccion();
            try
            {
                if (mantenimiento == null || mantenimiento.IdMantenimiento <= 0) throw new Exception("mantenimiento nulo o id de mantenimiento invalido");
                if (mantenimiento.Aeronave == null || mantenimiento.Aeronave.IdAeronave <= 0) throw new Exception("aeronave nula o con id invalido");
                if (mantenimiento.FacturaMantenimiento!= null) throw new Exception("El mantenimiento ya tiene presentada la factura  y no puede eliminarse");

                if (mantenimiento.TipoMantenimiento.IdTipoMantenimiento.Equals((int)EnumTipoMantenimiento.Hs100) && mantenimiento.Aeronave.Revision100Hs >= 100) throw new Exception("No se puede eliminar el mantanimiento de 100hs si la aeronave no cumple el requisito tecnico");
                if (mantenimiento.TipoMantenimiento.IdTipoMantenimiento.Equals((int)EnumTipoMantenimiento.Anual) && mantenimiento.Aeronave.RevisionAnual < DateTime.Now.Date) throw new Exception("No se puede elmiminar el mantenimiento anual si tiene vencida la fecha");

                AeronaveBLL AeronaveBLO = new AeronaveBLL();
                EstadoAeronaveBLL EstadoAeronaveBLO = new EstadoAeronaveBLL();
                EstadoAeronave estadoAeronave = EstadoAeronaveBLO.BuscarPorId((int)EnumEstadoEaronave.Activo);
                if (estadoAeronave == null) throw new Exception("no se encontro el estado aeronave activo");

                MantenimientoDAO.EliminarMantenimiento(mantenimiento.IdMantenimiento);
                AeronaveBLO.ActualizarEstadoAeronave(mantenimiento.Aeronave.IdAeronave, estadoAeronave);
            }
            catch (Exception ex)
            {
                helperTransaccion.RollbackDfParaTransaccion(ds);
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

        public void RegistrarFacturaMant(Mantenimiento mantenimiento)
        {
            HelperTransaccion helperTransaccion = new HelperTransaccion();
            DataSet ds = helperTransaccion.DfParaTransaccion();
            try
            {
                if (mantenimiento == null || mantenimiento.IdMantenimiento <= 0) throw new Exception(" Mantenimiento nulo o con id invalido");
                if (mantenimiento.FacturaMantenimiento == null || mantenimiento.FacturaMantenimiento.IdFactura <= 0) throw new Exception("factura nula o id invalido");
                if (mantenimiento.Aeronave == null || mantenimiento.Aeronave.IdAeronave <= 0) throw new Exception("aeronave nula o id invalido");
                


                EstadoMantenimientoBLL EstadoMantenimientoBLO =new EstadoMantenimientoBLL();
                EstadoMantenimiento estadoMant = EstadoMantenimientoBLO.BuscarEstadoMantenimientoPorId((int)EnumEstadoMantenimiento.Finalizado);
                if (estadoMant == null || estadoMant.IdEstadoMantenimiento <= 0) throw new Exception("error a conseguir el estado mantenimiento finalizado");
                mantenimiento.EstadoMantenimiento = estadoMant;

                EstadoAeronaveBLL EstadoAeronaveBLO = new EstadoAeronaveBLL();
                EstadoAeronave estadoAeronave = EstadoAeronaveBLO.BuscarPorId((int)EnumEstadoEaronave.Activo);
                if (estadoAeronave == null || estadoAeronave.IdEstadoAeronave <= 0) throw new Exception("error al conseguir el estado aeronave activo");
                
                

                MantenimientoDAO.RegistrarFacturaMant(mantenimiento);
                AeronaveBLL AeronaveBLO = new AeronaveBLL();

                if (mantenimiento.TipoMantenimiento.IdTipoMantenimiento.Equals((int)EnumTipoMantenimiento.Anual))
                {
                    mantenimiento.Aeronave.RevisionAnual = mantenimiento.FacturaMantenimiento.FechaFactura.AddYears(1);
                    mantenimiento.Aeronave.Revision100Hs = 0;
                }
                if (mantenimiento.TipoMantenimiento.IdTipoMantenimiento.Equals((int)EnumTipoMantenimiento.Hs100))
                {
                    mantenimiento.Aeronave.Revision100Hs = 0;
                }
                AeronaveBLO.ModificarAeronave(mantenimiento.Aeronave);
                AeronaveBLO.ActualizarEstadoAeronave(mantenimiento.Aeronave.IdAeronave, estadoAeronave);

            }
            catch (Exception ex)
            {
                helperTransaccion.RollbackDfParaTransaccion(ds);
                throw new Exception("BLL Mantenimiento error al registrar factura mantenimiento: "+ex.Message,ex);
            }
        }

        public Mantenimiento BuscarMantenimientoPorIdFactura(int idFactura)
        {
            try
            {
                Mantenimiento mantenimiento = MantenimientoDAO.BuscarMantenimientoPorIdFactura(idFactura);
                if (mantenimiento == null) throw new Exception($"no se encontro un mantenimiento con la factura id {idFactura} asociada");
                AeronaveBLL AeronaveBLO = new AeronaveBLL();
                TipoMantenimientoBLL TipoMantenimientoBLO = new TipoMantenimientoBLL();
                EstadoMantenimientoBLL EstadoMantenimientoBLO = new EstadoMantenimientoBLL();

                mantenimiento.Aeronave = AeronaveBLO.BuscarAeronavePorId(mantenimiento.Aeronave.IdAeronave);
                mantenimiento.TipoMantenimiento = TipoMantenimientoBLO.BuscarTipoMantenimientoPorId(mantenimiento.TipoMantenimiento.IdTipoMantenimiento);
                mantenimiento.EstadoMantenimiento = EstadoMantenimientoBLO.BuscarEstadoMantenimientoPorId(mantenimiento.EstadoMantenimiento.IdEstadoMantenimiento);

                if (mantenimiento.Mecanico != null && mantenimiento.Mecanico.IdMecanico > 0)
                {
                    MecanicoBLL MecanicoBLO = new MecanicoBLL();
                    mantenimiento.Mecanico = MecanicoBLO.BuscarMecanicoPorId(mantenimiento.Mecanico.IdMecanico); //falta implementar
                }
                if (mantenimiento.FacturaMantenimiento != null && mantenimiento.FacturaMantenimiento.IdFactura > 0)
                {
                   //NO mapeo la factura para evitar ref circular. Si llego a necesitar la info uso otro metodo con consulta linq.
                  //  FacturaMantenimientoBLL FacturaMantenimientoBLO = new FacturaMantenimientoBLL();
                  //  mantenimiento.FacturaMantenimiento = FacturaMantenimientoBLO.BuscarFacturaMPorId(mantenimiento.FacturaMantenimiento.IdFactura);
                }
                return mantenimiento;
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Mantenimiento error al buscar mantenimiento por IdFactura: "+ex.Message,ex);
            }
        }

        public void EliminarFacturaDeMantenimiento(Mantenimiento mantenimiento)
        {
            HelperTransaccion helperTransaccion = new HelperTransaccion();
            DataSet ds = helperTransaccion.DfParaTransaccion();

            try
            {
                //La factura fue previamente borrada asi que preguntar si existe la factura para ver si se hizo correcto no buscar porque tiraria excepcion el metodo. 
                //Supongo de momento se borro correctamente. 
                if (mantenimiento == null || mantenimiento.IdMantenimiento <= 0) throw new Exception(" Mantenimiento nulo o con id invalido");
                if (mantenimiento.FacturaMantenimiento == null || mantenimiento.FacturaMantenimiento.IdFactura <= 0) throw new Exception("factura nula o id invalido");
                if (mantenimiento.Aeronave == null || mantenimiento.Aeronave.IdAeronave <= 0) throw new Exception("aeronave nula o id invalido");


                EstadoMantenimientoBLL EstadoMantenimientoBLO = new EstadoMantenimientoBLL();
                EstadoMantenimiento estadoMant = EstadoMantenimientoBLO.BuscarEstadoMantenimientoPorId((int)EnumEstadoMantenimiento.EnMantenimiento);
                if (estadoMant == null || estadoMant.IdEstadoMantenimiento <= 0) throw new Exception("error a conseguir el estado mantenimiento en mantenimiento");
                mantenimiento.EstadoMantenimiento = estadoMant;

                EstadoAeronaveBLL EstadoAeronaveBLO = new EstadoAeronaveBLL();
                EstadoAeronave estadoAeronave = EstadoAeronaveBLO.BuscarPorId((int)EnumEstadoEaronave.Mantenimiento);
                if (estadoAeronave == null || estadoAeronave.IdEstadoAeronave <= 0) throw new Exception("error al conseguir el estado aeronave mantenimiento");


                MantenimientoDAO.EliminarFacturadeMantenimiento(mantenimiento);
                AeronaveBLL AeronaveBLO = new AeronaveBLL();

                if (mantenimiento.TipoMantenimiento.IdTipoMantenimiento.Equals((int)EnumTipoMantenimiento.Anual))
                {
                    mantenimiento.Aeronave.RevisionAnual = mantenimiento.FechaAnualAeronave;
                    mantenimiento.Aeronave.Revision100Hs = mantenimiento.HorasAeronave;
                }
                if (mantenimiento.TipoMantenimiento.IdTipoMantenimiento.Equals((int)EnumTipoMantenimiento.Hs100))
                {
                    mantenimiento.Aeronave.Revision100Hs = mantenimiento.HorasAeronave;
                }
                AeronaveBLO.ModificarAeronave(mantenimiento.Aeronave);

                AeronaveBLO.ActualizarEstadoAeronave(mantenimiento.Aeronave.IdAeronave, estadoAeronave);




            }
            catch (Exception ex)
            {
                helperTransaccion.RollbackDfParaTransaccion(ds);
                throw new Exception("BLL Mantenimiento error al eliminar la factura del mantenimiento: "+ex.Message,ex);
            }
        }
    }
}
