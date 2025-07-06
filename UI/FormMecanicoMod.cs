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
    public partial class FormMecanicoMod : Form
    {
        public Mecanico mecanicoModificado;
        public FormMecanicosABM formABM;
        public TipoMantenimientoBLL TipoMantenimientoBLO = new TipoMantenimientoBLL();
        public FormMecanicoMod(Mecanico mecanico, FormMecanicosABM formPpal)
        {
            InitializeComponent();
            txt_IdMecanico.Enabled = false;
            txt_IdPersona.Enabled = false;
            txt_IdMecanico.Text = mecanico.IdMecanico.ToString();
            txt_IdPersona.Text = mecanico.IDPersona.ToString();
            txt_Apellido.Text = mecanico.Apellido;
            txt_Nombre.Text = mecanico.Nombre;
            txt_Cuil.Text = mecanico.CuitCuil;
            txt_Dni.Text = mecanico.DNI.ToString();
            dtp_FechaNacimiento.Value = mecanico.FechaNacimiento.Date;
            txt_Telefono.Text = mecanico.Telefono;
            txt_Email.Text = mecanico.Email;
            txt_MatriculaTecnica.Text = mecanico.MatriculaTecnica;
            txt_DireccionTaller.Text = mecanico.DireccionTaller;
            checkBox_Activo.Checked = mecanico.Activo;

            mecanicoModificado = mecanico;
            formABM = formPpal;
        }

        private void FormMecanicoMod_Load(object sender, EventArgs e)
        {
            CargarTiposMantenimiento();
        }

        private void CargarTiposMantenimiento()
        {
            try
            {
                List<TipoMantenimiento> tipos = TipoMantenimientoBLO.ObtenerTiposMantenimiento();
                checkedListBox_Mod.DataSource = null; // Limpia la fuente de datos antes de asignar una nueva
                checkedListBox_Mod.DataSource = tipos;
                checkedListBox_Mod.DisplayMember = "Descripcion"; // Asegúrate de que la clase TipoMantenimiento tenga una propiedad Descripcion
                checkedListBox_Mod.ValueMember = "IdTipoMantenimiento"; // Asegúrate de que la clase TipoMantenimiento tenga una propiedad Id_Tipo_Mantenimiento


                // Luego de cargar los tipos, marcar los que ya tiene el mecánico
                for (int i = 0; i < checkedListBox_Mod.Items.Count; i++)
                {
                    TipoMantenimiento tipo = checkedListBox_Mod.Items[i] as TipoMantenimiento;
                    if (tipo != null && mecanicoModificado.TiposDeMantenimiento.Any(t => t.IdTipoMantenimiento == tipo.IdTipoMantenimiento))
                    {
                        checkedListBox_Mod.SetItemChecked(i, true);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!long.TryParse(txt_Dni.Text, out long dni)) throw new Exception("dni invalido este debe ser numerico");
                mecanicoModificado.Apellido = txt_Apellido.Text;
                mecanicoModificado.Nombre = txt_Nombre.Text;
                mecanicoModificado.CuitCuil = txt_Cuil.Text;
                mecanicoModificado.DNI = dni;
                mecanicoModificado.Email = txt_Email.Text;
                mecanicoModificado.FechaNacimiento = dtp_FechaNacimiento.Value.Date;
                mecanicoModificado.Telefono = txt_Telefono.Text;
                mecanicoModificado.MatriculaTecnica = txt_MatriculaTecnica.Text;
                mecanicoModificado.DireccionTaller = txt_DireccionTaller.Text;
                mecanicoModificado.Activo = checkBox_Activo.Checked;

                // Limpia y vuelve a cargar los tipos de mantenimiento seleccionados
                mecanicoModificado.TiposDeMantenimiento.Clear();

                foreach (TipoMantenimiento tipo in checkedListBox_Mod.CheckedItems)
                {
                    mecanicoModificado.TiposDeMantenimiento.Add(tipo);
                }

                // Validación de que no se quede sin tipos de mantenimiento
                if (!mecanicoModificado.TiposDeMantenimiento.Any()) throw new Exception("Debe seleccionar al menos un tipo de mantenimiento.");
               
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
