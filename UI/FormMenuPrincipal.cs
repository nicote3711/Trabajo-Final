﻿using ENTITY;
using ENTITY.Composite;
using Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UI
{
    public partial class FormMenuPrincipal : Form
    {
        Usuario usuarioLogueado;

        public FormMenuPrincipal(Usuario usuarioValido)
        {
            InitializeComponent();
            usuarioLogueado = usuarioValido;
        }


        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            OcultarTodosLosMenus();
            string prueba = gestioDeUsuariosToolStripMenuItem.Text;
            HablitirarItemsMenuPorPermiso();

        }

        #region Funciones Form

        private void HablitirarItemsMenuPorPermiso()
        {
            List<Componente> permisos = usuarioLogueado.ObtenerPermisos();

            foreach (Componente permiso in permisos)
            {
                HabilitarMenuItemPorNombre(permiso.NombreComponente, menuStrip1.Items);
            }
        }

        private void HabilitarMenuItemPorNombre(string nombreComponente, ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    // Comparar por texto del ítem con el nombre del permiso

                    if (menuItem.Text.Trim().Equals(nombreComponente.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        menuItem.Visible = true;
                    }

                    // Llamada recursiva para submenús
                    if (menuItem.DropDownItems.Count > 0)
                    {
                        HabilitarMenuItemPorNombre(nombreComponente, menuItem.DropDownItems);
                    }
                }
            }
        }

        private void OcultarTodosLosMenus()
        {
            foreach (ToolStripMenuItem menu in menuStrip1.Items)
            {
                OcultarRecursivamente(menu);
            }
        }

        private void OcultarRecursivamente(ToolStripMenuItem item)
        {
            item.Visible = false;
            foreach (ToolStripItem subItem in item.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    OcultarRecursivamente(subMenuItem);
                }
            }
        }

        private void FormMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea cerrar la sesión?", "Cerrar sesión", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    SessionManager.Instancia.CerrarSesion();
                    // e.Cancel = false; ← opcional, el cierre ya va a ocurrir
                }
                else
                {
                    e.Cancel = true; // Cancela el cierre
                }
            }
        }

        #endregion Termina Funciones Form   


        #region Botones de los items del menu

        private void RolesYPermisos_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormRolPermiso formRolPermiso = new FormRolPermiso();
                formRolPermiso.MdiParent = this;
                formRolPermiso.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void LogOut_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SessionManager.Instancia.CerrarSesion();
                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void AeronaveABM_StripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                FormAeronaveABM formAeronaveABM = new FormAeronaveABM();
                formAeronaveABM.MdiParent = this;
                formAeronaveABM.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void realizarBackUpRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormBackUpRestore formBackUpRestore = new FormBackUpRestore();
                formBackUpRestore.MdiParent = this;
                formBackUpRestore.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void registrarVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormRegistrarVuelo formRegistrarVuelo = new FormRegistrarVuelo();
                formRegistrarVuelo.MdiParent = this;
                formRegistrarVuelo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormClienteABM formClienteABM = new FormClienteABM();
                formClienteABM.MdiParent = this;
                formClienteABM.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void registrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormUsuarioABM formUsuarioABM = new FormUsuarioABM();
                formUsuarioABM.MdiParent = this;
                formUsuarioABM.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void registrarSimuladToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormRegistrarSimulador formRegistrarSimulador = new FormRegistrarSimulador();
                formRegistrarSimulador.MdiParent = this;
                formRegistrarSimulador.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        #endregion Termina Botones de los items del menu






        private void dueñoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void solicitarHorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormSolicitudHoras formSolicitarHoras = new FormSolicitudHoras();
                formSolicitarHoras.MdiParent = this;
                formSolicitarHoras.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void instuctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormInstructorABM formInstructorABM = new FormInstructorABM();
                formInstructorABM.MdiParent = this;
                formInstructorABM.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void liquidarDueñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormLiquidacionesDueño formLiquidacionesDueño = new FormLiquidacionesDueño();
                formLiquidacionesDueño.MdiParent = this;
                formLiquidacionesDueño.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dueñoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                FormDuenoABM formDuenoABM = new FormDuenoABM();
                formDuenoABM.MdiParent = this;
                formDuenoABM.Show();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void mecanicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormMecanicosABM formMecanicosABM = new FormMecanicosABM();
                formMecanicosABM.ShowDialog();
                //  formMecanicosABM.MdiParent = this; 
                // formMecanicosABM.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void aeronaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormAeronaveABM formAeronaveABM = new FormAeronaveABM();
                formAeronaveABM.MdiParent = this;
                formAeronaveABM.Show();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void liquidarInstructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormLiquidacionesInstructor formLiquidacionesInstructor = new FormLiquidacionesInstructor();
                formLiquidacionesInstructor.MdiParent = this;
                formLiquidacionesInstructor.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void registrarRecargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormRecargaCombustible formRecargaCombustible = new FormRecargaCombustible();
                formRecargaCombustible.MdiParent = this; 
                formRecargaCombustible.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
