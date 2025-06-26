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

        public void GenerarLiquidacion(LiquidacionInstructor liquidacionI)
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

        public  void Calcular(LiquidacionInstructor liquidacionI)
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

        public List<LiquidacionInstructor> ObtenerLiquidacionesIPorIdPersonaDueño(int iDPersona)
        {
            try
            {
                if (iDPersona == null || iDPersona <= 0) throw new Exception("El id de persona del dueño es un id nulo o invalido");
                List<LiquidacionInstructor> LLiquidaciones = LiquidacionInstructorDAO.ObtenerLiquidacionesIPorIdPersonaInstructor(iDPersona);
                InstructorBLL InstructorBLO = new InstructorBLL();
                VueloBLL VueloBLO = new VueloBLL();
                SimuladorBLL SimuladorBLO = new SimuladorBLL();

                foreach(LiquidacionInstructor liquidacionInstructor in LLiquidaciones)
                {
                    Instructor instructor = InstructorBLO.BuscarInstructorPorID(liquidacionInstructor.Persona.IDPersona);
                    if (instructor == null) throw new Exception("Error al obtener el instructor para la liquidacion");
                    liquidacionInstructor.Persona = instructor; 
                    List<Vuelo> LvuelosCompletos = new List<Vuelo>();
                    foreach(Vuelo vuelo in liquidacionInstructor.Vuelos)
                    {
                        Vuelo vueloCompleto = VueloBLO.BuscarVueloPorId(vuelo.IdVuelo);
                        LvuelosCompletos.Add(vueloCompleto);
                    }
                    
                    List<Simulador> Lsimuladores = SimuladorBLO.ObtenerSimuladoresPorIdLiquidacion(liquidacionInstructor.IdLiquidacionServicio);
                    if (Lsimuladores.Count <= 0 && LvuelosCompletos.Count <= 0) throw new Exception("Error al obtener los vuelos y liquidaciones. Ambas no pueden estar vacias");
                    liquidacionInstructor.Vuelos =LvuelosCompletos;
                    liquidacionInstructor.Simuladores = Lsimuladores;
                }

                return LLiquidaciones;
            }
            catch (Exception ex)
            {

                throw new Exception("BLL LiquidacionInstructor error al generar liquidacion");
            }
        }

        public List<LiquidacionInstructor> ObtenerLiquidacionesPorIdFactura(int idFactura)
        {
            try
            {
                List<LiquidacionInstructor> LLiquidacionesI = LiquidacionInstructorDAO.BuscarLiquidacionesPorIdFactura(idFactura);
                return LLiquidacionesI;

            }
            catch (Exception ex)
            {

                throw new Exception("BLL LiquidacionInstructor error al ObtenerLiquidacionesPorIdFactura");
            }
        }

        public void QuitarIdFacturaALiquidacion(LiquidacionInstructor liquidacion)
        {
            try
            {
                if (liquidacion.IdLiquidacionServicio <= 0) throw new Exception("Id liquidacion nulo o invalido");
                

                LiquidacionInstructorDAO.QuitarIdFacturaALiquidacion(liquidacion.IdLiquidacionServicio);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL LiquidacionInstructor error al AsignarIdFactura a liquidacion: "+ex.Message,ex);
            }
        }
        public void AsignarIdFacturaALiquidacion(LiquidacionInstructor liquidacion)
        {
            try
            {
                if (liquidacion.IdLiquidacionServicio <= 0) throw new Exception("Id liquidacion nulo o invalido");
                if (liquidacion.IdFactura == null || liquidacion.IdFactura <= 0) throw new Exception("Id de factura nulo o invalido");

                LiquidacionInstructorDAO.AsignarIdFacturaALiquidacion(liquidacion.IdLiquidacionServicio,liquidacion.IdFactura);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL LiquidacionInstructor error al AsignarIdFactura a liquidacion: " + ex.Message, ex);
            }
        }
    }
}
