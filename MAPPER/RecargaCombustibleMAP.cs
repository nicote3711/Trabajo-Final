using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public static class RecargaCombustibleMAP
    {
        public static void MapearDesdeDB(RecargaCombustible recarga, DataRow row)
        {
            try
            {
                recarga.IdRecargaCombustible = Convert.ToInt32(row["Id_Recarga_Combustible"]);
                recarga.Fecha = DateTime.ParseExact(row["Fecha"].ToString(), "dd/MM/yyyy", null);
                recarga.CantidadLitros = Convert.ToDecimal(row["Cantidad_Litros"]);
                recarga.PrecioLitros = Convert.ToDecimal(row["Precio_Litro"]);

                recarga.DepositoCombu = new DepositoCombustible
                {
                    IdDepositoCombustible = Convert.ToInt32(row["Id_Deposito_Combustible"])
                };

                recarga.ProveedorCombu = new ProveedorCombustible
                {
                    IdProveedorCombustible = Convert.ToInt32(row["Id_Proveedor_Combustible"])
                };

                recarga.FacturaCombu = string.IsNullOrEmpty(row["Id_Factura"].ToString()) ? null : new FacturaCombustible { IdFactura = Convert.ToInt32(row["Id_Factura"]) };
            }
            catch (Exception ex)
            {
                throw new Exception("MAP RecargarCombustible error: " + ex.Message, ex);
            }

         
        }

        public static void MapearHaciaDB(RecargaCombustible recarga, DataRow row)
        {
            try
            {

                row["Id_Recarga_Combustible"] = recarga.IdRecargaCombustible;
                row["Fecha"] = recarga.Fecha.ToString("dd/MM/yyyy");
                row["Cantidad_Litros"] = recarga.CantidadLitros;
                row["Precio_Litro"] = recarga.PrecioLitros;
                row["Id_Deposito_Combustible"] = recarga.DepositoCombu.IdDepositoCombustible;
                row["Id_Proveedor_Combustible"] = recarga.ProveedorCombu.IdProveedorCombustible;
                row["Id_Factura"] = recarga.FacturaCombu == null ? DBNull.Value : recarga.FacturaCombu.IdFactura;
            }
            catch (Exception ex)
            {
                throw new Exception("MAP Recarga Combustible error: " + ex.Message, ex);
            }

        }
    }
}
