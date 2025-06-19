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
            bitacora.IdBitacora = Convert.ToInt32(row["Id_Bitacora"]);
            bitacora.Descripcion = row["Descripcion"].ToString();
            bitacora.FechaRegistro = DateTime.ParseExact(row["Fecha_Registro"].ToString(),"dd-MM-yyyy HH.mm",CultureInfo.InvariantCulture);
            bitacora.Id_Usuario = Convert.ToInt32(row["Id_Usuario"]);
        }

        public static void MapearHaciaDB(Bitacora bitacora, DataRow row)
        {
            row["Id_Bitacora"] = bitacora.IdBitacora;
            row["Descripcion"] = bitacora.Descripcion;
            row["Fecha_Registro"] = bitacora.FechaRegistro.ToString("dd-MM-yyyy HH.mm");
            row["Id_Usuario"] = bitacora.Id_Usuario;
        }
    }

}
