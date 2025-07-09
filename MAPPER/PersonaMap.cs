using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MAPPER
{
    public class PersonaMap
    {
        public static void MapearPersonaHaciaDB(Persona unaPersona, DataRow rowAltaPersona)
        {
            try
            {
                rowAltaPersona["Id_Persona"] = unaPersona.IDPersona;
                rowAltaPersona["Dni"] = unaPersona.DNI;
                rowAltaPersona["Cuit_Cuil"] = unaPersona.CuitCuil;
                rowAltaPersona["Nombre"] = unaPersona.Nombre;
                rowAltaPersona["Apellido"] = unaPersona.Apellido;
                rowAltaPersona["Fecha_Nacimiento"] = unaPersona.FechaNacimiento.ToString("dd/MM/yyyy");
                rowAltaPersona["Telefono"] = unaPersona.Telefono ?? string.Empty;
                rowAltaPersona["Email"] = unaPersona.Email ?? string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("MAP Persona error: " + ex.Message, ex);
            }

        }

        public static void MapearPesonaDesdeDB(Persona unaPersona,DataRow personaRow)
        {
            try
            {
                if (personaRow == null || unaPersona == null)
                    throw new ArgumentNullException("Los parámetros no pueden ser nulos.");
                // Atributos heredados desde Persona
                unaPersona.IDPersona = Convert.ToInt32(personaRow["Id_Persona"]);
                unaPersona.DNI = Convert.ToInt64(personaRow["Dni"]);
                unaPersona.CuitCuil = personaRow["Cuit_Cuil"].ToString();
                unaPersona.Nombre = personaRow["Nombre"].ToString();
                unaPersona.Apellido = personaRow["Apellido"].ToString();
                unaPersona.FechaNacimiento = DateTime.ParseExact(personaRow["Fecha_Nacimiento"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                unaPersona.Telefono = personaRow.Table.Columns.Contains("Telefono") ? personaRow["Telefono"]?.ToString() : null;
                unaPersona.Email = personaRow.Table.Columns.Contains("Email") ? personaRow["Email"]?.ToString() : null;

            }
            catch (Exception ex)
            {
                throw new Exception("MAP Persona error: " + ex.Message, ex);
            }
      
        }
    }
}
