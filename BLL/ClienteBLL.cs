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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }
        }

        public Cliente BuscarPersonaPorDni(long dNI)
        {
            try
            {
                return clienteDAO.BuscarPersonaPorDNI(dNI);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ModifcarPersonaExistente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void ModificarCliente(Cliente clienteMod)
        {
            try
            {
                clienteDAO.ModificarCliente(clienteMod);
            }
            catch (Exception)
            {

                throw;
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
               return clienteDAO.BuscarClientePorID(iDCliente);
             
            }
            catch (Exception ex)
            {
                throw new Exception("BLL Cliente Error al buscar cliente por ID" + ex.Message, ex);
            }
                       
        }
    }
}
