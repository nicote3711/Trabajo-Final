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
    public class DuenoBLL
    {
        private readonly DuenoDAL duenoDAO = new DuenoDAL();

        public Dueno BuscarPersonaPorDNI(long dni)
        {
            try
            {
                return duenoDAO.BuscarPersonaPorDNI(dni);
            }
            catch (Exception ex)
            {
                throw new Exception("BLL Dueño error al buscar persona por DNI: " + ex.Message, ex);
            }
        }

        public void AltaDueno(Dueno dueno)
        {
            try
            {
                ValidarDatosDueno(dueno);
                if (duenoDAO.BuscarDuenoPorDNI(dueno.DNI) != null) throw new Exception("el dueño que intenta registrar ya existe");
                dueno.Activo = true;

                duenoDAO.AltaDueno(dueno);
            }
            catch (Exception ex)
            {
                throw new Exception("BLL Dueño error al dar alta Dueño: " + ex.Message, ex);
            }
        }

        private void ValidarDatosDueno(Dueno dueno)
        {
            try
            {
                // Dueño
                if (dueno == null) throw new ArgumentNullException(nameof(dueno), "El dueño no puede ser nulo.");
                // Persona
                if (dueno.DNI <= 0) throw new ArgumentException("Valor de DNI inválido.");
                if (string.IsNullOrEmpty(dueno.Nombre) || !dueno.Nombre.All(char.IsLetter))  throw new ArgumentException("El nombre es obligatorio y solo puede contener letras.");
                if (string.IsNullOrEmpty(dueno.Apellido) || !dueno.Apellido.All(char.IsLetter)) throw new ArgumentException("El apellido es obligatorio y solo puede contener letras.");
                if (string.IsNullOrEmpty(dueno.CuitCuil)) throw new ArgumentException("El CUIT/CUIL es obligatorio.");
                if (dueno.FechaNacimiento.Date > DateTime.Now.AddYears(-18).Date)  throw new Exception("El dueño debe ser mayor de edad.");
                if (!Regex.IsMatch(dueno.CuitCuil, $"^\\d{{2}}-{dueno.DNI}-\\d$")) throw new Exception("El CUIT/CUIL no es válido para el DNI del dueño.");
                if (string.IsNullOrEmpty(dueno.Telefono) || !Regex.IsMatch(dueno.Telefono, @"^\d+$")) throw new Exception("El teléfono no puede estar vacío y solo debe contener números.");
                if (string.IsNullOrEmpty(dueno.Email) || !dueno.Email.Contains("@")) throw new Exception("El email ingresado no es válido. Debe contener '@'.");

            }
            catch (Exception ex)
            {

                throw new Exception("BLL Dueño error al validar datos dueño: "+ex.Message,ex);
            }
        }

        public List<Dueno> ObtenerDuenos()
        {
            try
            {
                return duenoDAO.ObtenerDuenos();
            }
            catch (Exception ex)
            {
                throw new Exception("BLL Dueño error al obtener dueños: " + ex.Message, ex);
            }
        }

        public void ModificarDueno(Dueno duenoMod)
        {
            try
            {
              
                ValidarDatosDueno(duenoMod);
                Dueno dueno = duenoDAO.BuscarPersonaPorDNI(duenoMod.DNI);
                if (dueno != null && dueno.IDPersona != duenoMod.IDPersona) throw new Exception("Ya existe otra persona registrada con estew DNI");
                duenoDAO.ModificarDueno(duenoMod);
            }
            catch (Exception ex)
            {
                throw new Exception("BLL Dueño error al modoficar dueño: " + ex.Message, ex);
            }
        }

        public void ModificarPersonaExistente(Dueno duenoMod)
        {
            try
            {

                duenoDAO.ModificarPersonaExistente(duenoMod);
            }
            catch (Exception ex)
            {
                throw new Exception("BLL Dueño error al modificar persona existente: "+ex.Message,ex);
            }
        }

        public void BajaDueno(int idDueno)
        {
            try
            {
                Dueno dueno = duenoDAO.BuscarDuenoPorId(idDueno);
                if (dueno == null) throw new Exception("No se encontró el dueño a eliminar.");
                duenoDAO.BajaDueno(idDueno);
            }
            catch (Exception ex)
            {
                throw new Exception("BLL Dueño error al dar bajar a dueño: " + ex.Message, ex);
            }
        }

        public Dueno BuscarDuenoPorIdPersona(int iDPersona)
        {
            try
            {
                if (iDPersona == null || iDPersona <= 0) throw new Exception("Id Nulo o invalido");

                return duenoDAO.BuscarDuenoPorIdPersona(iDPersona); 

            }
            catch (Exception ex)
            {

                throw new Exception ("BLL dueño error al buscar Dueño por Id Persona: "+ex.Message,ex);
            }
        }

        public Dueno BuscarDuenoPorCuit(string cuit)
        {
            try
            {
                if (string.IsNullOrEmpty(cuit)) throw new Exception("cuit invalido");

                return duenoDAO.BuscarDuenoPorCuit(cuit);

            }
            catch (Exception ex)
            {

                throw new Exception("BLL dueño error al buscar Dueño por cuit Persona: " + ex.Message, ex);
            }
        }
    }
}

