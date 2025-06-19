namespace UI
{
    partial class FormDuenoABM
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
            label6 = new Label();
            txt_FechaNac = new TextBox();
            txt_Dni = new TextBox();
            label2 = new Label();
            txt_Cuil = new TextBox();
            label3 = new Label();
            txt_Nombre = new TextBox();
            label4 = new Label();
            txt_Apellido = new TextBox();
            label5 = new Label();
            txt_Telefono = new TextBox();
            txt_Email = new TextBox();
            label7 = new Label();
            label1 = new Label();
            btn_AltaDueno = new Button();
            btn_BajaDueno = new Button();
            btn_ModDueno = new Button();
            dgv_DuenoAMB = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_DuenoAMB).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 273);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 48;
            label6.Text = "Email";
            // 
            // txt_FechaNac
            // 
            txt_FechaNac.Location = new Point(138, 184);
            txt_FechaNac.Name = "txt_FechaNac";
            txt_FechaNac.Size = new Size(125, 23);
            txt_FechaNac.TabIndex = 51;
            // 
            // txt_Dni
            // 
            txt_Dni.Location = new Point(138, 20);
            txt_Dni.Name = "txt_Dni";
            txt_Dni.Size = new Size(125, 23);
            txt_Dni.TabIndex = 39;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 72);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 40;
            label2.Text = "CUIT/CUIL";
            // 
            // txt_Cuil
            // 
            txt_Cuil.Location = new Point(140, 64);
            txt_Cuil.Name = "txt_Cuil";
            txt_Cuil.Size = new Size(125, 23);
            txt_Cuil.TabIndex = 41;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 110);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 42;
            label3.Text = "Nombre";
            // 
            // txt_Nombre
            // 
            txt_Nombre.Location = new Point(138, 107);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new Size(125, 23);
            txt_Nombre.TabIndex = 43;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 149);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 44;
            label4.Text = "Apellido";
            // 
            // txt_Apellido
            // 
            txt_Apellido.Location = new Point(138, 149);
            txt_Apellido.Name = "txt_Apellido";
            txt_Apellido.Size = new Size(125, 23);
            txt_Apellido.TabIndex = 45;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 225);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 46;
            label5.Text = "Telefono";
            // 
            // txt_Telefono
            // 
            txt_Telefono.Location = new Point(138, 225);
            txt_Telefono.Name = "txt_Telefono";
            txt_Telefono.Size = new Size(125, 23);
            txt_Telefono.TabIndex = 47;
            // 
            // txt_Email
            // 
            txt_Email.Location = new Point(138, 270);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(125, 23);
            txt_Email.TabIndex = 49;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 192);
            label7.Name = "label7";
            label7.Size = new Size(103, 15);
            label7.TabIndex = 50;
            label7.Text = "Fecha Nacimiento";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 23);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 38;
            label1.Text = "DNI";
            // 
            // btn_AltaDueno
            // 
            btn_AltaDueno.Location = new Point(112, 320);
            btn_AltaDueno.Name = "btn_AltaDueno";
            btn_AltaDueno.Size = new Size(151, 23);
            btn_AltaDueno.TabIndex = 52;
            btn_AltaDueno.Text = "Alta Dueño";
            btn_AltaDueno.UseVisualStyleBackColor = true;
            btn_AltaDueno.Click += btn_AltaDueno_Click;
            // 
            // btn_BajaDueno
            // 
            btn_BajaDueno.Location = new Point(480, 227);
            btn_BajaDueno.Name = "btn_BajaDueno";
            btn_BajaDueno.Size = new Size(75, 23);
            btn_BajaDueno.TabIndex = 55;
            btn_BajaDueno.Text = "Baja ";
            btn_BajaDueno.UseVisualStyleBackColor = true;
            btn_BajaDueno.Click += btn_BajaDueno_Click;
            // 
            // btn_ModDueno
            // 
            btn_ModDueno.Location = new Point(340, 227);
            btn_ModDueno.Name = "btn_ModDueno";
            btn_ModDueno.Size = new Size(122, 23);
            btn_ModDueno.TabIndex = 54;
            btn_ModDueno.Text = "Modificar Dueño";
            btn_ModDueno.UseVisualStyleBackColor = true;
            btn_ModDueno.Click += btn_ModDueno_Click;
            // 
            // dgv_DuenoAMB
            // 
            dgv_DuenoAMB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_DuenoAMB.Location = new Point(340, 64);
            dgv_DuenoAMB.Name = "dgv_DuenoAMB";
            dgv_DuenoAMB.Size = new Size(755, 157);
            dgv_DuenoAMB.TabIndex = 53;
            // 
            // FormDuenoABM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1254, 371);
            Controls.Add(btn_BajaDueno);
            Controls.Add(btn_ModDueno);
            Controls.Add(dgv_DuenoAMB);
            Controls.Add(btn_AltaDueno);
            Controls.Add(txt_FechaNac);
            Controls.Add(label7);
            Controls.Add(txt_Email);
            Controls.Add(label6);
            Controls.Add(txt_Telefono);
            Controls.Add(label5);
            Controls.Add(txt_Apellido);
            Controls.Add(label4);
            Controls.Add(txt_Nombre);
            Controls.Add(label3);
            Controls.Add(txt_Cuil);
            Controls.Add(label2);
            Controls.Add(txt_Dni);
            Controls.Add(label1);
            Name = "FormDuenoABM";
            Text = "FormDuenoABM";
            ((System.ComponentModel.ISupportInitialize)dgv_DuenoAMB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private TextBox txt_FechaNac;
        private TextBox txt_Dni;
        private Label label2;
        private TextBox txt_Cuil;
        private Label label3;
        private TextBox txt_Nombre;
        private Label label4;
        private TextBox txt_Apellido;
        private Label label5;
        private TextBox txt_Telefono;
        private TextBox txt_Email;
        private Label label7;
        private Label label1;
        private Button btn_AltaDueno;
        private Button btn_BajaDueno;
        private Button btn_ModDueno;
        private DataGridView dgv_DuenoAMB;
    }
}