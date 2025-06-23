using DAL;
using ENTITY;
using MAPPER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InstructorBLL
    {
        private readonly InstructorDAL InstructorDAO;
        public InstructorBLL()
        {
            InstructorDAO = new InstructorDAL();
        }

        public  Instructor BuscarPersonaPorDni(long dNI)
        {
            try
            {
                return InstructorDAO.BuscarPersonaPorDNI(dNI);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AltaInstructor(Instructor instructorAlta)
        {
            try
            {
                if (string.IsNullOrEmpty(instructorAlta.Licencia)) throw new ArgumentException("La licencia es obligatoria para el instructor.");
                if (instructorAlta ==null) throw new ArgumentNullException(nameof(instructorAlta), "El instructor no puede ser nulo.");
                if(InstructorDAO.BuscarInstructorPorDNI(instructorAlta.DNI) != null) throw new Exception("El instructor con ese DNI ya existe.");
                if(string.IsNullOrWhiteSpace(instructorAlta.Nombre)) throw new ArgumentException("El nombre del instructor no puede estar vacío.", nameof(instructorAlta.Nombre));
                if(string.IsNullOrWhiteSpace(instructorAlta.Apellido)) throw new ArgumentException("El apellido del instructor no puede estar vacío.", nameof(instructorAlta.Apellido));
                if(string.IsNullOrWhiteSpace(instructorAlta.CuitCuil)) throw new ArgumentException("El CUIT/CUIL del instructor no puede estar vacío.", nameof(instructorAlta.CuitCuil));
                instructorAlta.Activo = true; // Por defecto, al dar de alta, el instructor está activo

                InstructorDAO.AltaInstructor(instructorAlta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Instructor> ObtenerInstructores()
        {
            try
            {
                return InstructorDAO.ObtenerInstructores();
            }
            catch (Exception ex)
            {
               
                throw new Exception("Error al obtener los instructores.", ex);
            }
        }

        public void ModificarInstructor(Instructor instructorMod)
        {
            try
            {
                Instructor instructor = new Instructor();
                if (string.IsNullOrEmpty(instructorMod.Licencia)) throw new ArgumentException("La licencia es obligatoria para el instructor.");
                if (instructorMod == null) throw new ArgumentNullException(nameof(instructorMod), "El instructor no puede ser nulo.");
                if (InstructorDAO.BuscarInstructorPorDNI(instructorMod.DNI) != null) throw new Exception("El instructor con ese DNI ya existe.");
                if (string.IsNullOrWhiteSpace(instructorMod.Nombre)) throw new ArgumentException("El nombre del instructor no puede estar vacío.", nameof(instructorMod.Nombre));
                if (string.IsNullOrWhiteSpace(instructorMod.Apellido)) throw new ArgumentException("El apellido del instructor no puede estar vacío.", nameof(instructorMod.Apellido));
                if (string.IsNullOrWhiteSpace(instructorMod.CuitCuil)) throw new ArgumentException("El CUIT/CUIL del instructor no puede estar vacío.", nameof(instructorMod.CuitCuil));
                instructor = InstructorDAO.BuscarPersonaPorDNI(instructorMod.DNI);
                if (instructor != null && instructor.IDPersona != instructorMod.IDPersona) throw new Exception("Ya existe otra persona registrada con este DNI");
                InstructorDAO.ModificarInstructor(instructorMod);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void BajaInstructor(int idInstructorBaja)
        {
            try
            {
                Instructor InstructorBaja = InstructorDAO.BuscarInstructorPorId(idInstructorBaja);
                if (InstructorBaja == null) throw new Exception("No se encontró el instructor a eliminar.");
                InstructorDAO.BajaInstructor(idInstructorBaja);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ModifcarPersonaExistente(Instructor instructorAlta)
        {
            try
            {
                InstructorDAO.ModificarPersonaExistente(instructorAlta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Instructor BuscarInstructorPorID(int idInstructor)
        {
            try
            {
                return InstructorDAO.BuscarInstructorPorId(idInstructor);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Instrucotr Error al buscar instructor por ID" + ex.Message, ex);
            }
        }
    }
}
