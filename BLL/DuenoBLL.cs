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
                if (dueno == null) throw new ArgumentNullException(nameof(dueno), "El dueño no puede ser nulo.");
                if (string.IsNullOrWhiteSpace(dueno.Nombre)) throw new ArgumentException("El nombre no puede estar vacío.");
                if (string.IsNullOrWhiteSpace(dueno.Apellido)) throw new ArgumentException("El apellido no puede estar vacío.");
                if (string.IsNullOrWhiteSpace(dueno.CuitCuil)) throw new ArgumentException("El CUIT/CUIL no puede estar vacío.");
                if (duenoDAO.BuscarDuenoPorDNI(dueno.DNI) != null) throw new Exception("El dueño con ese DNI ya existe.");
                
                dueno.Activo = true;

                duenoDAO.AltaDueno(dueno);
            }
            catch (Exception ex)
            {
                throw new Exception("BLL Dueño error al dar alta Dueño: " + ex.Message, ex);
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
                if (duenoMod == null) throw new ArgumentNullException(nameof(duenoMod), "El dueño no puede ser nulo.");
                if (string.IsNullOrWhiteSpace(duenoMod.Nombre)) throw new ArgumentException("El nombre no puede estar vacío.");
                if (string.IsNullOrWhiteSpace(duenoMod.Apellido)) throw new ArgumentException("El apellido no puede estar vacío.");
                if (string.IsNullOrWhiteSpace(duenoMod.CuitCuil)) throw new ArgumentException("El CUIT/CUIL no puede estar vacío.");
                if (duenoDAO.BuscarDuenoPorDNI(duenoMod.DNI) != null) throw new Exception("El dueño con ese DNI ya existe.");
                Dueno dueno = new Dueno();
                dueno = duenoDAO.BuscarPersonaPorDNI(duenoMod.DNI);
                if (dueno != null && dueno.IDPersona != duenoMod.IDPersona) throw new Exception("Ya existe otra persona registrar con estew DNI");
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

                throw new Exception("BLL dueño error al buscar Dueño por Id Persona: " + ex.Message, ex);
            }
        }
    }
}

