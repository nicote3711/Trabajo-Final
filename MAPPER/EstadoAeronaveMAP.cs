using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public class EstadoAeronaveMAP
    {
        public static void MapearDesdeDB(EstadoAeronave estado, DataRow row)
        {
            estado.IdEstadoAeronave = Convert.ToInt32(row["Id_Estado_Aeronave"]);
            estado.Descripcion = row["Descripcion"].ToString();
        }

        public static void MapearHaciaDB(EstadoAeronave estado, DataRow row)
        {
            row["Id_Estado_Aeronave"] = estado.IdEstadoAeronave;
            row["Descripcion"] = estado.Descripcion;
        }
    }
}
