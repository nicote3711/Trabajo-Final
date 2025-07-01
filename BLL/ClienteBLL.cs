using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteBLL
    {
        ClienteDAL clienteDAO = new ClienteDAL();
        public void AltaCliente(Cliente cliente)
        {
            try
            {
                if (cliente == null) throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser nulo.");
                if (clienteDAO.BuscarClientePorDNI(cliente.DNI) != null) throw new Exception("El cliente con ese DNI ya existe.");
                if (string.IsNullOrWhiteSpace(cliente.Nombre)) throw new ArgumentException("El nombre del cliente no puede estar vacío.", nameof(cliente.Nombre));
                if (string.IsNullOrWhiteSpace(cliente.Apellido)) throw new ArgumentException("El apellido del cliente no puede estar vacío.", nameof(cliente.Apellido));
                if (cliente.DNI <= 0) throw new ArgumentException("El DNI del cliente debe ser un número positivo.", nameof(cliente.DNI));
                if (string.IsNullOrWhiteSpace(cliente.CuitCuil)) throw new ArgumentException("El CUIT/CUIL del cliente no puede estar vacío.", nameof(cliente.CuitCuil));
                cliente.SaldoHorasSimulador = 0;
                cliente.SaldoHorasVuelo = 0;
                cliente.Activo = true;
                clienteDAO.AltaCliente(cliente);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Cliente error al dar alta cliente: "+ex.Message,ex);
            }
        }

        public void BajaCliente(int IdCliente)
        {
            try
            {
                Cliente clienteBaja = clienteDAO.BuscarClientePorID(IdCliente);
                if (clienteBaja == null) throw new Exception("El cliente no existe en la base de datos.");  
                clienteDAO.BajaCliente(IdCliente);


            }
            catch (Exception ex)
            {

                throw new Exception("BLL Cliente error al dar baja de cliente: " +ex.Message,ex);
            }
        }

        public Cliente BuscarPersonaPorDni(long dNI)
        {
            try
            {
                return clienteDAO.BuscarPersonaPorDNI(dNI);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL cliente error al Buscar Persona por Dni: " +ex.Message,ex);
            }
        }

        public Cliente BuscarClientePorDni(long dNI)
        {
            try
            {
                return clienteDAO.BuscarClientePorDNI(dNI);
            }
            catch (Exception ex)
            {
                throw new Exception("BLL cliente error al Buscar Persona por Dni: " + ex.Message, ex);
            }
        }

        public void ModifcarPersonaExistente(Cliente cliente)
        {
            try
            {
                clienteDAO.ModificarPersonaExistente(cliente);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL cliente error al Modificar Persona existente: " + ex.Message,ex);
            }
        }

        public void ModificarCliente(Cliente clienteMod)
        {
            try
            {
                if (clienteMod == null) throw new ArgumentNullException(nameof(clienteMod), "El cliente no puede ser nulo.");
                Cliente cliente = clienteDAO.BuscarPersonaPorDNI(clienteMod.DNI);
                if (cliente != null && clienteMod.IDPersona != cliente.IDPersona) throw new Exception("Ya existe una persona  con ese DNI ya existe."); // muy importante
                if (string.IsNullOrWhiteSpace(clienteMod.Nombre)) throw new ArgumentException("El nombre del cliente no puede estar vacío.", nameof(clienteMod.Nombre));
                if (string.IsNullOrWhiteSpace(clienteMod.Apellido)) throw new ArgumentException("El apellido del cliente no puede estar vacío.", nameof(clienteMod.Apellido));
                if (clienteMod.DNI <= 0) throw new ArgumentException("El DNI del cliente debe ser un número positivo.", nameof(clienteMod.DNI));
                if (string.IsNullOrWhiteSpace(clienteMod.CuitCuil)) throw new ArgumentException("El CUIT/CUIL del cliente no puede estar vacío.", nameof(clienteMod.CuitCuil));
                clienteDAO.ModificarCliente(clienteMod);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL cliente error al modificar cliente: "+ ex.Message,ex);
            }
        }

        public List<Cliente> ObtenerClientes()
        {
           return clienteDAO.ObtenerClientes();
        }

        public void DescontarSaldoVuelo(int iDCliente, decimal tV)
        {
            try
            {
                Cliente cliente = clienteDAO.BuscarClientePorID(iDCliente);
                if(cliente == null) throw new Exception("El cliente no existe.");
                cliente.SaldoHorasVuelo -= tV;
                clienteDAO.ModificarCliente(cliente);
            }

            catch (Exception ex)
            {

                throw new Exception("BLL Cliente Error al actualizar saldo Vuelo" + ex.Message, ex);
            }
        }
        public void AcreditarSaldoVuelo(int iDCliente, decimal tV)
        {
            try
            {
                Cliente cliente = clienteDAO.BuscarClientePorID(iDCliente);
                if (cliente == null) throw new Exception("El cliente no existe.");
                cliente.SaldoHorasVuelo += tV;
                clienteDAO.ModificarCliente(cliente);
            }

            catch (Exception ex)
            {

                throw new Exception("BLL Cliente Error al actualizar saldo Vuelo" + ex.Message, ex);
            }
        }

        public Cliente BuscarClientePorID(int iDCliente)
        {
            try
            {
                if(iDCliente <= 0|| iDCliente ==null) throw new ArgumentException("El ID del cliente debe ser un número positivo o no nulo.", nameof(iDCliente));

                return clienteDAO.BuscarClientePorID(iDCliente);
             
            }
            catch (Exception ex)
            {
                throw new Exception("BLL Cliente Error al buscar cliente por ID" + ex.Message, ex);
            }
                       
        }

        internal void DescontarHorasSimulador(int iDCliente, decimal tS)
        {
            try
            {
                Cliente cliente = clienteDAO.BuscarClientePorID(iDCliente);
                if (cliente == null) throw new Exception("El cliente no existe.");
                cliente.SaldoHorasSimulador -= tS;
                clienteDAO.ModificarCliente(cliente);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Cliente error al descontar horas simulador: " + ex.Message,ex);
            }
        }

        internal void AcreditarSaldoSimulador(int iDCliente, decimal tS)
        {
            try
            {
                Cliente cliente = clienteDAO.BuscarClientePorID(iDCliente);
                if (cliente == null) throw new Exception("El cliente no existe.");
                cliente.SaldoHorasSimulador += tS;
                clienteDAO.ModificarCliente(cliente);
            }
            catch (Exception ex)
            {

                throw new Exception ("BLL Cliente error al acreditar horas simulador"+ex.Message,ex);
            }
        }
    }
}
