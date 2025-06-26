namespace UI
{
    partial class FormLiquidacionesDueño
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
            btn_GenerarLiquidaciones = new Button();
            dgv_LiquidacionesDueño = new DataGridView();
            cmBox_Dueños = new ComboBox();
            Dueños = new Label();
            label1 = new Label();
            label2 = new Label();
            dgv_FacturasLiquidacionDueno = new DataGridView();
            btn_RegistrarFactura = new Button();
            label3 = new Label();
            label4 = new Label();
            txt_NroFactura = new TextBox();
            Txt_MontoTotal = new TextBox();
            btn_EliminarFactura = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_LiquidacionesDueño).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_FacturasLiquidacionDueno).BeginInit();
            SuspendLayout();
            // 
            // btn_GenerarLiquidaciones
            // 
            btn_GenerarLiquidaciones.Location = new Point(664, 12);
            btn_GenerarLiquidaciones.Name = "btn_GenerarLiquidaciones";
            btn_GenerarLiquidaciones.Size = new Size(222, 57);
            btn_GenerarLiquidaciones.TabIndex = 0;
            btn_GenerarLiquidaciones.Text = "Generar Liquidaciones";
            btn_GenerarLiquidaciones.UseVisualStyleBackColor = true;
            btn_GenerarLiquidaciones.Click += btn_GenerarLiquidaciones_Click;
            // 
            // dgv_LiquidacionesDueño
            // 
            dgv_LiquidacionesDueño.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_LiquidacionesDueño.Location = new Point(103, 160);
            dgv_LiquidacionesDueño.Name = "dgv_LiquidacionesDueño";
            dgv_LiquidacionesDueño.Size = new Size(502, 260);
            dgv_LiquidacionesDueño.TabIndex = 1;
            dgv_LiquidacionesDueño.SelectionChanged += dgv_LiquidacionesDueño_SelectionChanged;
            // 
            // cmBox_Dueños
            // 
            cmBox_Dueños.FormattingEnabled = true;
            cmBox_Dueños.Location = new Point(103, 89);
            cmBox_Dueños.Name = "cmBox_Dueños";
            cmBox_Dueños.Size = new Size(126, 23);
            cmBox_Dueños.TabIndex = 2;
            cmBox_Dueños.SelectedIndexChanged += cmBox_Dueños_SelectedIndexChanged;
            // 
            // Dueños
            // 
            Dueños.AutoSize = true;
            Dueños.Location = new Point(103, 71);
            Dueños.Name = "Dueños";
            Dueños.Size = new Size(47, 15);
            Dueños.TabIndex = 3;
            Dueños.Text = "Dueños";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(525, 142);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 4;
            label1.Text = "Liquidaciones";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1321, 142);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 5;
            label2.Text = "Factura Liquidacion";
            // 
            // dgv_FacturasLiquidacionDueno
            // 
            dgv_FacturasLiquidacionDueno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_FacturasLiquidacionDueno.Location = new Point(943, 160);
            dgv_FacturasLiquidacionDueno.Name = "dgv_FacturasLiquidacionDueno";
            dgv_FacturasLiquidacionDueno.Size = new Size(489, 260);
            dgv_FacturasLiquidacionDueno.TabIndex = 6;
            // 
            // btn_RegistrarFactura
            // 
            btn_RegistrarFactura.Location = new Point(472, 513);
            btn_RegistrarFactura.Name = "btn_RegistrarFactura";
            btn_RegistrarFactura.Size = new Size(133, 25);
            btn_RegistrarFactura.TabIndex = 7;
            btn_RegistrarFactura.Text = "Registrar Factura";
            btn_RegistrarFactura.UseVisualStyleBackColor = true;
            btn_RegistrarFactura.Click += btn_RegistrarFactura_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(371, 457);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 8;
            label3.Text = "Nro Factura";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(371, 484);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 9;
            label4.Text = "Monto Total";
            // 
            // txt_NroFactura
            // 
            txt_NroFactura.Location = new Point(483, 454);
            txt_NroFactura.Name = "txt_NroFactura";
            txt_NroFactura.Size = new Size(122, 23);
            txt_NroFactura.TabIndex = 10;
            // 
            // Txt_MontoTotal
            // 
            Txt_MontoTotal.Enabled = false;
            Txt_MontoTotal.Location = new Point(483, 481);
            Txt_MontoTotal.Name = "Txt_MontoTotal";
            Txt_MontoTotal.Size = new Size(122, 23);
            Txt_MontoTotal.TabIndex = 11;
            // 
            // btn_EliminarFactura
            // 
            btn_EliminarFactura.Location = new Point(1332, 426);
            btn_EliminarFactura.Name = "btn_EliminarFactura";
            btn_EliminarFactura.Size = new Size(100, 23);
            btn_EliminarFactura.TabIndex = 12;
            btn_EliminarFactura.Text = "Eliminar Factura";
            btn_EliminarFactura.UseVisualStyleBackColor = true;
            btn_EliminarFactura.Click += btn_EliminarFactura_Click;
            // 
            // FormLiquidacionesDueño
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1506, 622);
            Controls.Add(btn_EliminarFactura);
            Controls.Add(Txt_MontoTotal);
            Controls.Add(txt_NroFactura);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btn_RegistrarFactura);
            Controls.Add(dgv_FacturasLiquidacionDueno);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Dueños);
            Controls.Add(cmBox_Dueños);
            Controls.Add(dgv_LiquidacionesDueño);
            Controls.Add(btn_GenerarLiquidaciones);
            Name = "FormLiquidacionesDueño";
            Text = "FormLiquidacionesDueño";
            Load += FormLiquidacionesDueño_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_LiquidacionesDueño).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_FacturasLiquidacionDueno).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_GenerarLiquidaciones;
        private DataGridView dgv_LiquidacionesDueño;
        private ComboBox cmBox_Dueños;
        private Label Dueños;
        private Label label1;
        private Label label2;
        private DataGridView dgv_FacturasLiquidacionDueno;
        private Button btn_RegistrarFactura;
        private Label label3;
        private Label label4;
        private TextBox txt_NroFactura;
        private TextBox Txt_MontoTotal;
        private Button btn_EliminarFactura;
    }
}