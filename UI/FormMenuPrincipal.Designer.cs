namespace UI
{
    partial class FormMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            inicioToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            actividadesDeVueloToolStripMenuItem = new ToolStripMenuItem();
            registrarActividadesToolStripMenuItem = new ToolStripMenuItem();
            registrarVueloToolStripMenuItem = new ToolStripMenuItem();
            registrarSimuladToolStripMenuItem = new ToolStripMenuItem();
            moduloDeHorasToolStripMenuItem = new ToolStripMenuItem();
            solicitarHorasToolStripMenuItem = new ToolStripMenuItem();
            cancelarDeudaToolStripMenuItem = new ToolStripMenuItem();
            cobrarFacturaSolicitudToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            solicitudMantenimientosToolStripMenuItem = new ToolStripMenuItem();
            solicitarMantenimiento100HsToolStripMenuItem = new ToolStripMenuItem();
            solicitarMantenimientoAnualToolStripMenuItem = new ToolStripMenuItem();
            solicitarMantenimientoExtraordinarioToolStripMenuItem = new ToolStripMenuItem();
            resgistrarManteniToolStripMenuItem = new ToolStripMenuItem();
            registrarMantenimientoToolStripMenuItem = new ToolStripMenuItem();
            pagarMantenimientoToolStripMenuItem = new ToolStripMenuItem();
            liquidacionesToolStripMenuItem = new ToolStripMenuItem();
            dueñosToolStripMenuItem = new ToolStripMenuItem();
            liquidarDueñoToolStripMenuItem = new ToolStripMenuItem();
            pagarDueñoToolStripMenuItem = new ToolStripMenuItem();
            instructorToolStripMenuItem = new ToolStripMenuItem();
            liquidarInstructorToolStripMenuItem = new ToolStripMenuItem();
            pagarInstructorToolStripMenuItem = new ToolStripMenuItem();
            combustibleToolStripMenuItem = new ToolStripMenuItem();
            registrarRecargarToolStripMenuItem = new ToolStripMenuItem();
            pagarCombustibleToolStripMenuItem = new ToolStripMenuItem();
            gestionAMBSToolStripMenuItem = new ToolStripMenuItem();
            aeronaveToolStripMenuItem = new ToolStripMenuItem();
            mecanicoToolStripMenuItem = new ToolStripMenuItem();
            instuctorToolStripMenuItem = new ToolStripMenuItem();
            clienteToolStripMenuItem = new ToolStripMenuItem();
            dueñoToolStripMenuItem = new ToolStripMenuItem();
            BackUP_RestoretoolStripMenuItem = new ToolStripMenuItem();
            realizarBackUpRestoreToolStripMenuItem = new ToolStripMenuItem();
            gestioDeUsuariosToolStripMenuItem = new ToolStripMenuItem();
            registrarUsuariosToolStripMenuItem = new ToolStripMenuItem();
            rolesYPermisosToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, actividadesDeVueloToolStripMenuItem, toolStripMenuItem1, liquidacionesToolStripMenuItem, combustibleToolStripMenuItem, gestionAMBSToolStripMenuItem, BackUP_RestoretoolStripMenuItem, gestioDeUsuariosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1370, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logOutToolStripMenuItem });
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(53, 20);
            inicioToolStripMenuItem.Text = "Sesion";
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(117, 22);
            logOutToolStripMenuItem.Text = "Log Out";
            logOutToolStripMenuItem.Click += LogOut_ToolStripMenuItem_Click;
            // 
            // actividadesDeVueloToolStripMenuItem
            // 
            actividadesDeVueloToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrarActividadesToolStripMenuItem, moduloDeHorasToolStripMenuItem });
            actividadesDeVueloToolStripMenuItem.Name = "actividadesDeVueloToolStripMenuItem";
            actividadesDeVueloToolStripMenuItem.Size = new Size(129, 20);
            actividadesDeVueloToolStripMenuItem.Text = "Actividades de Vuelo";
            // 
            // registrarActividadesToolStripMenuItem
            // 
            registrarActividadesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrarVueloToolStripMenuItem, registrarSimuladToolStripMenuItem });
            registrarActividadesToolStripMenuItem.Name = "registrarActividadesToolStripMenuItem";
            registrarActividadesToolStripMenuItem.Size = new Size(184, 22);
            registrarActividadesToolStripMenuItem.Text = "Registrar Actividades";
            // 
            // registrarVueloToolStripMenuItem
            // 
            registrarVueloToolStripMenuItem.Name = "registrarVueloToolStripMenuItem";
            registrarVueloToolStripMenuItem.Size = new Size(177, 22);
            registrarVueloToolStripMenuItem.Text = "Registrar Vuelo";
            registrarVueloToolStripMenuItem.Click += registrarVueloToolStripMenuItem_Click;
            // 
            // registrarSimuladToolStripMenuItem
            // 
            registrarSimuladToolStripMenuItem.Name = "registrarSimuladToolStripMenuItem";
            registrarSimuladToolStripMenuItem.Size = new Size(177, 22);
            registrarSimuladToolStripMenuItem.Text = "Registrar Simulador";
            registrarSimuladToolStripMenuItem.Click += registrarSimuladToolStripMenuItem_Click;
            // 
            // moduloDeHorasToolStripMenuItem
            // 
            moduloDeHorasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { solicitarHorasToolStripMenuItem, cancelarDeudaToolStripMenuItem, cobrarFacturaSolicitudToolStripMenuItem });
            moduloDeHorasToolStripMenuItem.Name = "moduloDeHorasToolStripMenuItem";
            moduloDeHorasToolStripMenuItem.Size = new Size(184, 22);
            moduloDeHorasToolStripMenuItem.Text = "Modulo de Horas";
            // 
            // solicitarHorasToolStripMenuItem
            // 
            solicitarHorasToolStripMenuItem.Name = "solicitarHorasToolStripMenuItem";
            solicitarHorasToolStripMenuItem.Size = new Size(201, 22);
            solicitarHorasToolStripMenuItem.Text = "Solicitar Horas";
            solicitarHorasToolStripMenuItem.Click += solicitarHorasToolStripMenuItem_Click;
            // 
            // cancelarDeudaToolStripMenuItem
            // 
            cancelarDeudaToolStripMenuItem.Name = "cancelarDeudaToolStripMenuItem";
            cancelarDeudaToolStripMenuItem.Size = new Size(201, 22);
            cancelarDeudaToolStripMenuItem.Text = "Cancelar Deuda";
            // 
            // cobrarFacturaSolicitudToolStripMenuItem
            // 
            cobrarFacturaSolicitudToolStripMenuItem.Name = "cobrarFacturaSolicitudToolStripMenuItem";
            cobrarFacturaSolicitudToolStripMenuItem.Size = new Size(201, 22);
            cobrarFacturaSolicitudToolStripMenuItem.Text = "Cobrar Factura Solicitud";
            cobrarFacturaSolicitudToolStripMenuItem.Click += cobrarFacturaSolicitudToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { solicitudMantenimientosToolStripMenuItem, resgistrarManteniToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(101, 20);
            toolStripMenuItem1.Text = "Mantenimiento";
            // 
            // solicitudMantenimientosToolStripMenuItem
            // 
            solicitudMantenimientosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { solicitarMantenimiento100HsToolStripMenuItem, solicitarMantenimientoAnualToolStripMenuItem, solicitarMantenimientoExtraordinarioToolStripMenuItem });
            solicitudMantenimientosToolStripMenuItem.Name = "solicitudMantenimientosToolStripMenuItem";
            solicitudMantenimientosToolStripMenuItem.Size = new Size(210, 22);
            solicitudMantenimientosToolStripMenuItem.Text = "Solicitud Mantenimientos";
            // 
            // solicitarMantenimiento100HsToolStripMenuItem
            // 
            solicitarMantenimiento100HsToolStripMenuItem.Name = "solicitarMantenimiento100HsToolStripMenuItem";
            solicitarMantenimiento100HsToolStripMenuItem.Size = new Size(277, 22);
            solicitarMantenimiento100HsToolStripMenuItem.Text = "Solicitar Mantenimiento 100 Hs";
            solicitarMantenimiento100HsToolStripMenuItem.Click += solicitarMantenimiento100HsToolStripMenuItem_Click;
            // 
            // solicitarMantenimientoAnualToolStripMenuItem
            // 
            solicitarMantenimientoAnualToolStripMenuItem.Name = "solicitarMantenimientoAnualToolStripMenuItem";
            solicitarMantenimientoAnualToolStripMenuItem.Size = new Size(277, 22);
            solicitarMantenimientoAnualToolStripMenuItem.Text = "Solicitar Mantenimiento Anual";
            solicitarMantenimientoAnualToolStripMenuItem.Click += solicitarMantenimientoAnualToolStripMenuItem_Click;
            // 
            // solicitarMantenimientoExtraordinarioToolStripMenuItem
            // 
            solicitarMantenimientoExtraordinarioToolStripMenuItem.Name = "solicitarMantenimientoExtraordinarioToolStripMenuItem";
            solicitarMantenimientoExtraordinarioToolStripMenuItem.Size = new Size(277, 22);
            solicitarMantenimientoExtraordinarioToolStripMenuItem.Text = "Solicitar Mantenimiento Extraordinario";
            solicitarMantenimientoExtraordinarioToolStripMenuItem.Click += solicitarMantenimientoExtraordinarioToolStripMenuItem_Click;
            // 
            // resgistrarManteniToolStripMenuItem
            // 
            resgistrarManteniToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrarMantenimientoToolStripMenuItem, pagarMantenimientoToolStripMenuItem });
            resgistrarManteniToolStripMenuItem.Name = "resgistrarManteniToolStripMenuItem";
            resgistrarManteniToolStripMenuItem.Size = new Size(210, 22);
            resgistrarManteniToolStripMenuItem.Text = "Registrar Mantenimientos";
            // 
            // registrarMantenimientoToolStripMenuItem
            // 
            registrarMantenimientoToolStripMenuItem.Name = "registrarMantenimientoToolStripMenuItem";
            registrarMantenimientoToolStripMenuItem.Size = new Size(205, 22);
            registrarMantenimientoToolStripMenuItem.Text = "Registrar Mantenimiento";
            registrarMantenimientoToolStripMenuItem.Click += registrarMantenimientoToolStripMenuItem_Click;
            // 
            // pagarMantenimientoToolStripMenuItem
            // 
            pagarMantenimientoToolStripMenuItem.Name = "pagarMantenimientoToolStripMenuItem";
            pagarMantenimientoToolStripMenuItem.Size = new Size(205, 22);
            pagarMantenimientoToolStripMenuItem.Text = "Pagar Mantenimiento";
            pagarMantenimientoToolStripMenuItem.Click += pagarMantenimientoToolStripMenuItem_Click;
            // 
            // liquidacionesToolStripMenuItem
            // 
            liquidacionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dueñosToolStripMenuItem, instructorToolStripMenuItem });
            liquidacionesToolStripMenuItem.Name = "liquidacionesToolStripMenuItem";
            liquidacionesToolStripMenuItem.Size = new Size(92, 20);
            liquidacionesToolStripMenuItem.Text = "Liquidaciones";
            // 
            // dueñosToolStripMenuItem
            // 
            dueñosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { liquidarDueñoToolStripMenuItem, pagarDueñoToolStripMenuItem });
            dueñosToolStripMenuItem.Name = "dueñosToolStripMenuItem";
            dueñosToolStripMenuItem.Size = new Size(180, 22);
            dueñosToolStripMenuItem.Text = "Dueños";
            // 
            // liquidarDueñoToolStripMenuItem
            // 
            liquidarDueñoToolStripMenuItem.Name = "liquidarDueñoToolStripMenuItem";
            liquidarDueñoToolStripMenuItem.Size = new Size(155, 22);
            liquidarDueñoToolStripMenuItem.Text = "Liquidar Dueño";
            liquidarDueñoToolStripMenuItem.Click += liquidarDueñoToolStripMenuItem_Click;
            // 
            // pagarDueñoToolStripMenuItem
            // 
            pagarDueñoToolStripMenuItem.Name = "pagarDueñoToolStripMenuItem";
            pagarDueñoToolStripMenuItem.Size = new Size(155, 22);
            pagarDueñoToolStripMenuItem.Text = "Pagar Dueño";
            pagarDueñoToolStripMenuItem.Click += pagarDueñoToolStripMenuItem_Click;
            // 
            // instructorToolStripMenuItem
            // 
            instructorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { liquidarInstructorToolStripMenuItem, pagarInstructorToolStripMenuItem });
            instructorToolStripMenuItem.Name = "instructorToolStripMenuItem";
            instructorToolStripMenuItem.Size = new Size(180, 22);
            instructorToolStripMenuItem.Text = "Instructores";
            // 
            // liquidarInstructorToolStripMenuItem
            // 
            liquidarInstructorToolStripMenuItem.Name = "liquidarInstructorToolStripMenuItem";
            liquidarInstructorToolStripMenuItem.Size = new Size(180, 22);
            liquidarInstructorToolStripMenuItem.Text = "Liquidar Instructor";
            liquidarInstructorToolStripMenuItem.Click += liquidarInstructorToolStripMenuItem_Click;
            // 
            // pagarInstructorToolStripMenuItem
            // 
            pagarInstructorToolStripMenuItem.Name = "pagarInstructorToolStripMenuItem";
            pagarInstructorToolStripMenuItem.Size = new Size(180, 22);
            pagarInstructorToolStripMenuItem.Text = "Pagar Instructor";
            pagarInstructorToolStripMenuItem.Click += pagarInstructorToolStripMenuItem_Click;
            // 
            // combustibleToolStripMenuItem
            // 
            combustibleToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrarRecargarToolStripMenuItem, pagarCombustibleToolStripMenuItem });
            combustibleToolStripMenuItem.Name = "combustibleToolStripMenuItem";
            combustibleToolStripMenuItem.Size = new Size(87, 20);
            combustibleToolStripMenuItem.Text = "Combustible";
            // 
            // registrarRecargarToolStripMenuItem
            // 
            registrarRecargarToolStripMenuItem.Name = "registrarRecargarToolStripMenuItem";
            registrarRecargarToolStripMenuItem.Size = new Size(236, 22);
            registrarRecargarToolStripMenuItem.Text = "Registrar Recarga Combustible";
            registrarRecargarToolStripMenuItem.Click += registrarRecargarToolStripMenuItem_Click;
            // 
            // pagarCombustibleToolStripMenuItem
            // 
            pagarCombustibleToolStripMenuItem.Name = "pagarCombustibleToolStripMenuItem";
            pagarCombustibleToolStripMenuItem.Size = new Size(236, 22);
            pagarCombustibleToolStripMenuItem.Text = "Pagar Combustible";
            pagarCombustibleToolStripMenuItem.Click += pagarCombustibleToolStripMenuItem_Click;
            // 
            // gestionAMBSToolStripMenuItem
            // 
            gestionAMBSToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aeronaveToolStripMenuItem, mecanicoToolStripMenuItem, instuctorToolStripMenuItem, clienteToolStripMenuItem, dueñoToolStripMenuItem });
            gestionAMBSToolStripMenuItem.Name = "gestionAMBSToolStripMenuItem";
            gestionAMBSToolStripMenuItem.Size = new Size(136, 20);
            gestionAMBSToolStripMenuItem.Text = "Gestión ABM Negocio";
            // 
            // aeronaveToolStripMenuItem
            // 
            aeronaveToolStripMenuItem.Name = "aeronaveToolStripMenuItem";
            aeronaveToolStripMenuItem.Size = new Size(155, 22);
            aeronaveToolStripMenuItem.Text = "Aeronave ABM";
            aeronaveToolStripMenuItem.Click += aeronaveToolStripMenuItem_Click;
            // 
            // mecanicoToolStripMenuItem
            // 
            mecanicoToolStripMenuItem.Name = "mecanicoToolStripMenuItem";
            mecanicoToolStripMenuItem.Size = new Size(155, 22);
            mecanicoToolStripMenuItem.Text = "Mecanico ABM";
            mecanicoToolStripMenuItem.Click += mecanicoToolStripMenuItem_Click;
            // 
            // instuctorToolStripMenuItem
            // 
            instuctorToolStripMenuItem.Name = "instuctorToolStripMenuItem";
            instuctorToolStripMenuItem.Size = new Size(155, 22);
            instuctorToolStripMenuItem.Text = "Instructor ABM";
            instuctorToolStripMenuItem.Click += instuctorToolStripMenuItem_Click;
            // 
            // clienteToolStripMenuItem
            // 
            clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            clienteToolStripMenuItem.Size = new Size(155, 22);
            clienteToolStripMenuItem.Text = "Clientes ABM";
            clienteToolStripMenuItem.Click += clienteToolStripMenuItem_Click;
            // 
            // dueñoToolStripMenuItem
            // 
            dueñoToolStripMenuItem.Name = "dueñoToolStripMenuItem";
            dueñoToolStripMenuItem.Size = new Size(155, 22);
            dueñoToolStripMenuItem.Text = "Dueño ABM";
            dueñoToolStripMenuItem.Click += dueñoToolStripMenuItem_Click_1;
            // 
            // BackUP_RestoretoolStripMenuItem
            // 
            BackUP_RestoretoolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { realizarBackUpRestoreToolStripMenuItem });
            BackUP_RestoretoolStripMenuItem.Name = "BackUP_RestoretoolStripMenuItem";
            BackUP_RestoretoolStripMenuItem.Size = new Size(103, 20);
            BackUP_RestoretoolStripMenuItem.Text = "BackUp_Restore";
            // 
            // realizarBackUpRestoreToolStripMenuItem
            // 
            realizarBackUpRestoreToolStripMenuItem.Name = "realizarBackUpRestoreToolStripMenuItem";
            realizarBackUpRestoreToolStripMenuItem.Size = new Size(201, 22);
            realizarBackUpRestoreToolStripMenuItem.Text = "Realizar BackUp/Restore";
            realizarBackUpRestoreToolStripMenuItem.Click += realizarBackUpRestoreToolStripMenuItem_Click;
            // 
            // gestioDeUsuariosToolStripMenuItem
            // 
            gestioDeUsuariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrarUsuariosToolStripMenuItem, rolesYPermisosToolStripMenuItem });
            gestioDeUsuariosToolStripMenuItem.Name = "gestioDeUsuariosToolStripMenuItem";
            gestioDeUsuariosToolStripMenuItem.Size = new Size(123, 20);
            gestioDeUsuariosToolStripMenuItem.Text = "Gestión de Usuarios";
            // 
            // registrarUsuariosToolStripMenuItem
            // 
            registrarUsuariosToolStripMenuItem.Name = "registrarUsuariosToolStripMenuItem";
            registrarUsuariosToolStripMenuItem.Size = new Size(162, 22);
            registrarUsuariosToolStripMenuItem.Text = "Usuarios ABM";
            registrarUsuariosToolStripMenuItem.Click += registrarUsuariosToolStripMenuItem_Click;
            // 
            // rolesYPermisosToolStripMenuItem
            // 
            rolesYPermisosToolStripMenuItem.Name = "rolesYPermisosToolStripMenuItem";
            rolesYPermisosToolStripMenuItem.Size = new Size(162, 22);
            rolesYPermisosToolStripMenuItem.Text = "Roles y Permisos";
            rolesYPermisosToolStripMenuItem.Click += RolesYPermisos_ToolStripMenuItem_Click;
            // 
            // FormMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 620);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FormMenuPrincipal";
            Text = "Form menu principal";
            FormClosing += FormMenuPrincipal_FormClosing;
            Load += FormMenuPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem actividadesDeVueloToolStripMenuItem;
        private ToolStripMenuItem registrarActividadesToolStripMenuItem;
        private ToolStripMenuItem registrarVueloToolStripMenuItem;
        private ToolStripMenuItem registrarSimuladToolStripMenuItem;
        private ToolStripMenuItem moduloDeHorasToolStripMenuItem;
        private ToolStripMenuItem solicitarHorasToolStripMenuItem;
        private ToolStripMenuItem cancelarDeudaToolStripMenuItem;
        private ToolStripMenuItem cobrarFacturaSolicitudToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem solicitudMantenimientosToolStripMenuItem;
        private ToolStripMenuItem solicitarMantenimiento100HsToolStripMenuItem;
        private ToolStripMenuItem solicitarMantenimientoAnualToolStripMenuItem;
        private ToolStripMenuItem solicitarMantenimientoExtraordinarioToolStripMenuItem;
        private ToolStripMenuItem resgistrarManteniToolStripMenuItem;
        private ToolStripMenuItem registrarMantenimientoToolStripMenuItem;
        private ToolStripMenuItem pagarMantenimientoToolStripMenuItem;
        private ToolStripMenuItem liquidacionesToolStripMenuItem;
        private ToolStripMenuItem dueñosToolStripMenuItem;
        private ToolStripMenuItem liquidarDueñoToolStripMenuItem;
        private ToolStripMenuItem pagarDueñoToolStripMenuItem;
        private ToolStripMenuItem instructorToolStripMenuItem;
        private ToolStripMenuItem liquidarInstructorToolStripMenuItem;
        private ToolStripMenuItem pagarInstructorToolStripMenuItem;
        private ToolStripMenuItem combustibleToolStripMenuItem;
        private ToolStripMenuItem registrarRecargarToolStripMenuItem;
        private ToolStripMenuItem pagarCombustibleToolStripMenuItem;
        private ToolStripMenuItem gestionAMBSToolStripMenuItem;
        private ToolStripMenuItem aeronaveToolStripMenuItem;
        private ToolStripMenuItem mecanicoToolStripMenuItem;
        private ToolStripMenuItem instuctorToolStripMenuItem;
        private ToolStripMenuItem clienteToolStripMenuItem;
        private ToolStripMenuItem dueñoToolStripMenuItem;
        private ToolStripMenuItem BackUP_RestoretoolStripMenuItem;
        private ToolStripMenuItem realizarBackUpRestoreToolStripMenuItem;
        private ToolStripMenuItem gestioDeUsuariosToolStripMenuItem;
        private ToolStripMenuItem registrarUsuariosToolStripMenuItem;
        private ToolStripMenuItem rolesYPermisosToolStripMenuItem;
    }
}