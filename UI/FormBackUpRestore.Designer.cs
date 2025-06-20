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
            groupBoxAltaUsuario = new GroupBox();
            label3 = new Label();
            label4 = new Label();
            txt_Nombre = new TextBox();
            txt_Apellido = new TextBox();
            label6 = new Label();
            label7 = new Label();
            txt_Dni = new TextBox();
            txt_NombreUsuario = new TextBox();
            rb_BackUp = new RadioButton();
            rb_Restore = new RadioButton();
            rb_All = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgv_BackUps).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Bitacora).BeginInit();
            groupBoxAltaUsuario.SuspendLayout();
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
            dgv_BackUps.MultiSelect = false;
            dgv_BackUps.Name = "dgv_BackUps";
            dgv_BackUps.ReadOnly = true;
            dgv_BackUps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_BackUps.Size = new Size(313, 166);
            dgv_BackUps.TabIndex = 1;
            // 
            // dgv_Bitacora
            // 
            dgv_Bitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Bitacora.Location = new Point(543, 31);
            dgv_Bitacora.MultiSelect = false;
            dgv_Bitacora.Name = "dgv_Bitacora";
            dgv_Bitacora.ReadOnly = true;
            dgv_Bitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Bitacora.Size = new Size(446, 292);
            dgv_Bitacora.TabIndex = 2;
            dgv_Bitacora.SelectionChanged += dgv_Bitacora_SelectionChanged;
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
            label2.Location = new Point(543, 9);
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
            // groupBoxAltaUsuario
            // 
            groupBoxAltaUsuario.Controls.Add(label3);
            groupBoxAltaUsuario.Controls.Add(label4);
            groupBoxAltaUsuario.Controls.Add(txt_Nombre);
            groupBoxAltaUsuario.Controls.Add(txt_Apellido);
            groupBoxAltaUsuario.Controls.Add(label6);
            groupBoxAltaUsuario.Controls.Add(label7);
            groupBoxAltaUsuario.Controls.Add(txt_Dni);
            groupBoxAltaUsuario.Controls.Add(txt_NombreUsuario);
            groupBoxAltaUsuario.Location = new Point(543, 357);
            groupBoxAltaUsuario.Name = "groupBoxAltaUsuario";
            groupBoxAltaUsuario.Size = new Size(432, 187);
            groupBoxAltaUsuario.TabIndex = 6;
            groupBoxAltaUsuario.TabStop = false;
            groupBoxAltaUsuario.Text = "Usuario Seleccionado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(56, 150);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 7;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 112);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 6;
            label4.Text = "Apellido";
            // 
            // txt_Nombre
            // 
            txt_Nombre.Enabled = false;
            txt_Nombre.Location = new Point(188, 142);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new Size(137, 23);
            txt_Nombre.TabIndex = 5;
            // 
            // txt_Apellido
            // 
            txt_Apellido.Enabled = false;
            txt_Apellido.Location = new Point(188, 104);
            txt_Apellido.Name = "txt_Apellido";
            txt_Apellido.Size = new Size(137, 23);
            txt_Apellido.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(56, 68);
            label6.Name = "label6";
            label6.Size = new Size(25, 15);
            label6.TabIndex = 3;
            label6.Text = "Dni";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(56, 30);
            label7.Name = "label7";
            label7.Size = new Size(94, 15);
            label7.TabIndex = 2;
            label7.Text = "Nombre Usuario";
            // 
            // txt_Dni
            // 
            txt_Dni.Enabled = false;
            txt_Dni.Location = new Point(188, 60);
            txt_Dni.Name = "txt_Dni";
            txt_Dni.Size = new Size(137, 23);
            txt_Dni.TabIndex = 1;
            // 
            // txt_NombreUsuario
            // 
            txt_NombreUsuario.Enabled = false;
            txt_NombreUsuario.Location = new Point(188, 22);
            txt_NombreUsuario.Name = "txt_NombreUsuario";
            txt_NombreUsuario.Size = new Size(137, 23);
            txt_NombreUsuario.TabIndex = 0;
            // 
            // rb_BackUp
            // 
            rb_BackUp.AutoSize = true;
            rb_BackUp.Location = new Point(556, 329);
            rb_BackUp.Name = "rb_BackUp";
            rb_BackUp.Size = new Size(70, 19);
            rb_BackUp.TabIndex = 7;
            rb_BackUp.TabStop = true;
            rb_BackUp.Text = "BackUps";
            rb_BackUp.UseVisualStyleBackColor = true;
            rb_BackUp.CheckedChanged += rb_BackUp_CheckedChanged;
            // 
            // rb_Restore
            // 
            rb_Restore.AutoSize = true;
            rb_Restore.Location = new Point(731, 329);
            rb_Restore.Name = "rb_Restore";
            rb_Restore.Size = new Size(69, 19);
            rb_Restore.TabIndex = 8;
            rb_Restore.TabStop = true;
            rb_Restore.Text = "Restores";
            rb_Restore.UseVisualStyleBackColor = true;
            rb_Restore.CheckedChanged += rb_Restore_CheckedChanged;
            // 
            // rb_All
            // 
            rb_All.AutoSize = true;
            rb_All.Location = new Point(881, 329);
            rb_All.Name = "rb_All";
            rb_All.Size = new Size(52, 19);
            rb_All.TabIndex = 9;
            rb_All.TabStop = true;
            rb_All.Text = "Todo";
            rb_All.UseVisualStyleBackColor = true;
            rb_All.CheckedChanged += rb_All_CheckedChanged;
            // 
            // FormBackUpRestore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 569);
            Controls.Add(rb_All);
            Controls.Add(rb_Restore);
            Controls.Add(rb_BackUp);
            Controls.Add(groupBoxAltaUsuario);
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
            groupBoxAltaUsuario.ResumeLayout(false);
            groupBoxAltaUsuario.PerformLayout();
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
        private GroupBox groupBoxAltaUsuario;
        private Label label3;
        private Label label4;
        private TextBox txt_Nombre;
        private TextBox txt_Apellido;
        private Label label6;
        private Label label7;
        private TextBox txt_Dni;
        private TextBox txt_NombreUsuario;
        private RadioButton rb_BackUp;
        private RadioButton rb_Restore;
        private RadioButton rb_All;
    }
}