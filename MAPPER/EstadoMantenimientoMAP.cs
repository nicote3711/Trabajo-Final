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
            try
            {
                estado.IdEstadoMantenimiento = Convert.ToInt32(row["Id_Estado_Mantenimiento"]);
                estado.Descripcion = row["Descripcion"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("MAP Estado Mantenimiento error: " + ex.Message, ex);
            }

          
        }

        public static void MapearHaciaDB(EstadoMantenimiento estado, DataRow row)
        {
            try
            {
                row["Id_Estado_Mantenimiento"] = estado.IdEstadoMantenimiento;
                row["Descripcion"] = estado.Descripcion;
            }
            catch (Exception ex)
            {
                throw new Exception("MAP Estado Mantenimiento error: " + ex.Message, ex);
            }
          
        }
    }
}
