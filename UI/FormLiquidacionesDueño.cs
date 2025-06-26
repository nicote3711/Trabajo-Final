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
        LiquidacionServicioBLL LiquidacionServicioBLO = new LiquidacionServicioBLL();
        FacturaDuenoBLL FacturaDuenoBLO = new FacturaDuenoBLL();

        LiquidacionDuenoBLL LiquidacionDuenoBLO = new LiquidacionDuenoBLL();
        DuenoBLL DuenoBLO = new DuenoBLL();
        public FormLiquidacionesDueño()
        {
            InitializeComponent();
        }

        private void FormLiquidacionesDueño_Load(object sender, EventArgs e)
        {
            CargarComboDueños();

            CargarGrillaLiquidacionesDueno();
            CargarGrillaFacturasDueno();
        }


        #region Funciones Formulario

        private void CargarGrillaLiquidacionesDueno()
        {
            dgv_LiquidacionesDueño.DataSource = null;
            if (cmBox_Dueños.SelectedIndex != -1)
            {
                Dueno dueno = cmBox_Dueños.SelectedItem as Dueno;
                if (dueno != null && dueno.IdDueno != null)
                {
                    List<LiquidacionDueno> ListaLiquidacionesDuenos = LiquidacionDuenoBLO.ObtenerLiquidacionesDPorIdPersonaDueño(dueno.IDPersona).Where(l=> l.IdFactura==null||l.IdFactura<=0).ToList();
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

        private void cmBox_Dueños_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarGrillaLiquidacionesDueno();
                CargarGrillaFacturasDueno();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CalcularMontoTotal()
        {
            if (dgv_LiquidacionesDueño.Rows.Count > 0 && dgv_LiquidacionesDueño.SelectedRows.Count > 0)
            {
                decimal montoTotal = 0;
                foreach (DataGridViewRow row in dgv_LiquidacionesDueño.SelectedRows)
                {

                    LiquidacionDueno liquidacion = row.DataBoundItem as LiquidacionDueno;
                    montoTotal += liquidacion.MontoTotal;
                    Txt_MontoTotal.Text = montoTotal.ToString();
                }
            }
        }

        private void CargarGrillaFacturasDueno()
        {
            try
            {
                dgv_FacturasLiquidacionDueno.DataSource = null;
                List<FacturaDueno> LFacturasDueno = FacturaDuenoBLO.ObtenerFacturas();
                if (cmBox_Dueños.SelectedIndex <= -1)
                {

                    if (LFacturasDueno.Count > 0)
                    {
                        dgv_FacturasLiquidacionDueno.DataSource = LFacturasDueno;
                    }
                }
                else
                {
                    Dueno dueno = cmBox_Dueños.SelectedItem as Dueno;
                    if (dueno == null || dueno.IdDueno <= 0) throw new Exception("Error al obtener el dueño seleccionado en el combo box");
                    LFacturasDueno = LFacturasDueno.Where(f => f.CuilEmisor.Equals(dueno.CuitCuil)).ToList();   
                    dgv_FacturasLiquidacionDueno.DataSource = LFacturasDueno;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_LiquidacionesDueño_SelectionChanged(object sender, EventArgs e)
        {
            CalcularMontoTotal();
        }



        #endregion Fin Funciones Formulario

        #region Botones Formulario

        private void btn_GenerarLiquidaciones_Click(object sender, EventArgs e)
        {
            try
            {
                LiquidacionServicioBLO.GenerarLiquidaciones();
                CargarGrillaLiquidacionesDueno();
                CargarGrillaFacturasDueno();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_RegistrarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_LiquidacionesDueño.Rows.Count <= 0) throw new Exception("Debe haber liquidaciones de dueño para factura");
                if (dgv_LiquidacionesDueño.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar al menos una liquidacion a registrar factura");

                if (string.IsNullOrEmpty(txt_NroFactura.Text) || string.IsNullOrEmpty(Txt_MontoTotal.Text)) throw new Exception("Debe ingresar el numero de factura y visualizar el monto total");

                if (!decimal.TryParse(Txt_MontoTotal.Text, out decimal montoTotal)) throw new Exception("El monto debe ser valido");
                if (!int.TryParse(txt_NroFactura.Text, out int nroFactura)) throw new Exception("El numero de factura ser un numero valido ( solo ingrese digitos del 0 al 9");

                FacturaDueno facturaDueno = new FacturaDueno() { ListaLiquidaciones = new List<LiquidacionDueno>() };
                facturaDueno.NroFactura = nroFactura;
                facturaDueno.MontoTotal = montoTotal;
                facturaDueno.FechaFactura = DateTime.Now.Date;

                Dueno dueno = new Dueno();
                dueno = cmBox_Dueños.SelectedItem as Dueno;
                if (dueno == null) throw new Exception("Error al obtener el dueño del combo box");
                if (string.IsNullOrEmpty(dueno.CuitCuil)) throw new Exception("Error al obtener el Cuil del dueño, este es nulo o vacio");
                facturaDueno.CuilEmisor = dueno.CuitCuil;
                facturaDueno.Dueno = dueno;


                foreach (DataGridViewRow row in dgv_LiquidacionesDueño.SelectedRows)
                {
                    LiquidacionDueno liquidacion = row.DataBoundItem as LiquidacionDueno;
                    if (liquidacion == null) throw new Exception("Error al obtener la liquidacion de la grilla");
                    if (liquidacion.IdFactura != null && liquidacion.IdFactura >= 0) throw new Exception($"La liquidacion{liquidacion.IdLiquidacionServicio} ya tiene una factura asociada{liquidacion.IdFactura}");
                    facturaDueno.ListaLiquidaciones.Add(liquidacion);
                }


                FacturaDuenoBLO.RegistrarFacturaDueno(facturaDueno);
                CargarGrillaLiquidacionesDueno();
                CargarGrillaFacturasDueno();
                MessageBox.Show("Fatura Registrada Correctamente");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_EliminarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_FacturasLiquidacionDueno.Rows.Count <= 0) throw new Exception("No hay facturas para eliminar");
                if (dgv_FacturasLiquidacionDueno.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar una factura a eliminar");
                FacturaDueno factura = dgv_FacturasLiquidacionDueno.SelectedRows[0].DataBoundItem as FacturaDueno;
                if (factura == null) throw new Exception("Fallo al obtener la fatura de la grilla");
                if (factura.Transaccion != null && factura.Transaccion.IdTransaccionFinanciera >= 0) throw new Exception("No se puede eliminar una factura que ya fue pagada");

                FacturaDuenoBLO.EliminarFactura(factura);
                CargarGrillaFacturasDueno();
                CargarGrillaLiquidacionesDueno();

                MessageBox.Show("Factura Eliminada correctamente");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion Fin Botones Formulario



    }
}
