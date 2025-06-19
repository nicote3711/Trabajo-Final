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
    public partial class FormRegistrarVuelo : Form
    {
        private readonly BLL.FinalidadBLL FinalidadBLO = new BLL.FinalidadBLL();
        private readonly BLL.VueloBLL VueloBLO = new BLL.VueloBLL();
        private readonly BLL.ClienteBLL ClienteBLO = new BLL.ClienteBLL();
        private readonly BLL.InstructorBLL InstructorBLO = new BLL.InstructorBLL();
        private readonly BLL.AeronaveBLL AeronaveBLO = new BLL.AeronaveBLL();
        public FormRegistrarVuelo()
        {
            InitializeComponent();
            ConfigurarDtp();
        }



        private void FormRegistrarVuelo_Load(object sender, EventArgs e)
        {
            CargarDgvVuelos();
            CargarCombosBox();
        }


        #region Controles Formulario

        private void ConfigurarDtp()
        {
            try
            {
                dtp_Fecha.Format = DateTimePickerFormat.Custom;
                dtp_Fecha.CustomFormat = "dd/MM/yyyy"; // Formato de fecha personalizado
                dtp_HoraPM.CustomFormat = "HH:mm";
                dtp_HoraPM.ShowUpDown = true; // Para mostrar un control de hora
                dtv_HoraCorte.CustomFormat = "HH:mm";
                dtv_HoraCorte.ShowUpDown = true; // Para mostrar un control de hora
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarDgvVuelos()
        {
            try
            {
                List<Vuelo> LVuelo = VueloBLO.ObtenerVuelos();
                if (LVuelo != null && LVuelo.Count > 0)
                {
                    dgv_Vuelos.DataSource = null;
                    dgv_Vuelos.Columns.Clear();
                    dgv_Vuelos.AutoGenerateColumns = false;


                    // Id Vuelo
                    dgv_Vuelos.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Id Vuelo",
                        DataPropertyName = "IdVuelo",
                        Name = "colIdVuelo",
                        ReadOnly = true
                    });
                    // Fecha
                    dgv_Vuelos.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Fecha",
                        DataPropertyName = "Fecha",
                        Name = "colFecha",
                        ReadOnly = true
                    });

                    // Cliente
                    dgv_Vuelos.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Cliente",
                        Name = "colCliente",
                        DataPropertyName = "Cliente",
                        ReadOnly = true
                    });

                    // Instructor
                    dgv_Vuelos.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Instructor",
                        Name = "colInstructor",
                        DataPropertyName = "Instructor",
                        ReadOnly = true
                    });

                    // Aeronave
                    dgv_Vuelos.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Aeronave",
                        Name = "colAeronave",
                        DataPropertyName = "Aeronave",
                        ReadOnly = true
                    });

                    // Finalidad
                    dgv_Vuelos.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Finalidad",
                        Name = "colFinalidad",
                        DataPropertyName = "Finalidad",
                        ReadOnly = true
                    });

                    // Hora PM
                    dgv_Vuelos.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Hora PM",
                        DataPropertyName = "HoraPM",
                        Name = "colHoraPM",
                        ReadOnly = true
                    });

                    // Hora Corte
                    dgv_Vuelos.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Hora Corte",
                        DataPropertyName = "HoraCorte",
                        Name = "colHoraCorte",
                        ReadOnly = true
                    });

                    // Tiempo de vuelo (TV)
                    dgv_Vuelos.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "TV (hs)",
                        DataPropertyName = "TV",
                        Name = "colTV",
                        ReadOnly = true
                    });

                    // Hub Inicial
                    dgv_Vuelos.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Hub Inicial",
                        DataPropertyName = "HubInicial",
                        Name = "colHubInicial",
                        ReadOnly = true
                    });

                    // Hub Final
                    dgv_Vuelos.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Hub Final",
                        DataPropertyName = "HubFinal",
                        Name = "colHubFinal",
                        ReadOnly = true
                    });

                    // Hub Diff
                    dgv_Vuelos.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Diferencia Hub",
                        DataPropertyName = "HubDiff",
                        Name = "colHubDiff",
                        ReadOnly = true
                    });

                    // Liquidado
                    dgv_Vuelos.Columns.Add(new DataGridViewCheckBoxColumn
                    {
                        HeaderText = "Liquidado",
                        DataPropertyName = "Liquidado",
                        Name = "colLiquidado",
                        ReadOnly = true
                    });

                    // Origen
                    dgv_Vuelos.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Origen",
                        DataPropertyName = "Origen",
                        Name = "colOrigen",
                        ReadOnly = true
                    });

                    // Destino
                    dgv_Vuelos.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Destino",
                        DataPropertyName = "Destino",
                        Name = "colDestino",
                        ReadOnly = true
                    });

                    // Cargar datos
                    dgv_Vuelos.DataSource = LVuelo;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarCombosBox()
        {
            try
            {
                CargarComboBoxFinalidad();
                CargarComboBoxClientes();
                CargarCOmboboxAeronaves();
                CargarComboBoxInstructor();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarComboBoxInstructor()
        {
            try
            {
                List<Instructor> LInstructores = InstructorBLO.ObtenerInstructores().Where(i => i.Activo).ToList();
                if (LInstructores != null && LInstructores.Count > 0)
                {
                    cmBox_Instructor.DataSource = LInstructores;
                    cmBox_Instructor.DisplayMember = "Identificar"; // Asumiendo que tienes una propiedad NombreCompleto en Instructor
                    cmBox_Instructor.ValueMember = "IdInstructor"; // Asumiendo que IdInstructor es la clave primaria
                    cmBox_Instructor.SelectedIndex = -1; // Para que no seleccione nada por defecto
                    cmBox_Instructor.Text = "Seleccione un instructor";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarCOmboboxAeronaves()
        {
            try
            {
                List<Aeronave> LAeronaves = AeronaveBLO.ObtenerTodas().Where(a => a.Estado.Descripcion == "Activo").ToList();
                if (LAeronaves != null && LAeronaves.Count > 0)
                {
                    cmBox_Aeronave.DataSource = LAeronaves;
                    cmBox_Aeronave.DisplayMember = "Matricula"; // Asumiendo que tienes una propiedad Matricula en Aeronave
                    cmBox_Aeronave.ValueMember = "IdAeronave"; // Asumiendo que IdAeronave es la clave primaria
                    cmBox_Aeronave.SelectedIndex = -1; // Para que no seleccione nada por defecto
                    cmBox_Aeronave.Text = "Seleccione una aeronave";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarComboBoxClientes()
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

        private void CargarComboBoxFinalidad()
        {
            try
            {
                List<Finalidad> LFinalidad = FinalidadBLO.ObtenerTodas();
                if (LFinalidad != null && LFinalidad.Count >= 0)
                {
                    cmBox_Finalidad.DataSource = LFinalidad;
                    cmBox_Finalidad.DisplayMember = "Descripcion";
                    cmBox_Finalidad.ValueMember = "IdFinalidad";
                    cmBox_Finalidad.SelectedIndex = -1; // Para que no seleccione nada por defecto
                    cmBox_Finalidad.Text = "Seleccione una finalidad";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        #endregion Fin Controles Formulario

        #region  Botones Formulario
        private void btn_RegistrarVuelo_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmBox_Cliente.SelectedItem == null) throw new Exception("Debe seleccionar un cliente.");
                if (cmBox_Aeronave.SelectedItem == null) throw new Exception("Debe seleccionar una aeronave.");
                if (cmBox_Finalidad.SelectedItem == null) throw new Exception("Debe seleccionar una finalidad.");
                if (string.IsNullOrWhiteSpace(txt_HubInicial.Text) || string.IsNullOrWhiteSpace(txt_HubFinal.Text)) throw new Exception("Debe ingresar los valores de HUB.");
                Vuelo vuelo = new Vuelo();

                vuelo.Fecha = dtp_Fecha.Value.Date;
                vuelo.HoraPM = TimeOnly.FromTimeSpan(dtp_HoraPM.Value.TimeOfDay);
                vuelo.HoraCorte = TimeOnly.FromTimeSpan(dtv_HoraCorte.Value.TimeOfDay);
                vuelo.HubInicial = decimal.Parse(txt_HubInicial.Text);
                vuelo.HubFinal = decimal.Parse(txt_HubFinal.Text);
                vuelo.Origen = txt_Origen.Text;
                vuelo.Destino = txt_Destino.Text;
                vuelo.Cliente = cmBox_Cliente.SelectedItem as Cliente;
                vuelo.Aeronave = cmBox_Aeronave.SelectedItem as Aeronave;
                vuelo.Finalidad = cmBox_Finalidad.SelectedItem as Finalidad;
                if (cmBox_Instructor.SelectedItem != null)
                {
                    vuelo.Instructor = cmBox_Instructor.SelectedItem as Instructor; // Puede ser null
                }
                else
                {
                    vuelo.Instructor = null; // Si no se selecciona instructor, se asigna null
                }
                VueloBLO.RegistrarVuelo(vuelo);
                CargarDgvVuelos();
                CargarCombosBox();
                MessageBox.Show("Vuelo registrado correctamente.");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        #endregion Fin Botones Formulario

        private void btn_EliminarVuelo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Vuelos.Rows.Count <= 0) throw new Exception("No hay  vuelos para eliminar");
                if(dgv_Vuelos.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar un vuelo para eliminar.");

                Vuelo vuelo = dgv_Vuelos.SelectedRows[0].DataBoundItem as Vuelo;
                if(vuelo == null) throw new Exception("No se pudo obtener el vuelo seleccionado.");

                DialogResult confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar el vuelo del {vuelo.Fecha.ToShortDateString()} con aeronave {vuelo.Aeronave}?","Confirmar eliminación",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes) return;

                VueloBLO.EliminarVuelo(vuelo);
                CargarDgvVuelos();
                CargarCombosBox();
                MessageBox.Show("Vuelo eliminado correctamente.");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
