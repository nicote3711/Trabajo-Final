namespace UI
{
    partial class FormCobrarFacturaSolicitud
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
            dgv_FactSoliImp = new DataGridView();
            cmBox_Cliente = new ComboBox();
            Cliente = new Label();
            label1 = new Label();
            cmBox_FormaPago = new ComboBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            btn_ConfirmarCobro = new Button();
            label5 = new Label();
            dtp_FechaPago = new DateTimePicker();
            txt_Monto = new TextBox();
            label4 = new Label();
            txt_RefExterna = new TextBox();
            label3 = new Label();
            dgv_CobrosFactSolicitudes = new DataGridView();
            label6 = new Label();
            btn_EliminarCobro = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_FactSoliImp).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_CobrosFactSolicitudes).BeginInit();
            SuspendLayout();
            // 
            // dgv_FactSoliImp
            // 
            dgv_FactSoliImp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_FactSoliImp.Location = new Point(23, 78);
            dgv_FactSoliImp.MultiSelect = false;
            dgv_FactSoliImp.Name = "dgv_FactSoliImp";
            dgv_FactSoliImp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_FactSoliImp.Size = new Size(500, 196);
            dgv_FactSoliImp.TabIndex = 0;
            dgv_FactSoliImp.SelectionChanged += dgv_FactSoliImp_SelectionChanged;
            // 
            // cmBox_Cliente
            // 
            cmBox_Cliente.FormattingEnabled = true;
            cmBox_Cliente.Location = new Point(74, 21);
            cmBox_Cliente.Name = "cmBox_Cliente";
            cmBox_Cliente.Size = new Size(121, 23);
            cmBox_Cliente.TabIndex = 1;
            cmBox_Cliente.SelectedIndexChanged += cmBox_Cliente_SelectedIndexChanged;
            // 
            // Cliente
            // 
            Cliente.AutoSize = true;
            Cliente.Location = new Point(24, 24);
            Cliente.Name = "Cliente";
            Cliente.Size = new Size(44, 15);
            Cliente.TabIndex = 2;
            Cliente.Text = "Cliente";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 62);
            label1.Name = "label1";
            label1.Size = new Size(182, 15);
            label1.TabIndex = 3;
            label1.Text = "Facturas Solicitud Horas Impagas";
            // 
            // cmBox_FormaPago
            // 
            cmBox_FormaPago.FormattingEnabled = true;
            cmBox_FormaPago.Location = new Point(162, 33);
            cmBox_FormaPago.Name = "cmBox_FormaPago";
            cmBox_FormaPago.Size = new Size(121, 23);
            cmBox_FormaPago.TabIndex = 4;
            cmBox_FormaPago.SelectedIndexChanged += cmBox_FormaPago_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 33);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 5;
            label2.Text = "Forma de Pago";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_ConfirmarCobro);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dtp_FechaPago);
            groupBox1.Controls.Add(txt_Monto);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txt_RefExterna);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cmBox_FormaPago);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(24, 304);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(499, 264);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cobro Solicitud";
            // 
            // btn_ConfirmarCobro
            // 
            btn_ConfirmarCobro.Location = new Point(329, 221);
            btn_ConfirmarCobro.Name = "btn_ConfirmarCobro";
            btn_ConfirmarCobro.Size = new Size(146, 27);
            btn_ConfirmarCobro.TabIndex = 12;
            btn_ConfirmarCobro.Text = "Confirmar Cobro";
            btn_ConfirmarCobro.UseVisualStyleBackColor = true;
            btn_ConfirmarCobro.Click += btn_ConfirmarCobro_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 182);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 11;
            label5.Text = "Fecha Pago";
            // 
            // dtp_FechaPago
            // 
            dtp_FechaPago.Format = DateTimePickerFormat.Short;
            dtp_FechaPago.Location = new Point(163, 174);
            dtp_FechaPago.Name = "dtp_FechaPago";
            dtp_FechaPago.Size = new Size(120, 23);
            dtp_FechaPago.TabIndex = 10;
            // 
            // txt_Monto
            // 
            txt_Monto.Location = new Point(162, 129);
            txt_Monto.Name = "txt_Monto";
            txt_Monto.Size = new Size(121, 23);
            txt_Monto.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 129);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 8;
            label4.Text = "Monto";
            // 
            // txt_RefExterna
            // 
            txt_RefExterna.Location = new Point(162, 82);
            txt_RefExterna.Name = "txt_RefExterna";
            txt_RefExterna.Size = new Size(121, 23);
            txt_RefExterna.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 82);
            label3.Name = "label3";
            label3.Size = new Size(103, 15);
            label3.TabIndex = 6;
            label3.Text = "Referencia Externa";
            // 
            // dgv_CobrosFactSolicitudes
            // 
            dgv_CobrosFactSolicitudes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_CobrosFactSolicitudes.Location = new Point(669, 85);
            dgv_CobrosFactSolicitudes.Name = "dgv_CobrosFactSolicitudes";
            dgv_CobrosFactSolicitudes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_CobrosFactSolicitudes.Size = new Size(509, 189);
            dgv_CobrosFactSolicitudes.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(669, 62);
            label6.Name = "label6";
            label6.Size = new Size(105, 15);
            label6.TabIndex = 8;
            label6.Text = "Cobros Solicitudes";
            // 
            // btn_EliminarCobro
            // 
            btn_EliminarCobro.Location = new Point(1076, 289);
            btn_EliminarCobro.Name = "btn_EliminarCobro";
            btn_EliminarCobro.Size = new Size(102, 23);
            btn_EliminarCobro.TabIndex = 9;
            btn_EliminarCobro.Text = "Eliminar Cobro";
            btn_EliminarCobro.UseVisualStyleBackColor = true;
            btn_EliminarCobro.Click += btn_EliminarCobro_Click;
            // 
            // FormCobrarFacturaSolicitud
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1279, 630);
            Controls.Add(btn_EliminarCobro);
            Controls.Add(label6);
            Controls.Add(dgv_CobrosFactSolicitudes);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(Cliente);
            Controls.Add(cmBox_Cliente);
            Controls.Add(dgv_FactSoliImp);
            Name = "FormCobrarFacturaSolicitud";
            Text = "FormCobrarFacturaSolicitud";
            Load += FormCobrarFacturaSolicitud_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_FactSoliImp).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_CobrosFactSolicitudes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_FactSoliImp;
        private ComboBox cmBox_Cliente;
        private Label Cliente;
        private Label label1;
        private ComboBox cmBox_FormaPago;
        private Label label2;
        private GroupBox groupBox1;
        private TextBox txt_Monto;
        private Label label4;
        private TextBox txt_RefExterna;
        private Label label3;
        private DateTimePicker dtp_FechaPago;
        private Label label5;
        private Button btn_ConfirmarCobro;
        private DataGridView dgv_CobrosFactSolicitudes;
        private Label label6;
        private Button btn_EliminarCobro;
    }
}