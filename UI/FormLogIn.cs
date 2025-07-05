using BLL;
using ENTITY;
using Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormLogIn : Form
    {
        private readonly UsuarioBLL UsuarioBLO = new UsuarioBLL();
        public FormLogIn()
        {
            InitializeComponent();
            txt_Contrasena.UseSystemPasswordChar = true;
        }

        private void FormLogIn_Load(object sender, EventArgs e)
        {
            txt_Usuario.Text = "nico3711"; // Usuario por defecto para pruebas
            txt_Contrasena.Text = "1234"; // Contraseña por defecto para pruebas
        }

        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txt_Usuario.Text.Trim();
                string contrasena = txt_Contrasena.Text.Trim(); 
                string passEncriptado = Encriptador.Encriptar(contrasena); // Encriptamos la contraseña antes de validar por si el profesor quiere que vaya a la BLL encriptada (no lo uso)

                Usuario usuarioValido = UsuarioBLO.ValidarLogin(usuario, contrasena); // le paso el no encriptado pero puedo hacerlo segun criterio.
                if(usuarioValido == null) throw new Exception("Usuario o contraseña incorrectos.");
                SessionManager.Instancia.IniciarSesion(usuarioValido);
                this.Hide();
                FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal(usuarioValido);
                formMenuPrincipal.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
         
        }

    }
}
