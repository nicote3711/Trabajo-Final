﻿using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public class TipoMantenimientoMAP
    {
        public static void MapearTipoMantenimientoDesdeDB(TipoMantenimiento tipo, DataRow row)
        {
            tipo.IdTipoMantenimiento = Convert.ToInt32(row["Id_Tipo_Mantenimiento"]);
            tipo.Descripcion = row["Descripcion"].ToString();
        }

        public static void MapearTipoMantenimientoHaciaDB(TipoMantenimiento tipo, DataRow row)
        {
            row["Id_Tipo_Mantenimiento"] = tipo.IdTipoMantenimiento;
            row["Descripcion"] = tipo.Descripcion;
        }
    }
}
