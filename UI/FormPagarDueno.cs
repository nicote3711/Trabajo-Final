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
    public partial class FormPagarDueno : Form
    {
        DuenoBLL DuenoBLO = new DuenoBLL();
        FacturaDuenoBLL FacturaDuenoBLL = new FacturaDuenoBLL();
        TransaccionFinancieraBLL TransaccionFinancieraBLO = new TransaccionFinancieraBLL();
        FormaPagoBLL FormaPagoBLO = new FormaPagoBLL();

        public FormPagarDueno()
        {
            InitializeComponent();

            CargarDgvFacturasImp();
            CargarDgvPagos();
            CargarComboBoxDuenos();
            CargarComboFormaPago();
        }



        #region Funciones Form

        private void CargarDgvPagos()
        {
            try
            {
                dgv_Pagos.DataSource = null;
                List<TransaccionFinanciera> Ltransacciones = TransaccionFinancieraBLO.ObtenerTodas().Where(t => t.TipoTransaccion.IdTipoTransaccion.Equals((int)EnumTipoTransaccion.PagoDueño)).ToList();


                if (cmBox_Dueno.SelectedIndex >= 0 && cmBox_Dueno.SelectedItem is Dueno)
                {
                    Dueno dueno = cmBox_Dueno.SelectedItem as Dueno;
                    if (dueno == null) throw new Exception("error al obtener dueño del combo box");
                    Ltransacciones = Ltransacciones.Where(tf => tf.Factura is FacturaDueno fd && fd.CuilEmisor.Equals(dueno.CuitCuil)).ToList();
                }

                if (Ltransacciones.Count > 0) { dgv_Pagos.DataSource = Ltransacciones; }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
 
        private void CargarDgvFacturasImp()
        {
            try
            {
                List<FacturaDueno> LFacturasDueno = FacturaDuenoBLL.ObtenerFacturas().Where(f => f.Transaccion == null).ToList();
                dgv_FacturasImpagas.DataSource = null;

                if (cmBox_Dueno.SelectedIndex >= 0 && cmBox_Dueno.SelectedItem is Dueno duenoSeleccionado)
                {
                    LFacturasDueno = LFacturasDueno.Where(f => f.Transaccion == null && f.CuilEmisor.Equals(duenoSeleccionado.CuitCuil)).ToList();


                }
                if (LFacturasDueno.Count > 0) { dgv_FacturasImpagas.DataSource = LFacturasDueno; }
                else { txt_Monto.Clear(); }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void dgv_FacturasImpagas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_FacturasImpagas.SelectedRows.Count == 0) return;
                if (dgv_FacturasImpagas.Rows.Count > 0 && dgv_FacturasImpagas.SelectedRows[0].DataBoundItem is FacturaDueno)
                {
                    CalcularMontoPago();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void CargarComboBoxDuenos()
        {
            try
            {
                List<Dueno> LDuenos = DuenoBLO.ObtenerDuenos();
                cmBox_Dueno.DataSource = null;
                if (LDuenos.Count > 0)
                {
                    cmBox_Dueno.DataSource = LDuenos;
                    cmBox_Dueno.DisplayMember = "Identificar";
                    cmBox_Dueno.ValueMember = "IdDueno";
                    cmBox_Dueno.SelectedIndex = -1;
                    cmBox_Dueno.Text = "Seleccione un dueño";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cmBox_Dueno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDgvFacturasImp();
                CargarDgvPagos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void CargarComboFormaPago()
        {
            try
            {
                cmBox_FormaPago.DataSource = null;
                List<FormaPago> LFormasPago = FormaPagoBLO.ObtenerTodos();
                if (LFormasPago.Count > 0)
                {
                    cmBox_FormaPago.DataSource = LFormasPago;
                    cmBox_FormaPago.DisplayMember = "Descripcion";
                    cmBox_FormaPago.ValueMember = "IdFormaPago";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void cmBox_FormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (!(cmBox_FormaPago.SelectedItem is FormaPago)) throw new Exception(" error al obtener la forma de pago del combo box");
                FormaPago formaPago = cmBox_FormaPago.SelectedItem as FormaPago;
                if (formaPago == null || formaPago.IdFormaPago <= 0) throw new Exception("error al obtener la forma de pago del combo box esta es nula o con id invalido");

                if (formaPago.IdFormaPago == (int)EnumFormaPago.Efectivo)
                {
                    txt_RefExterna.Enabled = false;
                    txt_RefExterna.Clear();
                }
                else
                {
                    txt_RefExterna.Enabled = true;
                }
                CalcularMontoPago();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CalcularMontoPago()
        {
            try
            {
                 

                if (dgv_FacturasImpagas.SelectedRows.Count == 0) return;
                if (!(dgv_FacturasImpagas.SelectedRows[0].DataBoundItem is FacturaDueno)) throw new Exception("error al obtener la factura de la grilla");
                FacturaDueno facturaDueno = dgv_FacturasImpagas.SelectedRows[0].DataBoundItem as FacturaDueno;
                if (facturaDueno == null || facturaDueno.IdFactura <= 0) throw new Exception(" la factura de la grilla es nula o con id invalido");

                if (!(cmBox_FormaPago.SelectedItem is FormaPago)) throw new Exception(" error al obtener la forma de pago del combo box");
                FormaPago formaPago = cmBox_FormaPago.SelectedItem as FormaPago;
                if (formaPago == null || formaPago.IdFormaPago <= 0) throw new Exception("error al obtener la forma de pago del combo box esta es nula o con id invalido");

                txt_Monto.Text = (facturaDueno.MontoTotal * formaPago.PorcentajeDescuentoRecargo).ToString();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion Fin Funciones Form

        #region Botones Form
        private void btn_ConfirmarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_FacturasImpagas.Rows.Count <= 0) throw new Exception("No hay facturas para pagar");
                if (dgv_FacturasImpagas.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar una factura a pagar ");
                if (!(dgv_FacturasImpagas.SelectedRows[0].DataBoundItem is FacturaDueno)) throw new Exception("error de la factura en grilla. No corresponde a la clase factura dueño");
                
                FacturaDueno factura = dgv_FacturasImpagas.SelectedRows[0].DataBoundItem as FacturaDueno;
                if (factura == null) throw new Exception("error al obtener factura de la grilla");

                if (cmBox_FormaPago.SelectedIndex <= -1) throw new Exception("Debe seleccionar una forma de pago");
                if (!(cmBox_FormaPago.SelectedItem is FormaPago)) throw new Exception("error el objeto del combo no corresponde con una forma pago");
                FormaPago formaPago = cmBox_FormaPago.SelectedItem as FormaPago;
                if (formaPago == null) throw new Exception("error al obtener la forma de pago del combo box");

                TransaccionFinanciera transaccionFinanciera = new TransaccionFinanciera();
                transaccionFinanciera.Factura = factura;
                transaccionFinanciera.FormaPago = formaPago;
                transaccionFinanciera.FechaTransaccion = dtp_FechaPago.Value.Date;

                if (!string.IsNullOrEmpty(txt_RefExterna.Text))
                {
                    if (!int.TryParse(txt_RefExterna.Text, out int refExterna)) throw new Exception("la referencia externa debe ser numerica");
                    transaccionFinanciera.ReferenciaExterna = refExterna;
                }
                transaccionFinanciera.MontoTransaccion = decimal.Parse(txt_Monto.Text);

                TransaccionFinancieraBLO.RegistrarPagoDueno(transaccionFinanciera);

                CargarComboBoxDuenos();
                CargarDgvFacturasImp();
                CargarDgvPagos();
                MessageBox.Show("pago registrado correctamete");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_EliminarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Pagos.Rows.Count <= 0) throw new Exception("no hay pagos de dueño para eliminar");
                if (dgv_Pagos.SelectedRows.Count <= 0) throw new Exception("debe seleccionar un pago a eliminar");
                if (!(dgv_Pagos.SelectedRows[0].DataBoundItem is TransaccionFinanciera)) throw new Exception("error al obtener la transaccion de la grilla");

                TransaccionFinanciera transaccionFinanciera = dgv_Pagos.SelectedRows[0].DataBoundItem as TransaccionFinanciera;
                if (transaccionFinanciera == null) throw new Exception("la transaccion obtenida de la grilla es nula");

                TransaccionFinancieraBLO.EliminarPagoDueno(transaccionFinanciera);
                CargarDgvPagos();
                CargarDgvFacturasImp();
                MessageBox.Show("pago dueño eliminado exitosamente");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion Fin Botones Form



 
    }
}
