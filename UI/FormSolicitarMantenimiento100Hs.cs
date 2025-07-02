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
    public partial class FormSolicitarMantenimiento100Hs : Form
    {
        MantenimientoBLL MantenimientoBLO = new MantenimientoBLL();
        MecanicoBLL MecanicoBLO = new MecanicoBLL();
        public FormSolicitarMantenimiento100Hs()
        {
            InitializeComponent();
        }

        private void FormSolicitarMantenimiento100Hs_Load(object sender, EventArgs e)
        {
            CargarDgvMantPedientes();
            CargarComboMecanicos();
            CargarDgvMantEnCurso();
        }

        #region Funciones Form
        private void CargarComboMecanicos()
        {
            try
            {
                List<Mecanico> LMecanicos = MecanicoBLO.ObtenerMecanicos().Where(m =>m.Activo&& m.TiposDeMantenimiento.Any(tm => tm.IdTipoMantenimiento.Equals((int)EnumTipoMantenimiento.Hs100))).ToList();

                cmBox_Mecanicos.DataSource = null;
                if (LMecanicos.Count > 0)
                {
                    cmBox_Mecanicos.DataSource = LMecanicos;
                    cmBox_Mecanicos.DisplayMember = "Identificar";
                    cmBox_Mecanicos.ValueMember = "IdMecanico";
                    cmBox_Mecanicos.SelectedIndex = -1;
                    cmBox_Mecanicos.Text = "Seleccione un mecanico";
                }
              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cmBox_Mecanicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmBox_Mecanicos.SelectedIndex > -1)
                {
                    Mecanico mecanico = cmBox_Mecanicos.SelectedItem as Mecanico;
                    if (mecanico == null) throw new Exception("error al obtener mecanico del combo box");
                    txt_Telefono.Text = mecanico.Telefono;
                    txt_Mail.Text = mecanico.Email;
                }
                else
                {
                    txt_Telefono.Clear();
                    txt_Mail.Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void CargarDgvMantPedientes()
        {
            try
            {
                List<Mantenimiento> LMantenimientos = MantenimientoBLO.ObtenerTodos().Where(m => m.TipoMantenimiento.IdTipoMantenimiento.Equals((int)EnumTipoMantenimiento.Hs100) && m.EstadoMantenimiento.IdEstadoMantenimiento.Equals((int)EnumEstadoMantenimiento.Pendiente)).ToList();
                dgv_MantenimientosPendientes.DataSource = null;
                if (LMantenimientos.Count > 0)
                {
                    dgv_MantenimientosPendientes.DataSource = LMantenimientos;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void CargarDgvMantEnCurso()
        {
            try
            {
                try
                {
                    List<Mantenimiento> LMantenimientosEnCurso = MantenimientoBLO.ObtenerTodos().Where(m => m.TipoMantenimiento.IdTipoMantenimiento.Equals((int)EnumTipoMantenimiento.Hs100) &&
                                                                                                           m.EstadoMantenimiento.IdEstadoMantenimiento.Equals((int)EnumEstadoMantenimiento.EnMantenimiento)).ToList();

                    dgv_MantenimientosEnCurso.DataSource = null;
                    if(LMantenimientosEnCurso.Count>0)
                    {
                        dgv_MantenimientosEnCurso.DataSource = LMantenimientosEnCurso;
                    }
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar mantenimientos en curso: " + ex.Message);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion Fin Funciones Form


        #region Botones Form

        private void btn_SolicitarMantenimiento_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_MantenimientosPendientes.Rows.Count <= 0) throw new Exception("No hay mantenimientos pendientes");
                if (dgv_MantenimientosPendientes.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar un mantenimiento pendiente");
                if (cmBox_Mecanicos.Items.Count <= 0) throw new Exception("No hay mecanicos para asignar al mantenimiento");
                if (cmBox_Mecanicos.SelectedIndex < 0) throw new Exception("Debe seleccionar un mecanico");
                Mantenimiento mantenimiento = dgv_MantenimientosPendientes.SelectedRows[0].DataBoundItem as Mantenimiento;
                if (mantenimiento == null) throw new Exception("Error al obtener el mantenimiento de la grilla");
                Mecanico mecanico = cmBox_Mecanicos.SelectedItem as Mecanico;
                if (mecanico == null) throw new Exception("Error al obtener el mecanico del combo box");

                MantenimientoBLO.AsignarMecanico(mantenimiento, mecanico);

                CargarDgvMantPedientes();
                CargarDgvMantEnCurso();
                MessageBox.Show("Mantenimiento en Curso. Mecanico asignado exitosamente");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        private void btn_EliminarMatenimiento_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_MantenimientosEnCurso.Rows.Count <= 0) throw new Exception("No hay mantenimientos en curso para eliminiar");
                if (dgv_MantenimientosEnCurso.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar un mantenimiento en curso para eliminar");

                if (!(dgv_MantenimientosEnCurso.SelectedRows[0].DataBoundItem is Mantenimiento)) throw new Exception("error al obtener el mantenimiento de la grilla");
                Mantenimiento mantenimiento = dgv_MantenimientosEnCurso.SelectedRows[0].DataBoundItem as Mantenimiento;
                if (mantenimiento == null) throw new Exception("error mantenimiento de la grilla nulo");

                MantenimientoBLO.DesAsignarMecanico(mantenimiento);

                CargarDgvMantEnCurso();
                CargarDgvMantPedientes();
                MessageBox.Show("mantenimiento eliminado correctamente");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

  

        #endregion Fin Botones Form


    }
}
