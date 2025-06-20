namespace UI
{
    partial class FormUsuarioABM
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
            dgv_Usuarios = new DataGridView();
            groupBoxAltaUsuario = new GroupBox();
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
            btn_AltaUsuario = new Button();
            btn_BajaUsuario = new Button();
            btn_Modificar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_Usuarios).BeginInit();
            groupBoxAltaUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_Usuarios
            // 
            dgv_Usuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Usuarios.Location = new Point(561, 31);
            dgv_Usuarios.Name = "dgv_Usuarios";
            dgv_Usuarios.Size = new Size(584, 273);
            dgv_Usuarios.TabIndex = 0;
            // 
            // groupBoxAltaUsuario
            // 
            groupBoxAltaUsuario.Controls.Add(label5);
            groupBoxAltaUsuario.Controls.Add(txt_Contrasena);
            groupBoxAltaUsuario.Controls.Add(label3);
            groupBoxAltaUsuario.Controls.Add(label4);
            groupBoxAltaUsuario.Controls.Add(txt_Nombre);
            groupBoxAltaUsuario.Controls.Add(txt_Apellido);
            groupBoxAltaUsuario.Controls.Add(label2);
            groupBoxAltaUsuario.Controls.Add(label1);
            groupBoxAltaUsuario.Controls.Add(txt_Dni);
            groupBoxAltaUsuario.Controls.Add(txt_NombreUsuario);
            groupBoxAltaUsuario.Location = new Point(25, 18);
            groupBoxAltaUsuario.Name = "groupBoxAltaUsuario";
            groupBoxAltaUsuario.Size = new Size(417, 298);
            groupBoxAltaUsuario.TabIndex = 1;
            groupBoxAltaUsuario.TabStop = false;
            groupBoxAltaUsuario.Text = "Alta Usuario";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(72, 256);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 9;
            label5.Text = "Contraseña";
            // 
            // txt_Contrasena
            // 
            txt_Contrasena.Location = new Point(204, 248);
            txt_Contrasena.Name = "txt_Contrasena";
            txt_Contrasena.Size = new Size(137, 23);
            txt_Contrasena.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 209);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 7;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(72, 171);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 6;
            label4.Text = "Apellido";
            // 
            // txt_Nombre
            // 
            txt_Nombre.Location = new Point(204, 201);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new Size(137, 23);
            txt_Nombre.TabIndex = 5;
            // 
            // txt_Apellido
            // 
            txt_Apellido.Location = new Point(204, 163);
            txt_Apellido.Name = "txt_Apellido";
            txt_Apellido.Size = new Size(137, 23);
            txt_Apellido.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 127);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 3;
            label2.Text = "Dni";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 89);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 2;
            label1.Text = "Nombre Usuario";
            // 
            // txt_Dni
            // 
            txt_Dni.Location = new Point(204, 119);
            txt_Dni.Name = "txt_Dni";
            txt_Dni.Size = new Size(137, 23);
            txt_Dni.TabIndex = 1;
            // 
            // txt_NombreUsuario
            // 
            txt_NombreUsuario.Location = new Point(204, 81);
            txt_NombreUsuario.Name = "txt_NombreUsuario";
            txt_NombreUsuario.Size = new Size(137, 23);
            txt_NombreUsuario.TabIndex = 0;
            // 
            // btn_AltaUsuario
            // 
            btn_AltaUsuario.Location = new Point(334, 333);
            btn_AltaUsuario.Name = "btn_AltaUsuario";
            btn_AltaUsuario.Size = new Size(108, 33);
            btn_AltaUsuario.TabIndex = 2;
            btn_AltaUsuario.Text = "Alta Usuario";
            btn_AltaUsuario.UseVisualStyleBackColor = true;
            btn_AltaUsuario.Click += btn_AltaUsuario_Click;
            // 
            // btn_BajaUsuario
            // 
            btn_BajaUsuario.Location = new Point(1046, 310);
            btn_BajaUsuario.Name = "btn_BajaUsuario";
            btn_BajaUsuario.Size = new Size(99, 33);
            btn_BajaUsuario.TabIndex = 3;
            btn_BajaUsuario.Text = "Baja Usuario";
            btn_BajaUsuario.UseVisualStyleBackColor = true;
            btn_BajaUsuario.Click += btn_BajaUsuario_Click;
            // 
            // btn_Modificar
            // 
            btn_Modificar.Location = new Point(918, 312);
            btn_Modificar.Name = "btn_Modificar";
            btn_Modificar.Size = new Size(101, 28);
            btn_Modificar.TabIndex = 4;
            btn_Modificar.Text = "Modificar";
            btn_Modificar.UseVisualStyleBackColor = true;
            btn_Modificar.Click += btn_Modificar_Click;
            // 
            // FormUsuarioABM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1190, 432);
            Controls.Add(btn_Modificar);
            Controls.Add(btn_BajaUsuario);
            Controls.Add(btn_AltaUsuario);
            Controls.Add(groupBoxAltaUsuario);
            Controls.Add(dgv_Usuarios);
            Name = "FormUsuarioABM";
            Text = "UsuarioABM";
            Load += UsuarioABM_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Usuarios).EndInit();
            groupBoxAltaUsuario.ResumeLayout(false);
            groupBoxAltaUsuario.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_Usuarios;
        private GroupBox groupBoxAltaUsuario;
        private Label label2;
        private Label label1;
        private TextBox txt_Dni;
        private TextBox txt_NombreUsuario;
        private Label label3;
        private Label label4;
        private TextBox txt_Nombre;
        private TextBox txt_Apellido;
        private Button btn_AltaUsuario;
        private Button btn_BajaUsuario;
        private Button btn_Modificar;
        private Label label5;
        private TextBox txt_Contrasena;
    }
}