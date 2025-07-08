using BLL;
using ENTITY;
using ENTITY.Enum;
using iText.Kernel.Pdf.Canvas.Parser.ClipperLib;
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
    public partial class FormRegistrarMantenimiento : Form
    {
        MantenimientoBLL MantenimientoBLO = new MantenimientoBLL();
        AeronaveBLL AeronaveBLO = new AeronaveBLL();
        MecanicoBLL MecanicoBLO = new MecanicoBLL();
        EstadoMantenimientoBLL EstadoMantenimientoBLO = new EstadoMantenimientoBLL();
        TipoMantenimientoBLL TipoMantenimientoBLO = new TipoMantenimientoBLL();
        FacturaMantenimientoBLL FacturaMantenimientoBLO= new FacturaMantenimientoBLL();
        public FormRegistrarMantenimiento()
        {
            InitializeComponent();
        }

        private void FormRegistrarMantenimiento_Load(object sender, EventArgs e)
        {
            CargarComboAeronaves();
            CargarDgvMantenimientos();
            CargarDgvFacturaMantenimientso();
        }
        #region Funciones Form
        private void CargarDgvFacturaMantenimientso()
        {
            try
            {
                dgv_FacturasMantenimiento.DataSource = null;
                List<FacturaMantenimiento> LFactMantenimientos = FacturaMantenimientoBLO.ObtenerTodos().Where(fm=>fm.Transaccion==null||fm.Transaccion.IdTransaccionFinanciera<=0).ToList();

                if (LFactMantenimientos.Count > 0)
                {
                    dgv_FacturasMantenimiento.DataSource = LFactMantenimientos;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarDgvMantenimientos()
        {
            try
            {
                dgv_MantenimientosEnCurso.DataSource = null;
                List<Mantenimiento> LMantenimientos = MantenimientoBLO.ObtenerTodos().Where(m => m.EstadoMantenimiento.IdEstadoMantenimiento.Equals((int)EnumEstadoMantenimiento.EnMantenimiento)).ToList();
                if (cmBox_Aeronaves.SelectedIndex >= 0 && cmBox_Aeronaves.SelectedItem is Aeronave)
                {
                    Aeronave aeronave = cmBox_Aeronaves.SelectedItem as Aeronave;
                    if (aeronave == null || aeronave.IdAeronave <= 0) throw new Exception("error al obtener la aeronave del combo box");
                    LMantenimientos = LMantenimientos.Where(m => m.Aeronave.IdAeronave.Equals(aeronave.IdAeronave)).ToList();
                   
                }
                if (LMantenimientos.Count > 0) dgv_MantenimientosEnCurso.DataSource = LMantenimientos;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarComboAeronaves()
        {
            try
            {

                List<Aeronave> LAeronaves = AeronaveBLO.ObtenerTodas().Where(a => a.Estado.IdEstadoAeronave.Equals((int)EnumEstadoEaronave.Mantenimiento)).ToList();

                cmBox_Aeronaves.DataSource = null;
                if (LAeronaves.Count > 0)
                {
                    cmBox_Aeronaves.DataSource = LAeronaves;

                    cmBox_Aeronaves.SelectedIndex = -1;
                    cmBox_Aeronaves.Text = "Seleccione una Aeronave";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cmBox_Aeronaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDgvMantenimientos();
                CargarDgvFacturaMantenimientso();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        #endregion Fin Funciones Form

        #region Botones Form
        private void btn_RegistrarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_MantenimientosEnCurso.Rows.Count <= 0) throw new Exception("No hay mantenimientos en curso para registrar factura");
                if (dgv_MantenimientosEnCurso.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar un mantenimiento para registrarle su factura");
                if (!(dgv_MantenimientosEnCurso.SelectedRows[0].DataBoundItem is Mantenimiento)) throw new Exception("error al obtener el mantenimiento de la grilla");
                Mantenimiento mantenimiento = dgv_MantenimientosEnCurso.SelectedRows[0].DataBoundItem as Mantenimiento; 

                if (string.IsNullOrEmpty(txt_NroFactura.Text)) throw new Exception("Debe ingresar el numero de factura");
                if (!int.TryParse(txt_NroFactura.Text, out int nroFactrura)) throw new Exception("Numero de factura invalido. Este debe ser numerico");

                if (string.IsNullOrEmpty(txt_MontoTotal.Text)) throw new Exception("Debe ingresar monto total de la factura");
                if (!decimal.TryParse(txt_MontoTotal.Text, out decimal montoTotal)) throw new Exception("Monto de factura. Este debe ser numerico");

                if (string.IsNullOrEmpty(txt_Detalle.Text)) throw new Exception("Debe ingresar el detalle de la factura");

                FacturaMantenimiento facturaMantenimiento = new FacturaMantenimiento();
                facturaMantenimiento.Mantenimiento = mantenimiento;
                facturaMantenimiento.NroFactura = nroFactrura;
                facturaMantenimiento.FechaFactura = dtp_FechaFactura.Value;
                facturaMantenimiento.Detalle = txt_Detalle.Text;
                facturaMantenimiento.MontoTotal = montoTotal;
                 
                FacturaMantenimientoBLO.RegistrarFactura(facturaMantenimiento);
                CargarComboAeronaves();
                CargarDgvFacturaMantenimientso();
                CargarDgvMantenimientos();
                MessageBox.Show("Mantenimiento registrado exitosamente");

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
                if (dgv_FacturasMantenimiento.Rows.Count <= 0) throw new Exception("No hay facturas para elimianr");
                if (dgv_FacturasMantenimiento.SelectedRows.Count <= 0) throw new Exception("Debe seleccion una factura a eliminar");
                if (!(dgv_FacturasMantenimiento.SelectedRows[0].DataBoundItem is FacturaMantenimiento)) throw new Exception("no se pudo obtener la factura de la grilla");

                FacturaMantenimiento factura = dgv_FacturasMantenimiento.SelectedRows[0].DataBoundItem as FacturaMantenimiento;
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar esta factura?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    FacturaMantenimientoBLO.EliminarFacturaMantenimiento(factura);
                    CargarComboAeronaves();
                    CargarDgvFacturaMantenimientso();
                    CargarDgvMantenimientos();
                    MessageBox.Show("Factura eliminada correctamente.");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion Fin Botones Form
    }
}
