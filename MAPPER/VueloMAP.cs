using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public class VueloMAP
    {
        // Mapea de DataRow a Vuelo (desde la base de datos XML)
        public static void MapearDesdeDB(Vuelo vuelo, DataRow row)
        {
            try
            {
                vuelo.IdVuelo = Convert.ToInt32(row["Id_Vuelo"]);
                vuelo.Fecha = DateTime.Parse(row["Fecha"].ToString());

                vuelo.Aeronave = new Aeronave { IdAeronave = Convert.ToInt32(row["Id_Aeronave"]) };
                vuelo.Instructor = string.IsNullOrEmpty(row["Id_Instructor"].ToString()) ? null : new Instructor { IdInstructor = Convert.ToInt32(row["Id_Instructor"]) };
                vuelo.Cliente = new Cliente { IDCliente = Convert.ToInt32(row["Id_Cliente"]) };
                vuelo.Finalidad = new Finalidad { IdFinalidad = Convert.ToInt32(row["Id_Finalidad"]) };

                vuelo.HoraPM = TimeOnly.Parse(row["Hora_PM"].ToString());
                vuelo.HoraCorte = TimeOnly.Parse(row["Hora_Corte"].ToString());

                vuelo.HubInicial = Convert.ToDecimal(row["Hub_Inicial"]);
                vuelo.HubFinal = Convert.ToDecimal(row["Hub_Final"]);
                vuelo.Liquidado = Convert.ToBoolean(row["Liquidado"]);

                vuelo.Origen = row["Origen"].ToString();
                vuelo.Destino = row["Destino"].ToString();

                // NO mapear vuelo.TV ni vuelo.HubDiff ya que se calculan automáticamente
            }


            catch (Exception)
            {

                throw;
            }
        }
           
        // Mapea de Vuelo a DataRow (hacia la base de datos XML)
        public static void MapearHaciaDB(Vuelo vuelo, DataRow row)
        {
            try
            {
                row["Id_Vuelo"] = vuelo.IdVuelo;
                row["Fecha"] = vuelo.Fecha.ToString("dd/MM/yyyy");

                row["Id_Aeronave"] = vuelo.Aeronave.IdAeronave;
                row["Id_Instructor"] = vuelo.Instructor == null ? DBNull.Value : vuelo.Instructor.IdInstructor;
                row["Id_Cliente"] = vuelo.Cliente.IDCliente;
                row["Id_Finalidad"] = vuelo.Finalidad.IdFinalidad;

                row["Hora_PM"] = vuelo.HoraPM.ToString("HH:mm");
                row["Hora_Corte"] = vuelo.HoraCorte.ToString("HH:mm");

                row["Hub_Inicial"] = vuelo.HubInicial;
                row["Hub_Final"] = vuelo.HubFinal;
                row["TV"] = vuelo.TV;
                row["Hub_Diff"] = vuelo.HubDiff;
                row["Liquidado"] = vuelo.Liquidado;

                row["Origen"] = vuelo.Origen;
                row["Destino"] = vuelo.Destino;
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}
