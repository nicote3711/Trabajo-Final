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
            try
            {
                item.IdComponente = Convert.ToInt32(row["Id_Permiso"]);
                item.NombreComponente = row["Nombre"].ToString();
            }
            catch (Exception ex)
            {

                throw new Exception("Map permisoitem error :"+ex.Message,ex);
            }
          
            
        }

        public static void MapearHaciaDB(PermisoItem item, DataRow row)
        {
            try
            {
                row["Id_Permiso"] = item.IdComponente;
                row["Nombre"] = item.NombreComponente;
                row["Es_Item"] = item.EsHoja();
            }
            catch (Exception ex)
            {

                throw new Exception("Map error: "+ex.Message,ex);
            }
            
        }
    }
}

