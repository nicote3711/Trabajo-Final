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

    public partial class FormCancelarDeuda : Form
    {

        FacturaSolicitudHorasBLL FacturaSolicitudHorasBLO = new FacturaSolicitudHorasBLL();
        ClienteBLL ClienteBLO = new ClienteBLL();
        SolicitudHorasBLL SolicitudHorasBLO = new SolicitudHorasBLL();

        public FormCancelarDeuda()
        {
            InitializeComponent();
        }

        private void FormCancelarDeuda_Load(object sender, EventArgs e)
        {
            CargarComboBoxCliente();
            CargarDgvFacturaSolicitud();
            CargarDgvSolicitud();
        }




        #region Funciones Form


        private void CargarDgvSolicitud()
        {
            try
            {
                dgv_SolicitudHoras.DataSource = null;
                if (cmBox_Cliente.SelectedIndex >= 0 && cmBox_Cliente.SelectedItem is Cliente cli)
                {
                    if (cli == null || cli.IDCliente <= 0) throw new Exception("error al obtener cliente del combo box");
                    List<SolicitudHoras> LSolicitudes = SolicitudHorasBLO.ObtenerSolicitudesHoras().Where(s => s.Factura.Transaccion == null && s.Cliente.IDCliente.Equals(cli.IDCliente)).ToList();

                    if (LSolicitudes.Count > 0) { dgv_SolicitudHoras.DataSource = LSolicitudes; }

                }


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
                dgv_FacturaSolicitudHoras.DataSource = null;
                if (cmBox_Cliente.SelectedIndex >= 0 && cmBox_Cliente.SelectedItem is Cliente cli)
                {
                    if (cli == null || cli.CuitCuil == string.Empty) throw new Exception("error al obtener cliente del combo box");
                    List<FacturaSolicitudHoras> LFacturasSolicitudes = FacturaSolicitudHorasBLO.ObtenerFacturas().Where(f => f.Transaccion == null && f.CuilEmisor.Equals(cli.CuitCuil)).ToList();

                    if (LFacturasSolicitudes.Count > 0) { dgv_FacturaSolicitudHoras.DataSource = LFacturasSolicitudes; }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarComboBoxCliente()
        {
            try
            {
                cmBox_Cliente.DataSource = null;
                List<Cliente> LClientes = ClienteBLO.ObtenerClientes().Where(c => c.Activo && (c.SaldoHorasSimulador <= -10 || c.SaldoHorasVuelo <= -10)).ToList();
                if (LClientes != null && LClientes.Count > 0)
                {
                    cmBox_Cliente.DataSource = LClientes;
                    cmBox_Cliente.DisplayMember = "Identificar";
                    cmBox_Cliente.ValueMember = "IDCliente";
                    cmBox_Cliente.SelectedIndex = -1; // Para que no seleccione nada por defecto
                    cmBox_Cliente.Text = "Seleccione un cliente";
                }
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
                if (cmBox_Cliente.DataSource != null && cmBox_Cliente.SelectedIndex >= 0 && cmBox_Cliente.SelectedItem is Cliente cliente)
                {
                   
                    CargarDgvSolicitud();
                    CargarDgvFacturaSolicitud();

                    if (cliente.SaldoHorasSimulador > -10 && cliente.SaldoHorasVuelo > -10) throw new Exception("error el cliente deberia tener alguno de los 2 saldos inferiores a -10");

                    txt_CantHoraVuelo.Text = cliente.SaldoHorasVuelo < 0 ? Math.Abs(cliente.SaldoHorasVuelo).ToString() : 0.ToString();
                    txt_CantHoraSimu.Text = cliente.SaldoHorasSimulador < 0 ? Math.Abs(cliente.SaldoHorasSimulador).ToString() : 0.ToString();

                }
                else
                {
                    LimpiarCampos();
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





        #endregion Fin Funciones Form


        #region Botones Form





        private void btn_SolicitudDeuda_Click(object sender, EventArgs e)
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

        private void btn_EliminarSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_SolicitudHoras.Rows.Count <= 0) throw new Exception("No hay solictudes para eliminar");
                if (dgv_SolicitudHoras.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar una solicitud para eliminar.");
                SolicitudHoras solicitudSeleccionada = dgv_SolicitudHoras.SelectedRows[0].DataBoundItem as SolicitudHoras;
                if (solicitudSeleccionada == null) throw new Exception("la solicitud obtenida de la grilla es nula la solicitud.");

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







        #endregion Fin Botones Form



    }
}
