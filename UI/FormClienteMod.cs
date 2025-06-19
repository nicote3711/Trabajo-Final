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
            txtFechaNac.Text = ClienteAModificar.FechaNacimiento.ToString("dd/MM/yyyy");    
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
                ClienteModificado.Apellido = txtApellido.Text;
                ClienteModificado.CuitCuil = txtCuil.Text;
                ClienteModificado.DNI = long.Parse(txtDni.Text);
                ClienteModificado.Email = txtEmail.Text;
                ClienteModificado.FechaNacimiento = DateTime.ParseExact(txtFechaNac.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                ClienteModificado.Licencia = txtLicencia.Text;
                ClienteModificado.Telefono = txtTelefono.Text;
                ClienteModificado.Activo = checkBox_Activo.Checked;
                ClienteModificado.IDCliente = int.Parse(txt_IDCliente.Text);
                ClienteModificado.IDPersona = int.Parse(txt_IDPersona.Text);                
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
