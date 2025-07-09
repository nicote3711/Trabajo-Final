using ENTITY.Composite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER.Composite
{
    public class RolMAP
    {
        public static void MapearDesdeDB(Rol rol, DataRow row)
        {
            try
            {
                rol.IdComponente = Convert.ToInt32(row["Id_Rol"]);
                rol.NombreComponente = row["Nombre"].ToString();
            }
            catch (Exception ex)
            {

                throw new Exception("MAP rol error: "+ex.Message,ex) ;
            }
          
        }

        public static void MapearHaciaDB(Rol rol, DataRow row)
        {
            try
            {
                row["Id_Rol"] = rol.IdComponente;
                row["Nombre"] = rol.NombreComponente;
            }
            catch (Exception ex)
            {
                throw new Exception("MAP rol error: " + ex.Message, ex);
            }

            
        }
    }
}
