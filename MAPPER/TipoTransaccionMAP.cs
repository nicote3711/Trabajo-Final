using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public class TipoTransaccionMAP
    {
        public static void MapearDesdeDB(TipoTransaccion tipoTransaccion, DataRow row)
        {
            try
            {
                tipoTransaccion.IdTipoTransaccion = Convert.ToInt32(row["Id_Tipo_Transaccion"]);
                tipoTransaccion.Descripcion = row["Descripcion"].ToString();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public static void MapearHaciaDB(TipoTransaccion tipoTransaccion, DataRow row)
        {
            try
            {
                row["Id_Tipo_Transaccion"] = tipoTransaccion.IdTipoTransaccion;
                row["Descripcion"] = tipoTransaccion.Descripcion;
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}
