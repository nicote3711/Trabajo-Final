using ENTITY;
using MAPPER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using Helper;

namespace DAL
{
    public class ClienteDAL
    {
        
        ClienteMap ClienteMap = new ClienteMap();
        private  string rutaXml = HelperD.ObtenerConexionXMl();

        public void AltaCliente(Cliente cliente)
        {
            try
            {
                if (cliente == null) throw new ArgumentNullException(nameof(cliente));
                if (!File.Exists(rutaXml)) throw new Exception("El archivo no existe");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);
                var personas = ds.Tables["Persona"];
                var clientes = ds.Tables["Cliente"];
                
                DataRow personaEistente = personas.AsEnumerable().FirstOrDefault(row=> row.Field<long>("DNI")==cliente.DNI);
                if(personaEistente != null)
                {
                    //Si ya existe una persona con el mismo DNI, asigno su ID al cliente
                    cliente.IDPersona = Convert.ToInt32(personaEistente["Id_Persona"]);
                }
                else
                {
                    int proximoIDPersona = HelperD.ObtenerProximoID(personas, "Id_Persona");
                    cliente.IDPersona = proximoIDPersona;
                    DataRow rowAltaPersona = personas.NewRow();
                    PersonaMap.MapearPersonaHaciaDB(cliente, rowAltaPersona);
                    personas.Rows.Add(rowAltaPersona);
                }

                    
                int proximoIDCliente = HelperD.ObtenerProximoID(clientes, "Id_Cliente");
                cliente.IDCliente = proximoIDCliente;
                DataRow rowAlataCLiente =  clientes.NewRow();
                ClienteMap.MapearClienteHaciaDB(cliente, rowAlataCLiente);
                clientes.Rows.Add(rowAlataCLiente);
                
                ds.WriteXml(rutaXml,XmlWriteMode.WriteSchema);
            }
            catch (Exception)
            {

                throw;
            }
        }

       /* private int ObtenerProximoId(DataTable? tablaObjetivo, string nombreColumna)
        {
            if (tablaObjetivo == null || tablaObjetivo.Rows.Count == 0)
                return 1;
            return tablaObjetivo.AsEnumerable().Max(r => r.Field<int>(nombreColumna)) + 1;
        }*/


        public List<Cliente> ObtenerClientes()
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);
                var clientes = ds.Tables["Cliente"];
                var personas = ds.Tables["Persona"];
                if (clientes == null || personas == null) throw new Exception("Tablas 'Clientes' o 'Personas' no encontradas en el XML.");


                List<Cliente> lista = new List<Cliente>();

                foreach (DataRow clienteRow in clientes.Rows)
                {
                    int idPersona = Convert.ToInt32(clienteRow["Id_Persona"]);
                    DataRow personaRow = personas.Select($"Id_Persona = {idPersona}").FirstOrDefault();

                    if (personaRow == null) continue;

                    Cliente cliente = new Cliente();
                    ClienteMap.MapearClienteDesdeDB(cliente, clienteRow);
                    PersonaMap.MapearPesonaDesdeDB(cliente, personaRow); // Mapeo de Persona
                                                                         // Atributos heredados desde Persona

                    lista.Add(cliente);
                }

                return lista;
                
            }
            catch (Exception)
            {
                
                throw;
            }
       
        }

        public Cliente BuscarClientePorDNI(long dni)
        {
            try
            {
                if (!File.Exists(rutaXml))
                    throw new FileNotFoundException("No se encuentra el archivo de datos.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var personas = ds.Tables["Persona"];
                var clientes = ds.Tables["Cliente"];
                
                var personaRow = personas.Select($"Dni = {dni}").FirstOrDefault();
                if (personaRow == null)
                    return null;
               
                int idPersona = Convert.ToInt32(personaRow["Id_Persona"]);
                var clienteRow = clientes.Select($"Id_Persona = {idPersona}").FirstOrDefault();
                if (clienteRow == null)
                    return null;

                Cliente cliente = new Cliente();
                PersonaMap.MapearPesonaDesdeDB(cliente, personaRow);
                ClienteMap.MapearClienteDesdeDB(cliente,clienteRow);

                return cliente;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Cliente BuscarClientePorID(int idCliente)
        {
            try
            {
                if (!File.Exists(rutaXml))
                    throw new FileNotFoundException("No se encuentra el archivo de datos.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);
                var clientes = ds.Tables["Cliente"];
                var personas = ds.Tables["Persona"];
                var clienteRow = clientes.Select($"Id_Cliente = {idCliente}").FirstOrDefault();
                if (clienteRow == null)
                    return null;
                int idPersona = Convert.ToInt32(clienteRow["Id_Persona"]);
                var personaRow = personas.Select($"Id_Persona = {idPersona}").FirstOrDefault();
                if (personaRow == null)
                    return null;
                Cliente cliente = new Cliente();
                PersonaMap.MapearPesonaDesdeDB(cliente, personaRow);
                ClienteMap.MapearClienteDesdeDB(cliente, clienteRow);
                return cliente;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ModificarCliente(Cliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));
            if (!File.Exists(rutaXml)) throw new FileNotFoundException("Archivo XML no encontrado");

            DataSet ds = new DataSet();
            ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

            var tablaPersonas = ds.Tables["Persona"];
            var tablaClientes = ds.Tables["Cliente"];

            var rowPersona = tablaPersonas.Select($"Id_Persona = {cliente.IDPersona}").FirstOrDefault();
            var rowCliente = tablaClientes.Select($"Id_Cliente = {cliente.IDCliente}").FirstOrDefault();

            if (rowPersona == null || rowCliente == null)
                throw new Exception("No se encontró el cliente o la persona a modificar.");

            // Mapear datos actualizados
            PersonaMap.MapearPersonaHaciaDB(cliente, rowPersona);
            ClienteMap.MapearClienteHaciaDB(cliente, rowCliente);

            ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
        }

        
        public void BajaCliente(int idCliente)
        {
            if (!File.Exists(rutaXml)) throw new FileNotFoundException("Archivo XML no encontrado");

            DataSet ds = new DataSet();
            ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

            var tablaClientes = ds.Tables["Cliente"];
            var rowCliente = tablaClientes.Select($"Id_Cliente = {idCliente}").FirstOrDefault();

            if (rowCliente == null)
                throw new Exception("No se encontró el cliente a dar de baja.");

            rowCliente["Activo"] = false;

            ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
        }

        public Cliente BuscarPersonaPorDNI(long dni)
        {
            if (!File.Exists(rutaXml)) throw new FileNotFoundException("Archivo XML no encontrado");

            DataSet ds = new DataSet();
            ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

            var tablaPersonas = ds.Tables["Persona"];
            var row = tablaPersonas?.AsEnumerable().FirstOrDefault(p => Convert.ToInt64(p["Dni"]) == dni);
            if (row == null) return null;

            Cliente persona = new Cliente();
            PersonaMap.MapearPesonaDesdeDB(persona, row);
            return persona;
        }

        public void ModificarPersonaExistente(Persona persona)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);
            var tabla = ds.Tables["Persona"];
            var row = tabla.Select($"Id_Persona = {persona.IDPersona}").FirstOrDefault();
            if (row == null) throw new Exception("No se encontró la persona a modificar.");
            PersonaMap.MapearPersonaHaciaDB(persona, row);
            ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
        }
    }
}
