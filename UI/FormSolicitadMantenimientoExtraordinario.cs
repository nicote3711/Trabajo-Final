using BLL;
using ENTITY;
using ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormSolicitadMantenimientoExtraordinario : Form
    {
        MantenimientoBLL MantenimientoBLO = new MantenimientoBLL();
        AeronaveBLL AeronaveBLO = new AeronaveBLL();
        MecanicoBLL MecanicoBLO = new MecanicoBLL();
        EstadoMantenimientoBLL EstadoMantenimientoBLO = new EstadoMantenimientoBLL();
        TipoMantenimientoBLL TipoMantenimientoBLO = new TipoMantenimientoBLL();


        public FormSolicitadMantenimientoExtraordinario()
        {
            InitializeComponent();
        }
        private void FormSolicitadMantenimientoExtraordinario_Load(object sender, EventArgs e)
        {
            CargarComboAeronaves();
            CargarComboMecanicos();
            CargarDgvMantenimientosEnCurso();
        }


        #region Funciones Form


        private void CargarComboMecanicos()
        {
            try
            {
                List<Mecanico> LMecanicos = MecanicoBLO.ObtenerMecanicos().Where(m => m.Activo && m.TiposDeMantenimiento.Any(tm => tm.IdTipoMantenimiento.Equals((int)EnumTipoMantenimiento.Extraordinario))).ToList();

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

        private void CargarDgvMantenimientosEnCurso()
        {
            try
            {
                List<Mantenimiento> LMantenimientosEnCurso = MantenimientoBLO.ObtenerTodos().Where(m => m.TipoMantenimiento.IdTipoMantenimiento.Equals((int)EnumTipoMantenimiento.Extraordinario) &&
                                                                                                        m.EstadoMantenimiento.IdEstadoMantenimiento.Equals((int)EnumEstadoMantenimiento.EnMantenimiento)).ToList();

                dgv_MantenimientosEnCurso.DataSource = null;
                if (LMantenimientosEnCurso.Count > 0)
                {
                    dgv_MantenimientosEnCurso.DataSource = LMantenimientosEnCurso;
                }
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
                List<Aeronave> LAeronaves = AeronaveBLO.ObtenerTodas().Where(a => a.Estado.IdEstadoAeronave.Equals((int)EnumEstadoEaronave.Activo)).ToList();
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




        #endregion Fin Funciones Form



        #region Botones Form
        private void btn_SolicitarMantenimiento_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_Detalle.Text)) throw new Exception("Debe ingresar un detalle de la averia para el mantenimiento");
                if (cmBox_Aeronaves.SelectedIndex <= -1) throw new Exception("debe seleccionar la aeronave a la que se le debe realizar el mantenimiento");
                if (!(cmBox_Aeronaves.SelectedItem is Aeronave)) throw new Exception("error al obtener la aeronave del combo box ");
                Aeronave aeronave = cmBox_Aeronaves.SelectedItem as Aeronave;

                if (cmBox_Mecanicos.SelectedIndex <= -1) throw new Exception("debe seleccionar al mecanico asignado al mantenimiento");
                if (!(cmBox_Mecanicos.SelectedItem is Mecanico)) throw new Exception("error al obtener el mecanico del combo box");
                Mecanico mecanico = cmBox_Mecanicos.SelectedItem as Mecanico;

                Mantenimiento mantenimiento = new Mantenimiento();

                TipoMantenimiento tipoMantenimiento = TipoMantenimientoBLO.BuscarTipoMantenimientoPorId((int)EnumTipoMantenimiento.Extraordinario);
                EstadoMantenimiento estado = EstadoMantenimientoBLO.BuscarEstadoMantenimientoPorId((int)EnumEstadoMantenimiento.EnMantenimiento);

                mantenimiento.Fecha = DateTime.Now.Date;
                mantenimiento.Detalle = txt_Detalle.Text;
                mantenimiento.Mecanico = mecanico;
                mantenimiento.Aeronave = aeronave;
                mantenimiento.TipoMantenimiento = tipoMantenimiento;
                mantenimiento.EstadoMantenimiento = estado;

                MantenimientoBLO.AltaMantenimiento(mantenimiento);

                CargarComboAeronaves();
                CargarDgvMantenimientosEnCurso();
                MessageBox.Show("solicutud de mantenimiento extraordinario Exitosa!");

            }
            catch (Exception ex)
            {
                CargarDgvMantenimientosEnCurso();
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_EliminarMatenimiento_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_MantenimientosEnCurso.Rows.Count <= 0) throw new Exception("no hay mantenimientos en curso para eliminar");
                if (dgv_MantenimientosEnCurso.SelectedRows.Count <= 0) throw new Exception("debe seleccionar un mantenimiento a eliminar");
                if (!(dgv_MantenimientosEnCurso.SelectedRows[0].DataBoundItem is Mantenimiento)) throw new Exception("error al obtener el mantenimiento de la grilla");

                Mantenimiento mantenimiento = dgv_MantenimientosEnCurso.SelectedRows[0].DataBoundItem as Mantenimiento;

                MantenimientoBLO.EliminarMantenimiento(mantenimiento);

                CargarComboAeronaves();
                CargarDgvMantenimientosEnCurso();
                MessageBox.Show("se elimino el mantenimiento extraordinario exitosamente");
            }
            catch (Exception ex)
            {
                CargarDgvMantenimientosEnCurso();
                MessageBox.Show(ex.Message);
            }
        }

        #endregion Fin Botones Form


    }
}
