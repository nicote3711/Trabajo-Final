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
    public partial class FormDuenoMod : Form
    {
        public Dueno duenoModificado;
        public FormDuenoABM formABM;
        public FormDuenoMod(Dueno Dueno, FormDuenoABM fromPpal)
        {
            InitializeComponent();
            txt_IdDueno.Enabled = false;
            txt_IdPersona.Enabled = false;
            txt_IdDueno.Text = Dueno.IdDueno.ToString();
            txt_IdPersona.Text = Dueno.IDPersona.ToString();
            txt_Apellido.Text = Dueno.Apellido;
            txt_Nombre.Text = Dueno.Nombre; 
            txt_Cuil.Text = Dueno.CuitCuil; 
            txt_Dni.Text = Dueno.DNI.ToString();
            dtp_FechaNacimiento.Value = Dueno.FechaNacimiento.Date;
            txt_Telefono.Text = Dueno.Telefono;
            txt_Email.Text = Dueno.Email;
            checkBox_Activo.Checked = Dueno.Activo;

            duenoModificado = Dueno;
            formABM = fromPpal;
        }

        private void btn_ModificarDueno_Click(object sender, EventArgs e)
        {
            try
            {
                if (!long.TryParse(txt_Dni.Text, out long dni)) throw new Exception("dni invalido este debe ser numerico");
                duenoModificado.Apellido = txt_Apellido.Text;
                duenoModificado.Nombre = txt_Nombre.Text;
                duenoModificado.CuitCuil = txt_Cuil.Text;
                duenoModificado.DNI = dni;
                duenoModificado.Email = txt_Email.Text;
                duenoModificado.FechaNacimiento = dtp_FechaNacimiento.Value.Date;
                duenoModificado.Telefono = txt_Telefono.Text;
                duenoModificado.Activo = checkBox_Activo.Checked;

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
