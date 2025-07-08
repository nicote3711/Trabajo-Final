using ENTITY;
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
    public partial class FormClienteMod : Form
    {
        public Cliente ClienteModificado;
        public FormClienteABM FormABM;
        public FormClienteMod(Cliente ClienteAModificar, FormClienteABM FormPpal)
        {
            InitializeComponent();  
            txt_IDCliente.Enabled = false;
            txt_IDPersona.Enabled = false;
            txtApellido.Text = ClienteAModificar.Apellido;
            txtNombre.Text = ClienteAModificar.Nombre;  
            txtCuil.Text = ClienteAModificar.CuitCuil;
            txtDni.Text = ClienteAModificar.DNI.ToString();
            txtEmail.Text = ClienteAModificar.Email;    
            dtp_FechaNacimiento.Value = ClienteAModificar.FechaNacimiento.Date;    
            txtLicencia.Text = ClienteAModificar.Licencia;
            txt_IDCliente.Text = ClienteAModificar.IDCliente.ToString();
            txt_IDPersona.Text= ClienteAModificar.IDPersona.ToString();
            txtTelefono.Text = ClienteAModificar.Telefono;
            checkBox_Activo.Checked = ClienteAModificar.Activo;
            ClienteModificado = ClienteAModificar;
            FormABM = FormPpal;

        }

        private void btn_ModificarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (!long.TryParse(txtDni.Text, out long dni)) throw new Exception("dni invalido este debe ser numerico");
                ClienteModificado.Nombre = txtNombre.Text;
                ClienteModificado.Apellido = txtApellido.Text;
                ClienteModificado.CuitCuil = txtCuil.Text;
                ClienteModificado.DNI = dni;
                ClienteModificado.Email = txtEmail.Text;
                ClienteModificado.FechaNacimiento = dtp_FechaNacimiento.Value.Date;
                ClienteModificado.Licencia = txtLicencia.Text;
                ClienteModificado.Telefono = txtTelefono.Text;
                ClienteModificado.Activo = checkBox_Activo.Checked;             
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
