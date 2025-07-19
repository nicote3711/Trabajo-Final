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
                ValidarAltaAeronave(aeronave);
                EstadoAeronaveBLL EstadoAeronaveBLO = new EstadoAeronaveBLL();
                EstadoAeronave estado = EstadoAeronaveBLO.BuscarPorId((int)EnumEstadoEaronave.Activo);
                if (estado == null) throw new Exception(" no se encontro el estado activo en la base de datos para dar alta");
                aeronave.Estado = estado;
                AeronaveDAO.AltaAeronave(aeronave);

            }
            catch (Exception ex)
            {

                throw new Exception("BLL Aeronave error al dar alta aeronave:"+ex.Message,ex);
            }

        }

        private void ValidarAltaAeronave(Aeronave aeronave)
        {
            try
            {
                if (aeronave == null) throw new Exception("la aeronave no puede ser nula");
                if (string.IsNullOrEmpty(aeronave.Matricula)) throw new Exception("la matricula no puede estar vacia");
                if (string.IsNullOrEmpty(aeronave.Marca)) throw new Exception("Debe ingresar una marca.");
                if (string.IsNullOrEmpty(aeronave.Modelo)) throw new Exception("Debe ingresar un modelo.");
                if (aeronave.Año > DateTime.Now.Year || aeronave.Año < 1970) throw new Exception("El año de la aeronave no puede ser mayor al actual o menor a 1970");
                if (aeronave.Revision100Hs >= 100) throw new Exception("No se puede dar de alta una aeronave con 100hs o mas");
                if (aeronave.RevisionAnual.Date <= DateTime.Now.Date) throw new Exception("La fecha de revision de la aeronave no puede ser el dia de hoy o estar vencida");
                Aeronave aExistente = AeronaveDAO.BuscarAeronavePorMatricula(aeronave.Matricula);
                if (aExistente != null) throw new Exception("Ya hay una aeronave con esa matricula registrada");
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Aeronave error al validar alta: "+ex.Message,ex);
            }
        }

        public void ModificarAeronave(Aeronave aeronave)
        {
            try
            {
                if (aeronave == null) throw new ArgumentNullException(nameof(aeronave));
                if (string.IsNullOrEmpty(aeronave.Matricula)) throw new Exception("la matricula no puede estar vacia");
                if (string.IsNullOrEmpty(aeronave.Marca)) throw new Exception("Debe ingresar una marca.");
                if (string.IsNullOrEmpty(aeronave.Modelo)) throw new Exception("Debe ingresar un modelo.");
                if (aeronave.Año > DateTime.Now.Year || aeronave.Año < 1970) throw new Exception("El año de la aeronave no puede ser mayor al actual o menor a 1970");
                Aeronave aeronaveAux = AeronaveDAO.BuscarAeronavePorMatricula(aeronave.Matricula);
                if (aeronaveAux != null && aeronaveAux.IdAeronave != aeronave.IdAeronave) throw new Exception("La matricula ingresada ya le pertenece a otra aeronave");
                Aeronave aeronaveActual = AeronaveDAO.BuscarAeronavePorId(aeronave.IdAeronave);
                if (aeronaveActual == null) throw new Exception("No se encontró la aeronave original para validar su estado.");
                if (aeronaveActual.Estado.IdEstadoAeronave.Equals((int)EnumEstadoEaronave.Mantenimiento)&& !aeronave.Estado.IdEstadoAeronave.Equals((int)EnumEstadoEaronave.Mantenimiento))throw new Exception("No se puede modificar una aeronave que está en mantenimiento.");
                if (aeronaveActual.Estado.IdEstadoAeronave.Equals((int)EnumEstadoEaronave.Mantenimiento) && aeronaveActual.Revision100Hs!=(aeronave.Revision100Hs)) throw new Exception("No se pueden editar las horas de una aeronave en mantenimiento");
                if (aeronaveActual.Estado.IdEstadoAeronave.Equals((int)EnumEstadoEaronave.Mantenimiento) && aeronaveActual.RevisionAnual.Date!=(aeronave.RevisionAnual.Date)) throw new Exception("No se puede editar la fecha de revisar anual de una aeronave en mantenimiento");
                if (!aeronaveActual.Estado.IdEstadoAeronave.Equals((int)EnumEstadoEaronave.Mantenimiento) && aeronave.Estado.IdEstadoAeronave.Equals((int)EnumEstadoEaronave.Mantenimiento)) throw new Exception("No se pude pasar de estado activo/inactivo a mantenimiento");
                AeronaveDAO.ModificarAeronave(aeronave);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Aeronave error al modificar aeronave: "+ ex.Message,ex);
            }
        }

        public void BajaAeronave(int idAeronave)
        {
            try
            {
                EstadoAeronave estadoInactivo = EstadoBLO.BuscarPorDescripcion("Inactivo");
                if (estadoInactivo == null) throw new Exception("No se encontró el estado 'Inactivo' para realizar la baja.");
                Aeronave aeronave = BuscarAeronavePorId(idAeronave);
                if (aeronave == null) throw new Exception("no se encontro la aeronave a dar de baja");
                AeronaveDAO.BajaAeronave(idAeronave, estadoInactivo.IdEstadoAeronave);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Aeronave error al dar de baja:"+ex.Message,ex);
            }

        }

        public List<Aeronave> ObtenerTodas()
        {
            try
            {
                return AeronaveDAO.ObtenerAeronaves();
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Aeronave error al obtener todas:"+ex.Message,ex);
            }

        }

        public Aeronave BuscarAeronavePorId(int id)
        {
            try
            {
                return AeronaveDAO.BuscarAeronavePorId(id);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Aeronave error al buscar por aeronave por id: "+ex.Message,ex);
            }

        }
        public Aeronave BuscarAeronavePorMatricula(string matricula)
        {
            try
            {
                return AeronaveDAO.BuscarAeronavePorMatricula(matricula);
            }
            catch (Exception ex)
            {
                throw new Exception("BLL Aeronave error al buscar aeronave por matricula: "+ex.Message,ex);
            }
        }

        public Aeronave ObtenerAeronavePorId(int idAeronave)
        {
            try
            {

                Aeronave aeronave = AeronaveDAO.BuscarAeronavePorId(idAeronave);
                if (aeronave == null) throw new Exception("Aeronave no encontrada.");   
                return aeronave;
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

        public void ActualizarEstadoAeronave(int idAeronave, EstadoAeronave estado)
        {
            try
            {
                Aeronave aeronave = AeronaveDAO.BuscarAeronavePorId(idAeronave);
                if (aeronave == null) throw new Exception($"No se encontro la aeronave id {idAeronave}");
                if (estado==null|| estado.IdEstadoAeronave<=0) throw new Exception("el estado es nulo o su id es invalido");

                AeronaveDAO.ActualizarEstadoAeronave(idAeronave, estado);
            }
            catch (Exception ex)
            {

                throw new Exception ("BLL Aeronave error al actualizar estado de la Aeronave: "+ex.Message,ex);
            }
        }
    }
}
