using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public static class SolicitudHorasMAP
    {
        public static void MapearDesdeDB(SolicitudHoras solicitud, DataRow row)
        {
            try
            {
                solicitud.IdSolicitudHoras = Convert.ToInt32(row["Id_Solicitud_Horas"]);
                solicitud.FechaSolicitud = DateTime.ParseExact(row["Fecha_Solicitud"].ToString(), "dd/MM/yyyy", null);
                solicitud.Cliente = new Cliente { IDCliente = Convert.ToInt32(row["Id_Cliente"]) };
                solicitud.CantidadHorasVuelo = Convert.ToDecimal(row["Cantidad_Horas_Vuelo"]);
                solicitud.CantidadHorasSimulador = Convert.ToDecimal(row["Cantidad_Horas_Simulador"]);
                solicitud.ValorHoraVuelo = Convert.ToDecimal(row["Valor_Hora_Vuelo"]);
                solicitud.ValorHoraSimulador = Convert.ToDecimal(row["Valor_Hora_Simulador"]);

                solicitud.Factura = string.IsNullOrEmpty(row["Id_Factura"].ToString()) ? null : new FacturaSolicitudHoras { IdFactura = Convert.ToInt32(row["Id_Factura"]) };
            }
            catch (Exception ex)
            {
                throw new Exception("MAP SolicitudHoras error: " + ex.Message, ex);
            }          
        }

        public static void MapearHaciaDB(SolicitudHoras solicitud, DataRow row)
        {

            try
            {
                row["Id_Solicitud_Horas"] = solicitud.IdSolicitudHoras;
                row["Fecha_Solicitud"] = solicitud.FechaSolicitud.ToString("dd/MM/yyyy");
                row["Id_Cliente"] = solicitud.Cliente.IDCliente;
                row["Cantidad_Horas_Vuelo"] = solicitud.CantidadHorasVuelo;
                row["Cantidad_Horas_Simulador"] = solicitud.CantidadHorasSimulador;
                row["Valor_Hora_Vuelo"] = solicitud.ValorHoraVuelo;
                row["Valor_Hora_Simulador"] = solicitud.ValorHoraSimulador;
                row["Id_Factura"] = solicitud.Factura == null ? DBNull.Value : solicitud.Factura.IdFactura;
            }
            catch (Exception ex)
            {
                throw new Exception("MAP SolicitudHoras error: " + ex.Message, ex);
            }           
        }
    }
}
