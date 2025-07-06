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
    public class MecanicoBLL
    {
		MecanicoDAL MecanicoDAO = new MecanicoDAL();

      

        public Mecanico BuscarPersonaPorDni(long dNI)
        {
            try
            {
                return MecanicoDAO.BuscarPersonaPorDNI(dNI);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ModifcarPersonaExistente(Mecanico mecanicoAlta)
        {
            try
            {
                MecanicoDAO.ModificarPersonaExistente(mecanicoAlta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Mecanico> ObtenerMecanicos()
        {
			try
			{
				return  MecanicoDAO.ObtenerMecanicos();
            }
			catch (Exception)
			{

				throw;
			}
        }

        public void AltaMecanico(Mecanico mecanicoAlta)
        {
            try
            {
                ValidarDatosMecanico(mecanicoAlta);

                // Validar que no exista ya un mecánico con ese DNI
                if (MecanicoDAO.BuscarMecanicoPorDNI(mecanicoAlta.DNI) != null) throw new Exception("Ya existe un mecánico con ese DNI.");

                mecanicoAlta.Activo = true;

                MecanicoDAO.AltaMecanico(mecanicoAlta);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Mecanico error al dar alta mecanico: "+ex.Message,ex);
            }
        }

        private static void ValidarDatosMecanico(Mecanico mecanicoAlta)
        {
            try
            {
                //Mecanico
                if (mecanicoAlta == null) throw new ArgumentNullException(nameof(mecanicoAlta), "El mecánico no puede ser nulo.");
                if (string.IsNullOrEmpty(mecanicoAlta.MatriculaTecnica)) throw new ArgumentException("La matrícula técnica es obligatoria.");
                if (string.IsNullOrEmpty(mecanicoAlta.DireccionTaller)) throw new ArgumentException("La dirección del taller es obligatoria.");
                if (mecanicoAlta.TiposDeMantenimiento == null || !mecanicoAlta.TiposDeMantenimiento.Any()) throw new ArgumentException("Debe seleccionar al menos un tipo de mantenimiento.");

                //Persona
                if (string.IsNullOrEmpty(mecanicoAlta.Nombre) || !mecanicoAlta.Nombre.All(char.IsLetter)) throw new ArgumentException("El nombre es obligatorio y solo puede contener letras.");
                if (string.IsNullOrEmpty(mecanicoAlta.Apellido) || !mecanicoAlta.Apellido.All(char.IsLetter)) throw new ArgumentException("El apellido es obligatorio y solo puede contener letras.");
                if (string.IsNullOrEmpty(mecanicoAlta.CuitCuil)) throw new ArgumentException("El CUIT/CUIL es obligatorio.");
                if (mecanicoAlta.FechaNacimiento.Date > DateTime.Now.AddYears(-18).Date) throw new Exception("El mecánico debe ser mayor de edad.");
                if (!Regex.IsMatch(mecanicoAlta.CuitCuil, $"^\\d{{2}}-{mecanicoAlta.DNI}-\\d$")) throw new Exception("El CUIT/CUIL no es válido para el DNI del mecánico.");
                if (string.IsNullOrEmpty(mecanicoAlta.Telefono) || !Regex.IsMatch(mecanicoAlta.Telefono, @"^\d+$")) throw new Exception("El teléfono no puede estar vacio solo debe contener números.");
                if (string.IsNullOrEmpty(mecanicoAlta.Email) || !mecanicoAlta.Email.Contains("@")) throw new Exception("El email ingresado no es válido. Debe contener '@'.");
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Mecanico error al validar datos mecanico: "+ex.Message,ex);
            }
           
        }

        public void ModificarMecanico(Mecanico mecanicoMod)
        {
            try
            {
                ValidarDatosMecanico(mecanicoMod);


                //validar que no se esta usando el dni de otra persona
                Mecanico mecanico = MecanicoDAO.BuscarPersonaPorDNI(mecanicoMod.DNI);
                if (mecanico != null && mecanico.IDPersona != mecanicoMod.IDPersona) throw new Exception("Ya existe otra persona registrada con este DNI");
                MecanicoDAO.ModificarMecanico(mecanicoMod);
            }
            catch (Exception ex)
            {
                throw new Exception("BLL Mecanico error al modificar mecanico: "+ex.Message,ex);
            }
        }

        public void BajaMecanico(int idMecanico)
        {
            try
            {
                Mecanico mecanico = MecanicoDAO.BuscarMecanicoPorId(idMecanico);
                if (mecanico == null) throw new Exception("No se encontró el mecánico con el ID especificado.");    
                MecanicoDAO.BajaMecanico(idMecanico);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Mecanico BuscarMecanicoPorId(int idMecanico)
        {
            try
            {
                Mecanico mecanico = MecanicoDAO.BuscarMecanicoPorId(idMecanico);
                if (mecanico == null) throw new Exception($"No se encontro al mecanico id {idMecanico}");

                return mecanico;
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Mecanico error al buscar mecanico por id: "+ex.Message,ex);
            }
        }
    }
}
