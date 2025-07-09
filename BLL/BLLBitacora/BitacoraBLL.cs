using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY.Bitacora;
using System.Data;
using ENTITY;
using Seguridad;
using System.Transactions;
using Helper;

namespace BLL.BLLBitacora
{
    public class BitacoraBLL
    {
        private readonly DAL.DALBitacora.BitacoraDAL BitacoraDAO = new DAL.DALBitacora.BitacoraDAL();
        public void RealizarBackUp()
        {
            try
            {
                Bitacora backup = new Bitacora();
                backup.Descripcion = "BackUp";
                backup.Id_Usuario = SessionManager.Instancia.UsuarioLogueado.IdUsuario;
                backup.FechaRegistro = DateTime.Now;

                BitacoraDAO.GuardarBitacora(backup);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Bitacora error al realiza back up: "+ex.Message,ex);
            }

        }

        public void RealizarRestore(Bitacora BackUpSeleccionado)
        {
            try
            {
                if (BackUpSeleccionado == null)throw new ArgumentNullException(nameof(BackUpSeleccionado), "Debe seleccionar un registro de tipo BackUp para restaurar.");
                if (BackUpSeleccionado.Descripcion != "BackUp")throw new ArgumentException("El registro seleccionado no es un BackUp válido.");

                if (!HelperD.ExisteBackUp(BackUpSeleccionado.FechaRegistro)) throw new FileNotFoundException("No se encontró el archivo de BackUp seleccionada.");

                Bitacora restore = new Bitacora();
                restore.Descripcion = "Restore";
                restore.Id_Usuario = SessionManager.Instancia.UsuarioLogueado.IdUsuario;
                restore.FechaRegistro = DateTime.Now;
                BitacoraDAO.RealizarRestore(BackUpSeleccionado, restore);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Bitacora error al realizar restore: "+ex.Message,ex);
            }
        }
        public List<Bitacora> ObtenerTodos()
        {
            try
            {
                return BitacoraDAO.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("BLL Bitacora Error al obtener las bitácoras: " + ex.Message, ex);
            }
        }
    }
}
