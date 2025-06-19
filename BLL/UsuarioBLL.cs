using DAL;
using ENTITY;
using ENTITY.Composite;
using Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAL UsuarioDAO = new UsuarioDAL();


        public List<Usuario> ObtenerTodos()
        {
            try
            {
                return UsuarioDAO.ObtenerTodos();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void AltaUsuario(Usuario usuario)
        {
            try
            {
                if (usuario == null) throw new ArgumentNullException(nameof(usuario));
                if (string.IsNullOrWhiteSpace(usuario.NombreUsuario)) throw new ArgumentException("El nombre de usuario es obligatorio.");
                if (string.IsNullOrWhiteSpace(usuario.Contrasena)) throw new ArgumentException("La contraseña es obligatoria.");
                if (UsuarioDAO.BuscarPorNombre(usuario.NombreUsuario) != null)throw new Exception("Ya existe un usuario con ese nombre de usuario.");
                // Encriptamos antes de guardar
                usuario.Contrasena = Encriptador.Encriptar(usuario.Contrasena);
                usuario.Activo = true;

                UsuarioDAO.AltaUsuario(usuario);
            }
            catch
            {
                throw;
            }
        }

        public void BajaUsuario(int idUsuario)
        {
            try
            {
                UsuarioDAO.BajaUsuario(idUsuario);
            }
            catch
            {
                throw;
            }
        }

   

        public Usuario ValidarLogin(string nombreUsuario, string passPlano)
        {
            try
            {
                Usuario usuario = UsuarioDAO.BuscarPorNombre(nombreUsuario);
                if (usuario == null || !usuario.Activo) return null;

                string passDesencriptada = Encriptador.Desencriptar(usuario.Contrasena);

                if (passDesencriptada != passPlano) return null;

                return usuario;
            }
            catch
            {
                throw;
            }
        }

        public void AsociarRolAUsuario(int idUsuario, int idRol)
        {
            try
            {

                UsuarioDAO.AsociarRolAUsuario(idUsuario, idRol);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DesasociarRolDeUsuario(int idUsuario, int idRol)
        {
            try
            {
                UsuarioDAO.DesasociarRolDeUsuario(idUsuario, idRol);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
