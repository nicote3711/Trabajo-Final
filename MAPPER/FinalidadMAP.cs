using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public class FinalidadMAP
    {
        public static void MapearDesdeDB(Finalidad finalidad, DataRow row)
        {
            try
            {
                finalidad.IdFinalidad = Convert.ToInt32(row["Id_Finalidad"]);
                finalidad.Descripcion = row["Descripcion"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("MAP Finalidad error: " + ex.Message, ex);
            }

            
        }

        public static void MapearHaciaDB(Finalidad finalidad, DataRow row)
        {
            try
            {
                row["Id_Finalidad"] = finalidad.IdFinalidad;
                row["Descripcion"] = finalidad.Descripcion;
            }
            catch (Exception ex)
            {
                throw new Exception("MAP Finalidad error: " + ex.Message, ex);
            }
          
        }
    }
}
