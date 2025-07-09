using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public static class FacturaMAP
    {
        public static void MapearDesdeDB(Factura factura, DataRow row)
        {
            try
            {
                factura.IdFactura = Convert.ToInt32(row["Id_Factura"]);
                factura.NroFactura = Convert.ToInt32(row["Nro_Factura"]);
                factura.CuilEmisor = row["Cuil_Emisor"].ToString();
                factura.FechaFactura = DateTime.ParseExact(row["Fecha_Factura"].ToString(), "dd/MM/yyyy", null);
                factura.MontoTotal = Convert.ToDecimal(row["Monto_Total"]);
                factura.Detalle = row["Detalle"].ToString();
                factura.TipoFactura = new TipoFactura { IdTipoFactura = Convert.ToInt32(row["Id_Tipo_Factura"]) };
            }
            catch (Exception ex)
            {
                throw new Exception("MAP Factura error: " + ex.Message, ex);
            }
 
        }

        public static void MapearHaciaDB(Factura factura, DataRow row)
        {
            try
            {
                row["Id_Factura"] = factura.IdFactura;
                row["Nro_Factura"] = factura.NroFactura;
                row["Cuil_Emisor"] = factura.CuilEmisor;
                row["Fecha_Factura"] = factura.FechaFactura.ToString("dd/MM/yyyy");
                row["Monto_Total"] = factura.MontoTotal;
                row["Detalle"] = factura.Detalle;
                row["Id_Tipo_Factura"] = factura.TipoFactura.IdTipoFactura;
            }
            catch (Exception ex)
            {
                throw new Exception("MAP Factura error: " + ex.Message, ex);
            }
 
        }
    }
}
