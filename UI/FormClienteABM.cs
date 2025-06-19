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
    public partial class FormClienteABM : Form
    {
        public ClienteBLL ClienteBLO = new ClienteBLL();
        public FormClienteABM()
        {
            InitializeComponent();
        }

        private void FormAMBCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            List<Cliente> Clientes;
            Clientes = ClienteBLO.ObtenerClientes();
            var activos = Clientes.Where(c => c.Activo).ToList();
            dgvClientesAMB.DataSource = null;
            dgvClientesAMB.DataSource = activos;
        }

        private void btn_AltaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente Cliente = new Cliente();
                Cliente.DNI = long.Parse(txtDni.Text);
                Cliente.Nombre = txtNombre.Text;
                Cliente.Apellido = txtApellido.Text;
                Cliente.CuitCuil = txtCuil.Text;
                Cliente.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                Cliente.Telefono = txtTelefono.Text;
                Cliente.Email = txtEmail.Text;
                Cliente.Licencia = txtLicencia.Text;

                Cliente personaexistente = ClienteBLO.BuscarPersonaPorDni(Cliente.DNI);
                if (personaexistente != null)
                {
                    DialogResult respuesta = MessageBox.Show("Ya existe una persona con ese DNI. ¿Desea actualizar sus datos?", "Persona existente", MessageBoxButtons.YesNo);
                    if (respuesta == DialogResult.Yes)
                    {
                        ClienteBLO.AltaCliente(Cliente); // Actualizar los datos del cliente
                        ClienteBLO.ModifcarPersonaExistente(Cliente);
                        CargarClientes();
                        MessageBox.Show("Cliente creado y actualizado datos correctamente.");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Operación cancelada. No se realizaron cambios.");
                        return;
                    }
                }
                else
                {
                    ClienteBLO.AltaCliente(Cliente);
                    CargarClientes();
                    MessageBox.Show("Cliente creado correctamente.");
                }
            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_BajaCli_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientesAMB.Rows.Count <= 0) throw new Exception("No hay clientes para eliminar.");
                if (dgvClientesAMB.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar un cliente para eliminar.");
                int idClienteBaja = Convert.ToInt32(dgvClientesAMB.SelectedRows[0].Cells["IDCliente"].Value);
                ClienteBLO.BajaCliente(idClienteBaja);
                MessageBox.Show("Cliente eliminado correctamente.");
                CargarClientes();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_ModCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientesAMB.Rows.Count <= 0) throw new Exception("No hay clientes para modificar");
                if (dgvClientesAMB.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar un cliente para modificar.");
                Cliente clienteMod = new Cliente();
                clienteMod.IDCliente = Convert.ToInt32(dgvClientesAMB.SelectedRows[0].Cells["IDCliente"].Value);
                clienteMod.DNI = Convert.ToInt64(dgvClientesAMB.SelectedRows[0].Cells["DNI"].Value);
                clienteMod.Nombre = dgvClientesAMB.SelectedRows[0].Cells["Nombre"].Value.ToString();
                clienteMod.Apellido = dgvClientesAMB.SelectedRows[0].Cells["Apellido"].Value.ToString();
                clienteMod.CuitCuil = dgvClientesAMB.SelectedRows[0].Cells["CuitCuil"].Value.ToString();
                clienteMod.FechaNacimiento = DateTime.Parse(dgvClientesAMB.SelectedRows[0].Cells["FechaNacimiento"].Value.ToString());
                clienteMod.Telefono = dgvClientesAMB.SelectedRows[0].Cells["Telefono"].Value.ToString();
                clienteMod.Email = dgvClientesAMB.SelectedRows[0].Cells["Email"].Value.ToString();
                clienteMod.Licencia = dgvClientesAMB.SelectedRows[0].Cells["Licencia"].Value.ToString();
                clienteMod.Activo = Convert.ToBoolean(dgvClientesAMB.SelectedRows[0].Cells["Activo"].Value);
                clienteMod.SaldoHorasSimulador = Convert.ToDecimal(dgvClientesAMB.SelectedRows[0].Cells["SaldoHorasSimulador"].Value);
                clienteMod.SaldoHorasVuelo = Convert.ToDecimal(dgvClientesAMB.SelectedRows[0].Cells["SaldoHorasVuelo"].Value);
                clienteMod.IDPersona = Convert.ToInt32(dgvClientesAMB.SelectedRows[0].Cells["IDPersona"].Value);

                FormClienteMod formModCliente = new FormClienteMod(clienteMod, this);
                if (formModCliente.ShowDialog() == DialogResult.OK)
                {
                    ClienteBLO.ModificarCliente(clienteMod);
                    CargarClientes();
                    MessageBox.Show("Cliente modificado correctamente.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
