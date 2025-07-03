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
    public partial class FormLiquidacionesInstructor : Form
    {
        LiquidacionServicioBLL LiquidacionServicioBLO = new LiquidacionServicioBLL();
        LiquidacionInstructorBLL LiquidacionInstructorBLO = new LiquidacionInstructorBLL();
        FacturaInstructorBLL FacturaInstructorBLO = new FacturaInstructorBLL();
        InstructorBLL InstructorBLO = new InstructorBLL();


        public FormLiquidacionesInstructor()
        {
            InitializeComponent();
        }

        private void FormLiquidacionesInstructor_Load(object sender, EventArgs e)
        {
            CargarComboInstructores();

            CargarGrillaLiquidacionesI();
            CargarGrillaFacturasI();
        }
        #region Funciones Form
        private void CargarGrillaFacturasI()
        {
            try
            {
                dgv_FacturasLiquidacionIns.DataSource = null;
                List<FacturaInstructor> LFacturaInstructor = FacturaInstructorBLO.ObtenerFacturas();
                if (cmBox_Instructores.SelectedIndex <= -1)
                {
                    if (LFacturaInstructor.Count > 0)
                    {
                        dgv_FacturasLiquidacionIns.DataSource = LFacturaInstructor;
                    }
                }
                else
                {
                    Instructor instructor = cmBox_Instructores.SelectedItem as Instructor;
                    if (instructor == null) throw new Exception("Error al obtener el instructor seleccionado en el combo box");
                    LFacturaInstructor = LFacturaInstructor.Where(f => f.CuilEmisor.Equals(instructor.CuitCuil)).ToList();
                    dgv_FacturasLiquidacionIns.DataSource = LFacturaInstructor;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarGrillaLiquidacionesI()
        {
            try
            {
                dgv_LiquidacionesInstructor.DataSource = null;
                if (cmBox_Instructores.SelectedIndex != -1)
                {
                    Instructor instructor = cmBox_Instructores.SelectedItem as Instructor;
                    if (instructor != null && instructor.IdInstructor != null)
                    {
                        List<LiquidacionInstructor> ListaLiquidacionesInstructores = LiquidacionInstructorBLO.ObtenerLiquidacionesIPorIdPersonaInstructor(instructor.IDPersona).Where(l => l.IdFactura == null || l.IdFactura <= 0).ToList();
                        if (ListaLiquidacionesInstructores != null && ListaLiquidacionesInstructores.Count > 0)
                        {
                            dgv_LiquidacionesInstructor.DataSource = ListaLiquidacionesInstructores;
                            // dgv_LiquidacionesDueño.Columns["IdLiquidacionServicio"].Visible = false; // Ocultar columna de ID si no es necesaria
                            // dgv_LiquidacionesDueño.Columns["IdPersona"].Visible = false; // Ocultar columna de ID de persona si no es necesaria
                        }
                        else
                        {
                            dgv_LiquidacionesInstructor.DataSource = null; // Limpiar grilla si no hay datos
                        }

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarComboInstructores()
        {
            try
            {
                List<Instructor> LInstructores = InstructorBLO.ObtenerInstructores();
                if (LInstructores != null && LInstructores.Count > 0)
                {
                    cmBox_Instructores.DataSource = null;
                    cmBox_Instructores.DataSource = LInstructores;
                    cmBox_Instructores.DisplayMember = "Identificar";
                    cmBox_Instructores.ValueMember = "IdInstructor";
                    cmBox_Instructores.SelectedIndex = -1;
                    cmBox_Instructores.Text = "Seleccione un dueño";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cmBox_Instructores_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrillaLiquidacionesI();
            CargarGrillaFacturasI();
        }

        private void dgv_LiquidacionesInstructor_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularMontoTotal();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CalcularMontoTotal()
        {
            if (dgv_LiquidacionesInstructor.Rows.Count > 0 && dgv_LiquidacionesInstructor.SelectedRows.Count > 0)
            {
                try
                {
                    decimal montoTotal = 0;
                    foreach (DataGridViewRow row in dgv_LiquidacionesInstructor.SelectedRows)
                    {
                        LiquidacionInstructor liquidacion = row.DataBoundItem as LiquidacionInstructor;
                        montoTotal += liquidacion.MontoTotal;
                        Txt_MontoTotal.Text = montoTotal.ToString();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }
        }


        #endregion Fin Funciones Form

        #region Botones Form


        private void btn_GenerarLiquidaciones_Click(object sender, EventArgs e)
        {
            try
            {
                LiquidacionServicioBLO.GenerarLiquidaciones();
                CargarGrillaLiquidacionesI();
                CargarGrillaFacturasI();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        #endregion Fin Botones FOrm




        private void btn_RegistrarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_LiquidacionesInstructor.Rows.Count <= 0) throw new Exception("Debe haber liquidaciones de instructor para factura");
                if (dgv_LiquidacionesInstructor.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar al menos una liquidacion a registrar factura");

                if (string.IsNullOrEmpty(txt_NroFactura.Text) || string.IsNullOrEmpty(Txt_MontoTotal.Text)) throw new Exception("Debe ingresar el numero de factura y visualizar el monto total");

                if (!decimal.TryParse(Txt_MontoTotal.Text, out decimal montoTotal)) throw new Exception("El monto debe ser valido");
                if (!int.TryParse(txt_NroFactura.Text, out int nroFactura)) throw new Exception("El numero de factura ser un numero valido ( solo ingrese digitos del 0 al 9");

                FacturaInstructor facturaInstructor = new FacturaInstructor() { ListaLiquidaciones = new List<LiquidacionInstructor>() };
                facturaInstructor.NroFactura = nroFactura;
                facturaInstructor.MontoTotal = montoTotal;
                facturaInstructor.FechaFactura = DateTime.Now.Date;

                Instructor instructor = new Instructor();

                instructor = cmBox_Instructores.SelectedItem as Instructor;
                if (instructor == null) throw new Exception("Error al obtener el instructor del combo box");
                if (string.IsNullOrEmpty(instructor.CuitCuil)) throw new Exception("Error al obtener el cuit del instructor, este es vacio o nulo");
                facturaInstructor.CuilEmisor = instructor.CuitCuil;
                facturaInstructor.Instructor = instructor;


                foreach (DataGridViewRow row in dgv_LiquidacionesInstructor.SelectedRows)
                {
                    LiquidacionInstructor liquidacion = row.DataBoundItem as LiquidacionInstructor;
                    if (liquidacion == null) throw new Exception("Error al obtener la liquidacion de la grilla");
                    if (liquidacion.IdFactura != null && liquidacion.IdFactura >= 0) throw new Exception($"La liquidacion {liquidacion.IdLiquidacionServicio} ya tiene una factura asociada con id {liquidacion.IdFactura}");
                    facturaInstructor.ListaLiquidaciones.Add(liquidacion);
                }

                FacturaInstructorBLO.RegistrarFacturaInstructor(facturaInstructor);

                CargarGrillaLiquidacionesI();
                CargarGrillaFacturasI();
                MessageBox.Show("Factura Registrada Correctamente");
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
                if (dgv_FacturasLiquidacionIns.Rows.Count <= 0) throw new Exception("No hay facturas para eliminar");
                if (dgv_FacturasLiquidacionIns.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar una factura a eliminar");

                FacturaInstructor facturaInstructor = dgv_FacturasLiquidacionIns.SelectedRows[0].DataBoundItem as FacturaInstructor;
                if (facturaInstructor == null) throw new Exception("Fallo al obtener la factura de la grilla");
                if (facturaInstructor.Transaccion != null && facturaInstructor.Transaccion.IdTransaccionFinanciera >= 0) throw new Exception("No se puede eliminar una factura ya pagada");

                FacturaInstructorBLO.EliminarFactura(facturaInstructor);
                CargarGrillaFacturasI();
                CargarGrillaLiquidacionesI();
                MessageBox.Show("Factura eliminada correctamente");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
