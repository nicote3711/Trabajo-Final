using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public class AeronaveMAP
    {
        public static void MapearDesdeDB(Aeronave aeronave, DataRow row)
        {
            try
            {
                aeronave.IdAeronave = Convert.ToInt32(row["Id_Aeronave"]);
                aeronave.Matricula = row["Matricula"].ToString();
                aeronave.Marca = row["Marca"].ToString();
                aeronave.Modelo = row["Modelo"].ToString();
                aeronave.Año = Convert.ToInt32(row["Año"]);
                aeronave.Revision100Hs = Convert.ToDecimal(row["Revision100Hs"]);
                aeronave.RevisionAnual = DateTime.ParseExact(row["RevisionAnual"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                // NO se mapea ni Estado ni Dueño aquí
            }
            catch (Exception ex)
            {
                throw new Exception("MAP Aeronave error: " + ex.Message, ex);
            }

           
        }

        public static void MapearHaciaDB(Aeronave aeronave, DataRow row)
        {
            try
            {
                row["Id_Aeronave"] = aeronave.IdAeronave;
                row["Matricula"] = aeronave.Matricula;
                row["Marca"] = aeronave.Marca;
                row["Modelo"] = aeronave.Modelo;
                row["Año"] = aeronave.Año;
                row["Revision100Hs"] = aeronave.Revision100Hs;
                row["RevisionAnual"] = aeronave.RevisionAnual.ToString("dd/MM/yyyy");
                row["Id_Estado_Aeronave"] = aeronave.Estado.IdEstadoAeronave;
                row["Id_Dueno"] = aeronave.Dueno != null ? aeronave.Dueno.IdDueno : DBNull.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("MAP Aeronave error: " + ex.Message, ex);
            }

         
        }
    }
}

