using DAL;
using ENTITY;
using ENTITY.Enum;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using System.Data;
using ENTITY.Enum;


namespace BLL
{
    public class VueloBLL
    {
        private readonly ClienteBLL ClienteBLO = new ClienteBLL();
        private readonly InstructorBLL InstructorBLO = new InstructorBLL();
        private readonly AeronaveBLL AeronaveBLO = new AeronaveBLL();
        private readonly FinalidadBLL FinalidadBLO = new FinalidadBLL();
        private readonly VueloDAL VueloDAO = new VueloDAL();

        public List<Vuelo> ObtenerVuelos()
        {
            try
            {
                List<Vuelo> LVuelos = VueloDAO.ObtenerVuelos();
                foreach (Vuelo vuelo in LVuelos)
                {
                    vuelo.Cliente = ClienteBLO.BuscarClientePorID(vuelo.Cliente.IDCliente);
                    if (vuelo.Instructor != null && vuelo.Instructor.IdInstructor != null)
                    {

                        vuelo.Instructor = InstructorBLO.BuscarInstructorPorID(vuelo.Instructor.IdInstructor); // Si el instructor es null, no se asigna para evitar NullReferenceException
                    }

                    vuelo.Aeronave = AeronaveBLO.ObtenerAeronavePorId(vuelo.Aeronave.IdAeronave);
                    vuelo.Finalidad = FinalidadBLO.ObtenerPorId(vuelo.Finalidad.IdFinalidad);

                 /*  if (vuelo == null) throw new ArgumentNullException(nameof(vuelo), "El vuelo no puede ser nulo.");
                    if (vuelo.Cliente == null) throw new ArgumentNullException(nameof(vuelo.Cliente), "El cliente del vuelo no puede ser nulo.");
                    if (vuelo.Aeronave == null) throw new ArgumentNullException(nameof(vuelo.Aeronave), "La aeronave del vuelo no puede ser nula.");
                    if (vuelo.Finalidad == null) throw new ArgumentNullException(nameof(vuelo.Finalidad), "La finalidad del vuelo no puede ser nula.");
                    if (vuelo.Instructor == null && string.IsNullOrEmpty(vuelo.Cliente.Licencia)) throw new Exception("El instructor del vuelo no puede ser nulo si el Cliente no posee Licencia.");
                    if (vuelo.Cliente.SaldoHorasVuelo <= -10 || vuelo.Cliente.SaldoHorasSimulador <= -10) throw new Exception("El cliente debe mas de 10 horas y debe cancelar la deuda primero.");
                    if (vuelo.HubInicial >= vuelo.HubFinal) throw new Exception("El Hub inicial debe ser menor que el Hub final.");*/
                }


                return LVuelos;

            }
            catch (Exception ex)
            {
               throw new Exception("BLL Error al obtener vuelos: " + ex.Message, ex);   
            }
        }
        public void RegistrarVuelo(Vuelo vuelo)
        {
            HelperTransaccion helperTransaccion = new HelperTransaccion();
            DataSet dsTransaccion = helperTransaccion.DfParaTransaccion();
            
            try
            {
                if (vuelo == null) throw new ArgumentNullException(nameof(vuelo), "El vuelo no puede ser nulo.");
                if (vuelo.Cliente == null) throw new ArgumentNullException(nameof(vuelo.Cliente), "El cliente del vuelo no puede ser nulo.");
                if (vuelo.Aeronave == null) throw new ArgumentNullException(nameof(vuelo.Aeronave), "La aeronave del vuelo no puede ser nula.");
                if(vuelo.Finalidad == null) throw new ArgumentNullException(nameof(vuelo.Finalidad), "La finalidad del vuelo no puede ser nula.");  
                if(vuelo.Instructor == null &&  string.IsNullOrEmpty(vuelo.Cliente.Licencia)) throw new Exception( "El instructor del vuelo no puede ser nulo si el Cliente no posee Licencia.");
                if (vuelo.Cliente.SaldoHorasVuelo<=-10 || vuelo.Cliente.SaldoHorasSimulador<=-10 ) throw new Exception("El cliente debe mas de 10 horas y debe cancelar la deuda primero.");
                if(vuelo.HubInicial >= vuelo.HubFinal) throw new Exception("El Hub inicial debe ser menor que el Hub final.");

              
                if(vuelo.Instructor==null && vuelo.Aeronave.Dueno==null)
                {
                    vuelo.Liquidado = true; // Si no hay instructor ni dueño, se marca como liquidado
                }
                else
                {
                    vuelo.Liquidado = false; // Si hay instructor o dueño, no se marca como liquidado
                }
                if (vuelo == null) throw new ArgumentNullException(nameof(vuelo));
                VueloDAO.RegistrarVuelo(vuelo);
                ClienteBLO.DescontarSaldoVuelo(vuelo.Cliente.IDCliente, vuelo.TV);
                AeronaveBLO.ActualizarHorasAeronave(vuelo.Aeronave.IdAeronave, vuelo.TV);
                
                Aeronave aeronave = AeronaveBLO.ObtenerAeronavePorId(vuelo.Aeronave.IdAeronave);
                if(aeronave.RevisionAnual.Date<DateTime.Now.Date)
                {
                    TipoMantenimientoBLL TipoMantenimientoBLO = new TipoMantenimientoBLL();
                    MantenimientoBLL MantenimientoBLO = new MantenimientoBLL();
                    EstadoMantenimientoBLL EstadoMantenimientoBLO = new EstadoMantenimientoBLL(); 

                    Mantenimiento mantenimientoAnual = new Mantenimiento();
                    TipoMantenimiento tipoMantenimiento = TipoMantenimientoBLO.BuscarTipoMantenimientoPorId((int)EnumTipoMantenimiento.Anual);
                    if (tipoMantenimiento == null) throw new Exception($"tipo mantenimiento anual con id {(int)EnumTipoMantenimiento.Anual} no encontrado");

                    EstadoMantenimiento estadoMantenimiento = EstadoMantenimientoBLO.BuscarEstadoMantenimientoPorId((int)EnumEstadoMantenimiento.Pendiente);
                    if (estadoMantenimiento == null) throw new Exception($"estado matenimiento pendiente con id {(int)EnumEstadoMantenimiento.Pendiente} no encontrado");

                    mantenimientoAnual.EstadoMantenimiento = estadoMantenimiento;
                    mantenimientoAnual.TipoMantenimiento = tipoMantenimiento;
                    mantenimientoAnual.Aeronave = aeronave;
                    mantenimientoAnual.HorasAeronave = aeronave.Revision100Hs;
                    mantenimientoAnual.FechaAnualAeronave = aeronave.RevisionAnual;
                    mantenimientoAnual.Fecha = DateTime.Now.Date;
                    mantenimientoAnual.Detalle = $"Mantenimiento anual a la aeronave matricula {aeronave.Matricula}.";

                    MantenimientoBLO.AltaMantenimiento(mantenimientoAnual);

                }
                else if(aeronave.Revision100Hs >= 100)
                {
                    TipoMantenimientoBLL TipoMantenimientoBLO = new TipoMantenimientoBLL();
                    MantenimientoBLL MantenimientoBLO = new MantenimientoBLL();
                    EstadoMantenimientoBLL EstadoMantenimientoBLO = new EstadoMantenimientoBLL();

                    Mantenimiento mantenimiento100Hs = new Mantenimiento();
                    TipoMantenimiento tipoMantenimiento = TipoMantenimientoBLO.BuscarTipoMantenimientoPorId((int)EnumTipoMantenimiento.Hs100);
                    if (tipoMantenimiento == null) throw new Exception($"tipo mantenimiento 100Hs con id {(int)EnumTipoMantenimiento.Hs100} no encontrado");

                    EstadoMantenimiento estadoMantenimiento = EstadoMantenimientoBLO.BuscarEstadoMantenimientoPorId((int)EnumEstadoMantenimiento.Pendiente);
                    if (estadoMantenimiento == null) throw new Exception($"estado matenimiento pendiente con id {(int)EnumEstadoMantenimiento.Pendiente} no encontrado");

                    mantenimiento100Hs.EstadoMantenimiento = estadoMantenimiento;
                    mantenimiento100Hs.TipoMantenimiento = tipoMantenimiento;
                    mantenimiento100Hs.Aeronave = aeronave;
                    mantenimiento100Hs.HorasAeronave = aeronave.Revision100Hs;
                    mantenimiento100Hs.FechaAnualAeronave = aeronave.RevisionAnual;
                    mantenimiento100Hs.Fecha = DateTime.Now.Date;
                    mantenimiento100Hs.Detalle = $"Mantenimiento de 100hs a la aeronave matricula {aeronave.Matricula}.";

                    MantenimientoBLO.AltaMantenimiento(mantenimiento100Hs);
                }

            }
            catch (Exception ex)
            {
                helperTransaccion.RollbackDfParaTransaccion(dsTransaccion);
                throw new Exception("BLL Error al regisrar vuelo:" +ex.Message, ex);
            }
        }

