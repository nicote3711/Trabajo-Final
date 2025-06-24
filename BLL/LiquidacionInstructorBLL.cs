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
    public class LiquidacionInstructorBLL
    {
        LiquidacionInstructorDAL LiquidacionInstructorDAO = new LiquidacionInstructorDAL();


        public List<LiquidacionInstructor> ObtenerLiquidacionesIdPersonaInstructor(int IdPersona)
        {
            try
            {
                if(IdPersona == null || IdPersona <= 0) throw new Exception("El id de persona del instructor es un id nulo o invalido");
                List<LiquidacionInstructor> LLiquidacionesI = LiquidacionInstructorDAO.ObtenerLiquidacionesIPorIdPersonaInstructor(IdPersona);
                return LLiquidacionesI;
            }
            catch (Exception ex)
            {
                throw new Exception("BLL LiquidacionInstructor error al obtener liquidaciones: " + ex.Message, ex);
            }
        }
        public List<LiquidacionInstructor> ObtenerLiquidacionesIPorPeriodo(DateTime periodo)
        {
			try
			{
                ServicioBLL ServicioBLO = new ServicioBLL();
                Servicio servicio = ServicioBLO.BuscarServicioPorID((int)EnumServicios.Instructor);
                if (servicio == null) throw new Exception("No se encontró el servicio Instructor.");

                List<LiquidacionInstructor> LLiquidacionesI = LiquidacionInstructorDAO.ObtenerLiquidacionesIPorPeriodo(periodo);
                
                return LLiquidacionesI;
            }
			catch (Exception ex)
			{

				throw new Exception("BLL LiquidacionInstructor error al obtener liquidaciones: "+ ex.Message,ex);
			}
        }

        internal void GenerarLiquidacion(LiquidacionInstructor liquidacionI)
        {
            HelperTransaccion helperTransaccion = new HelperTransaccion();
            DataSet ds = helperTransaccion.DfParaTransaccion();
            try
            {
                if (liquidacionI.IdPersona == null || liquidacionI.IdPersona <= 0) throw new Exception("El ID del instructor no puede ser nulo o menor o igual a cero.");
                if (liquidacionI.Vuelos == null || liquidacionI.Simuladores == null) throw new Exception("error al generar las listas de vuelos y simuladores");
                if (liquidacionI.Vuelos.Count == 0 && liquidacionI.Simuladores.Count == 0) throw new Exception("Listas Vacias!No hay vuelos ni simuladores para liquidar.");
                Calcular(liquidacionI);

                LiquidacionInstructorDAO.GenerarLiquidacionI(liquidacionI);

                foreach (Simulador simulador in liquidacionI.Simuladores)
                {
                    simulador.IdLiquidacion = liquidacionI.IdLiquidacionServicio; // Asignar la liquidación al simulador no necesario
                    SimuladorBLL simuladorBLO = new SimuladorBLL();
                    simuladorBLO.AsignarLiquidacionASimulador(simulador); // Actualizar el simulador en la base de datos
                }

            }
            catch (Exception ex)
            {
                helperTransaccion.RollbackDfParaTransaccion(ds);
                throw new Exception("BLL LiquidacionInsctructor error al generar liquidacion: "+ex.Message,ex);
            }
        }

        public static void Calcular(LiquidacionInstructor liquidacionI)
        {
            liquidacionI.CantHoras = 0;
            liquidacionI.MontoTotal = 0;

            foreach (Vuelo vuelo in liquidacionI.Vuelos)
            {
                liquidacionI.CantHoras += vuelo.TV;
            }
            foreach (Simulador simulador in liquidacionI.Simuladores)
            {
                liquidacionI.CantHoras += simulador.TS;
            }
            liquidacionI.MontoTotal = liquidacionI.CantHoras * liquidacionI.Servicio.Precio;
        }
    }
}
