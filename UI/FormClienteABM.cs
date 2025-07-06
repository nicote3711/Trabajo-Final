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
            try
            {
                List<Cliente> LClientes = ClienteBLO.ObtenerClientes();
                dgvClientesAMB.DataSource = null;      
                
                if (!checkBox_VerInactivos.Checked){ LClientes = LClientes.Where(c => c.Activo).ToList();}
                                                       
                if(LClientes!=null && LClientes.Count() > 0)
                {
                    dgvClientesAMB.DataSource = LClientes;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void LimpiarCampos()
        {
            txtDni.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtCuil.Text = string.Empty;
            dtp_FechaNacimiento.Value = DateTime.Now;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtLicencia.Text = string.Empty;
        }
        private void btn_AltaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (long.TryParse(txtDni.Text, out long dni) == false || dni <= 0) throw new Exception("El DNI debe ser un número válido y mayor a 0.");
                if (string.IsNullOrWhiteSpace(txtNombre.Text)) throw new Exception("El nombre no puede estar vacío.");
                if (string.IsNullOrWhiteSpace(txtApellido.Text)) throw new Exception("El apellido no puede estar vacío.");
                if (string.IsNullOrWhiteSpace(txtCuil.Text)) throw new Exception("El CUIL no puede estar vacío.");


                Cliente Cliente = new Cliente();
                Cliente.DNI = dni;
                Cliente.Nombre = txtNombre.Text;
                Cliente.Apellido = txtApellido.Text;
                Cliente.CuitCuil = txtCuil.Text;
                Cliente.FechaNacimiento = dtp_FechaNacimiento.Value;
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
                        LimpiarCampos();
                        MessageBox.Show("Cliente creado y actualizado datos correctamente.");
                        return;
                    }
                    else
                    {
                        LimpiarCampos();

                        MessageBox.Show("Operación cancelada. No se realizaron cambios.");
                        return;
                    }
                }
                else
                {
                    ClienteBLO.AltaCliente(Cliente);
                    CargarClientes();
                    LimpiarCampos();
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
                if (!(dgvClientesAMB.SelectedRows[0].DataBoundItem is Cliente cliente)) throw new Exception("error al obtener objeto cliente de la gilla");
                if (cliente == null) throw new Exception("el cliente es nulo");

                ClienteBLO.BajaCliente(cliente.IDCliente);                // solo inactiva al cliente la persona sigue disponible
                CargarClientes();
                MessageBox.Show("Cliente eliminado correctamente.");
              
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
                clienteMod = dgvClientesAMB.SelectedRows[0].DataBoundItem as Cliente;
                if (clienteMod == null) throw new Exception("El cliente seleccionado es nulo.");

                FormClienteMod formModCliente = new FormClienteMod(clienteMod, this);
                if (formModCliente.ShowDialog() == DialogResult.OK)
                {
                    ClienteBLO.ModificarCliente(clienteMod);
                    MessageBox.Show("Cliente modificado correctamente.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                CargarClientes();
            }
        }

        private void checkBox_VerInactivos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CargarClientes();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
