using BLL;
using ENTITY;
using ENTITY.Enum;
using Org.BouncyCastle.Pqc.Crypto.Lms;
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
    public partial class FormCobrarFacturaSolicitud : Form
    {
        ClienteBLL ClienteBLO = new ClienteBLL();
        FacturaSolicitudHorasBLL FacturaSolicitudHorasBLO = new FacturaSolicitudHorasBLL();
        FormaPagoBLL FormaPagoBLO = new FormaPagoBLL();
        TransaccionFinancieraBLL TransaccionFinancieraBLO = new TransaccionFinancieraBLL();
        public FormCobrarFacturaSolicitud()
        {
            InitializeComponent();
            CargarDgvFacturasSolicitud();
            CargarDgvTransaccionesCobroHoras();
            CargarComboClientes();
            CargarComboFormaPago();

        }
        private void FormCobrarFacturaSolicitud_Load(object sender, EventArgs e)
        {

        }

        #region Funciones Form

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
        private void CargarComboClientes()
        {
            try
            {
                List<Cliente> LClientes = ClienteBLO.ObtenerClientes();
                cmBox_Cliente.DataSource = null;
                if (LClientes.Count > 0)
                {
                    cmBox_Cliente.DataSource = LClientes;
                    cmBox_Cliente.DisplayMember = "Identificar";
                    cmBox_Cliente.ValueMember = "IDCliente";
                    cmBox_Cliente.SelectedIndex = -1;
                    cmBox_Cliente.Text = "Seleccione un cliente";
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void CargarDgvFacturasSolicitud()
        {
            try
            {
                dgv_FactSoliImp.DataSource = null;
                List<FacturaSolicitudHoras> LFacturasSolicitud = FacturaSolicitudHorasBLO.ObtenerFacturas().Where(f => f.Transaccion == null).ToList();
                if (cmBox_Cliente.SelectedIndex >= 0 && cmBox_Cliente.SelectedItem is Cliente)
                {
                    Cliente cliente = cmBox_Cliente.SelectedItem as Cliente;
                    if (cliente == null) throw new Exception("error al obtener cliente del combo box");
                    LFacturasSolicitud = LFacturasSolicitud.Where(fs => fs.Solicitud.Cliente.IDCliente.Equals(cliente.IDCliente)).ToList();

                }
                if (LFacturasSolicitud.Count > 0) dgv_FactSoliImp.DataSource = LFacturasSolicitud;
                else { txt_Monto.Clear(); }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void cmBox_Cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDgvFacturasSolicitud();
                CargarDgvTransaccionesCobroHoras();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_FactSoliImp_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_FactSoliImp.SelectedRows.Count == 0) return;
                if (dgv_FactSoliImp.Rows.Count > 0 && dgv_FactSoliImp.SelectedRows[0].DataBoundItem is FacturaSolicitudHoras)
                {
                    CalcularMontoPago();
                }

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
                if (dgv_FactSoliImp.SelectedRows.Count == 0) return;
                if (!(dgv_FactSoliImp.SelectedRows[0].DataBoundItem is FacturaSolicitudHoras)) throw new Exception("error al obtener la factura de la grilla");
                FacturaSolicitudHoras facturaSolicitudHoras = dgv_FactSoliImp.SelectedRows[0].DataBoundItem as FacturaSolicitudHoras;
                if (facturaSolicitudHoras == null || facturaSolicitudHoras.IdFactura <= 0) throw new Exception(" la factura de la grilla es nula o con id invalido");

                if (!(cmBox_FormaPago.SelectedItem is FormaPago)) throw new Exception(" error al obtener la forma de pago del combo box");
                FormaPago formaPago = cmBox_FormaPago.SelectedItem as FormaPago;
                if (formaPago == null || formaPago.IdFormaPago <= 0) throw new Exception("error al obtener la forma de pago del combo box esta es nula o con id invalido");

                txt_Monto.Text = (facturaSolicitudHoras.MontoTotal * formaPago.PorcentajeDescuentoRecargo).ToString();


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


        private void CargarDgvTransaccionesCobroHoras()
        {
            try
            {
                dgv_CobrosFactSolicitudes.DataSource = null;
                List<TransaccionFinanciera> Ltransacciones = TransaccionFinancieraBLO.ObtenerTodas().Where(t => t.TipoTransaccion.IdTipoTransaccion.Equals((int)EnumTipoTransaccion.CobroSolicitudHoras)).ToList();


                if (cmBox_Cliente.SelectedIndex >= 0 && cmBox_Cliente.SelectedItem is Cliente)
                {
                    Cliente cliente = cmBox_Cliente.SelectedItem as Cliente;
                    if (cliente == null) throw new Exception("error al obtener cliente del combo box");
                    Ltransacciones = Ltransacciones.Where(tf =>tf.Factura is FacturaSolicitudHoras fsh && fsh.Solicitud.Cliente.IDCliente.Equals(cliente.IDCliente)).ToList(); // no hacia falta puedo buscar por cuit del cliente.
                }

                if (Ltransacciones.Count > 0){dgv_CobrosFactSolicitudes.DataSource = Ltransacciones;}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        #endregion Fin Funciones Form




        #region Botones Form


        private void btn_ConfirmarCobro_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_FactSoliImp.Rows.Count <= 0) throw new Exception("No hay facturas para cobrar");
                if (dgv_FactSoliImp.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar  una factura de solicitud");
                FacturaSolicitudHoras factura = dgv_FactSoliImp.SelectedRows[0].DataBoundItem as FacturaSolicitudHoras;
                if (factura == null) throw new Exception("error al obtener la factura de la grilla");
                if (cmBox_FormaPago.SelectedIndex <= -1) throw new Exception("Debe seleccionar una forma de pago");
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

                TransaccionFinancieraBLO.RegistrarCobroHoras(transaccionFinanciera);

                CargarComboClientes();
                CargarDgvFacturasSolicitud();
                CargarDgvTransaccionesCobroHoras();
                MessageBox.Show("cobro registrado correctamente");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        #endregion Fin Botones Form



        private void btn_EliminarCobro_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_CobrosFactSolicitudes.Rows.Count <= 0) throw new Exception("no hay cobros de horas para eliminar");
                if (dgv_CobrosFactSolicitudes.SelectedRows.Count <= 0) throw new Exception("debe seleccionar un cobro a eliminar");
                if (!(dgv_CobrosFactSolicitudes.SelectedRows[0].DataBoundItem is TransaccionFinanciera)) throw new Exception("error al obtener la transaccion financiera de la grilla");

                TransaccionFinanciera transaccionFinanciera = dgv_CobrosFactSolicitudes.SelectedRows[0].DataBoundItem as TransaccionFinanciera;
                if (transaccionFinanciera == null) throw new Exception("la transaccion obtenida de la grilla es nula");

                TransaccionFinancieraBLO.EliminarCobroHoras(transaccionFinanciera);
                CargarDgvFacturasSolicitud();
                CargarDgvTransaccionesCobroHoras();

                MessageBox.Show("Cobro eliminado exitosamente");

             }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
        }
    }
}
