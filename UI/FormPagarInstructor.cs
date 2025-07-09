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
    public partial class FormPagarInstructor : Form
    {
        InstructorBLL InstructorBLO = new InstructorBLL();
        FacturaInstructorBLL FacturaInstructorBLO = new FacturaInstructorBLL();
        FormaPagoBLL FormaPagoBLO = new FormaPagoBLL();
        TransaccionFinancieraBLL TransaccionFinancieraBLO = new TransaccionFinancieraBLL();
        public FormPagarInstructor()
        {
            InitializeComponent();

            CargarDgvFacturasImp();
            CargarDgvPagos();
            CargarComboInstructor();
            CargarComboFormaPago();
        }

        #region Funciones Form


        private void CargarDgvPagos()
        {
            try
            {
                dgv_Pagos.DataSource = null;
                List<TransaccionFinanciera> Ltransacciones = TransaccionFinancieraBLO.ObtenerTodas().Where(t => t.TipoTransaccion.IdTipoTransaccion.Equals((int)EnumTipoTransaccion.PagoInstructor)).ToList();


                if (cmBox_Instructor.SelectedIndex >= 0 && cmBox_Instructor.SelectedItem is Instructor)
                {
                    Instructor instructor = cmBox_Instructor.SelectedItem as Instructor;
                    if (instructor == null) throw new Exception("error al obtener dueño del combo box");
                    Ltransacciones = Ltransacciones.Where(tf => tf.Factura is FacturaInstructor fi && fi.CuilEmisor.Equals(instructor.CuitCuil)).ToList();
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
                List<FacturaInstructor> LFacturasInstructor = FacturaInstructorBLO.ObtenerFacturas().Where(f => f.Transaccion == null).ToList();
                dgv_FacturasImpagas.DataSource = null;

                if (cmBox_Instructor.SelectedIndex >= 0 && cmBox_Instructor.SelectedItem is Instructor instructorSeleccionado)
                {
                    LFacturasInstructor = LFacturasInstructor.Where(f => f.Transaccion == null && f.CuilEmisor.Equals(instructorSeleccionado.CuitCuil)).ToList();

                }
                if (LFacturasInstructor.Count > 0) { dgv_FacturasImpagas.DataSource = LFacturasInstructor; }
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
                if (dgv_FacturasImpagas.Rows.Count > 0 && dgv_FacturasImpagas.SelectedRows[0].DataBoundItem is FacturaInstructor)
                {
                    CalcularMontoPago();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarComboInstructor()
        {
            try
            {
                List<Instructor> LInstructores = InstructorBLO.ObtenerInstructores();
                cmBox_Instructor.DataSource = null;
                if (LInstructores.Count > 0)
                {
                    cmBox_Instructor.DataSource = LInstructores;
                    cmBox_Instructor.DisplayMember = "Identificar";
                    cmBox_Instructor.ValueMember = "IdInstructor";
                    cmBox_Instructor.SelectedIndex = -1;
                    cmBox_Instructor.Text = "Seleccione un dueño";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void cmBox_Instructor_SelectedIndexChanged(object sender, EventArgs e)
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
                if (!(dgv_FacturasImpagas.SelectedRows[0].DataBoundItem is FacturaInstructor)) throw new Exception("error al obtener la factura de la grilla");
                FacturaInstructor facturaInstructor = dgv_FacturasImpagas.SelectedRows[0].DataBoundItem as FacturaInstructor;
                if (facturaInstructor == null || facturaInstructor.IdFactura <= 0) throw new Exception(" la factura de la grilla es nula o con id invalido");

                if (!(cmBox_FormaPago.SelectedItem is FormaPago)) throw new Exception(" error al obtener la forma de pago del combo box");
                FormaPago formaPago = cmBox_FormaPago.SelectedItem as FormaPago;
                if (formaPago == null || formaPago.IdFormaPago <= 0) throw new Exception("error al obtener la forma de pago del combo box esta es nula o con id invalido");

                txt_Monto.Text = (facturaInstructor.MontoTotal * formaPago.PorcentajeDescuentoRecargo).ToString();


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
                if (!(dgv_FacturasImpagas.SelectedRows[0].DataBoundItem is FacturaInstructor)) throw new Exception("error de la factura en grilla. No corresponde a la clase factura instructor");

                FacturaInstructor factura = dgv_FacturasImpagas.SelectedRows[0].DataBoundItem as FacturaInstructor;
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

                TransaccionFinancieraBLO.RegistrarPagoInstructor(transaccionFinanciera);
                CargarComboInstructor();
                CargarDgvFacturasImp();
                CargarDgvPagos();
                MessageBox.Show("pago registrado correctamete");

            }
            catch (Exception ex)
            {
                CargarDgvFacturasImp();
                CargarDgvPagos();
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_EliminarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Pagos.Rows.Count <= 0) throw new Exception("no hay pagos de instructor para eliminar");
                if (dgv_Pagos.SelectedRows.Count <= 0) throw new Exception("debe seleccionar un pago a eliminar");
                if (!(dgv_Pagos.SelectedRows[0].DataBoundItem is TransaccionFinanciera)) throw new Exception("error al obtener la transaccion de la grilla");

                TransaccionFinanciera transaccionFinanciera = dgv_Pagos.SelectedRows[0].DataBoundItem as TransaccionFinanciera;
                if (transaccionFinanciera == null) throw new Exception("la transaccion obtenida de la grilla es nula");

                TransaccionFinancieraBLO.EliminarPagoInstructor(transaccionFinanciera);
                CargarDgvPagos();
                CargarDgvFacturasImp();
                MessageBox.Show("pago dueño eliminado exitosamente");
            }
            catch (Exception ex)
            {
                CargarDgvFacturasImp();
                CargarDgvPagos();
                MessageBox.Show(ex.Message);
            }
        }
        #endregion Fin Botones Form


      
    }
}
