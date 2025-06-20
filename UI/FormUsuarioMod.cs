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
    public partial class FormUsuarioMod : Form
    {
        FormUsuarioABM formPpal;
        Usuario usuarioModificado;
        public FormUsuarioMod(Usuario usuario, FormUsuarioABM formPadre)
        {
            InitializeComponent();
            txt_IdUsuario.Text = usuario.IdUsuario.ToString();
            txt_NombreUsuario.Text = usuario.NombreUsuario;
            txt_Dni.Text = usuario.DNI.ToString();
            txt_Apellido.Text = usuario.Apellido;
            txt_Nombre.Text = usuario.Nombre;
            txt_Contrasena.Text = Encriptador.Desencriptar(usuario.Contrasena);
            checkBox_Activo.Checked = usuario.Activo;
            formPpal = formPadre;
            usuarioModificado = usuario;
        }

        private void FormUsuarioMod_Load(object sender, EventArgs e)
        {

        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_Dni.Text.Trim())) throw new Exception("El DNI es obligatorio.");
                if (string.IsNullOrEmpty(txt_Nombre.Text.Trim())) throw new Exception("El nombre es obligatorio.");
                if (string.IsNullOrEmpty(txt_Apellido.Text.Trim())) throw new Exception("El apellido es obligatorio.");
                if (string.IsNullOrEmpty(txt_Contrasena.Text.Trim())) throw new Exception("La contraseña es obligatoria.");
                if (!long.TryParse(txt_Dni.Text, out long dni)) throw new Exception("El DNI debe ser un número válido.");
                usuarioModificado.DNI = dni;
                usuarioModificado.NombreUsuario = txt_NombreUsuario.Text.Trim();
                usuarioModificado.Apellido = txt_Apellido.Text.Trim();  
                usuarioModificado.Nombre = txt_Nombre.Text.Trim();
                usuarioModificado.Contrasena = txt_Contrasena.Text.Trim(); // Encriptamos la contraseña antes de guardar
                usuarioModificado.Activo = checkBox_Activo.Checked;
                DialogResult = DialogResult.OK;
                Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
