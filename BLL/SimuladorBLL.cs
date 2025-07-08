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
    public class SimuladorBLL
    {
		SimuladorDAL SimuladorDAO = new SimuladorDAL();	
		ClienteBLL ClienteBLO = new ClienteBLL();
		InstructorBLL InstructorBLO = new InstructorBLL();
		FinalidadBLL FinalidadBLO = new FinalidadBLL();
		

		public List<Simulador> ObtenerSimuladores()
		{
			try
			{
				List<Simulador> LSimuladores = SimuladorDAO.ObtenerTodos();
				foreach (Simulador simulador in LSimuladores)
				{
					simulador.Cliente = ClienteBLO.BuscarClientePorID(simulador.Cliente.IDCliente);
					simulador.Instructor = InstructorBLO.BuscarInstructorPorID(simulador.Instructor.IdInstructor);
					simulador.Finalidad = FinalidadBLO.ObtenerPorId(simulador.Finalidad.IdFinalidad);
					if(simulador.Liquidacion != null && simulador.Liquidacion.IdLiquidacionServicio!=null)
					{
                        //TODO: Asignar la liquidación al simulador Consultar a Pablo
                    }
                }
                    return LSimuladores;
			}
			catch (Exception ex)
			{
				throw new Exception("BLL Simulador error al obtener simuladores: " + ex.Message, ex);
			}
        }

        public Dictionary<string, int> BuscarSimuladoresPorFiltro(DashboardFiltroPeriodo filtroSimuladores)
        {
            try
            {
                Dictionary<string, int> vuelos = new Dictionary<string, int>();

                if (filtroSimuladores == null) throw new Exception("Filtro invalido");

                switch (filtroSimuladores.TipoFiltro)
                {
                    case (int)EnumFiltrosDashboard.Semanal:
                        {
                            vuelos = SimuladorDAO.BuscarSimuladoresFiltroSemanal(filtroSimuladores.Anio, filtroSimuladores.Mes);
                            break;
                        }
                    case (int)EnumFiltrosDashboard.Diario:
                        {
                            vuelos = SimuladorDAO.BuscarSimuladoresFiltroDiario(filtroSimuladores.Anio, filtroSimuladores.Mes, filtroSimuladores.Semana);
                            break;
                        }
                    default:
                        {
                            vuelos = SimuladorDAO.BuscarSimuladoresFiltroMensual(filtroSimuladores.Anio);
                            break;
                        }
                }


                return vuelos;


            }
            catch (Exception ex)
            {

                throw new Exception("BLL Vuelo error al buscar vuelo por id: " + ex.Message, ex);
            }
        }

        public void RegistrarSimulador(Simulador simulador)
        {
			HelperTransaccion helperTransaccion = new HelperTransaccion();
			DataSet ds = helperTransaccion.DfParaTransaccion();	
            try
			{
				if(simulador == null)throw new ArgumentNullException(nameof(simulador), "El simulador no puede ser nulo.");
                if(simulador.Cliente == null) throw new ArgumentNullException(nameof(simulador.Cliente), "El cliente del simulador no puede ser nulo.");
				if(simulador.Instructor == null) throw new ArgumentNullException(nameof(simulador.Instructor), "El instructor del simulador no puede ser nulo.");
				if(simulador.Finalidad == null) throw new ArgumentNullException(nameof(simulador.Finalidad), "La finalidad del simulador no puede ser nula.");
				if(simulador.Cliente.SaldoHorasSimulador <= -10 || simulador.Cliente.SaldoHorasVuelo <=-10) throw new Exception("El cliente debe mas de 10 horas de simulador o de vuelo y debe cancelar la deuda primero.");
				simulador.Liquidacion = null; // es null al momento de registrar el simulador, se asigna luego en la liquidación al crearse la misma

				SimuladorDAO.RegistrarSimulador(simulador);
				ClienteBLO.DescontarHorasSimulador(simulador.Cliente.IDCliente, simulador.TS); // Descontar las horas de simulador al cliente
				
            }
			catch (Exception ex)
			{
				helperTransaccion.RollbackDfParaTransaccion(ds);
                throw new Exception("BLL error al registrar simulador" + ex.Message, ex);
			}
        }

		public void EliminarSimulador(Simulador simulador)
		{
			HelperTransaccion helperTransaccion = new HelperTransaccion();
			DataSet ds = helperTransaccion.DfParaTransaccion();
            try
            {
                if (simulador == null) throw new ArgumentNullException(nameof(simulador), "El simulador no puede ser nulo.");
                if (simulador.Liquidacion != null || simulador.IdLiquidacion>=0) throw new Exception("No se puede eliminar un simulador que ya tiene una liquidación asociada.");
				SimuladorDAO.EliminarSimulador(simulador.IdSimulador);
				ClienteBLO.AcreditarSaldoSimulador(simulador.Cliente.IDCliente, simulador.TS); // Acreditar las horas de simulador al cliente al eliminar el simulador
            }
			catch (Exception ex)
			{
				helperTransaccion.RollbackDfParaTransaccion(ds);
                throw new Exception("BLL Simulador error al eliminar simulador" + ex.Message,ex);
			}
        }

        public void AsignarLiquidacionASimulador(Simulador simulador)
        {
			try
			{
               
				if (simulador.IdLiquidacion == null || simulador.IdLiquidacion <= 0) throw new ArgumentException("El ID de la liquidación no puede ser nulo o menor o igual a cero.", nameof(simulador.IdLiquidacion));
                Simulador simu = SimuladorDAO.BuscarPorId(simulador.IdSimulador);
				if(simu == null) throw new Exception("Simulador no encontrado en base de datos.");
				
                SimuladorDAO.AsignarLiquidacionASimulador(simu.IdSimulador, simulador.IdLiquidacion);

            }
			catch (Exception ex)
			{

				throw new Exception("BLL Simulador error al actualizar simulador: "+ex.Message,ex);
			}
        }

        internal List<Simulador> ObtenerSimuladoresPorIdLiquidacion(int idLiquidacionServicio)
        {
			try
			{
				List<Simulador> Lsimuladores = SimuladorDAO.ObtenerSimuladoresPorIdLiquidacion(idLiquidacionServicio);

				foreach(Simulador simulador in Lsimuladores)
				{
                    simulador.Cliente = ClienteBLO.BuscarClientePorID(simulador.Cliente.IDCliente);
                    simulador.Instructor = InstructorBLO.BuscarInstructorPorID(simulador.Instructor.IdInstructor);
                    simulador.Finalidad = FinalidadBLO.ObtenerPorId(simulador.Finalidad.IdFinalidad);
                }

				return Lsimuladores;
			}
			catch (Exception ex)
			{

				throw new Exception("BLL Simulador error al obtener simuladores por Id Liquidacion: "+ex.Message,ex);
			}
        }
    }
}
