namespace UI
{
    partial class FormRecargaCombustible
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
            label1 = new Label();
            cmBox_ProveedorCombu = new ComboBox();
            cmBox_DepositoCombu = new ComboBox();
            label2 = new Label();
            txt_CantidadLitros = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txt_PrecioLitro = new TextBox();
            label5 = new Label();
            txt_MontoFactura = new TextBox();
            NroFactura = new Label();
            txt_NroFactura = new TextBox();
            label7 = new Label();
            label8 = new Label();
            dgv_RecargasCombustible = new DataGridView();
            dgv_FacturasRecarga = new DataGridView();
            label6 = new Label();
            dtp_Fecha = new DateTimePicker();
            btn_RegistrarRecarga = new Button();
            btn_EliminarFactura = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_RecargasCombustible).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_FacturasRecarga).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 58);
            label1.Name = "label1";
            label1.Size = new Size(132, 15);
            label1.TabIndex = 0;
            label1.Text = "Proveedor Combustible";
            // 
            // cmBox_ProveedorCombu
            // 
            cmBox_ProveedorCombu.FormattingEnabled = true;
            cmBox_ProveedorCombu.Location = new Point(187, 55);
            cmBox_ProveedorCombu.Name = "cmBox_ProveedorCombu";
            cmBox_ProveedorCombu.Size = new Size(121, 23);
            cmBox_ProveedorCombu.TabIndex = 1;
            // 
            // cmBox_DepositoCombu
            // 
            cmBox_DepositoCombu.FormattingEnabled = true;
            cmBox_DepositoCombu.Location = new Point(187, 106);
            cmBox_DepositoCombu.Name = "cmBox_DepositoCombu";
            cmBox_DepositoCombu.Size = new Size(121, 23);
            cmBox_DepositoCombu.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 109);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Deposito";
            // 
            // txt_CantidadLitros
            // 
            txt_CantidadLitros.Location = new Point(187, 140);
            txt_CantidadLitros.Name = "txt_CantidadLitros";
            txt_CantidadLitros.Size = new Size(121, 23);
            txt_CantidadLitros.TabIndex = 4;
            txt_CantidadLitros.TextChanged += txt_CantidadLitros_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 148);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 5;
            label3.Text = "Cantidad de Litos";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 194);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 7;
            label4.Text = "Precio Litro";
            // 
            // txt_PrecioLitro
            // 
            txt_PrecioLitro.Location = new Point(187, 186);
            txt_PrecioLitro.Name = "txt_PrecioLitro";
            txt_PrecioLitro.Size = new Size(121, 23);
            txt_PrecioLitro.TabIndex = 6;
            txt_PrecioLitro.TextChanged += txt_PrecioLitro_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(49, 339);
            label5.Name = "label5";
            label5.Size = new Size(85, 15);
            label5.TabIndex = 9;
            label5.Text = "Monto Factura";
            // 
            // txt_MontoFactura
            // 
            txt_MontoFactura.Enabled = false;
            txt_MontoFactura.Location = new Point(187, 331);
            txt_MontoFactura.Name = "txt_MontoFactura";
            txt_MontoFactura.Size = new Size(121, 23);
            txt_MontoFactura.TabIndex = 8;
            // 
            // NroFactura
            // 
            NroFactura.AutoSize = true;
            NroFactura.Location = new Point(49, 306);
            NroFactura.Name = "NroFactura";
            NroFactura.Size = new Size(69, 15);
            NroFactura.TabIndex = 11;
            NroFactura.Text = "Nro.Factura";
            // 
            // txt_NroFactura
            // 
            txt_NroFactura.Location = new Point(187, 298);
            txt_NroFactura.Name = "txt_NroFactura";
            txt_NroFactura.Size = new Size(121, 23);
            txt_NroFactura.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(581, 37);
            label7.Name = "label7";
            label7.Size = new Size(125, 15);
            label7.TabIndex = 12;
            label7.Text = "Recargas Combustible";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(585, 251);
            label8.Name = "label8";
            label8.Size = new Size(167, 15);
            label8.TabIndex = 13;
            label8.Text = "Facturas Recarga Combustible";
            // 
            // dgv_RecargasCombustible
            // 
            dgv_RecargasCombustible.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_RecargasCombustible.Location = new Point(581, 55);
            dgv_RecargasCombustible.Name = "dgv_RecargasCombustible";
            dgv_RecargasCombustible.Size = new Size(557, 153);
            dgv_RecargasCombustible.TabIndex = 14;
            // 
            // dgv_FacturasRecarga
            // 
            dgv_FacturasRecarga.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_FacturasRecarga.Location = new Point(581, 269);
            dgv_FacturasRecarga.Name = "dgv_FacturasRecarga";
            dgv_FacturasRecarga.Size = new Size(557, 153);
            dgv_FacturasRecarga.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(49, 248);
            label6.Name = "label6";
            label6.Size = new Size(127, 15);
            label6.TabIndex = 16;
            label6.Text = "Facha Factura/Recarga";
            // 
            // dtp_Fecha
            // 
            dtp_Fecha.Format = DateTimePickerFormat.Short;
            dtp_Fecha.Location = new Point(187, 242);
            dtp_Fecha.Name = "dtp_Fecha";
            dtp_Fecha.Size = new Size(121, 23);
            dtp_Fecha.TabIndex = 17;
            // 
            // btn_RegistrarRecarga
            // 
            btn_RegistrarRecarga.Location = new Point(187, 400);
            btn_RegistrarRecarga.Name = "btn_RegistrarRecarga";
            btn_RegistrarRecarga.Size = new Size(121, 22);
            btn_RegistrarRecarga.TabIndex = 18;
            btn_RegistrarRecarga.Text = "Registrar Recarga";
            btn_RegistrarRecarga.UseVisualStyleBackColor = true;
            btn_RegistrarRecarga.Click += btn_RegistrarRecarga_Click;
            // 
            // btn_EliminarFactura
            // 
            btn_EliminarFactura.Location = new Point(1031, 437);
            btn_EliminarFactura.Name = "btn_EliminarFactura";
            btn_EliminarFactura.Size = new Size(107, 23);
            btn_EliminarFactura.TabIndex = 19;
            btn_EliminarFactura.Text = "Eliminar Factura";
            btn_EliminarFactura.UseVisualStyleBackColor = true;
            btn_EliminarFactura.Click += btn_EliminarFactura_Click;
            // 
            // FormRecargaCombustible
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 564);
            Controls.Add(btn_EliminarFactura);
            Controls.Add(btn_RegistrarRecarga);
            Controls.Add(dtp_Fecha);
            Controls.Add(label6);
            Controls.Add(dgv_FacturasRecarga);
            Controls.Add(dgv_RecargasCombustible);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(NroFactura);
            Controls.Add(txt_NroFactura);
            Controls.Add(label5);
            Controls.Add(txt_MontoFactura);
            Controls.Add(label4);
            Controls.Add(txt_PrecioLitro);
            Controls.Add(label3);
            Controls.Add(txt_CantidadLitros);
            Controls.Add(cmBox_DepositoCombu);
            Controls.Add(label2);
            Controls.Add(cmBox_ProveedorCombu);
            Controls.Add(label1);
            Name = "FormRecargaCombustible";
            Text = "FormRecargaCombustible";
            Load += FormRecargaCombustible_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_RecargasCombustible).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_FacturasRecarga).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmBox_ProveedorCombu;
        private ComboBox cmBox_DepositoCombu;
        private Label label2;
        private TextBox txt_CantidadLitros;
        private Label label3;
        private Label label4;
        private TextBox txt_PrecioLitro;
        private Label label5;
        private TextBox txt_MontoFactura;
        private Label NroFactura;
        private TextBox txt_NroFactura;
        private Label label7;
        private Label label8;
        private DataGridView dgv_RecargasCombustible;
        private DataGridView dgv_FacturasRecarga;
        private Label label6;
        private DateTimePicker dtp_Fecha;
        private Button btn_RegistrarRecarga;
        private Button btn_EliminarFactura;
    }
}