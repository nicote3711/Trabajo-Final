﻿using DAL;
using ENTITY;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using System.Data;


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

                 /*   if (vuelo == null) throw new ArgumentNullException(nameof(vuelo), "El vuelo no puede ser nulo.");
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

                vuelo.Liquidado= false; // Por defecto, un vuelo recién registrado no está liquidado                
                if (vuelo == null) throw new ArgumentNullException(nameof(vuelo));
                VueloDAO.RegistrarVuelo(vuelo);
                ClienteBLO.DescontarSaldoVuelo(vuelo.Cliente.IDCliente, vuelo.TV);
                AeronaveBLO.ActualizarHorasAeronave(vuelo.Aeronave.IdAeronave, vuelo.TV);
                
                Aeronave aeronave = AeronaveBLO.ObtenerAeronavePorId(vuelo.Aeronave.IdAeronave);
                if(aeronave.Revision100Hs>=100)
                {
                    //TODO: Implementar lógica para manejar la revisión de 100 horas;
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
                if(vuelo.Liquidado) throw new Exception("No se puede eliminar un vuelo ya liquidado.");
                VueloDAO.EliminarVuelo(vuelo);
                ClienteBLO.AcreditarSaldoVuelo(vuelo.Cliente.IDCliente, vuelo.TV); // Se resta el saldo del cliente por el vuelo eliminado
                AeronaveBLO.ActualizarHorasAeronave(vuelo.Aeronave.IdAeronave, -vuelo.TV); // Se resta las horas de la aeronave por el vuelo eliminado


            }
            catch (Exception ex)
            {
                helperTransaccion.RollbackDfParaTransaccion(dsTransaccion);
                throw new Exception("BLL Error al eliminar vuelo."+ ex.Message,ex);
            }
        }
    }
}
