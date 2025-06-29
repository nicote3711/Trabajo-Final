using BLL;
using ENTITY;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormLlenadoDeDatos : Form
    {
        public FormLlenadoDeDatos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FormLlenadoDeDatos_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerarClientes_Click(object sender, EventArgs e)
        {
            ClienteBLL clienteBLO = new ClienteBLL();   
            Cliente Cliente = new Cliente();
            Cliente.DNI = 123456789;
            Cliente.Nombre = "";
            Cliente.Apellido = string.Empty;
            Cliente.CuitCuil = "";
            Cliente.FechaNacimiento = DateTime.Now;
            Cliente.Telefono = string.Empty;
            Cliente.Email = string.Empty;
            Cliente.Licencia = string.Empty;

            Cliente personaexistente = clienteBLO.BuscarPersonaPorDni(Cliente.DNI);
            if (personaexistente != null)
            {
                DialogResult respuesta = MessageBox.Show("Ya existe una persona con ese DNI. ¿Desea actualizar sus datos?", "Persona existente", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    clienteBLO.AltaCliente(Cliente); // Actualizar los datos del cliente
                    clienteBLO.ModifcarPersonaExistente(Cliente);
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
                clienteBLO.AltaCliente(Cliente);
                MessageBox.Show("Cliente creado correctamente.");
            }
        }
    }
}
