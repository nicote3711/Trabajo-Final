using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BLL.BLLBitacora;
using ENTITY.Bitacora;

namespace UI
{
    public partial class FormBackUpRestore : Form
    {
        BitacoraBLL BitacoraBLO = new BitacoraBLL();
        public FormBackUpRestore()
        {
            InitializeComponent();
            CargarGrillaBitacora();
            CargarGrillaBackUp();
        }

        private void CargarGrillaBackUp()
        {
            try
            {
                List<Bitacora> LBackUps = BitacoraBLO.ObtenerTodos().Where(r=>r.Descripcion=="BackUp").ToList();
                
                if (LBackUps != null && LBackUps.Count > 0)
                {
                    dgv_BackUps.DataSource = null;
                    dgv_BackUps.DataSource = LBackUps;
                   // dgv_Bitacora.Columns["IdBitacora"].Visible = false; // Ocultar columna IdBitacora
                    // dgv_Bitacora.Columns["Id_Usuario"].Visible = false; // Ocultar columna Id_Usuario
                    //dgv_Bitacora.Columns["FechaRegistro"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"; // Formatear fecha
                }
                else
                {
                    MessageBox.Show("No hay registros de BackUp en la bitácora.");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void CargarGrillaBitacora()
        {
            try
            {
                List<Bitacora> Lbitacoras = BitacoraBLO.ObtenerTodos();
                if (Lbitacoras != null && Lbitacoras.Count > 0)
                {
                    dgv_Bitacora.DataSource = null;
                    dgv_Bitacora.DataSource = Lbitacoras;
                  // dgv_Bitacora.Columns["IdBitacora"].Visible = false; // Ocultar columna IdBitacora
                   // dgv_Bitacora.Columns["Id_Usuario"].Visible = false; // Ocultar columna Id_Usuario
                    //dgv_Bitacora.Columns["FechaRegistro"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"; // Formatear fecha
                }
                else
                {
                    MessageBox.Show("No hay registros en la bitácora.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BitacoraBLO.RealizarBackUp();
                CargarGrillaBitacora();
                MessageBox.Show("BackUp realizado correctamente.");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_RealizarRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_BackUps.Rows.Count <= 0) throw new Exception("No hay backs ups para realizar el restore");
                if(dgv_BackUps.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar un back up para restaurar.");
                Bitacora filaBackUp = dgv_BackUps.SelectedRows[0].DataBoundItem as Bitacora;
                if (filaBackUp == null) throw new Exception("No se pudo obtener el back up seleccionado.");
                DialogResult result = MessageBox.Show($"¿Está seguro que desea restaurar el backup del {filaBackUp.FechaRegistro:dd-MM-yyyy HH:mm}?",
                                              "Confirmar Restore",
                                              MessageBoxButtons.OKCancel,
                                              MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    BitacoraBLO.RealizarRestore(filaBackUp);
                    CargarGrillaBitacora();
                    MessageBox.Show("Restore realizado correctamente.");    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