        public List<Vuelo> BuscarVuelosPorCliente(int idCliente)
        {
            try
            {
                List<Vuelo> LVuelos = VueloDAO.BuscarVuelosPorCliente(idCliente);
                foreach (Vuelo vuelo in LVuelos)
                {
                    vuelo.Cliente = ClienteBLO.BuscarClientePorID(vuelo.Cliente.IDCliente);
                    if (vuelo.Instructor != null && vuelo.Instructor.IdInstructor != null)
                        vuelo.Instructor = InstructorBLO.BuscarInstructorPorID(vuelo.Instructor.IdInstructor);

                    vuelo.Aeronave = AeronaveBLO.ObtenerAeronavePorId(vuelo.Aeronave.IdAeronave);
                    vuelo.Finalidad = FinalidadBLO.ObtenerPorId(vuelo.Finalidad.IdFinalidad);
                }
                return LVuelos;
            }
            catch (Exception ex)
            {
                throw new Exception("BLL Error al buscar vuelos por cliente: " + ex.Message, ex);
            }
        }

        public void EliminarVuelo(Vuelo vuelo)
        {
            HelperTransaccion helperTransaccion = new HelperTransaccion();
            DataSet dsTransaccion = helperTransaccion.DfParaTransaccion();
            try
            {
                if (vuelo == null) throw new ArgumentNullException(nameof(vuelo), "El vuelo no puede ser nulo.");
                if (vuelo.Liquidado) throw new Exception("No se puede eliminar un vuelo ya liquidado.");
                VueloDAO.EliminarVuelo(vuelo);
                ClienteBLO.AcreditarSaldoVuelo(vuelo.Cliente.IDCliente, vuelo.TV); // Se resta el saldo del cliente por el vuelo eliminado
                AeronaveBLO.ActualizarHorasAeronave(vuelo.Aeronave.IdAeronave, -vuelo.TV); // Se resta las horas de la aeronave por el vuelo eliminado


                //Falta retrotraer mantenimiento 100Hs en caso de que el vuelo lo haya provocado. Ej si aernova hs- hs vuelo <100 Mantenimiento 100hs delete. Y mantenimiento en pediente porque si se asigno mecanico no se puede volver atras.

            }
            catch (Exception ex)
            {
                helperTransaccion.RollbackDfParaTransaccion(dsTransaccion);
                throw new Exception("BLL Error al eliminar vuelo."+ ex.Message,ex);
            }
        }

