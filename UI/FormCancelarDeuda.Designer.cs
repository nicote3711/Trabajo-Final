namespace UI
{
    partial class FormCancelarDeuda
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
            btn_EliminarSolicitud = new Button();
            dgv_FacturaSolicitudHoras = new DataGridView();
            dgv_SolicitudHoras = new DataGridView();
            txt_PrecioHoraSimu = new TextBox();
            label5 = new Label();
            txt_PrecioHoraVuelo = new TextBox();
            label4 = new Label();
            txt_CantHoraSimu = new TextBox();
            label2 = new Label();
            txt_CantHoraVuelo = new TextBox();
            label1 = new Label();
            cmBox_Cliente = new ComboBox();
            label3 = new Label();
            btn_SolicitudDeuda = new Button();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_FacturaSolicitudHoras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_SolicitudHoras).BeginInit();
            SuspendLayout();
            // 
            // btn_EliminarSolicitud
            // 
            btn_EliminarSolicitud.Location = new Point(1181, 282);
            btn_EliminarSolicitud.Name = "btn_EliminarSolicitud";
            btn_EliminarSolicitud.Size = new Size(75, 23);
            btn_EliminarSolicitud.TabIndex = 34;
            btn_EliminarSolicitud.Text = "Eliminar Solicitud";
            btn_EliminarSolicitud.UseVisualStyleBackColor = true;
            btn_EliminarSolicitud.Click += btn_EliminarSolicitud_Click;
            // 
            // dgv_FacturaSolicitudHoras
            // 
            dgv_FacturaSolicitudHoras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_FacturaSolicitudHoras.Location = new Point(638, 348);
            dgv_FacturaSolicitudHoras.Name = "dgv_FacturaSolicitudHoras";
            dgv_FacturaSolicitudHoras.Size = new Size(620, 228);
            dgv_FacturaSolicitudHoras.TabIndex = 33;
            // 
            // dgv_SolicitudHoras
            // 
            dgv_SolicitudHoras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_SolicitudHoras.Location = new Point(634, 62);
            dgv_SolicitudHoras.Name = "dgv_SolicitudHoras";
            dgv_SolicitudHoras.Size = new Size(622, 217);
            dgv_SolicitudHoras.TabIndex = 32;
            // 
            // txt_PrecioHoraSimu
            // 
            txt_PrecioHoraSimu.Location = new Point(246, 274);
            txt_PrecioHoraSimu.Name = "txt_PrecioHoraSimu";
            txt_PrecioHoraSimu.Size = new Size(111, 23);
            txt_PrecioHoraSimu.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(58, 282);
            label5.Name = "label5";
            label5.Size = new Size(126, 15);
            label5.TabIndex = 30;
            label5.Text = "Precio Hora Simulador";
            // 
            // txt_PrecioHoraVuelo
            // 
            txt_PrecioHoraVuelo.Location = new Point(246, 229);
            txt_PrecioHoraVuelo.Name = "txt_PrecioHoraVuelo";
            txt_PrecioHoraVuelo.Size = new Size(111, 23);
            txt_PrecioHoraVuelo.TabIndex = 29;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(58, 232);
            label4.Name = "label4";
            label4.Size = new Size(102, 15);
            label4.TabIndex = 28;
            label4.Text = "Precio Hora Vuelo";
            // 
            // txt_CantHoraSimu
            // 
            txt_CantHoraSimu.Enabled = false;
            txt_CantHoraSimu.Location = new Point(246, 180);
            txt_CantHoraSimu.Name = "txt_CantHoraSimu";
            txt_CantHoraSimu.Size = new Size(111, 23);
            txt_CantHoraSimu.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 188);
            label2.Name = "label2";
            label2.Size = new Size(146, 15);
            label2.TabIndex = 26;
            label2.Text = "Cantidad Horas Simulador";
            // 
            // txt_CantHoraVuelo
            // 
            txt_CantHoraVuelo.Enabled = false;
            txt_CantHoraVuelo.Location = new Point(246, 125);
            txt_CantHoraVuelo.Name = "txt_CantHoraVuelo";
            txt_CantHoraVuelo.Size = new Size(111, 23);
            txt_CantHoraVuelo.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 133);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 24;
            label1.Text = "Cantidad Horas Vuelo";
            // 
            // cmBox_Cliente
            // 
            cmBox_Cliente.FormattingEnabled = true;
            cmBox_Cliente.Location = new Point(213, 76);
            cmBox_Cliente.Name = "cmBox_Cliente";
            cmBox_Cliente.Size = new Size(144, 23);
            cmBox_Cliente.TabIndex = 23;
            cmBox_Cliente.SelectedIndexChanged += cmBox_Cliente_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 79);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 22;
            label3.Text = "Cliente";
            // 
            // btn_SolicitudDeuda
            // 
            btn_SolicitudDeuda.Location = new Point(241, 359);
            btn_SolicitudDeuda.Name = "btn_SolicitudDeuda";
            btn_SolicitudDeuda.Size = new Size(116, 32);
            btn_SolicitudDeuda.TabIndex = 21;
            btn_SolicitudDeuda.Text = "Solicitar Horas";
            btn_SolicitudDeuda.UseVisualStyleBackColor = true;
            btn_SolicitudDeuda.Click += btn_SolicitudDeuda_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(634, 44);
            label6.Name = "label6";
            label6.Size = new Size(87, 15);
            label6.TabIndex = 35;
            label6.Text = "Solicitud Horas";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(638, 320);
            label7.Name = "label7";
            label7.Size = new Size(95, 15);
            label7.TabIndex = 36;
            label7.Text = "Factura Solicitud";
            // 
            // FormCancelarDeuda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1310, 622);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(btn_EliminarSolicitud);
            Controls.Add(dgv_FacturaSolicitudHoras);
            Controls.Add(dgv_SolicitudHoras);
            Controls.Add(txt_PrecioHoraSimu);
            Controls.Add(label5);
            Controls.Add(txt_PrecioHoraVuelo);
            Controls.Add(label4);
            Controls.Add(txt_CantHoraSimu);
            Controls.Add(label2);
            Controls.Add(txt_CantHoraVuelo);
            Controls.Add(label1);
            Controls.Add(cmBox_Cliente);
            Controls.Add(label3);
            Controls.Add(btn_SolicitudDeuda);
            Name = "FormCancelarDeuda";
            Text = "FormCancelarDeuda";
            Load += FormCancelarDeuda_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_FacturaSolicitudHoras).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_SolicitudHoras).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_EliminarSolicitud;
        private DataGridView dgv_FacturaSolicitudHoras;
        private DataGridView dgv_SolicitudHoras;
        private TextBox txt_PrecioHoraSimu;
        private Label label5;
        private TextBox txt_PrecioHoraVuelo;
        private Label label4;
        private TextBox txt_CantHoraSimu;
        private Label label2;
        private TextBox txt_CantHoraVuelo;
        private Label label1;
        private ComboBox cmBox_Cliente;
        private Label label3;
        private Button btn_SolicitudDeuda;
        private Label label6;
        private Label label7;
    }
}