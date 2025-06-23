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
    public partial class FormDuenoABM : Form
    {
        public DuenoBLL DuenoBLO = new DuenoBLL();
        public FormDuenoABM()
        {
            InitializeComponent();
            CargarDgvDuenos();
        }

        private void CargarDgvDuenos()
        {

            List<Dueno> LDuenos = DuenoBLO.ObtenerDuenos();
            if(checkBox_VerInactivos.Checked )
            {
                LDuenos = LDuenos.Where(d => d.Activo).ToList();
            }
            if(LDuenos != null && LDuenos.Count > 0)
            {
                dgv_DuenoAMB.DataSource = null;
                dgv_DuenoAMB.DataSource = LDuenos;

            }
           
            dgv_DuenoAMB.DataSource = null;
           
        }

        private void btn_AltaDueno_Click(object sender, EventArgs e)
        {
            try
            {
                Dueno duenoAlta = new Dueno();
                duenoAlta.DNI = long.Parse(txt_Dni.Text);
                duenoAlta.Nombre = txt_Nombre.Text;
                duenoAlta.Apellido = txt_Apellido.Text;
                duenoAlta.CuitCuil = txt_Cuil.Text;
                duenoAlta.FechaNacimiento =dtp_FechaNacimiento.Value;
                duenoAlta.Telefono = txt_Telefono.Text;
                duenoAlta.Email = txt_Email.Text;
                duenoAlta.Activo = true; // Por defecto, al dar de alta, el dueño está activo
                Dueno personaExistente = DuenoBLO.BuscarPersonaPorDNI(duenoAlta.DNI);

                if (personaExistente != null)
                {
                    DialogResult respuesta = MessageBox.Show("Ya existe una persona con ese DNI. ¿Desea actualizar sus datos?", "Persona existente", MessageBoxButtons.YesNo);
                    if (respuesta == DialogResult.Yes)
                    {
                        DuenoBLO.AltaDueno(duenoAlta); // Actualizar los datos del dueño
                        DuenoBLO.ModificarPersonaExistente(duenoAlta);
                        CargarDgvDuenos();
                        MessageBox.Show("Dueño creado y actualizado datos correctamente.");
                        return;
                    }
                    else
                    {
                        DuenoBLO.AltaDueno(duenoAlta);
                        CargarDgvDuenos();
                        MessageBox.Show("Dueño creado correctamente.");
                        return;
                    }
                }
                else
                {
                    DuenoBLO.AltaDueno(duenoAlta);
                    CargarDgvDuenos();
                    MessageBox.Show("Dueño creado correctamente.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_ModDueno_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_DuenoAMB.SelectedRows.Count == 0) throw new Exception("Debe seleccionar un dueño para modificar.");
                if (dgv_DuenoAMB.Rows.Count <= 0) throw new Exception("No hay dueños para modificar.");
                Dueno duenoMod = new Dueno();
                duenoMod = dgv_DuenoAMB.SelectedRows[0].DataBoundItem as Dueno;
                if (dgv_DuenoAMB == null) throw new Exception("Error al obtener Dueño de grilla");
           
                FormDuenoMod formModDueno = new FormDuenoMod(duenoMod, this);
                if (formModDueno.ShowDialog() == DialogResult.OK)
                {
                    DuenoBLO.ModificarDueno(duenoMod);
                    CargarDgvDuenos();
                    MessageBox.Show("Dueño modificado correctamente.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_BajaDueno_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_DuenoAMB.Rows.Count <= 0) throw new Exception("No hay dueños para dar de baja.");
                if (dgv_DuenoAMB.SelectedRows.Count == 0) throw new Exception("Debe seleccionar un dueño para dar de baja.");
                int idDuenoBaja = int.Parse(dgv_DuenoAMB.SelectedRows[0].Cells["IdDueno"].Value.ToString());
                DuenoBLO.BajaDueno(idDuenoBaja);
                CargarDgvDuenos();
                MessageBox.Show("Dueño dado de baja correctamente.");
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
                CargarDgvDuenos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
