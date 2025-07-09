using ENTITY.Bitacora;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER.MAPBitacora
{
    public class BitacoraMAP
    {
        public static void MapearDesdeDB(Bitacora bitacora, DataRow row)
        {
            try
            {
                bitacora.IdBitacora = Convert.ToInt32(row["Id_Bitacora"]);
                bitacora.Descripcion = row["Descripcion"].ToString();
                bitacora.FechaRegistro = DateTime.ParseExact(row["Fecha_Registro"].ToString(), "dd-MM-yyyy HH.mm", CultureInfo.InvariantCulture);
                bitacora.Id_Usuario = Convert.ToInt32(row["Id_Usuario"]);
            }
            catch (Exception ex)
            {
                throw new Exception("MAP bitacora error: " + ex.Message, ex);
            }

          
        }

        public static void MapearHaciaDB(Bitacora bitacora, DataRow row)
        {
            try
            {
                row["Id_Bitacora"] = bitacora.IdBitacora;
                row["Descripcion"] = bitacora.Descripcion;
                row["Fecha_Registro"] = bitacora.FechaRegistro.ToString("dd-MM-yyyy HH.mm");
                row["Id_Usuario"] = bitacora.Id_Usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("MAP bitacora error: " + ex.Message, ex);
            }

           
        }
    }

}
