using DAL;
using ENTITY;
using ENTITY.Enum;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AeronaveBLL
    {
        private readonly AeronaveDAL AeronaveDAO = new AeronaveDAL();
        private readonly EstadoAeronaveBLL EstadoBLO = new EstadoAeronaveBLL();
        private readonly DuenoBLL DuenoBLL = new DuenoBLL();
        private List<EstadoAeronave> EstadosAeronave;

        public AeronaveBLL() 
        {
            if (EstadosAeronave == null) EstadosAeronave = EstadoBLO.ObtenerTodos();
        }

        public void AltaAeronave(Aeronave aeronave)
        {

            try
            {
                if (aeronave == null) throw new ArgumentNullException(nameof(aeronave));
                if (string.IsNullOrWhiteSpace(aeronave.Matricula)) throw new ArgumentException("La matrícula es obligatoria.");
                aeronave.Estado = EstadosAeronave.FirstOrDefault(n => n.IdEstadoAeronave.Equals((int)EnumEstadoEaronave.Activo));
               
                Aeronave aeexistente = AeronaveDAO.BuscarAeronavePorMatricula(aeronave.Matricula);

                AeronaveDAO.AltaAeronave(aeronave);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void ModificarAeronave(Aeronave aeronave)
        {
            try
            {
                if (aeronave == null) throw new ArgumentNullException(nameof(aeronave));
                AeronaveDAO.ModificarAeronave(aeronave);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void BajaAeronave(int idAeronave)
        {
            try
            {
                EstadoAeronave estadoInactivo = EstadoBLO.BuscarPorDescripcion("Inactivo");
                if (estadoInactivo == null) throw new Exception("No se encontró el estado 'Inactivo' para realizar la baja.");

                AeronaveDAO.BajaAeronave(idAeronave, estadoInactivo.IdEstadoAeronave);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Aeronave> ObtenerTodas()
        {
            try
            {
                return AeronaveDAO.ObtenerAeronaves();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Aeronave BuscarAeronavePorId(int id)
        {
            try
            {
                return AeronaveDAO.BuscarAeronavePorId(id);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public Aeronave BuscarAeronavePorMatricula(string matricula)
        {
            try
            {
                return AeronaveDAO.BuscarAeronavePorMatricula(matricula);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal Aeronave ObtenerAeronavePorId(int idAeronave)
        {
            try
            {

                Aeronave aeronave = AeronaveDAO.BuscarAeronavePorId(idAeronave);
                if (aeronave == null) throw new Exception("Aeronave no encontrada.");   
                return AeronaveDAO.BuscarAeronavePorId(idAeronave);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Aeronave error al buscar aeronave por Id:"+ ex.Message,ex); 
            }
        }

        public void ActualizarHorasAeronave(int idAeronave, decimal tV)
        {
            try
            {
                Aeronave aeronave = AeronaveDAO.BuscarAeronavePorId(idAeronave);
                if (aeronave == null) throw new Exception("Aeronave no encontrada.");
                aeronave.Revision100Hs += tV;
                AeronaveDAO.ModificarAeronave(aeronave);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Aeronave error al actualizar horas aeronave:"+ ex.Message,ex);
            }
        }

    }
}
