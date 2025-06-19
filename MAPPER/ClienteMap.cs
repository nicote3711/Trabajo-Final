using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public class ClienteMap
    {

        public static void MapearClienteHaciaDB(Cliente cliente,DataRow row)
        {
            try
            {
                row["Id_Cliente"] = cliente.IDCliente;
                row["Id_Persona"] = cliente.IDPersona;
                row["Licencia"] = cliente.Licencia ?? string.Empty;
                row["Saldo_Horas_Vuelo"] = cliente.SaldoHorasVuelo;
                row["Saldo_Horas_Simulador"] = cliente.SaldoHorasSimulador;
                row["Activo"] = cliente.Activo;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void MapearClienteDesdeDB(Cliente cliente, DataRow row)
        {
            try
            {
                if (row == null || cliente == null)
                    throw new ArgumentNullException("Los parámetros no pueden ser nulos.");

                cliente.IDCliente = Convert.ToInt32(row["Id_Cliente"]);
                cliente.IDPersona = Convert.ToInt32(row["Id_Persona"]);
                cliente.Licencia = row["Licencia"]?.ToString();
                cliente.SaldoHorasVuelo = Convert.ToDecimal(row["Saldo_Horas_Vuelo"]);
                cliente.SaldoHorasSimulador = Convert.ToDecimal(row["Saldo_Horas_Simulador"]);
                cliente.Activo = Convert.ToBoolean(row["Activo"]);
            }
            catch (Exception)
            {

                throw;
            }
         
        }


    }
}
