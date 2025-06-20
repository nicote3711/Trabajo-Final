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
using BLL;
using BLL.BLLBitacora;
using ENTITY;
using ENTITY.Bitacora;

namespace UI
{
    public partial class FormBackUpRestore : Form
    {
        UsuarioBLL UsuarioBLO = new UsuarioBLL();
        BitacoraBLL BitacoraBLO = new BitacoraBLL();
        public FormBackUpRestore()
        {
            InitializeComponent();
            CargarGrillaBitacora();
            CargarGrillaBackUp();
            rb_All.Checked = true; // Por defecto mostramos todos los registros
        }

        private void CargarGrillaBackUp()
        {
            try
            {
                List<Bitacora> LBackUps = BitacoraBLO.ObtenerTodos().Where(r => r.Descripcion == "BackUp").ToList();

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
                if (rb_BackUp.Checked)
                {
                    Lbitacoras = Lbitacoras.Where(r => r.Descripcion == "BackUp").ToList();
                }
                if (rb_Restore.Checked)
                {
                    Lbitacoras = Lbitacoras.Where(r => r.Descripcion == "Restore").ToList();
                }
                if (rb_All.Checked)
                {
                    // No filtramos, mostramos todos
                }
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
                CargarGrillaBackUp();
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
                if (dgv_BackUps.SelectedRows.Count <= 0) throw new Exception("Debe seleccionar un back up para restaurar.");
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

        private void dgv_Bitacora_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Bitacora.DataSource != null && dgv_Bitacora.Rows.Count > 0)
                {
                    if (dgv_Bitacora.SelectedRows.Count > 0)
                    {
                        Bitacora bitacora = dgv_Bitacora.SelectedRows[0].DataBoundItem as Bitacora;
                        if (bitacora != null)
                        {
                            Usuario usuario = UsuarioBLO.BuscarUsuarioPorId(bitacora.Id_Usuario);
                            if (usuario == null) throw new Exception("No se encontró el usuario asociado a la bitácora.");
                            txt_Dni.Text = usuario.IdUsuario.ToString();
                            txt_NombreUsuario.Text = usuario.NombreUsuario;
                            txt_Apellido.Text = usuario.Apellido;
                            txt_Nombre.Text = usuario.Nombre;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void rb_All_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CargarGrillaBitacora();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void rb_Restore_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CargarGrillaBitacora();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void rb_BackUp_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CargarGrillaBitacora();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
