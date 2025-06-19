using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguridad
{
    public class SessionManager
    {
        private static SessionManager instancia;

        public static SessionManager Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new SessionManager();
                }
                return instancia;
            }
        }

        public Usuario UsuarioLogueado { get; private set; }

        public void IniciarSesion(Usuario usuario)
        {
            UsuarioLogueado = usuario;
        }
        public void CerrarSesion()
        {
            UsuarioLogueado = null;
        }
        public bool EstaLogueado()
        {
            return UsuarioLogueado != null;
        }
    }
}
