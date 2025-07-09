using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public class MecanicoMAP
    {
        public static void MapearMecanicoDesdeDB(Mecanico mecanico, DataRow row)
        {
            try
            {
                mecanico.IdMecanico = Convert.ToInt32(row["Id_Mecanico"]);
                mecanico.MatriculaTecnica = row["Matricula_Tecnica"].ToString();
                mecanico.DireccionTaller = row["Direccion_Taller"].ToString();
                mecanico.Activo = Convert.ToBoolean(row["Activo"]);
                // La carga de TiposDeMantenimiento se hará por separado desde la tabla intermedia
            }
            catch (Exception ex)
            {
                throw new Exception("MAP Mecanico error: " + ex.Message, ex);
            }

           
        }

        public static void MapearMecanicoHaciaDB(Mecanico mecanico, DataRow row)
        {
            try
            {
                row["Id_Mecanico"] = mecanico.IdMecanico;
                row["Matricula_Tecnica"] = mecanico.MatriculaTecnica;
                row["Direccion_Taller"] = mecanico.DireccionTaller;
                row["Activo"] = mecanico.Activo;
                row["Id_Persona"] = mecanico.IDPersona; // heredado de Persona
            }
            catch (Exception ex)
            {
                throw new Exception("MAP Mecanico error: " + ex.Message, ex);
            }
          
        }
    }
}
