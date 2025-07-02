namespace UI
{
    partial class FormSolicitarMantenimiento100Hs
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
            dgv_MantenimientosPendientes = new DataGridView();
            cmBox_Mecanicos = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            btn_SolicitarMantenimiento = new Button();
            dgv_MantenimientosEnCurso = new DataGridView();
            btn_EliminarMatenimiento = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txt_Telefono = new TextBox();
            txt_Mail = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgv_MantenimientosPendientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_MantenimientosEnCurso).BeginInit();
            SuspendLayout();
            // 
            // dgv_MantenimientosPendientes
            // 
            dgv_MantenimientosPendientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_MantenimientosPendientes.Location = new Point(32, 71);
            dgv_MantenimientosPendientes.Name = "dgv_MantenimientosPendientes";
            dgv_MantenimientosPendientes.Size = new Size(428, 153);
            dgv_MantenimientosPendientes.TabIndex = 0;
            // 
            // cmBox_Mecanicos
            // 
            cmBox_Mecanicos.FormattingEnabled = true;
            cmBox_Mecanicos.Location = new Point(160, 232);
            cmBox_Mecanicos.Name = "cmBox_Mecanicos";
            cmBox_Mecanicos.Size = new Size(121, 23);
            cmBox_Mecanicos.TabIndex = 1;
            cmBox_Mecanicos.SelectedIndexChanged += cmBox_Mecanicos_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 53);
            label1.Name = "label1";
            label1.Size = new Size(190, 15);
            label1.TabIndex = 2;
            label1.Text = "Mantenimientos 100Hs Pendientes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 236);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 3;
            label2.Text = "Seleccione Mecanico";
            // 
            // btn_SolicitarMantenimiento
            // 
            btn_SolicitarMantenimiento.Location = new Point(304, 232);
            btn_SolicitarMantenimiento.Name = "btn_SolicitarMantenimiento";
            btn_SolicitarMantenimiento.Size = new Size(156, 23);
            btn_SolicitarMantenimiento.TabIndex = 4;
            btn_SolicitarMantenimiento.Text = "Solcitar Mantenimiento";
            btn_SolicitarMantenimiento.UseVisualStyleBackColor = true;
            btn_SolicitarMantenimiento.Click += btn_SolicitarMantenimiento_Click;
            // 
            // dgv_MantenimientosEnCurso
            // 
            dgv_MantenimientosEnCurso.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_MantenimientosEnCurso.Location = new Point(696, 71);
            dgv_MantenimientosEnCurso.Name = "dgv_MantenimientosEnCurso";
            dgv_MantenimientosEnCurso.Size = new Size(424, 153);
            dgv_MantenimientosEnCurso.TabIndex = 5;
            // 
            // btn_EliminarMatenimiento
            // 
            btn_EliminarMatenimiento.Location = new Point(933, 232);
            btn_EliminarMatenimiento.Name = "btn_EliminarMatenimiento";
            btn_EliminarMatenimiento.Size = new Size(187, 23);
            btn_EliminarMatenimiento.TabIndex = 6;
            btn_EliminarMatenimiento.Text = "Eliminar Matenimiento";
            btn_EliminarMatenimiento.UseVisualStyleBackColor = true;
            btn_EliminarMatenimiento.Click += btn_EliminarMatenimiento_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(696, 53);
            label3.Name = "label3";
            label3.Size = new Size(177, 15);
            label3.TabIndex = 7;
            label3.Text = "Mantenimiento 100 Hs en Curso";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 276);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 8;
            label4.Text = "Telefono";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 302);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 9;
            label5.Text = "Email";
            // 
            // txt_Telefono
            // 
            txt_Telefono.Location = new Point(123, 273);
            txt_Telefono.Name = "txt_Telefono";
            txt_Telefono.Size = new Size(158, 23);
            txt_Telefono.TabIndex = 10;
            // 
            // txt_Mail
            // 
            txt_Mail.Location = new Point(123, 299);
            txt_Mail.Name = "txt_Mail";
            txt_Mail.Size = new Size(158, 23);
            txt_Mail.TabIndex = 11;
            // 
            // FormSolicitarMantenimiento100Hs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 517);
            Controls.Add(txt_Mail);
            Controls.Add(txt_Telefono);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btn_EliminarMatenimiento);
            Controls.Add(dgv_MantenimientosEnCurso);
            Controls.Add(btn_SolicitarMantenimiento);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmBox_Mecanicos);
            Controls.Add(dgv_MantenimientosPendientes);
            Name = "FormSolicitarMantenimiento100Hs";
            Text = "FormSolicitarMantenimiento100Hs";
            Load += FormSolicitarMantenimiento100Hs_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_MantenimientosPendientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_MantenimientosEnCurso).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_MantenimientosPendientes;
        private ComboBox cmBox_Mecanicos;
        private Label label1;
        private Label label2;
        private Button btn_SolicitarMantenimiento;
        private DataGridView dgv_MantenimientosEnCurso;
        private Button btn_EliminarMatenimiento;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txt_Telefono;
        private TextBox txt_Mail;
    }
}