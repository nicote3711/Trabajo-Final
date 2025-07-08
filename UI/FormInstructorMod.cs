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
    public partial class FormInstructorMod : Form
    {
        public Instructor instructorModificado;
        public FormInstructorABM formABM;
        public FormInstructorMod(Instructor instuctor, FormInstructorABM fromPpal)
        {
            InitializeComponent();
            txt_IdInstructor.Enabled = false;
            txt_IdPersona.Enabled = false;
            txt_IdInstructor.Text = instuctor.IdInstructor.ToString();
            txt_IdPersona.Text = instuctor.IDPersona.ToString();
            txt_Apellido.Text = instuctor.Apellido;
            txt_Nombre.Text = instuctor.Nombre;
            txt_Cuil.Text = instuctor.CuitCuil;
            txt_Dni.Text = instuctor.DNI.ToString();
            dtp_FechaNacimiento.Value = instuctor.FechaNacimiento.Date;
            txt_Email.Text = instuctor.Email;
            txt_Telefono.Text = instuctor.Telefono;
            txt_Licencia.Text = instuctor.Licencia;
            checkBox_Activo.Checked = instuctor.Activo;

            instructorModificado = instuctor;
            formABM = fromPpal;
        }

        private void btn_ModificarInstructor_Click(object sender, EventArgs e)
        {
            try
            {
                if (!long.TryParse(txt_Dni.Text, out long dni)) throw new Exception("dni invalido este debe ser numerico");
                instructorModificado.Apellido = txt_Apellido.Text;
                instructorModificado.Nombre = txt_Nombre.Text;
                instructorModificado.CuitCuil = txt_Cuil.Text;
                instructorModificado.DNI = dni;
                instructorModificado.Email = txt_Email.Text;
                instructorModificado.FechaNacimiento = dtp_FechaNacimiento.Value.Date;
                instructorModificado.Licencia = txt_Licencia.Text;
                instructorModificado.Telefono = txt_Telefono.Text;
                instructorModificado.Activo = checkBox_Activo.Checked;
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
