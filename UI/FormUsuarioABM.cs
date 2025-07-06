using BLL;
using ENTITY;
using Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormUsuarioABM : Form
    {
        UsuarioBLL UsuarioBLO = new UsuarioBLL();
        public FormUsuarioABM()
        {
            InitializeComponent();
        }

        private void UsuarioABM_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        #region Funciones Form  
        private void CargarGrilla()
        {
            try
            {
                List<Usuario> LUsuarios = UsuarioBLO.ObtenerTodos();
                if (LUsuarios != null && LUsuarios.Count > 0)
                {
                    dgv_Usuarios.DataSource = null;
                    dgv_Usuarios.DataSource = LUsuarios;
                    dgv_Usuarios.Columns["Contrasena"].Visible = false; // Ocultamos la columna de contraseña

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);   
            }
        }

        private void LimpiarCampos()
        {
            try
            {
                txt_Dni.Clear();
                txt_Nombre.Clear();
                txt_Apellido.Clear();
                txt_Contrasena.Clear();
                txt_NombreUsuario.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        #endregion Fin Funciones Form   


        #region Botones Form    
        private void btn_AltaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (string.IsNullOrEmpty(txt_NombreUsuario.Text)) throw new Exception("El nombre de usuario es obligatorio");   
                if (string.IsNullOrEmpty(txt_Dni.Text.Trim())) throw new Exception("El DNI es obligatorio.");
                if (string.IsNullOrEmpty(txt_Nombre.Text.Trim())) throw new Exception("El nombre es obligatorio.");
                if (string.IsNullOrEmpty(txt_Apellido.Text.Trim())) throw new Exception("El apellido es obligatorio.");
                if (string.IsNullOrEmpty(txt_Contrasena.Text.Trim())) throw new Exception("La contraseña es obligatoria.");
                if (!long.TryParse(txt_Dni.Text, out long dni)) throw new Exception("El DNI debe ser un número válido.");

                Usuario usuario = new Usuario();
                usuario.NombreUsuario = txt_NombreUsuario.Text.Trim();
                usuario.DNI = dni;
                usuario.Nombre = txt_Nombre.Text.Trim();
                usuario.Apellido = txt_Apellido.Text.Trim();
                usuario.Contrasena = txt_Contrasena.Text.Trim();
                UsuarioBLO.AltaUsuario(usuario);
                CargarGrilla();
                LimpiarCampos();
                MessageBox.Show("Usuario agregado correctamente.");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }



        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Usuarios.Rows.Count<=0) throw new Exception("No hay usuarios para modificar");
                if(dgv_Usuarios.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar un usuario para modificar");

                Usuario usuario = dgv_Usuarios.SelectedRows[0].DataBoundItem as Usuario;
                FormUsuarioMod formUsuarioMod = new FormUsuarioMod(usuario, this);
                formUsuarioMod.ShowDialog();
                if (formUsuarioMod.DialogResult == DialogResult.OK)
                {
                    UsuarioBLO.ModificarUsuario(usuario);                     
                    MessageBox.Show("Usuario modificado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
               CargarGrilla();
                //TODO: a todos los metodos modificar que manuipulen una lista se debe agragar un finally para que se actualice la grilla sino tenemos datos inconsistentes
            }
        }

        private void btn_BajaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Usuarios.Rows.Count <= 0) throw new Exception("No hay usuarios para modificar");
                if (dgv_Usuarios.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar un usuario para modificar");

                Usuario usuario = dgv_Usuarios.SelectedRows[0].DataBoundItem as Usuario;
                UsuarioBLO.BajaUsuario(usuario.IdUsuario);
                CargarGrilla();
                MessageBox.Show("Usuario dado de baja correctamente."); 
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        #endregion Fin Botones Form   
       
    }
}
