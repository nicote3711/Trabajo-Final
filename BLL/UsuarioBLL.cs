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
            catch (Exception ex)
            {
                throw new Exception("BLL Usuario error al obtener todos: "+ex.Message,ex);
            }
        }
        public void AltaUsuario(Usuario usuario)
        {
            try
            {  

                ValidarAltaUsuario(usuario);
                
               
                // Encriptamos antes de guardar
                usuario.Contrasena = Encriptador.Encriptar(usuario.Contrasena);
                usuario.Activo = true;

                UsuarioDAO.AltaUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception ("BLL Usuario error en alta de usuario: " + ex.Message,ex );
            }
        }

        private void ValidarAltaUsuario(Usuario usuario)
        {
            try
            {
                if (usuario == null) throw new ArgumentNullException(nameof(usuario));
                if (string.IsNullOrWhiteSpace(usuario.NombreUsuario)) throw new ArgumentException("El nombre de usuario es obligatorio.");
                if (string.IsNullOrWhiteSpace(usuario.Contrasena)) throw new ArgumentException("La contraseña es obligatoria.");
                if(string.IsNullOrEmpty(usuario.Nombre)||!usuario.Nombre.All(char.IsLetter)) throw new Exception("el nombre no puede estar vacio y solo debe contener letras");
                if (string.IsNullOrEmpty(usuario.Apellido) || !usuario.Apellido.All(char.IsLetter)) throw new Exception("el apellido no puede estar vacio y solo debe contener letras");
                if (UsuarioDAO.BuscarPorNombreUsuario(usuario.NombreUsuario) != null) throw new Exception("Ya existe un usuario con ese nombre de usuario.");
                if (UsuarioDAO.BuscarPorDNI(usuario.DNI) != null) throw new Exception("Ya existe un usuario con ese DNI.");
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Usuario arror al validar: "+ex.Message,ex);
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
                throw new Exception("BLL Usuario error en baja de usuario: " + ex.Message, ex);
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
                // aca podria manejarse encryptado tambien, pero lo paso plano del form. A cambiar segun criterio profersor
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("BLL Usuario error al valida log in:" + ex.Message, ex);
            }
        }

        public void AsociarRolAUsuario(int idUsuario, int idRol)
        {
            try
            {
                if (UsuarioDAO.ExisteRolEnUsuario(idUsuario, idRol)) throw new Exception("El usuario ya tiene asignado el rol");
                UsuarioDAO.AsociarRolAUsuario(idUsuario, idRol);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Usuario error al asociar un rol a usuario: "+ex.Message,ex);
            }
        }

        public void DesasociarRolDeUsuario(int idUsuario, int idRol)
        {
            try
            {
                if(!UsuarioDAO.ExisteRolEnUsuario(idUsuario, idRol)) throw new Exception("ese rol no esta asociado al usuario");
                UsuarioDAO.DesasociarRolDeUsuario(idUsuario, idRol);

            }
            catch (Exception ex)
            {

                throw new Exception("BLL Usuario error al des-asociar un rolo a usuario: "+ex.Message,ex);
            }
        }

        public void ModificarUsuario(Usuario usuario)
        {
            try
            {

                if (usuario == null) throw new ArgumentNullException(nameof(usuario));
                if (string.IsNullOrWhiteSpace(usuario.NombreUsuario)) throw new ArgumentException("El nombre de usuario es obligatorio.");
                if (string.IsNullOrWhiteSpace(usuario.Contrasena)) throw new ArgumentException("La contraseña es obligatoria.");
                if (string.IsNullOrEmpty(usuario.Nombre) || !usuario.Nombre.All(char.IsLetter)) throw new Exception("el nombre no puede estar vacio y solo debe contener letras");
                if (string.IsNullOrEmpty(usuario.Apellido) || !usuario.Apellido.All(char.IsLetter)) throw new Exception("el apellido no puede estar vacio y solo debe contener letras");
                Usuario usuarioAux;
               
                
                usuarioAux = UsuarioDAO.BuscarPorNombreUsuario(usuario.NombreUsuario);
                if(usuarioAux != null && usuarioAux.IdUsuario != usuario.IdUsuario) throw new Exception("Ya existe otro usuario con ese NombreUsuario");
               
                

                usuarioAux = UsuarioDAO.BuscarPorDNI(usuario.DNI);
                if(usuarioAux!=null && usuarioAux.IdUsuario != usuario.IdUsuario) throw new Exception("Ya existe otro usuario con ese DNI.");
               
                
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

                throw new Exception("BLL error al buscar Usuario por id: " + ex.Message, ex);
            }
        }
    }
}
