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
    public partial class FormRegistrarSimulador : Form
    {
        SimuladorBLL SimuladorBLO = new SimuladorBLL();
        InstructorBLL InstructorBLO = new InstructorBLL();
        ClienteBLL ClienteBLO = new ClienteBLL();
        FinalidadBLL FinalidadBLO = new FinalidadBLL();

        public FormRegistrarSimulador()
        {
            InitializeComponent();
            ConfigurarDtp();
           
        }

        private void FormRegistrarSimulador_Load(object sender, EventArgs e)
        {
            CargarComboBox();
            CargarDgv();
        }



        #region Funciones Form  

          private void ConfigurarDtp()
        {
            try
            {
                dtp_Fecha.Format = DateTimePickerFormat.Custom;
                dtp_Fecha.CustomFormat = "dd/MM/yyyy"; // Formato de fecha personalizado
                dtp_HoraInicio.CustomFormat = "HH:mm";
                dtp_HoraInicio.ShowUpDown = true; // Para mostrar un control de hora
                dtv_HoraFin.CustomFormat = "HH:mm";
                dtv_HoraFin.ShowUpDown = true; // Para mostrar un control de hora
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarComboBox()
        {
            try
            {
                CargarComboBoxFinalidad();
                CargarComboBoxClientes();
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

        private void CargarDgv()
        {
            try
            {
                List<Simulador> LSimu = SimuladorBLO.ObtenerSimuladores();
                if (LSimu!= null && LSimu.Count > 0)
                {
                    dgv_Simus.DataSource = null;
                    dgv_Simus.Columns.Clear();
                    dgv_Simus.AutoGenerateColumns = false; // Deshabilitar la generación automática de columnas

                    // Id Simulador
                    dgv_Simus.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Id Simulador",
                        DataPropertyName = "IdSimulador",
                        Name = "colIdSimulador",
                        ReadOnly = true
                    });

                    // Fecha
                    dgv_Simus.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Fecha",
                        DataPropertyName = "Fecha",
                        Name = "colFecha",
                        ReadOnly = true
                    });

                    // Cliente
                    dgv_Simus.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Cliente",
                        DataPropertyName = "Cliente",
                        Name = "colCliente",
                        ReadOnly = true
                    });

                    // Instructor
                    dgv_Simus.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Instructor",
                        DataPropertyName = "Instructor",
                        Name = "colInstructor",
                        ReadOnly = true
                    });

                    // Finalidad
                    dgv_Simus.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Finalidad",
                        DataPropertyName = "Finalidad",
                        Name = "colFinalidad",
                        ReadOnly = true
                    });

                    // Hora Inicio
                    dgv_Simus.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Hora Inicio",
                        DataPropertyName = "HoraInicio",
                        Name = "colHoraInicio",
                        ReadOnly = true
                    });

                    // Hora Fin
                    dgv_Simus.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Hora Fin",
                        DataPropertyName = "HoraFin",
                        Name = "colHoraFin",
                        ReadOnly = true
                    });

                    // TS (tiempo simulador)
                    dgv_Simus.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "TS (hs)",
                        DataPropertyName = "TS",
                        Name = "colTS",
                        ReadOnly = true
                    });

                    // Id Liquidado
                    dgv_Simus.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Id Liquidacion",
                        DataPropertyName = "IdLiquidacion", // Debes crear esta propiedad bool en la clase Simulador
                        Name = "colLiquidado",
                        ReadOnly = true
                    });
                    dgv_Simus.DataSource = LSimu;
                }
                else
                {
                    dgv_Simus.DataSource = null;                                        
                }
            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        #endregion  Fin Funciones Form



        #region Botones Form
        private void btn_RegistrarSimulador_Click(object sender, EventArgs e)
        {
            try
            {
                Simulador simulador = new Simulador();
                simulador.Fecha = dtp_Fecha.Value.Date;
                simulador.HoraInicio = TimeOnly.FromTimeSpan(dtp_HoraInicio.Value.TimeOfDay);
                simulador.HoraFin = TimeOnly.FromTimeSpan(dtv_HoraFin.Value.TimeOfDay);
                simulador.Instructor = cmBox_Instructor.SelectedItem as Instructor;
                simulador.Cliente = cmBox_Cliente.SelectedItem as Cliente;  
                simulador.Finalidad = cmBox_Finalidad.SelectedItem as Finalidad;

                SimuladorBLO.RegistrarSimulador(simulador);
                CargarDgv();
                CargarComboBox();
                MessageBox.Show("Simulador registrado correctamente."); 

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

     

        private void btn_EliminarSimulador_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Simus.Rows.Count <= 0) throw new Exception("No hay simuladores a eliminar");
                if (dgv_Simus.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar un simulador para eliminar.");

                Simulador simulador = dgv_Simus.SelectedRows[0].DataBoundItem as Simulador;
                if (simulador == null) throw new Exception("Simulador no encontrado.");
                DialogResult confirmacion = MessageBox.Show($"¿Está seguro de eliminar el simulador con ID {simulador.IdSimulador}, de fecha {simulador.Fecha} y cliente {simulador.Cliente.Identificar}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(confirmacion!= DialogResult.Yes) return; // Si el usuario cancela, no hacemos nada
                SimuladorBLO.EliminarSimulador(simulador);
                CargarDgv();
                CargarComboBox();
                MessageBox.Show("Simulador eliminado correctamente.");  
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        #endregion Fin Botones Form 
    }
}
