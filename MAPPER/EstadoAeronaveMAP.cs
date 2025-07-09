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
            try
            {
                estado.IdEstadoAeronave = Convert.ToInt32(row["Id_Estado_Aeronave"]);
                estado.Descripcion = row["Descripcion"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("MAP Estado Aeronave error: " + ex.Message, ex);
            }

            
        }

        public static void MapearHaciaDB(EstadoAeronave estado, DataRow row)
        {
            try
            {
                row["Id_Estado_Aeronave"] = estado.IdEstadoAeronave;
                row["Descripcion"] = estado.Descripcion;
            }
            catch (Exception ex)
            {
                throw new Exception("MAP EstadoAeronave error: " + ex.Message, ex);
            }
        }
    }
}
