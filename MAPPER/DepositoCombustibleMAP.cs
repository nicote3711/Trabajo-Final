using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public static class DepositoCombustibleMAP
    {
        public static void MapearDesdeDB(DepositoCombustible deposito, DataRow row)
        {
            try
            {
                deposito.IdDepositoCombustible = Convert.ToInt32(row["Id_Deposito_Combustible"]);
                deposito.Capacidad = Convert.ToDecimal(row["Capacidad"]);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void MapearHaciaDB(DepositoCombustible deposito, DataRow row)
        {
            try
            {
                row["Id_Deposito_Combustible"] = deposito.IdDepositoCombustible;
                row["Capacidad"] = deposito.Capacidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
