namespace UI
{
    partial class FormInstructorMod
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
            label8 = new Label();
            label9 = new Label();
            txt_IdInstructor = new TextBox();
            txt_IdPersona = new TextBox();
            btn_ModificarInstructor = new Button();
            checkBox_Activo = new CheckBox();
            dtp_FechaNacimiento = new DateTimePicker();
            SuspendLayout();
            // 
            // txt_Licencia
            // 
            txt_Licencia.Location = new Point(156, 369);
            txt_Licencia.Name = "txt_Licencia";
            txt_Licencia.Size = new Size(125, 23);
            txt_Licencia.TabIndex = 55;
            // 
            // Licencia
            // 
            Licencia.AutoSize = true;
            Licencia.Location = new Point(46, 377);
            Licencia.Name = "Licencia";
            Licencia.Size = new Size(50, 15);
            Licencia.TabIndex = 54;
            Licencia.Text = "Licencia";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(46, 247);
            label7.Name = "label7";
            label7.Size = new Size(103, 15);
            label7.TabIndex = 52;
            label7.Text = "Fecha Nacimiento";
            // 
            // txt_Email
            // 
            txt_Email.Location = new Point(154, 325);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(125, 23);
            txt_Email.TabIndex = 51;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(46, 328);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 50;
            label6.Text = "Email";
            // 
            // txt_Telefono
            // 
            txt_Telefono.Location = new Point(154, 280);
            txt_Telefono.Name = "txt_Telefono";
            txt_Telefono.Size = new Size(125, 23);
            txt_Telefono.TabIndex = 49;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(46, 280);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 48;
            label5.Text = "Telefono";
            // 
            // txt_Apellido
            // 
            txt_Apellido.Location = new Point(154, 204);
            txt_Apellido.Name = "txt_Apellido";
            txt_Apellido.Size = new Size(125, 23);
            txt_Apellido.TabIndex = 47;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 204);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 46;
            label4.Text = "Apellido";
            // 
            // txt_Nombre
            // 
            txt_Nombre.Location = new Point(154, 162);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new Size(125, 23);
            txt_Nombre.TabIndex = 45;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 165);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 44;
            label3.Text = "Nombre";
            // 
            // txt_Cuil
            // 
            txt_Cuil.Location = new Point(156, 119);
            txt_Cuil.Name = "txt_Cuil";
            txt_Cuil.Size = new Size(125, 23);
            txt_Cuil.TabIndex = 43;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 127);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 42;
            label2.Text = "CUIT/CUIL";
            // 
            // txt_Dni
            // 
            txt_Dni.Location = new Point(154, 75);
            txt_Dni.Name = "txt_Dni";
            txt_Dni.Size = new Size(125, 23);
            txt_Dni.TabIndex = 41;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 78);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 40;
            label1.Text = "DNI";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(46, 9);
            label8.Name = "label8";
            label8.Size = new Size(71, 15);
            label8.TabIndex = 56;
            label8.Text = "Id Instructor";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(46, 48);
            label9.Name = "label9";
            label9.Size = new Size(62, 15);
            label9.TabIndex = 57;
            label9.Text = "Id Persona";
            // 
            // txt_IdInstructor
            // 
            txt_IdInstructor.Enabled = false;
            txt_IdInstructor.Location = new Point(156, 10);
            txt_IdInstructor.Name = "txt_IdInstructor";
            txt_IdInstructor.Size = new Size(123, 23);
            txt_IdInstructor.TabIndex = 58;
            // 
            // txt_IdPersona
            // 
            txt_IdPersona.Location = new Point(156, 39);
            txt_IdPersona.Name = "txt_IdPersona";
            txt_IdPersona.Size = new Size(123, 23);
            txt_IdPersona.TabIndex = 59;
            // 
            // btn_ModificarInstructor
            // 
            btn_ModificarInstructor.Location = new Point(156, 451);
            btn_ModificarInstructor.Name = "btn_ModificarInstructor";
            btn_ModificarInstructor.Size = new Size(114, 23);
            btn_ModificarInstructor.TabIndex = 60;
            btn_ModificarInstructor.Text = "Modificar";
            btn_ModificarInstructor.UseVisualStyleBackColor = true;
            btn_ModificarInstructor.Click += btn_ModificarInstructor_Click;
            // 
            // checkBox_Activo
            // 
            checkBox_Activo.AutoSize = true;
            checkBox_Activo.Location = new Point(165, 408);
            checkBox_Activo.Name = "checkBox_Activo";
            checkBox_Activo.Size = new Size(60, 19);
            checkBox_Activo.TabIndex = 61;
            checkBox_Activo.Text = "Activo";
            checkBox_Activo.UseVisualStyleBackColor = true;
            // 
            // dtp_FechaNacimiento
            // 
            dtp_FechaNacimiento.Format = DateTimePickerFormat.Short;
            dtp_FechaNacimiento.Location = new Point(154, 241);
            dtp_FechaNacimiento.Name = "dtp_FechaNacimiento";
            dtp_FechaNacimiento.Size = new Size(125, 23);
            dtp_FechaNacimiento.TabIndex = 67;
            // 
            // FormInstructorMod
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 499);
            Controls.Add(dtp_FechaNacimiento);
            Controls.Add(checkBox_Activo);
            Controls.Add(btn_ModificarInstructor);
            Controls.Add(txt_IdPersona);
            Controls.Add(txt_IdInstructor);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(txt_Licencia);
            Controls.Add(Licencia);
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
            Name = "FormInstructorMod";
            Text = "FormInstructorMod";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Licencia;
        private Label Licencia;
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
        private Label label8;
        private Label label9;
        private TextBox txt_IdInstructor;
        private TextBox txt_IdPersona;
        private Button btn_ModificarInstructor;
        private CheckBox checkBox_Activo;
        private DateTimePicker dtp_FechaNacimiento;
    }
}