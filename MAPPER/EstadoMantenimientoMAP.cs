using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public class EstadoMantenimientoMAP
    {
        public static void MapearDesdeDB(EstadoMantenimiento estado, DataRow row)
        {
            estado.IdEstadoMantenimiento = Convert.ToInt32(row["Id_Estado_Mantenimiento"]);
            estado.Descripcion = row["Descripcion"].ToString();
        }

        public static void MapearHaciaDB(EstadoMantenimiento estado, DataRow row)
        {
            row["Id_Estado_Mantenimiento"] = estado.IdEstadoMantenimiento;
            row["Descripcion"] = estado.Descripcion;
        }
    }
}
