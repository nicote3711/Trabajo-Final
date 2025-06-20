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
                if (UsuarioDAO.BuscarPorNombreUsuario(usuario.NombreUsuario) != null)throw new Exception("Ya existe un usuario con ese nombre de usuario.");
                if (UsuarioDAO.BuscarPorDNI(usuario.DNI) != null) throw new Exception("Ya existe un usuario con ese DNI.");
               
                // Encriptamos antes de guardar
                usuario.Contrasena = Encriptador.Encriptar(usuario.Contrasena);
                usuario.Activo = true;

                UsuarioDAO.AltaUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception ("BLL error en alta de usuario: " + ex.Message,ex );
            }
        }

        public void BajaUsuario(int idUsuario)
        {
            try
            {
                
                if (UsuarioDAO.BuscarPorId(idUsuario) == null) throw new Exception("No se encontro el usuario a dar de baja.");
                UsuarioDAO.BajaUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("BLL error en baja de usuario: " + ex.Message, ex);
            }          
        }

   

        public Usuario ValidarLogin(string nombreUsuario, string passPlano)
        {
            try
            {
                Usuario usuario = UsuarioDAO.BuscarPorNombreUsuario(nombreUsuario);
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

        public void ModificarUsuario(Usuario usuario)
        {
            try
            {
                Usuario usuarioAux;
                if (usuario == null) throw new ArgumentNullException(nameof(usuario));
                if (string.IsNullOrWhiteSpace(usuario.NombreUsuario)) throw new ArgumentException("El nombre de usuario es obligatorio.");
                if (string.IsNullOrWhiteSpace(usuario.Contrasena)) throw new ArgumentException("La contraseña es obligatoria.");
                
                
                usuarioAux = UsuarioDAO.BuscarPorNombreUsuario(usuario.NombreUsuario);
                if(usuarioAux != null)
                {
                    if (usuarioAux.IdUsuario != usuario.IdUsuario) throw new Exception("Ya existe otro usuario con ese NombreUsuario");
                }
                
          
                usuarioAux = UsuarioDAO.BuscarPorDNI(usuario.DNI);
                if(usuarioAux!=null)
                {
                    if (usuarioAux.IdUsuario != usuario.IdUsuario) throw new Exception("Ya existe otro usuario con ese DNI.");
                }
                
                usuario.Contrasena = Encriptador.Encriptar(usuario.Contrasena); // Encriptamos la contraseña antes de guardar

                UsuarioDAO.ModificarUsuario(usuario);
            }
            catch (Exception ex)
            {

                throw new Exception ("BLL error al modificar Usuario: " + ex.Message,ex);
            }
        }

        public Usuario BuscarUsuarioPorId(int id_Usuario)
        {
            try
            {
              return  UsuarioDAO.BuscarPorId(id_Usuario);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL error al modificar Usuario: " + ex.Message, ex);
            }
        }
    }
}
