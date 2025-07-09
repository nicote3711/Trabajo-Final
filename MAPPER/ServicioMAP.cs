using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public static class ServicioMAP
    {
        public static void MapearDesdeDB(Servicio servicio, DataRow row)
        {
            try
            {
                servicio.IdServicio = Convert.ToInt32(row["Id_Servicio"]);
                servicio.Descripcion = row["Descripcion"].ToString();
                servicio.Precio = Convert.ToDecimal(row["Precio_Hora"]);
            }
            catch (Exception ex)
            {
                throw new Exception("MAP Servicio error: " + ex.Message, ex);
            }         
        }

        public static void MapearHaciaDB(Servicio servicio, DataRow row)
        {
            try
            {
                row["Id_Servicio"] = servicio.IdServicio;
                row["Descripcion"] = servicio.Descripcion;
                row["Precio_Hora"] = servicio.Precio;
            }
            catch (Exception ex)
            {
                throw new Exception("MAP Servicio error: " + ex.Message, ex);
            }
        }
    }
}
