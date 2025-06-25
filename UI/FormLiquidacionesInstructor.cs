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
    public partial class FormLiquidacionesInstructor : Form
    {
        LiquidacionServicioBLL LiquidacionServicioBLO = new LiquidacionServicioBLL();
        LiquidacionInstructorBLL LiquidacionInstructorBLO = new LiquidacionInstructorBLL();
        FacturaInstructorBLL FacturaInstructorBLO = new FacturaInstructorBLL();
        InstructorBLL InstructorBLO = new InstructorBLL();


        public FormLiquidacionesInstructor()
        {
            InitializeComponent();
        }

        private void FormLiquidacionesInstructor_Load(object sender, EventArgs e)
        {
            CargarComboInstructores();

            CargarGrillaLiquidacionesI();
            CargarGrillaFacturasI();
        }
        #region Funciones Form
        private void CargarGrillaFacturasI()
        {
            try
            {


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarGrillaLiquidacionesI()
        {
            try
            {
                dgv_LiquidacionesInstructor.DataSource = null;
                if (cmBox_Instructores.SelectedIndex != -1)
                {
                    Instructor instructor = cmBox_Instructores.SelectedItem as Instructor;
                    if (instructor != null && instructor.IdInstructor != null)
                    {
                        List<LiquidacionInstructor> ListaLiquidacionesInstructores = LiquidacionInstructorBLO.ObtenerLiquidacionesIPorIdPersonaDueño(instructor.IDPersona).Where(l => l.IdFactura == null || l.IdFactura <= 0).ToList();
                        if (ListaLiquidacionesInstructores != null && ListaLiquidacionesInstructores.Count > 0)
                        {
                            dgv_LiquidacionesInstructor.DataSource = ListaLiquidacionesInstructores;
                            // dgv_LiquidacionesDueño.Columns["IdLiquidacionServicio"].Visible = false; // Ocultar columna de ID si no es necesaria
                            // dgv_LiquidacionesDueño.Columns["IdPersona"].Visible = false; // Ocultar columna de ID de persona si no es necesaria
                        }
                        else
                        {
                            dgv_LiquidacionesInstructor.DataSource = null; // Limpiar grilla si no hay datos
                        }

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarComboInstructores()
        {
            try
            {
                List<Instructor> LInstructores = InstructorBLO.ObtenerInstructores();
                if (LInstructores != null && LInstructores.Count > 0)
                {
                    cmBox_Instructores.DataSource = null;
                    cmBox_Instructores.DataSource = LInstructores;
                    cmBox_Instructores.DisplayMember = "Identificar";
                    cmBox_Instructores.ValueMember = "IdInstructor";
                    cmBox_Instructores.SelectedIndex = -1;
                    cmBox_Instructores.Text = "Seleccione un dueño";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion Fin Funciones Form


        #region Botones Form






        #endregion Fin Botones FOrm

        private void btn_GenerarLiquidaciones_Click(object sender, EventArgs e)
        {
            try
            {
                LiquidacionServicioBLO.GenerarLiquidaciones();
                CargarGrillaLiquidacionesI();
                CargarGrillaFacturasI();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cmBox_Instructores_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrillaLiquidacionesI();
        }
    }
}
