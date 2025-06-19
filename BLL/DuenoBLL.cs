using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaDueno(Dueno dueno)
        {
            try
            {
                if (dueno == null) throw new ArgumentNullException(nameof(dueno), "El dueño no puede ser nulo.");
                if (string.IsNullOrWhiteSpace(dueno.Nombre)) throw new ArgumentException("El nombre no puede estar vacío.");
                if (string.IsNullOrWhiteSpace(dueno.Apellido)) throw new ArgumentException("El apellido no puede estar vacío.");
                if (string.IsNullOrWhiteSpace(dueno.CuitCuil)) throw new ArgumentException("El CUIT/CUIL no puede estar vacío.");
                if (duenoDAO.BuscarDuenoPorDNI(dueno.DNI) != null) throw new Exception("El dueño con ese DNI ya existe.");
                
                dueno.Activo = true;

                duenoDAO.AltaDueno(dueno);
            }
            catch (Exception)
            {
                throw;
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
                throw new Exception("Error al obtener los dueños.", ex);
            }
        }

        public void ModificarDueno(Dueno dueno)
        {
            try
            {
                duenoDAO.ModificarDueno(dueno);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarPersonaExistente(Dueno dueno)
        {
            try
            {
                duenoDAO.ModificarPersonaExistente(dueno);
            }
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}

