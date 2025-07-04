namespace UI
{
    partial class FormPagarMantenimiento
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
            btn_EliminarPago = new Button();
            label6 = new Label();
            dgv_Pagos = new DataGridView();
            groupBox1 = new GroupBox();
            btn_ConfirmarPago = new Button();
            label5 = new Label();
            dtp_FechaPago = new DateTimePicker();
            txt_Monto = new TextBox();
            label4 = new Label();
            txt_RefExterna = new TextBox();
            label3 = new Label();
            cmBox_FormaPago = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            Mecanico = new Label();
            cmBox_Mecanicos = new ComboBox();
            dgv_FacturasImpagas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_Pagos).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_FacturasImpagas).BeginInit();
            SuspendLayout();
            // 
            // btn_EliminarPago
            // 
            btn_EliminarPago.Location = new Point(1099, 301);
            btn_EliminarPago.Name = "btn_EliminarPago";
            btn_EliminarPago.Size = new Size(102, 23);
            btn_EliminarPago.TabIndex = 25;
            btn_EliminarPago.Text = "Eliminar Pago";
            btn_EliminarPago.UseVisualStyleBackColor = true;
            btn_EliminarPago.Click += btn_EliminarPago_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(692, 74);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 24;
            label6.Text = "Pagos";
            // 
            // dgv_Pagos
            // 
            dgv_Pagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Pagos.Location = new Point(692, 97);
            dgv_Pagos.Name = "dgv_Pagos";
            dgv_Pagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Pagos.Size = new Size(509, 189);
            dgv_Pagos.TabIndex = 23;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_ConfirmarPago);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dtp_FechaPago);
            groupBox1.Controls.Add(txt_Monto);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txt_RefExterna);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cmBox_FormaPago);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(47, 316);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(499, 264);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pago";
            // 
            // btn_ConfirmarPago
            // 
            btn_ConfirmarPago.Location = new Point(329, 221);
            btn_ConfirmarPago.Name = "btn_ConfirmarPago";
            btn_ConfirmarPago.Size = new Size(146, 27);
            btn_ConfirmarPago.TabIndex = 12;
            btn_ConfirmarPago.Text = "Confirmar Pago";
            btn_ConfirmarPago.UseVisualStyleBackColor = true;
            btn_ConfirmarPago.Click += btn_ConfirmarPago_Click;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 74);
            label1.Name = "label1";
            label1.Size = new Size(184, 15);
            label1.TabIndex = 21;
            label1.Text = "Facturas Mantenimiento Impagas";
            // 
            // Mecanico
            // 
            Mecanico.AutoSize = true;
            Mecanico.Location = new Point(47, 36);
            Mecanico.Name = "Mecanico";
            Mecanico.Size = new Size(59, 15);
            Mecanico.TabIndex = 20;
            Mecanico.Text = "Mecanico";
            // 
            // cmBox_Mecanicos
            // 
            cmBox_Mecanicos.FormattingEnabled = true;
            cmBox_Mecanicos.Location = new Point(112, 33);
            cmBox_Mecanicos.Name = "cmBox_Mecanicos";
            cmBox_Mecanicos.Size = new Size(121, 23);
            cmBox_Mecanicos.TabIndex = 19;
            cmBox_Mecanicos.SelectedIndexChanged += cmBox_Mecanicos_SelectedIndexChanged;
            // 
            // dgv_FacturasImpagas
            // 
            dgv_FacturasImpagas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_FacturasImpagas.Location = new Point(46, 90);
            dgv_FacturasImpagas.MultiSelect = false;
            dgv_FacturasImpagas.Name = "dgv_FacturasImpagas";
            dgv_FacturasImpagas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_FacturasImpagas.Size = new Size(500, 196);
            dgv_FacturasImpagas.TabIndex = 18;
            dgv_FacturasImpagas.SelectionChanged += dgv_FacturasImpagas_SelectionChanged;
            // 
            // FormPagarMantenimiento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1247, 613);
            Controls.Add(btn_EliminarPago);
            Controls.Add(label6);
            Controls.Add(dgv_Pagos);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(Mecanico);
            Controls.Add(cmBox_Mecanicos);
            Controls.Add(dgv_FacturasImpagas);
            Name = "FormPagarMantenimiento";
            Text = "FormPagarMantenimiento";
            ((System.ComponentModel.ISupportInitialize)dgv_Pagos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_FacturasImpagas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_EliminarPago;
        private Label label6;
        private DataGridView dgv_Pagos;
        private GroupBox groupBox1;
        private Button btn_ConfirmarPago;
        private Label label5;
        private DateTimePicker dtp_FechaPago;
        private TextBox txt_Monto;
        private Label label4;
        private TextBox txt_RefExterna;
        private Label label3;
        private ComboBox cmBox_FormaPago;
        private Label label2;
        private Label label1;
        private Label Mecanico;
        private ComboBox cmBox_Mecanicos;
        private DataGridView dgv_FacturasImpagas;
    }
}