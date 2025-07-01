namespace UI
{
    partial class FormRegistrarMantenimiento
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
            cmBox_Aeronaves = new ComboBox();
            label1 = new Label();
            dgv_MantenimientosEnCurso = new DataGridView();
            label2 = new Label();
            dgv_FacturasMantenimiento = new DataGridView();
            label3 = new Label();
            btn_RegistrarFactura = new Button();
            label4 = new Label();
            txt_NroFactura = new TextBox();
            label5 = new Label();
            txt_MontoTotal = new TextBox();
            txt_Detalle = new TextBox();
            label6 = new Label();
            btn_EliminarFactura = new Button();
            dtp_FechaFactura = new DateTimePicker();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_MantenimientosEnCurso).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_FacturasMantenimiento).BeginInit();
            SuspendLayout();
            // 
            // cmBox_Aeronaves
            // 
            cmBox_Aeronaves.FormattingEnabled = true;
            cmBox_Aeronaves.Location = new Point(31, 71);
            cmBox_Aeronaves.Name = "cmBox_Aeronaves";
            cmBox_Aeronaves.Size = new Size(121, 23);
            cmBox_Aeronaves.TabIndex = 0;
            cmBox_Aeronaves.SelectedIndexChanged += cmBox_Aeronaves_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 53);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 1;
            label1.Text = "Aeronave";
            // 
            // dgv_MantenimientosEnCurso
            // 
            dgv_MantenimientosEnCurso.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_MantenimientosEnCurso.Location = new Point(31, 133);
            dgv_MantenimientosEnCurso.Name = "dgv_MantenimientosEnCurso";
            dgv_MantenimientosEnCurso.Size = new Size(404, 211);
            dgv_MantenimientosEnCurso.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 115);
            label2.Name = "label2";
            label2.Size = new Size(144, 15);
            label2.TabIndex = 3;
            label2.Text = "Mantenimientos en Curso";
            // 
            // dgv_FacturasMantenimiento
            // 
            dgv_FacturasMantenimiento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_FacturasMantenimiento.Location = new Point(719, 133);
            dgv_FacturasMantenimiento.Name = "dgv_FacturasMantenimiento";
            dgv_FacturasMantenimiento.Size = new Size(433, 211);
            dgv_FacturasMantenimiento.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(719, 105);
            label3.Name = "label3";
            label3.Size = new Size(136, 15);
            label3.TabIndex = 5;
            label3.Text = "Facturas Mantenimiento";
            // 
            // btn_RegistrarFactura
            // 
            btn_RegistrarFactura.Location = new Point(134, 494);
            btn_RegistrarFactura.Name = "btn_RegistrarFactura";
            btn_RegistrarFactura.Size = new Size(130, 23);
            btn_RegistrarFactura.TabIndex = 6;
            btn_RegistrarFactura.Text = "Registrar Factura";
            btn_RegistrarFactura.UseVisualStyleBackColor = true;
            btn_RegistrarFactura.Click += btn_RegistrarFactura_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 373);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 7;
            label4.Text = "Nro Factura";
            // 
            // txt_NroFactura
            // 
            txt_NroFactura.Location = new Point(134, 365);
            txt_NroFactura.Name = "txt_NroFactura";
            txt_NroFactura.Size = new Size(130, 23);
            txt_NroFactura.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 459);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 9;
            label5.Text = "Monto Total";
            // 
            // txt_MontoTotal
            // 
            txt_MontoTotal.Location = new Point(134, 459);
            txt_MontoTotal.Name = "txt_MontoTotal";
            txt_MontoTotal.Size = new Size(130, 23);
            txt_MontoTotal.TabIndex = 10;
            // 
            // txt_Detalle
            // 
            txt_Detalle.Location = new Point(134, 421);
            txt_Detalle.Name = "txt_Detalle";
            txt_Detalle.Size = new Size(130, 23);
            txt_Detalle.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(31, 424);
            label6.Name = "label6";
            label6.Size = new Size(85, 15);
            label6.TabIndex = 11;
            label6.Text = "Detalle Factura";
            // 
            // btn_EliminarFactura
            // 
            btn_EliminarFactura.Location = new Point(1049, 364);
            btn_EliminarFactura.Name = "btn_EliminarFactura";
            btn_EliminarFactura.Size = new Size(103, 23);
            btn_EliminarFactura.TabIndex = 13;
            btn_EliminarFactura.Text = "Eliminar Factura";
            btn_EliminarFactura.UseVisualStyleBackColor = true;
            btn_EliminarFactura.Click += btn_EliminarFactura_Click;
            // 
            // dtp_FechaFactura
            // 
            dtp_FechaFactura.Format = DateTimePickerFormat.Short;
            dtp_FechaFactura.Location = new Point(134, 394);
            dtp_FechaFactura.Name = "dtp_FechaFactura";
            dtp_FechaFactura.Size = new Size(130, 23);
            dtp_FechaFactura.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(31, 394);
            label7.Name = "label7";
            label7.Size = new Size(80, 15);
            label7.TabIndex = 15;
            label7.Text = "Fecha Factura";
            // 
            // FormRegistrarMantenimiento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1173, 577);
            Controls.Add(label7);
            Controls.Add(dtp_FechaFactura);
            Controls.Add(btn_EliminarFactura);
            Controls.Add(txt_Detalle);
            Controls.Add(label6);
            Controls.Add(txt_MontoTotal);
            Controls.Add(label5);
            Controls.Add(txt_NroFactura);
            Controls.Add(label4);
            Controls.Add(btn_RegistrarFactura);
            Controls.Add(label3);
            Controls.Add(dgv_FacturasMantenimiento);
            Controls.Add(label2);
            Controls.Add(dgv_MantenimientosEnCurso);
            Controls.Add(label1);
            Controls.Add(cmBox_Aeronaves);
            Name = "FormRegistrarMantenimiento";
            Text = "FormRegistrarMantenimiento";
            Load += FormRegistrarMantenimiento_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_MantenimientosEnCurso).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_FacturasMantenimiento).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmBox_Aeronaves;
        private Label label1;
        private DataGridView dgv_MantenimientosEnCurso;
        private Label label2;
        private DataGridView dgv_FacturasMantenimiento;
        private Label label3;
        private Button btn_RegistrarFactura;
        private Label label4;
        private TextBox txt_NroFactura;
        private Label label5;
        private TextBox txt_MontoTotal;
        private TextBox txt_Detalle;
        private Label label6;
        private Button btn_EliminarFactura;
        private DateTimePicker dtp_FechaFactura;
        private Label label7;
    }
}