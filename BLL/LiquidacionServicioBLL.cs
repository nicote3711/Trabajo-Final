using ENTITY;
using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LiquidacionServicioBLL
    {
        LiquidacionInstructorBLL LiquidacionInstructorBLO = new LiquidacionInstructorBLL(); 
        LiquidacionDuenoBLL  LiquidacionDuenoBLO = new LiquidacionDuenoBLL();
        VueloBLL VueloBLO = new VueloBLL();
        SimuladorBLL SimuladorBLO = new SimuladorBLL();

        public void GenerarLiquidaciones()
        {
            ServicioBLL ServicioBLO = new ServicioBLL();    
          
            HelperTransaccion helperTransaccion = new HelperTransaccion();
            DataSet ds = helperTransaccion.DfParaTransaccion();
            try
            {
                var periodo = DateTime.Now.Date;
                List<LiquidacionInstructor> ListaLiquidacionesInstructor = LiquidacionInstructorBLO.ObtenerLiquidacionesIPorPeriodo(periodo);
                List<LiquidacionDueno> ListaLiquidacionesDueno = LiquidacionDuenoBLO.ObtenerLiquidacionesDPorPeriodo(periodo);
                if(ListaLiquidacionesInstructor.Count > 0 || ListaLiquidacionesDueno.Count > 0) throw new Exception("Ya existen liquidaciones para el periodo actual.");
                

                List<Vuelo> LvuelosSinLiquidar = VueloBLO.ObtenerVuelos().Where(v => !v.Liquidado).ToList();
                List<Simulador> LsimuladoresSinLiquidar = SimuladorBLO.ObtenerSimuladores().Where(s => s.Liquidacion == null).ToList();
                Servicio ServicioInstructor = ServicioBLO.BuscarServicioPorID((int)EnumServicios.Instructor);
                Servicio ServicioDueno = ServicioBLO.BuscarServicioPorID((int)EnumServicios.Dueño);

                //LLenado de liquidaciones de dueños y instructores para vuelos sin liquidar
                foreach (Vuelo vuelo in LvuelosSinLiquidar)
                {
                    if (vuelo.Aeronave.Dueno != null)
                    {
                        LiquidacionDueno liquidacionDueno = ListaLiquidacionesDueno.FirstOrDefault(ld => ld.Persona.IDPersona == vuelo.Aeronave.Dueno.IDPersona);
                        if (liquidacionDueno == null)
                        {
                            LiquidacionDueno liquidacion = new LiquidacionDueno();
                            liquidacion.Vuelos.Add(vuelo);
                            liquidacion.Periodo = periodo;
                            liquidacion.Persona = vuelo.Aeronave.Dueno; // Asignar el dueño de la aeronave
                            liquidacion.Servicio.Precio = ServicioDueno.Precio; // Asignar el precio del servicio de dueño
                            liquidacion.Servicio.Descripcion= ServicioDueno.Descripcion; // Asignar la descripción del servicio de dueño
                            liquidacion.IdPersona = vuelo.Aeronave.Dueno.IDPersona;
                            ListaLiquidacionesDueno.Add(liquidacion);   
                        }
                        else
                        {
                            liquidacionDueno.Vuelos.Add(vuelo); // Sumar el vuelo a la lista de vuelos del dueño
                        }
                            

                    }
                    if (vuelo.Instructor != null)
                    {
                        LiquidacionInstructor liquidacionInstructor = ListaLiquidacionesInstructor.FirstOrDefault(li => li.Persona.IDPersona == vuelo.Instructor.IdInstructor);
                        if (liquidacionInstructor == null)
                        {
                            LiquidacionInstructor liquidacion = new LiquidacionInstructor();
                            liquidacion.Vuelos.Add(vuelo);
                            liquidacion.Periodo = periodo;
                            liquidacion.Persona = vuelo.Instructor; // Asignar el instructor
                            liquidacion.Servicio.Precio = ServicioInstructor.Precio; // Asignar el precio del servicio de instructor
                            liquidacion.Servicio.Descripcion = ServicioInstructor.Descripcion; // Asignar la descripción del servicio de instructor
                            liquidacion.IdPersona = vuelo.Instructor.IdInstructor;
                            ListaLiquidacionesInstructor.Add(liquidacion);
                        }
                        else
                        {
                            liquidacionInstructor.Vuelos.Add(vuelo); // Sumar el vuelo a la lista de vuelos del instructor  
                        }
                            
                    }
                }
                // Llenado de liquidaciones de instructores para simuladores sin liquidar
                foreach (Simulador simulador in LsimuladoresSinLiquidar)
                {
                    if (simulador.Instructor != null)
                    {
                        LiquidacionInstructor liquidacionInstructor = ListaLiquidacionesInstructor.FirstOrDefault(li => li.Persona.IDPersona == simulador.Instructor.IdInstructor);
                        if (liquidacionInstructor == null)
                        {
                            LiquidacionInstructor liquidacion = new LiquidacionInstructor();
                            liquidacion.Simuladores.Add(simulador);
                            liquidacion.Periodo = periodo;
                            liquidacion.Persona = simulador.Instructor; // Asignar el instructor
                            liquidacion.Servicio.Precio = ServicioInstructor.Precio; // Asignar el precio del servicio de instructor
                            liquidacion.Servicio.Descripcion = ServicioInstructor.Descripcion; // Asignar la descripción del servicio de instructor
                            liquidacion.IdPersona = simulador.Instructor.IdInstructor;
                            ListaLiquidacionesInstructor.Add(liquidacion);
                        }
                        else
                        {
                            liquidacionInstructor.Simuladores.Add(simulador); // Sumar el simulador a la lista de simuladores del instructor 
                        }
                            
                    }
                }

                foreach (LiquidacionInstructor liquidacionI in ListaLiquidacionesInstructor)
                {
                    LiquidacionInstructorBLO.GenerarLiquidacion(liquidacionI);
                }
                foreach (LiquidacionDueno liquidacionD in ListaLiquidacionesDueno)
                {
                    LiquidacionDuenoBLO.GenerarLiquidacion(liquidacionD);
                }
                foreach (Vuelo vuelo in LvuelosSinLiquidar)
                {
                    vuelo.Liquidado = true; // Marcar el vuelo como liquidado
                    VueloBLO.LiquidarVuelo(vuelo); // Actualizar el vuelo en la base de datos
                }


            }
            catch (Exception ex)
            {
                helperTransaccion.RollbackDfParaTransaccion(ds);
                throw new Exception("BLL Liquidacion Servicio error al generar las liquidaciones: "+ ex.Message,ex);
            }
        }

    }
}
