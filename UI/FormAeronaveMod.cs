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
    public partial class FormAeronaveMod : Form
    {
        Aeronave aeronaveModificada;
        FormAeronaveABM formAeronaveABM;
        private readonly List<Dueno> lDuenos;
        private readonly List<EstadoAeronave> lEstadosAeronave;
        private readonly EstadoAeronaveBLL EstadoAeronaveBLO = new EstadoAeronaveBLL();
        public FormAeronaveMod(Aeronave aeronave, FormAeronaveABM formPpal)
        {
            InitializeComponent();
            txt_IdAeronave.Text = aeronave.IdAeronave.ToString();
            txt_Marca.Text = aeronave.Marca;
            txt_Modelo.Text = aeronave.Modelo;
            txt_Matricula.Text = aeronave.Matricula;
            txt_Ano.Text = aeronave.Año.ToString();
            txt_Revision100Hs.Text = aeronave.Revision100Hs.ToString();
            dtp_RevisionAnual.Value = aeronave.RevisionAnual;

            aeronaveModificada = aeronave;
            formAeronaveABM = formPpal;
            lDuenos = formAeronaveABM.DuenoBLO.ObtenerDuenos();
            lEstadosAeronave = EstadoAeronaveBLO.ObtenerTodos();

        }



        private void FormAeronaveMod_Load(object sender, EventArgs e)
        {
            CargarCombosBox();
        }

        private void CargarCombosBox()
        {
            try
            {
                cmbox_Dueno.DataSource = null;
                cmbox_Dueno.DataSource = lDuenos.Where(d => d.Activo).OrderByDescending(d => d.DNI).ToList();
                cmbox_Dueno.DisplayMember = "Identificar";
                cmbox_Dueno.ValueMember = "IdDueno";
                if (aeronaveModificada.Dueno != null)
                {
                    cmbox_Dueno.SelectedValue = aeronaveModificada.Dueno.IdDueno;
                }
                else
                {
                    cmbox_Dueno.SelectedIndex = -1; // Para que no seleccione un dueño por defecto
                    cmbox_Dueno.Text = "Seleccione un dueño";
                }
                cmbox_Estado.DataSource = null;
                cmbox_Estado.DataSource = lEstadosAeronave;
                cmbox_Estado.DisplayMember = "Descripcion";
                cmbox_Estado.ValueMember = "IdEstadoAeronave";

                cmbox_Estado.SelectedValue = aeronaveModificada.Estado.IdEstadoAeronave;

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
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(txt_Matricula.Text))throw new Exception("La matrícula es obligatoria.");
                if (!int.TryParse(txt_Ano.Text, out int ano))throw new Exception("El año debe ser un número válido.");
                if (!decimal.TryParse(txt_Revision100Hs.Text, out decimal revisionHs))throw new Exception("La revisión 100Hs debe ser un número decimal válido.");

                // Actualizamos los campos en el objeto ya instanciado
                aeronaveModificada.Matricula = txt_Matricula.Text;
                aeronaveModificada.Marca = txt_Marca.Text;
                aeronaveModificada.Modelo = txt_Modelo.Text;
                aeronaveModificada.Año = ano;
                aeronaveModificada.Revision100Hs = revisionHs;
                aeronaveModificada.RevisionAnual = dtp_RevisionAnual.Value;

                // Dueño (puede ser nulo)
                if (cmbox_Dueno.SelectedIndex != -1)
                {
                    aeronaveModificada.Dueno = cmbox_Dueno.SelectedItem as Dueno;
                }
                else
                {
                    aeronaveModificada.Dueno = null;
                }
                   
                aeronaveModificada.Estado = cmbox_Estado.SelectedItem as EstadoAeronave;
                if (aeronaveModificada.Estado == null)throw new Exception("Debe seleccionar un estado para la aeronave.");
                


                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
