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
            dvg_FaturasSolicitudImpagas = new DataGridView();
            comboBox1 = new ComboBox();
            Cliente = new Label();
            label1 = new Label();
            comboBox2 = new ComboBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dvg_FaturasSolicitudImpagas).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dvg_FaturasSolicitudImpagas
            // 
            dvg_FaturasSolicitudImpagas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvg_FaturasSolicitudImpagas.Location = new Point(23, 78);
            dvg_FaturasSolicitudImpagas.Name = "dvg_FaturasSolicitudImpagas";
            dvg_FaturasSolicitudImpagas.Size = new Size(397, 196);
            dvg_FaturasSolicitudImpagas.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(74, 21);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
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
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(115, 64);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 64);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 5;
            label2.Text = "Forma de Pago";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(24, 304);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(396, 227);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cobro Solicitud";
            // 
            // FormCobrarFacturaSolicitud
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1279, 630);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(Cliente);
            Controls.Add(comboBox1);
            Controls.Add(dvg_FaturasSolicitudImpagas);
            Name = "FormCobrarFacturaSolicitud";
            Text = "FormCobrarFacturaSolicitud";
            Load += FormCobrarFacturaSolicitud_Load;
            ((System.ComponentModel.ISupportInitialize)dvg_FaturasSolicitudImpagas).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dvg_FaturasSolicitudImpagas;
        private ComboBox comboBox1;
        private Label Cliente;
        private Label label1;
        private ComboBox comboBox2;
        private Label label2;
        private GroupBox groupBox1;
    }
}