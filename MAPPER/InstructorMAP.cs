using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public class InstructorMAP
    {
        public static void MapearInstructorHaciaDB(Instructor instructor,DataRow row)
        {
            try
            {
                row["Id_Instructor"] = instructor.IdInstructor;
                row["Id_Persona"] = instructor.IDPersona;
                row["Licencia"] = instructor.Licencia;
                row["Activo"] = instructor.Activo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void MapearInstructorDesdeDB(Instructor instructor,DataRow row)
        {
            try
            {
                if (row == null || instructor == null) throw new ArgumentNullException("Los parámetros no pueden ser nulos.");
                instructor.IdInstructor = Convert.ToInt32(row["Id_Instructor"]);
                instructor.Licencia = row["Licencia"].ToString(); // para instructor, la licencia es obligatoria
                instructor.Activo = Convert.ToBoolean(row["Activo"]);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
