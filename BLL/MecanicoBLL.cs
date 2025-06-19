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
                if (mecanicoAlta == null) throw new ArgumentNullException(nameof(mecanicoAlta), "El mecánico no puede ser nulo.");
                if (string.IsNullOrWhiteSpace(mecanicoAlta.MatriculaTecnica)) throw new ArgumentException("La matrícula técnica es obligatoria.");
                if (string.IsNullOrWhiteSpace(mecanicoAlta.DireccionTaller)) throw new ArgumentException("La dirección del taller es obligatoria.");
                if (string.IsNullOrWhiteSpace(mecanicoAlta.Nombre)) throw new ArgumentException("El nombre es obligatorio.");
                if (string.IsNullOrWhiteSpace(mecanicoAlta.Apellido)) throw new ArgumentException("El apellido es obligatorio.");
                if (string.IsNullOrWhiteSpace(mecanicoAlta.CuitCuil)) throw new ArgumentException("El CUIT/CUIL es obligatorio.");
                if (mecanicoAlta.TiposDeMantenimiento == null || !mecanicoAlta.TiposDeMantenimiento.Any()) throw new ArgumentException("Debe seleccionar al menos un tipo de mantenimiento.");

                // Validar que no exista ya un mecánico con ese DNI
                if (MecanicoDAO.BuscarMecanicoPorDNI(mecanicoAlta.DNI) != null) throw new Exception("Ya existe un mecánico con ese DNI.");

                mecanicoAlta.Activo = true;

                MecanicoDAO.AltaMecanico(mecanicoAlta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ModificarMecanico(Mecanico mecanicoMod)
        {
            try
            {
                if (mecanicoMod == null) throw new ArgumentNullException(nameof(mecanicoMod), "El mecánico no puede ser nulo.");
                if (string.IsNullOrWhiteSpace(mecanicoMod.MatriculaTecnica)) throw new ArgumentException("La matrícula técnica es obligatoria.");
                if (string.IsNullOrWhiteSpace(mecanicoMod.DireccionTaller)) throw new ArgumentException("La dirección del taller es obligatoria.");
                if (string.IsNullOrWhiteSpace(mecanicoMod.Nombre)) throw new ArgumentException("El nombre es obligatorio.");
                if (string.IsNullOrWhiteSpace(mecanicoMod.Apellido)) throw new ArgumentException("El apellido es obligatorio.");
                if (string.IsNullOrWhiteSpace(mecanicoMod.CuitCuil)) throw new ArgumentException("El CUIT/CUIL es obligatorio.");
                if (mecanicoMod.TiposDeMantenimiento == null || !mecanicoMod.TiposDeMantenimiento.Any()) throw new ArgumentException("Debe seleccionar al menos un tipo de mantenimiento.");
                MecanicoDAO.ModificarMecanico(mecanicoMod);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void BajaMecanico(int idMecanico)
        {
            try
            {
                var mecanico = MecanicoDAO.BuscarMecanicoPorId(idMecanico);
                if (mecanico == null) throw new Exception("No se encontró el mecánico con el ID especificado.");    
                MecanicoDAO.BajaMecanico(idMecanico);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
