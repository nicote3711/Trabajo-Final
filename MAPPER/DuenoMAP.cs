using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public class DuenoMAP
    {
        public static void MapearDuenoDesdeDB(Dueno dueno, DataRow row)
        {
            try
            {
                if (row == null || dueno == null)
                    throw new ArgumentNullException("Los parámetros no pueden ser nulos.");

                dueno.IdDueno = Convert.ToInt32(row["Id_Dueno"]);
                dueno.Activo = Convert.ToBoolean(row["Activo"]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void MapearDuenoHaciaDB(Dueno dueno, DataRow row)
        {
            try
            {
                if (row == null || dueno == null)
                    throw new ArgumentNullException("Los parámetros no pueden ser nulos.");

                row["Id_Dueno"] = dueno.IdDueno;
                row["Id_Persona"] = dueno.IDPersona;
                row["Activo"] = dueno.Activo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
