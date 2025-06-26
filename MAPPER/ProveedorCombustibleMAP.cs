using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public static class ProveedorCombustibleMAP
    {
        public static void MapearDesdeDB(ProveedorCombustible proveedor, DataRow row)
        {
            try
            {
                proveedor.IdProveedorCombustible = Convert.ToInt32(row["Id_Proveedor_Combustible"]);
                proveedor.NombreEmpresa = row["Nombre_Empresa"].ToString();
                proveedor.Cuit = row["CUIT"].ToString();
                proveedor.TelefonoContacto = row["Telefono_Contacto"].ToString();
                proveedor.DomicilioFiscal = row["Domicilio_Fiscal"].ToString();
                proveedor.Activo = Convert.ToBoolean(row["Activo"]);
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public static void MapearHaciaDB(ProveedorCombustible proveedor, DataRow row)
        {
            try
            {
                row["Id_Proveedor_Combustible"] = proveedor.IdProveedorCombustible;
                row["Nombre_Empresa"] = proveedor.NombreEmpresa;
                row["Cuit"] = proveedor.Cuit;
                row["Telefono_Contacto"] = proveedor.TelefonoContacto;
                row["Domicilio_Fiscal"] = proveedor.DomicilioFiscal;
                row["Activo"] = proveedor.Activo;
            }
            catch (Exception)
            {

                throw;
            }
         
        }
    }
}
