using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public static class LiquidacionServicioMAP
    {
        public static void MapearDesdeDB(LiquidacionServicio liquidacion, DataRow row)
        {
            liquidacion.IdLiquidacionServicio = Convert.ToInt32(row["Id_Liquidacion_Servicio"]);

            // Parse de string MM/yyyy a DateTime (se asume día 1 del mes)
            liquidacion.Periodo = DateTime.ParseExact(row["Periodo"].ToString(), "MM/yyyy", null);

            liquidacion.CantHoras = Convert.ToDecimal(row["Cantidad_Horas"]);

            liquidacion.MontoTotal = Convert.ToDecimal(row["Monto_Total"]);

            if(liquidacion.Servicio.IdServicio != Convert.ToInt32(row["Id_Servicio"])) throw new Exception("Error al mapear LiquidacionServicio: IdServicio no coincide con el objeto Servicio asociado en Base de Datos.");

            liquidacion.Servicio.IdServicio = Convert.ToInt32(row["Id_Servicio"]); //las liquidaciones ya crean su objeto servicio porque son de un tipo especifico y deberian saber si Id ademas.

            liquidacion.IdPersona = Convert.ToInt32(row["Id_Persona"]);          
        }

        public static void MapearHaciaDB(LiquidacionServicio liquidacion, DataRow row)
        {
            row["Id_Liquidacion_Servicio"] = liquidacion.IdLiquidacionServicio;

            // Guardar como string en formato MM/yyyy
            row["Periodo"] = liquidacion.Periodo.ToString("MM/yyyy");
            row["Cantidad_Horas"] = liquidacion.CantHoras;
            row["Monto_Total"] = liquidacion.MontoTotal;
            row["Id_Servicio"] = liquidacion.Servicio.IdServicio;
            row["Id_Persona"] = liquidacion.IdPersona;
            row["Id_Factura"] = liquidacion.IdFactura == null? DBNull.Value:(object)liquidacion.IdFactura;
        }
    }
}
