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
            ((System.ComponentModel.ISupportInitialize)dgv_LiquidacionesDueño).BeginInit();
            SuspendLayout();
            // 
            // btn_GenerarLiquidaciones
            // 
            btn_GenerarLiquidaciones.Location = new Point(953, 34);
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
            dgv_LiquidacionesDueño.Location = new Point(122, 214);
            dgv_LiquidacionesDueño.Name = "dgv_LiquidacionesDueño";
            dgv_LiquidacionesDueño.Size = new Size(502, 260);
            dgv_LiquidacionesDueño.TabIndex = 1;
            // 
            // cmBox_Dueños
            // 
            cmBox_Dueños.FormattingEnabled = true;
            cmBox_Dueños.Location = new Point(122, 163);
            cmBox_Dueños.Name = "cmBox_Dueños";
            cmBox_Dueños.Size = new Size(126, 23);
            cmBox_Dueños.TabIndex = 2;
            cmBox_Dueños.SelectedIndexChanged += cmBox_Dueños_SelectedIndexChanged;
            // 
            // FormLiquidacionesDueño
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 561);
            Controls.Add(cmBox_Dueños);
            Controls.Add(dgv_LiquidacionesDueño);
            Controls.Add(btn_GenerarLiquidaciones);
            Name = "FormLiquidacionesDueño";
            Text = "FormLiquidacionesDueño";
            Load += FormLiquidacionesDueño_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_LiquidacionesDueño).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_GenerarLiquidaciones;
        private DataGridView dgv_LiquidacionesDueño;
        private ComboBox cmBox_Dueños;
    }
}