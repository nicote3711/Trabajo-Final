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
            // FormRegistrarMantenimiento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1173, 531);
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
    }
}