        //TODO: Implementar BuscarVueloPorId en BLL vuelo para devolverlo full mappear si es necesario.

        public void LiquidarVuelo(Vuelo vuelo)
        {
            try
            {
                if (vuelo.IdVuelo== null || vuelo.IdVuelo <= 0) throw new ArgumentNullException(nameof(vuelo.IdVuelo), "El ID del vuelo no puede ser nulo o menor o igual a cero.");
                Vuelo vueloAux = VueloDAO.BuscarVueloPorId(vuelo.IdVuelo);
                if(vueloAux == null) throw new Exception("El vuelo no existe o no se encuentra en la base de datos.");
                
                VueloDAO.LiquidarVuelo(vuelo.IdVuelo); // Actualiza el vuelo en la base de datos como liquidado
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Vuelo error al liquidar vuelo: "+ex.Message,ex);
            }
        }

        internal Vuelo BuscarVueloPorId(int idVuelo)
        {
            try
            {
                if (idVuelo == null || idVuelo <= 0) throw new Exception("Id de vuelo nulo invalido");


                Vuelo vuelo = VueloDAO.BuscarVueloPorId(idVuelo);
                vuelo.Cliente = ClienteBLO.BuscarClientePorID(vuelo.Cliente.IDCliente);
                if (vuelo.Instructor != null && vuelo.Instructor.IdInstructor != null)
                {

                    vuelo.Instructor = InstructorBLO.BuscarInstructorPorID(vuelo.Instructor.IdInstructor); // Si el instructor es null, no se asigna para evitar NullReferenceException
                }

                vuelo.Aeronave = AeronaveBLO.ObtenerAeronavePorId(vuelo.Aeronave.IdAeronave);
                vuelo.Finalidad = FinalidadBLO.ObtenerPorId(vuelo.Finalidad.IdFinalidad);

                return vuelo;


            }
            catch (Exception ex)
            {

                throw new Exception("BLL Vuelo error al buscar vuelo por id: "+ex.Message,ex);
            }
        }

        public Dictionary<string,int> BuscarVuelosPorFiltro(DashboardFiltroPeriodo filtroVuelo)
        {
            try
            {
                Dictionary<string,int> vuelos = new Dictionary<string,int>();

                if (filtroVuelo == null) throw new Exception("Filtro invalido");

                switch (filtroVuelo.TipoFiltro) 
                {
                    case (int)EnumFiltrosDashboard.Semanal: 
                        {
                            vuelos = VueloDAO.BuscarVuelosFiltroSemanal(filtroVuelo.Anio,filtroVuelo.Mes);
                            break; 
                        }
                    case (int)EnumFiltrosDashboard.Diario:
                        {
                            vuelos = VueloDAO.BuscarVuelosFiltroDiario(filtroVuelo.Anio, filtroVuelo.Mes, filtroVuelo.Semana);
                            break;
                        }
                    default:
                        {
                            vuelos = VueloDAO.BuscarVuelosFiltroMensual(filtroVuelo.Anio);
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
    }
}
