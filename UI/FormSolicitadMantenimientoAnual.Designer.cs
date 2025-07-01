namespace UI
{
    partial class FormSolicitadMantenimientoAnual
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
            txt_Mail = new TextBox();
            txt_Telefono = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            btn_EliminarMatenimiento = new Button();
            dgv_MantenimientosEnCurso = new DataGridView();
            btn_SolicitarMantenimiento = new Button();
            label2 = new Label();
            label1 = new Label();
            cmBox_Mecanicos = new ComboBox();
            dgv_MantenimientosPendientes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_MantenimientosEnCurso).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_MantenimientosPendientes).BeginInit();
            SuspendLayout();
            // 
            // txt_Mail
            // 
            txt_Mail.Location = new Point(131, 337);
            txt_Mail.Name = "txt_Mail";
            txt_Mail.Size = new Size(158, 23);
            txt_Mail.TabIndex = 23;
            // 
            // txt_Telefono
            // 
            txt_Telefono.Location = new Point(131, 311);
            txt_Telefono.Name = "txt_Telefono";
            txt_Telefono.Size = new Size(158, 23);
            txt_Telefono.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(52, 340);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 21;
            label5.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 314);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 20;
            label4.Text = "Telefono";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(704, 91);
            label3.Name = "label3";
            label3.Size = new Size(173, 15);
            label3.TabIndex = 19;
            label3.Text = "Mantenimiento Anual en Curso";
            // 
            // btn_EliminarMatenimiento
            // 
            btn_EliminarMatenimiento.Location = new Point(941, 270);
            btn_EliminarMatenimiento.Name = "btn_EliminarMatenimiento";
            btn_EliminarMatenimiento.Size = new Size(187, 23);
            btn_EliminarMatenimiento.TabIndex = 18;
            btn_EliminarMatenimiento.Text = "Eliminar Matenimiento";
            btn_EliminarMatenimiento.UseVisualStyleBackColor = true;
            btn_EliminarMatenimiento.Click += btn_EliminarMatenimiento_Click;
            // 
            // dgv_MantenimientosEnCurso
            // 
            dgv_MantenimientosEnCurso.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_MantenimientosEnCurso.Location = new Point(704, 109);
            dgv_MantenimientosEnCurso.Name = "dgv_MantenimientosEnCurso";
            dgv_MantenimientosEnCurso.Size = new Size(424, 153);
            dgv_MantenimientosEnCurso.TabIndex = 17;
            // 
            // btn_SolicitarMantenimiento
            // 
            btn_SolicitarMantenimiento.Location = new Point(312, 270);
            btn_SolicitarMantenimiento.Name = "btn_SolicitarMantenimiento";
            btn_SolicitarMantenimiento.Size = new Size(156, 23);
            btn_SolicitarMantenimiento.TabIndex = 16;
            btn_SolicitarMantenimiento.Text = "Solcitar Mantenimiento";
            btn_SolicitarMantenimiento.UseVisualStyleBackColor = true;
            btn_SolicitarMantenimiento.Click += btn_SolicitarMantenimiento_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 274);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 15;
            label2.Text = "Seleccione Mecanico";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 91);
            label1.Name = "label1";
            label1.Size = new Size(189, 15);
            label1.TabIndex = 14;
            label1.Text = "Mantenimientos Anual Pendientes";
            // 
            // cmBox_Mecanicos
            // 
            cmBox_Mecanicos.FormattingEnabled = true;
            cmBox_Mecanicos.Location = new Point(168, 270);
            cmBox_Mecanicos.Name = "cmBox_Mecanicos";
            cmBox_Mecanicos.Size = new Size(121, 23);
            cmBox_Mecanicos.TabIndex = 13;
            cmBox_Mecanicos.SelectedIndexChanged += cmBox_Mecanicos_SelectedIndexChanged;
            // 
            // dgv_MantenimientosPendientes
            // 
            dgv_MantenimientosPendientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_MantenimientosPendientes.Location = new Point(40, 109);
            dgv_MantenimientosPendientes.Name = "dgv_MantenimientosPendientes";
            dgv_MantenimientosPendientes.Size = new Size(428, 153);
            dgv_MantenimientosPendientes.TabIndex = 12;
            // 
            // FormSolicitadMantenimientoAnual
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1357, 622);
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
            Name = "FormSolicitadMantenimientoAnual";
            Text = "FormSolicitadMantenimientoAnual";
            Load += FormSolicitadMantenimientoAnual_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_MantenimientosEnCurso).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_MantenimientosPendientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Mail;
        private TextBox txt_Telefono;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button btn_EliminarMatenimiento;
        private DataGridView dgv_MantenimientosEnCurso;
        private Button btn_SolicitarMantenimiento;
        private Label label2;
        private Label label1;
        private ComboBox cmBox_Mecanicos;
        private DataGridView dgv_MantenimientosPendientes;
    }
}