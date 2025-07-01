using BLL;
using ENTITY;
using ENTITY.Enum;
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
    public partial class FormRegistrarMantenimiento : Form
    {
        MantenimientoBLL MantenimientoBLO = new MantenimientoBLL();
        AeronaveBLL AeronaveBLO = new AeronaveBLL();
        MecanicoBLL MecanicoBLO = new MecanicoBLL();
        EstadoMantenimientoBLL EstadoMantenimientoBLO = new EstadoMantenimientoBLL();
        TipoMantenimientoBLL TipoMantenimientoBLO = new TipoMantenimientoBLL();
        public FormRegistrarMantenimiento()
        {
            InitializeComponent();
        }

        private void FormRegistrarMantenimiento_Load(object sender, EventArgs e)
        {
            CargarComboAeronaves();
            CargarDgvMantenimientos();
            CargarDgvFacturaMantenimientso();
        }

        private void CargarDgvFacturaMantenimientso()
        {
            try
            {

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarDgvMantenimientos()
        {
            try
            {
                dgv_MantenimientosEnCurso.DataSource = null;
                List<Mantenimiento> LMantenimientos = MantenimientoBLO.ObtenerTodos().Where(m => m.EstadoMantenimiento.IdEstadoMantenimiento.Equals((int)EnumEstadoMantenimiento.EnMantenimiento)).ToList();
                if (cmBox_Aeronaves.SelectedIndex >= 0 && cmBox_Aeronaves.SelectedItem is Aeronave)
                {
                    Aeronave aeronave = cmBox_Aeronaves.SelectedItem as Aeronave;
                    if (aeronave == null || aeronave.IdAeronave <= 0) throw new Exception("error al obtener la aeronave del combo box");
                    LMantenimientos = LMantenimientos.Where(m => m.Aeronave.IdAeronave.Equals(aeronave.IdAeronave)).ToList();
                    ;
                }
                if (LMantenimientos.Count > 0) dgv_MantenimientosEnCurso.DataSource = LMantenimientos;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarComboAeronaves()
        {
            try
            {

                List<Aeronave> LAeronaves = AeronaveBLO.ObtenerTodas().Where(a => a.Estado.IdEstadoAeronave.Equals((int)EnumEstadoEaronave.Mantenimiento)).ToList();

                cmBox_Aeronaves.DataSource = null;
                if (LAeronaves.Count > 0)
                {
                    cmBox_Aeronaves.DataSource = LAeronaves;

                    cmBox_Aeronaves.SelectedIndex = -1;
                    cmBox_Aeronaves.Text = "Seleccione una Aeronave";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cmBox_Aeronaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDgvMantenimientos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
