namespace UI
{
    partial class FormSolicitudHoras
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
            btn_SolicitarHoras = new Button();
            cmBox_Cliente = new ComboBox();
            label3 = new Label();
            label1 = new Label();
            txt_CantHoraVuelo = new TextBox();
            txt_CantHoraSimu = new TextBox();
            label2 = new Label();
            txt_PrecioHoraVuelo = new TextBox();
            label4 = new Label();
            txt_PrecioHoraSimu = new TextBox();
            label5 = new Label();
            dgv_SolicitudHoras = new DataGridView();
            dgv_FacturaSolicitudHoras = new DataGridView();
            btn_EliminarSolicitud = new Button();
            label7 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_SolicitudHoras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_FacturaSolicitudHoras).BeginInit();
            SuspendLayout();
            // 
            // btn_SolicitarHoras
            // 
            btn_SolicitarHoras.Location = new Point(201, 329);
            btn_SolicitarHoras.Name = "btn_SolicitarHoras";
            btn_SolicitarHoras.Size = new Size(116, 32);
            btn_SolicitarHoras.TabIndex = 0;
            btn_SolicitarHoras.Text = "Solicitar Horas";
            btn_SolicitarHoras.UseVisualStyleBackColor = true;
            btn_SolicitarHoras.Click += btnSolicitadHoras_Click;
            // 
            // cmBox_Cliente
            // 
            cmBox_Cliente.FormattingEnabled = true;
            cmBox_Cliente.Location = new Point(173, 46);
            cmBox_Cliente.Name = "cmBox_Cliente";
            cmBox_Cliente.Size = new Size(144, 23);
            cmBox_Cliente.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 49);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 8;
            label3.Text = "Cliente";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 103);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 10;
            label1.Text = "Cantidad Horas Vuelo";
            // 
            // txt_CantHoraVuelo
            // 
            txt_CantHoraVuelo.Location = new Point(206, 95);
            txt_CantHoraVuelo.Name = "txt_CantHoraVuelo";
            txt_CantHoraVuelo.Size = new Size(111, 23);
            txt_CantHoraVuelo.TabIndex = 11;
            // 
            // txt_CantHoraSimu
            // 
            txt_CantHoraSimu.Location = new Point(206, 150);
            txt_CantHoraSimu.Name = "txt_CantHoraSimu";
            txt_CantHoraSimu.Size = new Size(111, 23);
            txt_CantHoraSimu.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 158);
            label2.Name = "label2";
            label2.Size = new Size(146, 15);
            label2.TabIndex = 12;
            label2.Text = "Cantidad Horas Simulador";
            // 
            // txt_PrecioHoraVuelo
            // 
            txt_PrecioHoraVuelo.Location = new Point(206, 199);
            txt_PrecioHoraVuelo.Name = "txt_PrecioHoraVuelo";
            txt_PrecioHoraVuelo.Size = new Size(111, 23);
            txt_PrecioHoraVuelo.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 202);
            label4.Name = "label4";
            label4.Size = new Size(102, 15);
            label4.TabIndex = 14;
            label4.Text = "Precio Hora Vuelo";
            // 
            // txt_PrecioHoraSimu
            // 
            txt_PrecioHoraSimu.Location = new Point(206, 244);
            txt_PrecioHoraSimu.Name = "txt_PrecioHoraSimu";
            txt_PrecioHoraSimu.Size = new Size(111, 23);
            txt_PrecioHoraSimu.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 252);
            label5.Name = "label5";
            label5.Size = new Size(126, 15);
            label5.TabIndex = 16;
            label5.Text = "Precio Hora Simulador";
            // 
            // dgv_SolicitudHoras
            // 
            dgv_SolicitudHoras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_SolicitudHoras.Location = new Point(594, 32);
            dgv_SolicitudHoras.Name = "dgv_SolicitudHoras";
            dgv_SolicitudHoras.Size = new Size(622, 217);
            dgv_SolicitudHoras.TabIndex = 18;
            // 
            // dgv_FacturaSolicitudHoras
            // 
            dgv_FacturaSolicitudHoras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_FacturaSolicitudHoras.Location = new Point(598, 308);
            dgv_FacturaSolicitudHoras.Name = "dgv_FacturaSolicitudHoras";
            dgv_FacturaSolicitudHoras.Size = new Size(620, 228);
            dgv_FacturaSolicitudHoras.TabIndex = 19;
            // 
            // btn_EliminarSolicitud
            // 
            btn_EliminarSolicitud.Location = new Point(1141, 255);
            btn_EliminarSolicitud.Name = "btn_EliminarSolicitud";
            btn_EliminarSolicitud.Size = new Size(75, 23);
            btn_EliminarSolicitud.TabIndex = 20;
            btn_EliminarSolicitud.Text = "Eliminar Solicitud";
            btn_EliminarSolicitud.UseVisualStyleBackColor = true;
            btn_EliminarSolicitud.Click += btn_EliminarSolicitud_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(598, 290);
            label7.Name = "label7";
            label7.Size = new Size(95, 15);
            label7.TabIndex = 38;
            label7.Text = "Factura Solicitud";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(594, 14);
            label6.Name = "label6";
            label6.Size = new Size(87, 15);
            label6.TabIndex = 37;
            label6.Text = "Solicitud Horas";
            // 
            // FormSolicitudHoras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1289, 572);
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
            Controls.Add(btn_SolicitarHoras);
            Name = "FormSolicitudHoras";
            Text = "FormSolicitudHoras";
            Load += FormSolicitudHoras_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_SolicitudHoras).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_FacturaSolicitudHoras).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_SolicitarHoras;
        private ComboBox cmBox_Cliente;
        private Label label3;
        private Label label1;
        private TextBox txt_CantHoraVuelo;
        private TextBox txt_CantHoraSimu;
        private Label label2;
        private TextBox txt_PrecioHoraVuelo;
        private Label label4;
        private TextBox txt_PrecioHoraSimu;
        private Label label5;
        private DataGridView dgv_SolicitudHoras;
        private DataGridView dgv_FacturaSolicitudHoras;
        private Button btn_EliminarSolicitud;
        private Label label7;
        private Label label6;
    }
}