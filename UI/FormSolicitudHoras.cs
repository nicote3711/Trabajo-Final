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
    public partial class FormSolicitudHoras : Form
    {
        FacturaSolicitudHorasBLL FacturaSolicitudHorasBLO = new FacturaSolicitudHorasBLL();
        ClienteBLL ClienteBLO = new ClienteBLL();
        SolicitudHorasBLL SolicitudHorasBLO = new SolicitudHorasBLL();
        public FormSolicitudHoras()
        {
            InitializeComponent();


        }

        private void FormSolicitudHoras_Load(object sender, EventArgs e)
        {
            CargarComboBoxCliente();
            CargarDgvFacturaSolicitud();
            CargarDgvSolicitud();
        }


        #region Funciones Formulario
        private void CargarComboBoxCliente()
        {
            try
            {
                List<Cliente> LClientes = ClienteBLO.ObtenerClientes().Where(c => c.Activo).ToList();
                if (LClientes != null && LClientes.Count > 0)
                {
                    cmBox_Cliente.DataSource = LClientes;
                    cmBox_Cliente.DisplayMember = "Identificar"; // Asumiendo que tienes una propiedad NombreCompleto en Cliente
                    cmBox_Cliente.ValueMember = "IDCliente"; // Asumiendo que IDCliente es la clave primaria
                    cmBox_Cliente.SelectedIndex = -1; // Para que no seleccione nada por defecto
                    cmBox_Cliente.Text = "Seleccione un cliente";
                }
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
                cmBox_Cliente.SelectedIndex = -1; // Para que no seleccione nada por defecto
                cmBox_Cliente.Text = "Seleccione un cliente";
                txt_CantHoraVuelo.Clear();
                txt_CantHoraSimu.Clear();
                txt_PrecioHoraSimu.Clear();
                txt_PrecioHoraVuelo.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarDgvFacturaSolicitud()
        {
            try
            {
                List<FacturaSolicitudHoras> Lfacturas = FacturaSolicitudHorasBLO.ObtenerFacturas();
                if (Lfacturas != null && Lfacturas.Count > 0)
                {
                    dgv_FacturaSolicitudHoras.DataSource = null;
                    dgv_FacturaSolicitudHoras.DataSource = Lfacturas;
                }
                else
                {
                   dgv_FacturaSolicitudHoras.DataSource = null; // Limpiar el DataGridView si no hay facturas
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CargarDgvSolicitud()
        {
            try
            {
                List<SolicitudHoras> LSolicitudes = SolicitudHorasBLO.ObtenerSolicitudesHoras();
                if (LSolicitudes != null && LSolicitudes.Count > 0)
                {
                    dgv_SolicitudHoras.DataSource = null;
                    dgv_SolicitudHoras.DataSource = LSolicitudes;
                }
                else
                {
                     dgv_SolicitudHoras.DataSource = null; // Limpiar el DataGridView si no hay solicitudes
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion Fin Funciones Formulario 

        #region Botones Formulario
        private void btnSolicitadHoras_Click(object sender, EventArgs e)
        {
            try
            {
                SolicitudHoras solicitudHoras = new SolicitudHoras();

                if (!decimal.TryParse(txt_CantHoraVuelo.Text, out decimal cantidadHorasVuelo)) throw new ArgumentException("La cantidad de horas de vuelo debe ser un número válido.");
                if (!decimal.TryParse(txt_CantHoraSimu.Text, out decimal cantidadHorasSimulador)) throw new ArgumentException("La cantidad de horas de simulador debe ser un número válido.");
                if (!decimal.TryParse(txt_PrecioHoraVuelo.Text, out decimal precioHoraVuelo)) throw new ArgumentException("El precio por hora de vuelo debe ser un número válido.");
                if (!decimal.TryParse(txt_PrecioHoraSimu.Text, out decimal precioHoraSimulador)) throw new ArgumentException("El precio por hora de simulador debe ser un número válido.");

                if (cmBox_Cliente.SelectedItem == null) throw new ArgumentException("Debe seleccionar un cliente para la solicitud de horas.");
                if (cmBox_Cliente.SelectedItem != null && cmBox_Cliente.SelectedItem is Cliente clienteSeleccionado)
                {
                    solicitudHoras.Cliente = clienteSeleccionado;
                }
                else
                {
                    throw new ArgumentException("Debe seleccionar un cliente válido para la solicitud de horas.");
                }
                solicitudHoras.CantidadHorasVuelo = cantidadHorasVuelo;
                solicitudHoras.CantidadHorasSimulador = cantidadHorasSimulador;
                solicitudHoras.ValorHoraVuelo = precioHoraVuelo;
                solicitudHoras.ValorHoraSimulador = precioHoraSimulador;
                solicitudHoras.FechaSolicitud = DateTime.Now.Date;

                FacturaSolicitudHoras facturaHoras = new FacturaSolicitudHoras();
                facturaHoras.Solicitud = solicitudHoras;
                FacturaSolicitudHorasBLO.RegistrarFactura(facturaHoras);

                CargarDgvSolicitud();
                CargarDgvFacturaSolicitud();

                LimpiarCampos();
                MessageBox.Show("Solicitud de horas registrada correctamente.");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }




        #endregion Fin Botones Formulario


        private void btn_EliminarSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_SolicitudHoras.Rows.Count <= 0) throw new Exception("No hay solictudes para eliminar");
                if (dgv_SolicitudHoras.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar una solicitud para eliminar.");
                SolicitudHoras solicitudSeleccionada = dgv_SolicitudHoras.SelectedRows[0].DataBoundItem as SolicitudHoras;
                if (solicitudSeleccionada ==null) throw new Exception("No se puede pudo seleccion la solicitud.");

                SolicitudHorasBLO.EliminarSolicitudHoras(solicitudSeleccionada);
                CargarDgvSolicitud();
                CargarDgvFacturaSolicitud();
                LimpiarCampos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
