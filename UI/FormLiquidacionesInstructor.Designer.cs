namespace UI
{
    partial class FormLiquidacionesInstructor
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
            btn_EliminarFactura = new Button();
            Txt_MontoTotal = new TextBox();
            txt_NroFactura = new TextBox();
            label4 = new Label();
            label3 = new Label();
            btn_RegistrarFactura = new Button();
            dgv_FacturasLiquidacionIns = new DataGridView();
            label2 = new Label();
            label1 = new Label();
            Instructores = new Label();
            cmBox_Instructores = new ComboBox();
            dgv_LiquidacionesInstructor = new DataGridView();
            btn_GenerarLiquidaciones = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_FacturasLiquidacionIns).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_LiquidacionesInstructor).BeginInit();
            SuspendLayout();
            // 
            // btn_EliminarFactura
            // 
            btn_EliminarFactura.Location = new Point(1232, 447);
            btn_EliminarFactura.Name = "btn_EliminarFactura";
            btn_EliminarFactura.Size = new Size(100, 23);
            btn_EliminarFactura.TabIndex = 25;
            btn_EliminarFactura.Text = "Eliminar Factura";
            btn_EliminarFactura.UseVisualStyleBackColor = true;
            btn_EliminarFactura.Click += btn_EliminarFactura_Click;
            // 
            // Txt_MontoTotal
            // 
            Txt_MontoTotal.Enabled = false;
            Txt_MontoTotal.Location = new Point(413, 486);
            Txt_MontoTotal.Name = "Txt_MontoTotal";
            Txt_MontoTotal.Size = new Size(122, 23);
            Txt_MontoTotal.TabIndex = 24;
            // 
            // txt_NroFactura
            // 
            txt_NroFactura.Location = new Point(413, 459);
            txt_NroFactura.Name = "txt_NroFactura";
            txt_NroFactura.Size = new Size(122, 23);
            txt_NroFactura.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(301, 489);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 22;
            label4.Text = "Monto Total";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(301, 462);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 21;
            label3.Text = "Nro Factura";
            // 
            // btn_RegistrarFactura
            // 
            btn_RegistrarFactura.Location = new Point(413, 527);
            btn_RegistrarFactura.Name = "btn_RegistrarFactura";
            btn_RegistrarFactura.Size = new Size(122, 25);
            btn_RegistrarFactura.TabIndex = 20;
            btn_RegistrarFactura.Text = "Registrar Factura";
            btn_RegistrarFactura.UseVisualStyleBackColor = true;
            btn_RegistrarFactura.Click += btn_RegistrarFactura_Click;
            // 
            // dgv_FacturasLiquidacionIns
            // 
            dgv_FacturasLiquidacionIns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_FacturasLiquidacionIns.Location = new Point(843, 181);
            dgv_FacturasLiquidacionIns.Name = "dgv_FacturasLiquidacionIns";
            dgv_FacturasLiquidacionIns.Size = new Size(489, 260);
            dgv_FacturasLiquidacionIns.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1221, 163);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 18;
            label2.Text = "Factura Liquidacion";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(455, 147);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 17;
            label1.Text = "Liquidaciones";
            // 
            // Instructores
            // 
            Instructores.AutoSize = true;
            Instructores.Location = new Point(42, 62);
            Instructores.Name = "Instructores";
            Instructores.Size = new Size(69, 15);
            Instructores.TabIndex = 16;
            Instructores.Text = "Instructores";
            // 
            // cmBox_Instructores
            // 
            cmBox_Instructores.FormattingEnabled = true;
            cmBox_Instructores.Location = new Point(42, 80);
            cmBox_Instructores.Name = "cmBox_Instructores";
            cmBox_Instructores.Size = new Size(126, 23);
            cmBox_Instructores.TabIndex = 15;
            cmBox_Instructores.SelectedIndexChanged += cmBox_Instructores_SelectedIndexChanged;
            // 
            // dgv_LiquidacionesInstructor
            // 
            dgv_LiquidacionesInstructor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_LiquidacionesInstructor.Location = new Point(33, 165);
            dgv_LiquidacionesInstructor.Name = "dgv_LiquidacionesInstructor";
            dgv_LiquidacionesInstructor.Size = new Size(502, 260);
            dgv_LiquidacionesInstructor.TabIndex = 14;
            dgv_LiquidacionesInstructor.SelectionChanged += dgv_LiquidacionesInstructor_SelectionChanged;
            // 
            // btn_GenerarLiquidaciones
            // 
            btn_GenerarLiquidaciones.Location = new Point(594, 17);
            btn_GenerarLiquidaciones.Name = "btn_GenerarLiquidaciones";
            btn_GenerarLiquidaciones.Size = new Size(222, 57);
            btn_GenerarLiquidaciones.TabIndex = 13;
            btn_GenerarLiquidaciones.Text = "Generar Liquidaciones";
            btn_GenerarLiquidaciones.UseVisualStyleBackColor = true;
            btn_GenerarLiquidaciones.Click += btn_GenerarLiquidaciones_Click;
            // 
            // FormLiquidacionesInstructor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1358, 617);
            Controls.Add(btn_EliminarFactura);
            Controls.Add(Txt_MontoTotal);
            Controls.Add(txt_NroFactura);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btn_RegistrarFactura);
            Controls.Add(dgv_FacturasLiquidacionIns);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Instructores);
            Controls.Add(cmBox_Instructores);
            Controls.Add(dgv_LiquidacionesInstructor);
            Controls.Add(btn_GenerarLiquidaciones);
            Name = "FormLiquidacionesInstructor";
            Text = "FormLiquidacionesInstructor";
            Load += FormLiquidacionesInstructor_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_FacturasLiquidacionIns).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_LiquidacionesInstructor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_EliminarFactura;
        private TextBox Txt_MontoTotal;
        private TextBox txt_NroFactura;
        private Label label4;
        private Label label3;
        private Button btn_RegistrarFactura;
        private DataGridView dgv_FacturasLiquidacionIns;
        private Label label2;
        private Label label1;
        private Label Instructores;
        private ComboBox cmBox_Instructores;
        private DataGridView dgv_LiquidacionesInstructor;
        private Button btn_GenerarLiquidaciones;
    }
}