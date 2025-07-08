using BLL;
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
    public partial class FormInstructorABM : Form
    {
        public InstructorBLL InstructorBLO = new InstructorBLL();
        public FormInstructorABM()
        {
            InitializeComponent();
            CargarInstructores();
        }

        #region Funciones Form
        private void CargarInstructores()
        {
            try
            {
                List<Instructor> LInstructores = InstructorBLO.ObtenerInstructores();
                dgv_InstructorAMB.DataSource = null;
                if(!checkBox_VerInactivos.Checked )
                {
                    LInstructores = LInstructores.Where(i=>i.Activo).ToList();
                }
                if(LInstructores!=null &&LInstructores.Count > 0)
                {
                    dgv_InstructorAMB.DataSource = LInstructores;
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void checkBox_VerInactivos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CargarInstructores();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        #endregion Funciones Form

        #region Botones Form
        private void btn_AltaInstructor_Click(object sender, EventArgs e)
        {
            try
            {
                if (!long.TryParse(txt_Dni.Text, out long dni)) throw new Exception("dni invalido este debe ser numerico"); 

                Instructor instructorAlta = new Instructor();
                instructorAlta.DNI = dni;
                instructorAlta.Nombre = txt_Nombre.Text;
                instructorAlta.Apellido = txt_Apellido.Text;
                instructorAlta.CuitCuil = txt_Cuil.Text;
                instructorAlta.FechaNacimiento = dtp_FechaNacimiento.Value.Date;
                instructorAlta.Telefono = txt_Telefono.Text;
                instructorAlta.Email = txt_Email.Text;
                instructorAlta.Licencia = txt_Licencia.Text;

                Instructor personaexistente = InstructorBLO.BuscarPersonaPorDni(instructorAlta.DNI);

                if (personaexistente != null)
                {
                    DialogResult respuesta = MessageBox.Show("Ya existe una persona con ese DNI. ¿Desea actualizar sus datos?", "Persona existente", MessageBoxButtons.YesNo);
                    if (respuesta == DialogResult.Yes)
                    {

                        InstructorBLO.AltaInstructor(instructorAlta); // Actualizar los datos del instructor
                        InstructorBLO.ModifcarPersonaExistente(instructorAlta);
                        CargarInstructores();
                        MessageBox.Show("Instructor creado y  actualizado datos correctamente.");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Operación cancelada. No se realizaron cambios.");
                        return;
                    }
                }
                else
                {
                    InstructorBLO.AltaInstructor(instructorAlta);
                    CargarInstructores();
                    MessageBox.Show("Instructor agregado correctamente.");
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_ModInstructor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_InstructorAMB.Rows.Count <= 0) throw new Exception("No hay instructores para modificar");
                if (dgv_InstructorAMB.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar un instructor para modificar.");
                Instructor instructorMod = new Instructor();
                instructorMod = dgv_InstructorAMB.SelectedRows[0].DataBoundItem as Instructor;
                if (instructorMod == null) throw new Exception("Error al seleccionar el instructor de la grilla");

                FormInstructorMod formModInstructor = new FormInstructorMod(instructorMod, this);

                if (formModInstructor.ShowDialog() == DialogResult.OK)
                {
                    InstructorBLO.ModificarInstructor(instructorMod);
                    CargarInstructores();
                    MessageBox.Show("Instructor modificado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CargarInstructores();
            }
        }

        private void btn_BajaInstructor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_InstructorAMB.Rows.Count <= 0) throw new Exception("No hay instructores a eliminar");
                if (dgv_InstructorAMB.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar un instructor para eliminar.");
                if (!(dgv_InstructorAMB.SelectedRows[0].DataBoundItem is Instructor instructor)) throw new Exception("error al obtener instructor de la grilla");
                if (instructor == null) throw new Exception("el instructor de la grilla es nulo");
                
                InstructorBLO.BajaInstructor(instructor.IdInstructor);
                CargarInstructores();
                MessageBox.Show("Instructor eliminado correctamente.");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion Fin Botones Form
    }
}
