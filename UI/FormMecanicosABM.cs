using BLL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormMecanicosABM : Form
    {
        MecanicoBLL MecanicoBLO = new MecanicoBLL();
        public TipoMantenimientoBLL TipoMantenimientoBLO = new TipoMantenimientoBLL();
        public FormMecanicosABM()
        {
            InitializeComponent();

        }

        private void FormMecanicosABM_Load(object sender, EventArgs e)
        {
            CargarTiposMantenimiento();
            CargarMecanicos();
        }

        #region Funciones Form

        private void CargarMecanicos()
        {
            try
            {
                List<Mecanico> LMecanicos = MecanicoBLO.ObtenerMecanicos();
                dgv_MecanicosABM.DataSource = null;

                if (checkBox_VerInactivos.Checked)
                {
                    LMecanicos = LMecanicos.Where(m => m.Activo).ToList();
                }
                if (LMecanicos != null && LMecanicos.Count > 0)
                {

                    dgv_MecanicosABM.DataSource = LMecanicos;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarTiposMantenimiento()
        {
            try
            {
                List<TipoMantenimiento> tipos = TipoMantenimientoBLO.ObtenerTiposMantenimiento();
                checkedListBox_Alta.DataSource = null; // Limpia la fuente de datos antes de asignar una nueva
                checkedListBox_Alta.DataSource = tipos;
                checkedListBox_Alta.DisplayMember = "Descripcion"; // Asegúrate de que la clase TipoMantenimiento tenga una propiedad Descripcion
                checkedListBox_Alta.ValueMember = "IdTipoMantenimiento"; // Asegúrate de que la clase TipoMantenimiento tenga una propiedad Id_Tipo_Mantenimiento
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void LimpiarCampos()
        {
            try
            {
                txt_Dni.Clear();
                txt_Nombre.Clear();
                txt_Apellido.Clear();
                txt_Cuil.Clear();
                dtp_FechaNacimiento.Value = DateTime.Now.Date;
                txt_Telefono.Clear();
                txt_Email.Clear();
                txt_MatriculaTecnica.Clear();
                txt_DireccionTaller.Clear();
                foreach (int i in checkedListBox_Alta.CheckedIndices)
                {
                    checkedListBox_Alta.SetItemChecked(i, false);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void checkBox_VerInactivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarMecanicos();
        }

        private void dgv_MecanicosABM_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_MecanicosABM.DataSource != null && dgv_MecanicosABM.SelectedRows.Count > 0)
                {
                    Mecanico mecanicoSeleccionado = dgv_MecanicosABM.SelectedRows[0].DataBoundItem as Mecanico;
                    if (mecanicoSeleccionado != null)
                    {
                        MostrarTiposMantenimiento(mecanicoSeleccionado);
                    }
                }
                else
                {
                    dgv_MecanicosABM.DataSource = null; // Limpia el DataGridView si no hay selección
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarTiposMantenimiento(Mecanico mecanicoSeleccionado)
        {
            try
            {
                checkedListBox_Mostrar.DataSource = null; // Limpia la fuente de datos antes de asignar una nueva
                List<TipoMantenimiento> tipos = TipoMantenimientoBLO.ObtenerTiposMantenimiento();
                checkedListBox_Mostrar.DataSource = tipos;
                checkedListBox_Mostrar.DisplayMember = "Descripcion";
                checkedListBox_Mostrar.ValueMember = "IdTipoMantenimiento";

                for (int i = 0; i < checkedListBox_Mostrar.Items.Count; i++)
                {
                    TipoMantenimiento tipo = (TipoMantenimiento)checkedListBox_Mostrar.Items[i];
                    // Verifica si el tipo de mantenimiento está en la lista del mecánico seleccionado
                    if (mecanicoSeleccionado.TiposDeMantenimiento.Any(t => t.IdTipoMantenimiento == tipo.IdTipoMantenimiento))
                    {
                        checkedListBox_Mostrar.SetItemChecked(i, true); // Marca el tipo de mantenimiento como seleccionado
                    }
                    else
                    {
                        checkedListBox_Mostrar.SetItemChecked(i, false); // Desmarca el tipo de mantenimiento si no está en la lista del mecánico
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        #endregion Fin Funciones Form


        #region Botones Form


        private void btn_AltaMecanico_Click(object sender, EventArgs e)
        {
            try
            {
                Mecanico mecanicoAlta = new Mecanico();
                // mecanicoAlta.TiposDeMantenimiento = new List<TipoMantenimiento>();
                if (!long.TryParse(txt_Dni.Text, out long dni)) throw new Exception("el dni debe ser numerico");


                mecanicoAlta.DNI = dni;
                mecanicoAlta.Nombre = txt_Nombre.Text;
                mecanicoAlta.Apellido = txt_Apellido.Text;
                mecanicoAlta.CuitCuil = txt_Cuil.Text;
                mecanicoAlta.FechaNacimiento = dtp_FechaNacimiento.Value.Date;
                mecanicoAlta.Telefono = txt_Telefono.Text;
                mecanicoAlta.Email = txt_Email.Text;
                mecanicoAlta.MatriculaTecnica = txt_MatriculaTecnica.Text;
                mecanicoAlta.DireccionTaller = txt_DireccionTaller.Text;

                var tiposSeleccionados = checkedListBox_Alta.CheckedItems.Cast<TipoMantenimiento>().ToList();
                foreach (var tipo in tiposSeleccionados)
                {
                    mecanicoAlta.TiposDeMantenimiento.Add(tipo);
                }


                Mecanico personaexistente = MecanicoBLO.BuscarPersonaPorDni(mecanicoAlta.DNI);

                if (personaexistente != null)
                {
                    DialogResult respuesta = MessageBox.Show("Ya existe una persona con ese DNI. ¿Desea actualizar sus datos?", "Persona existente", MessageBoxButtons.YesNo);
                    if (respuesta == DialogResult.Yes)
                    {
                        MecanicoBLO.AltaMecanico(mecanicoAlta); // Actualizar los datos del mecánico
                        MecanicoBLO.ModifcarPersonaExistente(mecanicoAlta);
                        CargarMecanicos();
                        MessageBox.Show("Mecánico creado y actualizado datos correctamente.");
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
                    MecanicoBLO.AltaMecanico(mecanicoAlta);
                    CargarMecanicos();
                    MessageBox.Show("Mecánico creado correctamente.");
                    LimpiarCampos();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_ModMecanico_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_MecanicosABM.Rows.Count <= 0) throw new Exception("no hay mecanicos para dar baja");
                if (dgv_MecanicosABM.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar un mecánico para modificar.");

                Mecanico mecanicoMod = new Mecanico();
                mecanicoMod = dgv_MecanicosABM.SelectedRows[0].DataBoundItem as Mecanico;
                if (mecanicoMod == null) throw new Exception("Debe seleccionar un mecánico válido.");
                FormMecanicoMod formMod = new FormMecanicoMod(mecanicoMod, this);

                if (formMod.ShowDialog() == DialogResult.OK)
                {
                    MecanicoBLO.ModificarMecanico(mecanicoMod);
                    CargarMecanicos();
                    MessageBox.Show("Mecánico modificado correctamente.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_BajaMecanico_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_MecanicosABM.Rows.Count <= 0)throw new Exception("No hay mecánicos cargados.");
                if (dgv_MecanicosABM.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar un mecánico para dar de baja.");
                Mecanico mecanicoBaja = dgv_MecanicosABM.SelectedRows[0].DataBoundItem as Mecanico;
                if (mecanicoBaja == null) throw new Exception("Debe seleccionar un mecánico válido.");
                MecanicoBLO.BajaMecanico(mecanicoBaja.IdMecanico);
                CargarMecanicos();
                MessageBox.Show("Mecánico dado de baja correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }


        #endregion Fin Botone Form
    }
}
