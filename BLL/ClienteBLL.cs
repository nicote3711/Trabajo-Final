using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

                ValidarDatosCliente(cliente);
                if (clienteDAO.BuscarClientePorDNI(cliente.DNI) != null) throw new Exception("El cliente con ese DNI ya existe.");
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

        private void ValidarDatosCliente(Cliente cliente)
        {
            try
            {
                //Cliente
                if (cliente == null) throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser nulo.");

                // Persona
                if (cliente.DNI <= 0) throw new ArgumentException("Valor de DNI inválido.");
                if (string.IsNullOrEmpty(cliente.Nombre) || !cliente.Nombre.All(char.IsLetter)) throw new ArgumentException("El nombre es obligatorio y solo puede contener letras.");
                if (string.IsNullOrEmpty(cliente.Apellido) || !cliente.Apellido.All(char.IsLetter))throw new ArgumentException("El apellido es obligatorio y solo puede contener letras.");
                if (string.IsNullOrEmpty(cliente.CuitCuil)) throw new ArgumentException("El CUIT/CUIL es obligatorio.");
                if (cliente.FechaNacimiento.Date > DateTime.Now.AddYears(-18).Date) throw new Exception("El cliente debe ser mayor de edad.");
                if (!Regex.IsMatch(cliente.CuitCuil, $"^\\d{{2}}-{cliente.DNI}-\\d$")) throw new Exception("El CUIT/CUIL no es válido para el DNI del cliente.");
                if (string.IsNullOrEmpty(cliente.Telefono) || !Regex.IsMatch(cliente.Telefono, @"^\d+$")) throw new Exception("El teléfono no puede estar vacío y solo debe contener números.");
                if (string.IsNullOrEmpty(cliente.Email) || !cliente.Email.Contains("@"))throw new Exception("El email ingresado no es válido. Debe contener '@'.");

            }
            catch (Exception ex)
            {

                throw new Exception("BLL Cliente error al validar datos cliente: "+ex.Message,ex);
            }
        }

        public void BajaCliente(int IdCliente)
        {
            try
            {
                if (IdCliente <= 0) throw new Exception("id cliente invalido");
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
                ValidarDatosCliente(clienteMod);
                Cliente cliente = clienteDAO.BuscarPersonaPorDNI(clienteMod.DNI);
                if (cliente != null && clienteMod.IDPersona != cliente.IDPersona) throw new Exception("Ya existe una persona registrada con ese DNI."); // muy importante
              
                clienteDAO.ModificarCliente(clienteMod);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL cliente error al modificar cliente: "+ ex.Message,ex);
            }
        }

        public List<Cliente> ObtenerClientes()
        {
            try
            {
                return clienteDAO.ObtenerClientes();

            }
            catch (Exception ex)
            {

                throw new Exception("BLL Cliente error al obtener los clientes: "+ex.Message,ex);
            }
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

                throw new Exception("BLL Cliente Error al descontar saldo Vuelo" + ex.Message, ex);
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

                throw new Exception("BLL Cliente Error al acreditar saldo Vuelo" + ex.Message, ex);
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

        public void DescontarHorasSimulador(int iDCliente, decimal tS)
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

        public void AcreditarSaldoSimulador(int iDCliente, decimal tS)
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
