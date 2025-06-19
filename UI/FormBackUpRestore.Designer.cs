namespace UI
{
    partial class FormBackUpRestore
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
            btn_BackUP = new Button();
            dgv_BackUps = new DataGridView();
            dgv_Bitacora = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            btn_RealizarRestore = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_BackUps).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Bitacora).BeginInit();
            SuspendLayout();
            // 
            // btn_BackUP
            // 
            btn_BackUP.Location = new Point(41, 252);
            btn_BackUP.Name = "btn_BackUP";
            btn_BackUP.Size = new Size(107, 34);
            btn_BackUP.TabIndex = 0;
            btn_BackUP.Text = "Realizar Back Up";
            btn_BackUP.UseVisualStyleBackColor = true;
            btn_BackUP.Click += button1_Click;
            // 
            // dgv_BackUps
            // 
            dgv_BackUps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_BackUps.Location = new Point(41, 66);
            dgv_BackUps.Name = "dgv_BackUps";
            dgv_BackUps.Size = new Size(313, 166);
            dgv_BackUps.TabIndex = 1;
            // 
            // dgv_Bitacora
            // 
            dgv_Bitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Bitacora.Location = new Point(585, 31);
            dgv_Bitacora.Name = "dgv_Bitacora";
            dgv_Bitacora.Size = new Size(324, 360);
            dgv_Bitacora.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 31);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 3;
            label1.Text = "Back UP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(585, 9);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 4;
            label2.Text = "Bitacora";
            // 
            // btn_RealizarRestore
            // 
            btn_RealizarRestore.Location = new Point(241, 252);
            btn_RealizarRestore.Name = "btn_RealizarRestore";
            btn_RealizarRestore.Size = new Size(113, 34);
            btn_RealizarRestore.TabIndex = 5;
            btn_RealizarRestore.Text = "Realizar Restore";
            btn_RealizarRestore.UseVisualStyleBackColor = true;
            btn_RealizarRestore.Click += btn_RealizarRestore_Click;
            // 
            // FormBackUpRestore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 569);
            Controls.Add(btn_RealizarRestore);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgv_Bitacora);
            Controls.Add(dgv_BackUps);
            Controls.Add(btn_BackUP);
            Name = "FormBackUpRestore";
            Text = "FormBackUpRestore";
            ((System.ComponentModel.ISupportInitialize)dgv_BackUps).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Bitacora).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_BackUP;
        private DataGridView dgv_BackUps;
        private DataGridView dgv_Bitacora;
        private Label label1;
        private Label label2;
        private Button btn_RealizarRestore;
    }
}