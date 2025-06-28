namespace UI
{
    partial class FormSolicitarMantenimiento100Hs
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
            dgv_Mantenimientos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_Mantenimientos).BeginInit();
            SuspendLayout();
            // 
            // dgv_Mantenimientos
            // 
            dgv_Mantenimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Mantenimientos.Location = new Point(73, 76);
            dgv_Mantenimientos.Name = "dgv_Mantenimientos";
            dgv_Mantenimientos.Size = new Size(428, 153);
            dgv_Mantenimientos.TabIndex = 0;
            // 
            // FormSolicitarMantenimiento100Hs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_Mantenimientos);
            Name = "FormSolicitarMantenimiento100Hs";
            Text = "FormSolicitarMantenimiento100Hs";
            Load += FormSolicitarMantenimiento100Hs_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Mantenimientos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_Mantenimientos;
    }
}