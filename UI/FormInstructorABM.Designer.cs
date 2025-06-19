namespace UI
{
    partial class FormInstructorABM
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
            txt_Licencia = new TextBox();
            Licencia = new Label();
            txt_FechaNac = new TextBox();
            label7 = new Label();
            txt_Email = new TextBox();
            label6 = new Label();
            txt_Telefono = new TextBox();
            label5 = new Label();
            txt_Apellido = new TextBox();
            label4 = new Label();
            txt_Nombre = new TextBox();
            label3 = new Label();
            txt_Cuil = new TextBox();
            label2 = new Label();
            txt_Dni = new TextBox();
            label1 = new Label();
            btn_BajaInstructor = new Button();
            btn_ModInstructor = new Button();
            btn_AltaInstructor = new Button();
            dgv_InstructorAMB = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_InstructorAMB).BeginInit();
            SuspendLayout();
            // 
            // txt_Licencia
            // 
            txt_Licencia.Location = new Point(128, 322);
            txt_Licencia.Name = "txt_Licencia";
            txt_Licencia.Size = new Size(125, 23);
            txt_Licencia.TabIndex = 39;
            // 
            // Licencia
            // 
            Licencia.AutoSize = true;
            Licencia.Location = new Point(18, 330);
            Licencia.Name = "Licencia";
            Licencia.Size = new Size(50, 15);
            Licencia.TabIndex = 38;
            Licencia.Text = "Licencia";
            // 
            // txt_FechaNac
            // 
            txt_FechaNac.Location = new Point(126, 192);
            txt_FechaNac.Name = "txt_FechaNac";
            txt_FechaNac.Size = new Size(125, 23);
            txt_FechaNac.TabIndex = 37;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 200);
            label7.Name = "label7";
            label7.Size = new Size(103, 15);
            label7.TabIndex = 36;
            label7.Text = "Fecha Nacimiento";
            // 
            // txt_Email
            // 
            txt_Email.Location = new Point(126, 278);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(125, 23);
            txt_Email.TabIndex = 35;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 281);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 34;
            label6.Text = "Email";
            // 
            // txt_Telefono
            // 
            txt_Telefono.Location = new Point(126, 233);
            txt_Telefono.Name = "txt_Telefono";
            txt_Telefono.Size = new Size(125, 23);
            txt_Telefono.TabIndex = 33;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 233);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 32;
            label5.Text = "Telefono";
            // 
            // txt_Apellido
            // 
            txt_Apellido.Location = new Point(126, 157);
            txt_Apellido.Name = "txt_Apellido";
            txt_Apellido.Size = new Size(125, 23);
            txt_Apellido.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 157);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 30;
            label4.Text = "Apellido";
            // 
            // txt_Nombre
            // 
            txt_Nombre.Location = new Point(126, 115);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new Size(125, 23);
            txt_Nombre.TabIndex = 29;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 118);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 28;
            label3.Text = "Nombre";
            // 
            // txt_Cuil
            // 
            txt_Cuil.Location = new Point(128, 72);
            txt_Cuil.Name = "txt_Cuil";
            txt_Cuil.Size = new Size(125, 23);
            txt_Cuil.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 80);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 26;
            label2.Text = "CUIT/CUIL";
            // 
            // txt_Dni
            // 
            txt_Dni.Location = new Point(126, 28);
            txt_Dni.Name = "txt_Dni";
            txt_Dni.Size = new Size(125, 23);
            txt_Dni.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 31);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 24;
            label1.Text = "DNI";
            // 
            // btn_BajaInstructor
            // 
            btn_BajaInstructor.Location = new Point(511, 246);
            btn_BajaInstructor.Name = "btn_BajaInstructor";
            btn_BajaInstructor.Size = new Size(75, 23);
            btn_BajaInstructor.TabIndex = 23;
            btn_BajaInstructor.Text = "Baja ";
            btn_BajaInstructor.UseVisualStyleBackColor = true;
            btn_BajaInstructor.Click += btn_BajaInstructor_Click;
            // 
            // btn_ModInstructor
            // 
            btn_ModInstructor.Location = new Point(371, 246);
            btn_ModInstructor.Name = "btn_ModInstructor";
            btn_ModInstructor.Size = new Size(122, 23);
            btn_ModInstructor.TabIndex = 22;
            btn_ModInstructor.Text = "Modificar Instructor";
            btn_ModInstructor.UseVisualStyleBackColor = true;
            btn_ModInstructor.Click += btn_ModInstructor_Click;
            // 
            // btn_AltaInstructor
            // 
            btn_AltaInstructor.Location = new Point(100, 400);
            btn_AltaInstructor.Name = "btn_AltaInstructor";
            btn_AltaInstructor.Size = new Size(151, 23);
            btn_AltaInstructor.TabIndex = 21;
            btn_AltaInstructor.Text = "Alta Instructor";
            btn_AltaInstructor.UseVisualStyleBackColor = true;
            btn_AltaInstructor.Click += btn_AltaInstructor_Click;
            // 
            // dgv_InstructorAMB
            // 
            dgv_InstructorAMB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_InstructorAMB.Location = new Point(371, 83);
            dgv_InstructorAMB.Name = "dgv_InstructorAMB";
            dgv_InstructorAMB.Size = new Size(412, 157);
            dgv_InstructorAMB.TabIndex = 20;
            // 
            // FormInstructorABM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txt_Licencia);
            Controls.Add(Licencia);
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
            Controls.Add(btn_BajaInstructor);
            Controls.Add(btn_ModInstructor);
            Controls.Add(btn_AltaInstructor);
            Controls.Add(dgv_InstructorAMB);
            Name = "FormInstructorABM";
            Text = "FormInstructorABM";
            ((System.ComponentModel.ISupportInitialize)dgv_InstructorAMB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Licencia;
        private Label Licencia;
        private TextBox txt_FechaNac;
        private Label label7;
        private TextBox txt_Email;
        private Label label6;
        private TextBox txt_Telefono;
        private Label label5;
        private TextBox txt_Apellido;
        private Label label4;
        private TextBox txt_Nombre;
        private Label label3;
        private TextBox txt_Cuil;
        private Label label2;
        private TextBox txt_Dni;
        private Label label1;
        private Button btn_BajaInstructor;
        private Button btn_ModInstructor;
        private Button btn_AltaInstructor;
        private DataGridView dgv_InstructorAMB;
    }
}