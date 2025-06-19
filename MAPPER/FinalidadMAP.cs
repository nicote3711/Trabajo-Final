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
            finalidad.IdFinalidad = Convert.ToInt32(row["Id_Finalidad"]);
            finalidad.Descripcion = row["Descripcion"].ToString();
        }

        public static void MapearHaciaDB(Finalidad finalidad, DataRow row)
        {

            row["Id_Finalidad"] = finalidad.IdFinalidad;
            row["Descripcion"] = finalidad.Descripcion;
        }
    }
}
