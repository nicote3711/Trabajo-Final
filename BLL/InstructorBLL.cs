using DAL;
using ENTITY;
using MAPPER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            catch (Exception ex)
            {

                throw new Exception("BLL Instructor error al buscar persona por dni: "+ex.Message,ex);
            }
        }

        public void AltaInstructor(Instructor instructorAlta)
        {
            try
            {
                ValidarDatosInstructor(instructorAlta);
             
                if(InstructorDAO.BuscarInstructorPorDNI(instructorAlta.DNI) != null) throw new Exception("El instructor con ese DNI ya existe.");
              
                instructorAlta.Activo = true; // Por defecto, al dar de alta, el instructor está activo

                InstructorDAO.AltaInstructor(instructorAlta);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Instructor error al dar alta instructor: "+ex.Message,ex);
            }
        }

        private void ValidarDatosInstructor(Instructor instructorAlta)
        {
            try
            {
                //Instructor
                if (instructorAlta == null) throw new ArgumentNullException(nameof(instructorAlta), "El instructor no puede ser nulo.");
                if (string.IsNullOrEmpty(instructorAlta.Licencia)) throw new ArgumentException("La licencia es obligatoria para el instructor.");
            
                // Persona
                if (instructorAlta.DNI <= 0) throw new ArgumentException("Valor de DNI inválido.");
                if (string.IsNullOrEmpty(instructorAlta.Nombre) || !instructorAlta.Nombre.All(char.IsLetter)) throw new ArgumentException("El nombre es obligatorio y solo puede contener letras.");
                if (string.IsNullOrEmpty(instructorAlta.Apellido) || !instructorAlta.Apellido.All(char.IsLetter)) throw new ArgumentException("El apellido es obligatorio y solo puede contener letras.");
                if (string.IsNullOrEmpty(instructorAlta.CuitCuil)) throw new ArgumentException("El CUIT/CUIL es obligatorio.");
                if (instructorAlta.FechaNacimiento.Date > DateTime.Now.AddYears(-18).Date) throw new Exception("El instructor debe ser mayor de edad.");
                if (!Regex.IsMatch(instructorAlta.CuitCuil, $"^\\d{{2}}-{instructorAlta.DNI}-\\d$")) throw new Exception("El CUIT/CUIL no es válido para el DNI del instructor.");
                if (string.IsNullOrEmpty(instructorAlta.Telefono) || !Regex.IsMatch(instructorAlta.Telefono, @"^\d+$")) throw new Exception("El teléfono no puede estar vacío y solo debe contener números.");
                if (string.IsNullOrEmpty(instructorAlta.Email) || !instructorAlta.Email.Contains("@")) throw new Exception("El email ingresado no es válido. Debe contener '@'.");

            }
            catch (Exception ex)
            {

                throw new Exception("BLL Instructor error al validar datos instructor: "+ex.Message,ex);
            }
        }

        public List<Instructor> ObtenerInstructores()
        {
            try
            {
                List <Instructor> instructores = InstructorDAO.ObtenerInstructores();
                return instructores;
            }
            catch (Exception ex)
            {
               
                throw new Exception("BLL Instructor error al obtener los instructores: "+ex.Message , ex);
            }
        }

        public void ModificarInstructor(Instructor instructorMod)
        {
            try
            {
                ValidarDatosInstructor(instructorMod);

                Instructor instructor = new Instructor();
                instructor = InstructorDAO.BuscarPersonaPorDNI(instructorMod.DNI);
                if (instructor != null && instructor.IDPersona != instructorMod.IDPersona) throw new Exception("Ya existe otra persona registrada con este DNI");
                InstructorDAO.ModificarInstructor(instructorMod);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Instructor error al modificar instructor: "+ex.Message,ex);
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
            catch (Exception ex)
            {

                throw new Exception("BLL Instructor error al dar baja de instructor: "+ex.Message,ex);
            }
        }

        public void ModifcarPersonaExistente(Instructor instructorAlta)
        {
            try
            {
                InstructorDAO.ModificarPersonaExistente(instructorAlta);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Instructor error al modificar persona existente: "+ex.Message,ex);
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

                throw new Exception("BLL Instrucotr error al buscar instructor por ID" + ex.Message, ex);
            }
        }

        internal Instructor BuscarInstructorPorCuit(string cuilEmisor)
        {
            try
            {
                if (string.IsNullOrEmpty(cuilEmisor)) throw new Exception("cuit invalido");
                return InstructorDAO.BuscarInstructorPorCuit(cuilEmisor);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Instructor error al buscar instructor por cuit:"+ex.Message,ex);
            }
        }
    }
}
