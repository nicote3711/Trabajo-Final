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
            CargarDuenos();
        }

        private void CargarDuenos()
        {
            List<Dueno> Duenos;
            Duenos = DuenoBLO.ObtenerDuenos();
            var activos = Duenos.Where(d => d.Activo).ToList();
            dgv_DuenoAMB.DataSource = null; 
            dgv_DuenoAMB.DataSource = activos;
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
                duenoAlta.FechaNacimiento = DateTime.Parse(txt_FechaNac.Text);
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
                        CargarDuenos();
                        MessageBox.Show("Dueño creado y actualizado datos correctamente.");
                        return;
                    }
                    else
                    {
                        DuenoBLO.AltaDueno(duenoAlta);
                        CargarDuenos();
                        MessageBox.Show("Dueño creado correctamente.");
                        return;
                    }
                }
                else
                {
                    DuenoBLO.AltaDueno(duenoAlta);
                    CargarDuenos();
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
                if(dgv_DuenoAMB.SelectedRows.Count == 0) throw new Exception("Debe seleccionar un dueño para modificar.");
                if(dgv_DuenoAMB.Rows.Count <= 0) throw new Exception("No hay dueños para modificar.");
                Dueno duenoMod = new Dueno();
                duenoMod.IdDueno = int.Parse(dgv_DuenoAMB.SelectedRows[0].Cells["IdDueno"].Value.ToString());
                duenoMod.IDPersona = int.Parse(dgv_DuenoAMB.SelectedRows[0].Cells["IdPersona"].Value.ToString());
                duenoMod.DNI = long.Parse(dgv_DuenoAMB.SelectedRows[0].Cells["DNI"].Value.ToString());
                duenoMod.Nombre = dgv_DuenoAMB.SelectedRows[0].Cells["Nombre"].Value.ToString();
                duenoMod.Apellido = dgv_DuenoAMB.SelectedRows[0].Cells["Apellido"].Value.ToString();
                duenoMod.CuitCuil = dgv_DuenoAMB.SelectedRows[0].Cells["CuitCuil"].Value.ToString();
                duenoMod.FechaNacimiento = DateTime.Parse(dgv_DuenoAMB.SelectedRows[0].Cells["FechaNacimiento"].Value.ToString());
                duenoMod.Telefono = dgv_DuenoAMB.SelectedRows[0].Cells["Telefono"].Value.ToString();
                duenoMod.Email = dgv_DuenoAMB.SelectedRows[0].Cells["Email"].Value.ToString();
                duenoMod.Activo = Convert.ToBoolean(dgv_DuenoAMB.SelectedRows[0].Cells["Activo"].Value);

                FormDuenoMod formModDueno = new FormDuenoMod(duenoMod, this);
                if(formModDueno.ShowDialog()== DialogResult.OK)
                {
                    DuenoBLO.ModificarDueno(duenoMod);
                    CargarDuenos();
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
                if(dgv_DuenoAMB.Rows.Count <= 0) throw new Exception("No hay dueños para dar de baja.");    
                if (dgv_DuenoAMB.SelectedRows.Count == 0) throw new Exception("Debe seleccionar un dueño para dar de baja.");
                int idDuenoBaja = int.Parse(dgv_DuenoAMB.SelectedRows[0].Cells["IdDueno"].Value.ToString());   
                DuenoBLO.BajaDueno(idDuenoBaja);
                CargarDuenos();
                MessageBox.Show("Dueño dado de baja correctamente.");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
