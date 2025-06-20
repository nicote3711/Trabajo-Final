namespace UI
{
    partial class FormUsuarioMod
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
            label5 = new Label();
            txt_Contrasena = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txt_Nombre = new TextBox();
            txt_Apellido = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txt_Dni = new TextBox();
            txt_NombreUsuario = new TextBox();
            label6 = new Label();
            txt_IdUsuario = new TextBox();
            btn_Modificar = new Button();
            checkBox_Activo = new CheckBox();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(69, 274);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 19;
            label5.Text = "Contraseña";
            // 
            // txt_Contrasena
            // 
            txt_Contrasena.Location = new Point(201, 266);
            txt_Contrasena.Name = "txt_Contrasena";
            txt_Contrasena.Size = new Size(137, 23);
            txt_Contrasena.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 227);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 17;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(69, 189);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 16;
            label4.Text = "Apellido";
            // 
            // txt_Nombre
            // 
            txt_Nombre.Location = new Point(201, 219);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new Size(137, 23);
            txt_Nombre.TabIndex = 15;
            // 
            // txt_Apellido
            // 
            txt_Apellido.Location = new Point(201, 181);
            txt_Apellido.Name = "txt_Apellido";
            txt_Apellido.Size = new Size(137, 23);
            txt_Apellido.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 145);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 13;
            label2.Text = "Dni";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 107);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 12;
            label1.Text = "Nombre Usuario";
            // 
            // txt_Dni
            // 
            txt_Dni.Location = new Point(201, 137);
            txt_Dni.Name = "txt_Dni";
            txt_Dni.Size = new Size(137, 23);
            txt_Dni.TabIndex = 11;
            // 
            // txt_NombreUsuario
            // 
            txt_NombreUsuario.Location = new Point(201, 99);
            txt_NombreUsuario.Name = "txt_NombreUsuario";
            txt_NombreUsuario.Size = new Size(137, 23);
            txt_NombreUsuario.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(69, 66);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 21;
            label6.Text = "Id Usuario";
            // 
            // txt_IdUsuario
            // 
            txt_IdUsuario.Enabled = false;
            txt_IdUsuario.Location = new Point(201, 58);
            txt_IdUsuario.Name = "txt_IdUsuario";
            txt_IdUsuario.Size = new Size(29, 23);
            txt_IdUsuario.TabIndex = 20;
            // 
            // btn_Modificar
            // 
            btn_Modificar.Location = new Point(201, 333);
            btn_Modificar.Name = "btn_Modificar";
            btn_Modificar.Size = new Size(126, 23);
            btn_Modificar.TabIndex = 22;
            btn_Modificar.Text = "Modificar";
            btn_Modificar.UseVisualStyleBackColor = true;
            btn_Modificar.Click += btn_Modificar_Click;
            // 
            // checkBox_Activo
            // 
            checkBox_Activo.AutoSize = true;
            checkBox_Activo.Location = new Point(204, 301);
            checkBox_Activo.Name = "checkBox_Activo";
            checkBox_Activo.Size = new Size(60, 19);
            checkBox_Activo.TabIndex = 23;
            checkBox_Activo.Text = "Activo";
            checkBox_Activo.UseVisualStyleBackColor = true;
            // 
            // FormUsuarioMod
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(381, 450);
            Controls.Add(checkBox_Activo);
            Controls.Add(btn_Modificar);
            Controls.Add(label6);
            Controls.Add(txt_IdUsuario);
            Controls.Add(label5);
            Controls.Add(txt_Contrasena);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(txt_Nombre);
            Controls.Add(txt_Apellido);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txt_Dni);
            Controls.Add(txt_NombreUsuario);
            Name = "FormUsuarioMod";
            Text = "FormUsuarioMod";
            Load += FormUsuarioMod_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private TextBox txt_Contrasena;
        private Label label3;
        private Label label4;
        private TextBox txt_Nombre;
        private TextBox txt_Apellido;
        private Label label2;
        private Label label1;
        private TextBox txt_Dni;
        private TextBox txt_NombreUsuario;
        private Label label6;
        private TextBox txt_IdUsuario;
        private Button btn_Modificar;
        private CheckBox checkBox_Activo;
    }
}