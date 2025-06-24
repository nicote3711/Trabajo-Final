using ENTITY;
using ENTITY.Enum;
using Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormAeronaveABM : Form
    {
        public BLL.AeronaveBLL AeronaveBLO = new BLL.AeronaveBLL();
        public BLL.DuenoBLL DuenoBLO = new BLL.DuenoBLL();

        public FormAeronaveABM()
        {
            InitializeComponent();
        }

        private void FormAeronaveABM_Load(object sender, EventArgs e)
        {
            CargarDuenos();
            CargarAeronaves();
        }

        private void CargarAeronaves()
        {
            try
            {
                dgv_Aeronave.DataSource = null;
                List<Aeronave> Laeronaves = AeronaveBLO.ObtenerTodas();
                if (checkBox_VerNoDisp.Checked)
                {
                    dgv_Aeronave.DataSource = Laeronaves;
                }
                else
                {
                    List<Aeronave> aeronavesActivas = Laeronaves.Where(a => a.Estado.IdEstadoAeronave.Equals((int)EnumEstadoEaronave.Activo)).ToList();
                    dgv_Aeronave.DataSource = aeronavesActivas;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarDuenos()
        {
            try
            {

                List<Dueno> Lduenos = DuenoBLO.ObtenerDuenos().Where(d => d.Activo).OrderByDescending(d => d.DNI).ToList();
                cmbox_Dueno.DataSource = null;
                cmbox_Dueno.DataSource = Lduenos;
                cmbox_Dueno.DisplayMember = "Identificar";
                cmbox_Dueno.ValueMember = "IdDueno";

                cmbox_Dueno.SelectedIndex = -1; // Para que no seleccione un dueño por defecto
                cmbox_Dueno.Text = "Seleccione un dueño";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btn_AltaAeronave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_Matricula.Text)) throw new Exception("Debe ingresar una matrícula.");
                if (string.IsNullOrWhiteSpace(txt_Marca.Text)) throw new Exception("Debe ingresar una marca.");
                if (string.IsNullOrWhiteSpace(txt_Modelo.Text)) throw new Exception("Debe ingresar un modelo.");
                if (!int.TryParse(txt_Ano.Text, out int ano)) throw new Exception("El año debe ser un número entero válido.");
                if (!decimal.TryParse(txt_Revision100Hs.Text, out decimal rev100hs)) throw new Exception("La revisión 100Hs debe ser un número válido.");
                DateTime revAnual = dtp_RevisionAnual.Value;


                Aeronave aeronaveAlta = new Aeronave();
                aeronaveAlta.Matricula = txt_Matricula.Text;
                aeronaveAlta.Marca = txt_Marca.Text;
                aeronaveAlta.Modelo = txt_Modelo.Text;
                aeronaveAlta.Año = ano;
                aeronaveAlta.Revision100Hs = rev100hs;
                aeronaveAlta.RevisionAnual = revAnual;
                if (cmbox_Dueno.SelectedIndex != -1)
                {
                    aeronaveAlta.Dueno = (Dueno)cmbox_Dueno.SelectedItem;
                }
                else
                {
                    aeronaveAlta.Dueno = null; // Si no se selecciona un dueño, se asigna null
                }
                // se puede escribir en ternario este tambien como : aeronaveAlta.Dueno = cmbox_Dueno.SelectedIndex != -1 ? (Dueno)cmbox_Dueno.SelectedItem : null;

                AeronaveBLO.AltaAeronave(aeronaveAlta);
                CargarAeronaves();
                CargarDuenos();
                LimpiarTxt();
                MessageBox.Show("Aeronave dada de alta correctamente.");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void LimpiarTxt()
        {
            try
            {
                txt_Matricula.Clear();
                txt_Marca.Clear();
                txt_Modelo.Clear();
                txt_Ano.Clear();
                txt_Revision100Hs.Clear();
                dtp_RevisionAnual.Value = DateTime.Now;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_BajaAeronave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Aeronave.Rows.Count <= 0) throw new Exception("No hay aeronaves para dar la baja");
                if (dgv_Aeronave.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar una aeronave para dar de baja.");

                Aeronave aeronaveSeleccionada = dgv_Aeronave.SelectedRows[0].DataBoundItem as Aeronave;
                if (aeronaveSeleccionada == null) throw new Exception("No se pudo obtener la aeronave seleccionada.");
                AeronaveBLO.BajaAeronave(aeronaveSeleccionada.IdAeronave);
                CargarAeronaves();
                MessageBox.Show("Aeronave dada de baja correctamente.");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void checkBox_VerNoDisp_CheckedChanged(object sender, EventArgs e)
        {
            CargarAeronaves();
        }

        private void btn_ModAeronave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Aeronave.Rows.Count <= 0) throw new Exception("No hay aeronaves para modificar");
                if(dgv_Aeronave.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar una aeronave para modificar.");

                Aeronave aeronave =dgv_Aeronave.SelectedRows[0].DataBoundItem as Aeronave;
                if(aeronave == null) throw new Exception("No se pudo obtener la aeronave seleccionada.");   

                FormAeronaveMod formAeronaveMod = new FormAeronaveMod(aeronave, this);
                if (formAeronaveMod.ShowDialog() == DialogResult.OK)
                {
                    AeronaveBLO.ModificarAeronave(aeronave);
                    CargarAeronaves();
                    CargarDuenos();
                    MessageBox.Show("Aeronave modificada correctamente.");  
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
