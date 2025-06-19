using ENTITY.Composite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER.Composite
{
    public class PermisoItemMAP
    {
        public static void MapearDesdeDB(PermisoItem item, DataRow row)
        {
            item.IdComponente = Convert.ToInt32(row["Id_Permiso"]);
            item.NombreComponente = row["Nombre"].ToString();
            
        }

        public static void MapearHaciaDB(PermisoItem item, DataRow row)
        {
            row["Id_Permiso"] = item.IdComponente;
            row["Nombre"] = item.NombreComponente;
            row["Es_Item"] = item.EsHoja();
        }
    }
}

