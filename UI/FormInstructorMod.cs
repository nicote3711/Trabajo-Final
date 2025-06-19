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
        public FormInstructorMod(Instructor Instuctor, FormInstructorABM fromPpal)
        {
            InitializeComponent();
            txt_IdInstructor.Enabled = false;
            txt_IdPersona.Enabled = false;
            txt_IdInstructor.Text = Instuctor.IdInstructor.ToString();
            txt_IdPersona.Text = Instuctor.IDPersona.ToString();
            txt_Apellido.Text = Instuctor.Apellido;
            txt_Nombre.Text = Instuctor.Nombre;
            txt_Cuil.Text = Instuctor.CuitCuil;
            txt_Dni.Text = Instuctor.DNI.ToString();
            txt_FechaNac.Text = Instuctor.FechaNacimiento.ToString("dd/MM/yyyy");
            txt_Email.Text = Instuctor.Email;
            txt_Telefono.Text = Instuctor.Telefono;
            txt_Licencia.Text = Instuctor.Licencia;
            checkBox_Activo.Checked = Instuctor.Activo;

            instructorModificado = Instuctor;
            formABM = fromPpal;
        }

        private void btn_ModificarInstructor_Click(object sender, EventArgs e)
        {
            try
            {
                instructorModificado.Apellido = txt_Apellido.Text;
                instructorModificado.Nombre = txt_Nombre.Text;
                instructorModificado.CuitCuil = txt_Cuil.Text;
                instructorModificado.DNI = long.Parse(txt_Dni.Text);
                instructorModificado.Email = txt_Email.Text;
                instructorModificado.FechaNacimiento = DateTime.ParseExact(txt_FechaNac.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                instructorModificado.Licencia = txt_Licencia.Text;
                instructorModificado.Telefono = txt_Telefono.Text;
                instructorModificado.IdInstructor = int.Parse(txt_IdInstructor.Text);
                instructorModificado.IDPersona = int.Parse(txt_IdPersona.Text);
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
