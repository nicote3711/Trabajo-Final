using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public class SimuladorMAP
    {
        public static void MapearDesdeDB(Simulador simulador, DataRow row)
        {
            simulador.IdSimulador = Convert.ToInt32(row["Id_Simulador"]);
            simulador.Fecha = DateTime.ParseExact(row["Fecha"].ToString(), "dd/MM/yyyy", null);
            simulador.HoraInicio = TimeOnly.Parse(row["Hora_Inicio"].ToString());
            simulador.HoraFin = TimeOnly.Parse(row["Hora_Fin"].ToString());

            simulador.Instructor = new Instructor { IdInstructor = Convert.ToInt32(row["Id_Instructor"]) };
            simulador.Cliente = new Cliente { IDCliente = Convert.ToInt32(row["Id_Cliente"]) };
            simulador.Finalidad = new Finalidad { IdFinalidad = Convert.ToInt32(row["Id_Finalidad"]) };
            simulador.Finalidad= string.IsNullOrEmpty(row["Id_Finalidad"].ToString()) ? null : new Finalidad { IdFinalidad = Convert.ToInt32(row["Id_Finalidad"]) };    
            
            // Version larga del if
            /*if (!string.IsNullOrEmpty(row["Id_Liquidacion"].ToString()))
            {
                simulador.Liquidacion = new LiquidacionInstructor { IdLiquidacionServicio = Convert.ToInt32(row["Id_Liquidacion"]) };
            }
            else
            {
                simulador.Liquidacion = null;
            }*/
        }

        public static void MapearHaciaDB(Simulador simulador, DataRow row)
        {
            row["Id_Simulador"] = simulador.IdSimulador;
            row["Fecha"] = simulador.Fecha.ToString("dd/MM/yyyy");
            row["Hora_Inicio"] = simulador.HoraInicio.ToString("HH:mm");
            row["Hora_Fin"] = simulador.HoraFin.ToString("HH:mm");
            row["TS"] = simulador.TS; 
            row["Id_Instructor"] = simulador.Instructor.IdInstructor;
            row["Id_Cliente"] = simulador.Cliente.IDCliente;
            row["Id_Liquidacion"] = simulador.Liquidacion==null? DBNull.Value:simulador.Liquidacion.IdLiquidacionServicio;
            row["Id_Finalidad"] = simulador.Finalidad.IdFinalidad;
        }
    }
}

