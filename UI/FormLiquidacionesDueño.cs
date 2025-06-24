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
    public partial class FormLiquidacionesDueño : Form
    {
        public FormLiquidacionesDueño()
        {
            InitializeComponent();
        }
        LiquidacionServicioBLL LiquidacionServicioBLO = new LiquidacionServicioBLL();

        LiquidacionDuenoBLL LiquidacionDuenoBLO = new LiquidacionDuenoBLL();
        DuenoBLL DuenoBLO = new DuenoBLL();

        #region Funciones Formulario

        private void CargarGrillaLiquidacionesDueno()
        {
            dgv_LiquidacionesDueño.DataSource = null;
            if (cmBox_Dueños.SelectedIndex != -1)
            {
                Dueno dueno = cmBox_Dueños.SelectedItem as Dueno;
                if (dueno != null && dueno.IdDueno!=null)
                {
                    List<LiquidacionDueno> ListaLiquidacionesDuenos = LiquidacionDuenoBLO.ObtenerLiquidacionesDPorIdPersonaDueño(dueno.IDPersona);
                    if (ListaLiquidacionesDuenos != null && ListaLiquidacionesDuenos.Count > 0)
                    {
                        dgv_LiquidacionesDueño.DataSource = ListaLiquidacionesDuenos;
                        // dgv_LiquidacionesDueño.Columns["IdLiquidacionServicio"].Visible = false; // Ocultar columna de ID si no es necesaria
                        // dgv_LiquidacionesDueño.Columns["IdPersona"].Visible = false; // Ocultar columna de ID de persona si no es necesaria
                    }
                    else
                    {
                        dgv_LiquidacionesDueño.DataSource = null; // Limpiar grilla si no hay datos
                    }

                }
                
            }
        }

        private void CargarComboDueños()
        {
            try
            {
                List<Dueno> Lduenos = DuenoBLO.ObtenerDuenos();
                if (Lduenos != null && Lduenos.Count > 0)
                {
                    cmBox_Dueños.DataSource = null;
                    cmBox_Dueños.DataSource = Lduenos;
                    cmBox_Dueños.DisplayMember = "Identificar";
                    cmBox_Dueños.ValueMember = "IdDueno";
                    cmBox_Dueños.SelectedIndex = -1;
                    cmBox_Dueños.Text = "Seleccione un dueño";
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los dueños: " + ex.Message);
            }
        }

        #endregion Fin Funciones Formulario

        #region Botones Formulario

        private void btn_GenerarLiquidaciones_Click(object sender, EventArgs e)
        {
            try
            {
                LiquidacionServicioBLO.GenerarLiquidaciones();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        #endregion Fin Botones Formulario

        private void FormLiquidacionesDueño_Load(object sender, EventArgs e)
        {
            CargarComboDueños();
            CargarGrillaLiquidacionesDueno();
        }

        private void cmBox_Dueños_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarGrillaLiquidacionesDueno();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
