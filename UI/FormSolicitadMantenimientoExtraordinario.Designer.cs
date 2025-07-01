namespace UI
{
    partial class FormSolicitadMantenimientoExtraordinario
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
            btn_SolicitarMantenimiento = new Button();
            label2 = new Label();
            cmBox_Mecanicos = new ComboBox();
            groupBox1 = new GroupBox();
            dgv_MantenimientosEnCurso = new DataGridView();
            label1 = new Label();
            cmBox_Aeronaves = new ComboBox();
            label3 = new Label();
            txt_Detalle = new TextBox();
            btn_EliminarMatenimiento = new Button();
            label6 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_MantenimientosEnCurso).BeginInit();
            SuspendLayout();
            // 
            // txt_Mail
            // 
            txt_Mail.Location = new Point(99, 68);
            txt_Mail.Name = "txt_Mail";
            txt_Mail.Size = new Size(158, 23);
            txt_Mail.TabIndex = 18;
            // 
            // txt_Telefono
            // 
            txt_Telefono.Location = new Point(99, 39);
            txt_Telefono.Name = "txt_Telefono";
            txt_Telefono.Size = new Size(158, 23);
            txt_Telefono.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 71);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 16;
            label5.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 45);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 15;
            label4.Text = "Telefono";
            // 
            // btn_SolicitarMantenimiento
            // 
            btn_SolicitarMantenimiento.Location = new Point(128, 345);
            btn_SolicitarMantenimiento.Name = "btn_SolicitarMantenimiento";
            btn_SolicitarMantenimiento.Size = new Size(156, 23);
            btn_SolicitarMantenimiento.TabIndex = 14;
            btn_SolicitarMantenimiento.Text = "Solcitar Mantenimiento";
            btn_SolicitarMantenimiento.UseVisualStyleBackColor = true;
            btn_SolicitarMantenimiento.Click += btn_SolicitarMantenimiento_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 161);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 13;
            label2.Text = "Seleccione Mecanico";
            // 
            // cmBox_Mecanicos
            // 
            cmBox_Mecanicos.FormattingEnabled = true;
            cmBox_Mecanicos.Location = new Point(163, 158);
            cmBox_Mecanicos.Name = "cmBox_Mecanicos";
            cmBox_Mecanicos.Size = new Size(121, 23);
            cmBox_Mecanicos.TabIndex = 12;
            cmBox_Mecanicos.SelectedIndexChanged += cmBox_Mecanicos_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txt_Mail);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txt_Telefono);
            groupBox1.Location = new Point(27, 197);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(302, 122);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Contacto Mecanico";
            // 
            // dgv_MantenimientosEnCurso
            // 
            dgv_MantenimientosEnCurso.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_MantenimientosEnCurso.Location = new Point(772, 71);
            dgv_MantenimientosEnCurso.Name = "dgv_MantenimientosEnCurso";
            dgv_MantenimientosEnCurso.Size = new Size(545, 216);
            dgv_MantenimientosEnCurso.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 51);
            label1.Name = "label1";
            label1.Size = new Size(116, 15);
            label1.TabIndex = 22;
            label1.Text = "Seleccione Aeronave";
            // 
            // cmBox_Aeronaves
            // 
            cmBox_Aeronaves.FormattingEnabled = true;
            cmBox_Aeronaves.Location = new Point(163, 48);
            cmBox_Aeronaves.Name = "cmBox_Aeronaves";
            cmBox_Aeronaves.Size = new Size(121, 23);
            cmBox_Aeronaves.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 96);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 23;
            label3.Text = "Detalle Averia";
            // 
            // txt_Detalle
            // 
            txt_Detalle.Location = new Point(163, 93);
            txt_Detalle.Name = "txt_Detalle";
            txt_Detalle.Size = new Size(121, 23);
            txt_Detalle.TabIndex = 24;
            // 
            // btn_EliminarMatenimiento
            // 
            btn_EliminarMatenimiento.Location = new Point(1130, 293);
            btn_EliminarMatenimiento.Name = "btn_EliminarMatenimiento";
            btn_EliminarMatenimiento.Size = new Size(187, 23);
            btn_EliminarMatenimiento.TabIndex = 25;
            btn_EliminarMatenimiento.Text = "Eliminar Matenimiento";
            btn_EliminarMatenimiento.UseVisualStyleBackColor = true;
            btn_EliminarMatenimiento.Click += btn_EliminarMatenimiento_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(772, 48);
            label6.Name = "label6";
            label6.Size = new Size(144, 15);
            label6.TabIndex = 26;
            label6.Text = "Mantenimientos en Curso";
            // 
            // FormSolicitadMantenimientoExtraordinario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1356, 614);
            Controls.Add(label6);
            Controls.Add(btn_EliminarMatenimiento);
            Controls.Add(txt_Detalle);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(cmBox_Aeronaves);
            Controls.Add(dgv_MantenimientosEnCurso);
            Controls.Add(groupBox1);
            Controls.Add(btn_SolicitarMantenimiento);
            Controls.Add(label2);
            Controls.Add(cmBox_Mecanicos);
            Name = "FormSolicitadMantenimientoExtraordinario";
            Text = "FormSolicitadMantenimientoExtraordinario";
            Load += FormSolicitadMantenimientoExtraordinario_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_MantenimientosEnCurso).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Mail;
        private TextBox txt_Telefono;
        private Label label5;
        private Label label4;
        private Button btn_SolicitarMantenimiento;
        private Label label2;
        private ComboBox cmBox_Mecanicos;
        private GroupBox groupBox1;
        private DataGridView dgv_MantenimientosEnCurso;
        private Label label1;
        private ComboBox cmBox_Aeronaves;
        private Label label3;
        private TextBox txt_Detalle;
        private Button btn_EliminarMatenimiento;
        private Label label6;
    }
}