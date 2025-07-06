namespace UI
{
    partial class FormRolPermiso
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
            tv_Usuarios = new TreeView();
            label2 = new Label();
            tv_Roles = new TreeView();
            label3 = new Label();
            tv_Permisos = new TreeView();
            label4 = new Label();
            tv_PermisosRol = new TreeView();
            label1 = new Label();
            tv_PermisoUsuario = new TreeView();
            label5 = new Label();
            groupBox_Usuario = new GroupBox();
            checkBox_Desencriptar = new CheckBox();
            label8 = new Label();
            txt_Password = new TextBox();
            txt_Nombre = new TextBox();
            label7 = new Label();
            label6 = new Label();
            txt_IdUsuario = new TextBox();
            btn_AsignarRolSeleccionado = new Button();
            btn_QuitarRolSeleccionado = new Button();
            groupBox_Rol = new GroupBox();
            label10 = new Label();
            txt_NombreRol = new TextBox();
            txt_IdRol = new TextBox();
            label9 = new Label();
            groupBox_Permiso = new GroupBox();
            label12 = new Label();
            label11 = new Label();
            checkBox_EsHoja = new CheckBox();
            txt_NombrePermiso = new TextBox();
            txt_IdPermiso = new TextBox();
            btn_AsignarPermiso = new Button();
            btn_QuitarPermiso = new Button();
            btn_AltaRol = new Button();
            btn_BajaRol = new Button();
            label13 = new Label();
            groupBox1 = new GroupBox();
            txt_NombreRolAlta = new TextBox();
            groupBox_Usuario.SuspendLayout();
            groupBox_Rol.SuspendLayout();
            groupBox_Permiso.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tv_Usuarios
            // 
            tv_Usuarios.Location = new Point(21, 305);
            tv_Usuarios.Name = "tv_Usuarios";
            tv_Usuarios.Size = new Size(158, 194);
            tv_Usuarios.TabIndex = 4;
            tv_Usuarios.AfterSelect += tv_Usuarios_AfterSelect;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 278);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 5;
            label2.Text = "Usuarios";
            // 
            // tv_Roles
            // 
            tv_Roles.Location = new Point(238, 305);
            tv_Roles.Name = "tv_Roles";
            tv_Roles.Size = new Size(193, 194);
            tv_Roles.TabIndex = 6;
            tv_Roles.AfterSelect += tv_Roles_AfterSelect;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(238, 278);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 7;
            label3.Text = "Roles";
            // 
            // tv_Permisos
            // 
            tv_Permisos.Location = new Point(478, 305);
            tv_Permisos.Name = "tv_Permisos";
            tv_Permisos.Size = new Size(178, 194);
            tv_Permisos.TabIndex = 8;
            tv_Permisos.AfterSelect += tv_Permisos_AfterSelect;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(478, 278);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 9;
            label4.Text = "Permisos";
            // 
            // tv_PermisosRol
            // 
            tv_PermisosRol.Location = new Point(725, 305);
            tv_PermisosRol.Name = "tv_PermisosRol";
            tv_PermisosRol.Size = new Size(160, 194);
            tv_PermisosRol.TabIndex = 10;
            tv_PermisosRol.AfterSelect += tv_PermisosRol_AfterSelect;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(725, 278);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 11;
            label1.Text = "Permisos Rol";
            // 
            // tv_PermisoUsuario
            // 
            tv_PermisoUsuario.Location = new Point(951, 305);
            tv_PermisoUsuario.Name = "tv_PermisoUsuario";
            tv_PermisoUsuario.Size = new Size(165, 194);
            tv_PermisoUsuario.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(951, 278);
            label5.Name = "label5";
            label5.Size = new Size(93, 15);
            label5.TabIndex = 13;
            label5.Text = "Permiso Usuario";
            // 
            // groupBox_Usuario
            // 
            groupBox_Usuario.Controls.Add(checkBox_Desencriptar);
            groupBox_Usuario.Controls.Add(label8);
            groupBox_Usuario.Controls.Add(txt_Password);
            groupBox_Usuario.Controls.Add(txt_Nombre);
            groupBox_Usuario.Controls.Add(label7);
            groupBox_Usuario.Controls.Add(label6);
            groupBox_Usuario.Controls.Add(txt_IdUsuario);
            groupBox_Usuario.Location = new Point(29, 12);
            groupBox_Usuario.Name = "groupBox_Usuario";
            groupBox_Usuario.Size = new Size(192, 170);
            groupBox_Usuario.TabIndex = 14;
            groupBox_Usuario.TabStop = false;
            groupBox_Usuario.Text = "Usuario Selecionado";
            // 
            // checkBox_Desencriptar
            // 
            checkBox_Desencriptar.AutoSize = true;
            checkBox_Desencriptar.Location = new Point(94, 145);
            checkBox_Desencriptar.Name = "checkBox_Desencriptar";
            checkBox_Desencriptar.Size = new Size(92, 19);
            checkBox_Desencriptar.TabIndex = 6;
            checkBox_Desencriptar.Text = "Desencriptar";
            checkBox_Desencriptar.UseVisualStyleBackColor = true;
            checkBox_Desencriptar.CheckedChanged += checkBox_Desencriptar_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 101);
            label8.Name = "label8";
            label8.Size = new Size(57, 15);
            label8.TabIndex = 5;
            label8.Text = "Password";
            // 
            // txt_Password
            // 
            txt_Password.Enabled = false;
            txt_Password.Location = new Point(86, 98);
            txt_Password.Name = "txt_Password";
            txt_Password.Size = new Size(100, 23);
            txt_Password.TabIndex = 4;
            // 
            // txt_Nombre
            // 
            txt_Nombre.Enabled = false;
            txt_Nombre.Location = new Point(86, 57);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new Size(100, 23);
            txt_Nombre.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 61);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 2;
            label7.Text = "Nombre";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 28);
            label6.Name = "label6";
            label6.Size = new Size(17, 15);
            label6.TabIndex = 1;
            label6.Text = "Id";
            // 
            // txt_IdUsuario
            // 
            txt_IdUsuario.Enabled = false;
            txt_IdUsuario.Location = new Point(143, 28);
            txt_IdUsuario.Name = "txt_IdUsuario";
            txt_IdUsuario.Size = new Size(33, 23);
            txt_IdUsuario.TabIndex = 0;
            // 
            // btn_AsignarRolSeleccionado
            // 
            btn_AsignarRolSeleccionado.Location = new Point(21, 505);
            btn_AsignarRolSeleccionado.Name = "btn_AsignarRolSeleccionado";
            btn_AsignarRolSeleccionado.Size = new Size(75, 23);
            btn_AsignarRolSeleccionado.TabIndex = 15;
            btn_AsignarRolSeleccionado.Text = "Asignar Rol Selec";
            btn_AsignarRolSeleccionado.UseVisualStyleBackColor = true;
            btn_AsignarRolSeleccionado.Click += btn_AsignarRolSeleccionado_Click;
            // 
            // btn_QuitarRolSeleccionado
            // 
            btn_QuitarRolSeleccionado.Location = new Point(19, 534);
            btn_QuitarRolSeleccionado.Name = "btn_QuitarRolSeleccionado";
            btn_QuitarRolSeleccionado.Size = new Size(77, 23);
            btn_QuitarRolSeleccionado.TabIndex = 16;
            btn_QuitarRolSeleccionado.Text = "Quitar Rol";
            btn_QuitarRolSeleccionado.UseVisualStyleBackColor = true;
            btn_QuitarRolSeleccionado.Click += btn_QuitarRolSeleccionado_Click;
            // 
            // groupBox_Rol
            // 
            groupBox_Rol.Controls.Add(label10);
            groupBox_Rol.Controls.Add(txt_NombreRol);
            groupBox_Rol.Controls.Add(txt_IdRol);
            groupBox_Rol.Controls.Add(label9);
            groupBox_Rol.Location = new Point(253, 12);
            groupBox_Rol.Name = "groupBox_Rol";
            groupBox_Rol.Size = new Size(189, 170);
            groupBox_Rol.TabIndex = 17;
            groupBox_Rol.TabStop = false;
            groupBox_Rol.Text = "Rol Seleccionado";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(22, 77);
            label10.Name = "label10";
            label10.Size = new Size(51, 15);
            label10.TabIndex = 3;
            label10.Text = "Nombre";
            // 
            // txt_NombreRol
            // 
            txt_NombreRol.Enabled = false;
            txt_NombreRol.Location = new Point(96, 71);
            txt_NombreRol.Name = "txt_NombreRol";
            txt_NombreRol.Size = new Size(87, 23);
            txt_NombreRol.TabIndex = 2;
            // 
            // txt_IdRol
            // 
            txt_IdRol.Enabled = false;
            txt_IdRol.Location = new Point(144, 25);
            txt_IdRol.Name = "txt_IdRol";
            txt_IdRol.Size = new Size(39, 23);
            txt_IdRol.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(21, 26);
            label9.Name = "label9";
            label9.Size = new Size(17, 15);
            label9.TabIndex = 0;
            label9.Text = "Id";
            // 
            // groupBox_Permiso
            // 
            groupBox_Permiso.Controls.Add(label12);
            groupBox_Permiso.Controls.Add(label11);
            groupBox_Permiso.Controls.Add(checkBox_EsHoja);
            groupBox_Permiso.Controls.Add(txt_NombrePermiso);
            groupBox_Permiso.Controls.Add(txt_IdPermiso);
            groupBox_Permiso.Location = new Point(478, 12);
            groupBox_Permiso.Name = "groupBox_Permiso";
            groupBox_Permiso.Size = new Size(203, 170);
            groupBox_Permiso.TabIndex = 18;
            groupBox_Permiso.TabStop = false;
            groupBox_Permiso.Text = "Permiso Seleccionado";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(22, 85);
            label12.Name = "label12";
            label12.Size = new Size(51, 15);
            label12.TabIndex = 4;
            label12.Text = "Nombre";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(22, 37);
            label11.Name = "label11";
            label11.Size = new Size(17, 15);
            label11.TabIndex = 3;
            label11.Text = "id";
            // 
            // checkBox_EsHoja
            // 
            checkBox_EsHoja.AutoSize = true;
            checkBox_EsHoja.Enabled = false;
            checkBox_EsHoja.Location = new Point(115, 138);
            checkBox_EsHoja.Name = "checkBox_EsHoja";
            checkBox_EsHoja.Size = new Size(63, 19);
            checkBox_EsHoja.TabIndex = 2;
            checkBox_EsHoja.Text = "Es hoja";
            checkBox_EsHoja.UseVisualStyleBackColor = true;
            // 
            // txt_NombrePermiso
            // 
            txt_NombrePermiso.Enabled = false;
            txt_NombrePermiso.Location = new Point(97, 77);
            txt_NombrePermiso.Name = "txt_NombrePermiso";
            txt_NombrePermiso.Size = new Size(100, 23);
            txt_NombrePermiso.TabIndex = 1;
            // 
            // txt_IdPermiso
            // 
            txt_IdPermiso.Enabled = false;
            txt_IdPermiso.Location = new Point(169, 39);
            txt_IdPermiso.Name = "txt_IdPermiso";
            txt_IdPermiso.Size = new Size(28, 23);
            txt_IdPermiso.TabIndex = 0;
            // 
            // btn_AsignarPermiso
            // 
            btn_AsignarPermiso.Location = new Point(238, 505);
            btn_AsignarPermiso.Name = "btn_AsignarPermiso";
            btn_AsignarPermiso.Size = new Size(112, 23);
            btn_AsignarPermiso.TabIndex = 19;
            btn_AsignarPermiso.Text = "Asignar Permiso";
            btn_AsignarPermiso.UseVisualStyleBackColor = true;
            btn_AsignarPermiso.Click += btn_AsignarPermiso_Click;
            // 
            // btn_QuitarPermiso
            // 
            btn_QuitarPermiso.Location = new Point(238, 534);
            btn_QuitarPermiso.Name = "btn_QuitarPermiso";
            btn_QuitarPermiso.Size = new Size(112, 23);
            btn_QuitarPermiso.TabIndex = 20;
            btn_QuitarPermiso.Text = "Quitar Permiso";
            btn_QuitarPermiso.UseVisualStyleBackColor = true;
            btn_QuitarPermiso.Click += btn_QuitarPermiso_Click;
            // 
            // btn_AltaRol
            // 
            btn_AltaRol.Location = new Point(108, 55);
            btn_AltaRol.Name = "btn_AltaRol";
            btn_AltaRol.Size = new Size(75, 26);
            btn_AltaRol.TabIndex = 21;
            btn_AltaRol.Text = "Alta Rol";
            btn_AltaRol.UseVisualStyleBackColor = true;
            btn_AltaRol.Click += btn_AltaRol_Click;
            // 
            // btn_BajaRol
            // 
            btn_BajaRol.Location = new Point(356, 505);
            btn_BajaRol.Name = "btn_BajaRol";
            btn_BajaRol.Size = new Size(75, 23);
            btn_BajaRol.TabIndex = 22;
            btn_BajaRol.Text = "Baja RoL";
            btn_BajaRol.UseVisualStyleBackColor = true;
            btn_BajaRol.Click += btn_BajaRol_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 23);
            label13.Name = "label13";
            label13.Size = new Size(57, 15);
            label13.TabIndex = 23;
            label13.Text = "Nombre  ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txt_NombreRolAlta);
            groupBox1.Controls.Add(btn_AltaRol);
            groupBox1.Controls.Add(label13);
            groupBox1.Location = new Point(253, 188);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(189, 87);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "Alta Roles";
            // 
            // txt_NombreRolAlta
            // 
            txt_NombreRolAlta.Location = new Point(95, 22);
            txt_NombreRolAlta.Name = "txt_NombreRolAlta";
            txt_NombreRolAlta.Size = new Size(83, 23);
            txt_NombreRolAlta.TabIndex = 24;
            // 
            // FormRolPermiso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1140, 570);
            Controls.Add(groupBox1);
            Controls.Add(btn_BajaRol);
            Controls.Add(btn_QuitarPermiso);
            Controls.Add(btn_AsignarPermiso);
            Controls.Add(groupBox_Permiso);
            Controls.Add(groupBox_Rol);
            Controls.Add(btn_QuitarRolSeleccionado);
            Controls.Add(btn_AsignarRolSeleccionado);
            Controls.Add(groupBox_Usuario);
            Controls.Add(label5);
            Controls.Add(tv_PermisoUsuario);
            Controls.Add(label1);
            Controls.Add(tv_PermisosRol);
            Controls.Add(label4);
            Controls.Add(tv_Permisos);
            Controls.Add(label3);
            Controls.Add(tv_Roles);
            Controls.Add(label2);
            Controls.Add(tv_Usuarios);
            Name = "FormRolPermiso";
            Text = "FormRolPermiso";
            Load += FormRolPermiso_Load;
            groupBox_Usuario.ResumeLayout(false);
            groupBox_Usuario.PerformLayout();
            groupBox_Rol.ResumeLayout(false);
            groupBox_Rol.PerformLayout();
            groupBox_Permiso.ResumeLayout(false);
            groupBox_Permiso.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_Usuarios;
        private Label label;
        private DataGridView dgv_Roles;
        private TreeView tv_Usuarios;
        private Label label2;
        private TreeView tv_Roles;
        private Label label3;
        private TreeView tv_Permisos;
        private Label label4;
        private TreeView tv_PermisosRol;
        private Label label1;
        private TreeView tv_PermisoUsuario;
        private Label label5;
        private GroupBox groupBox_Usuario;
        private CheckBox checkBox_Desencriptar;
        private Label label8;
        private TextBox txt_Password;
        private TextBox txt_Nombre;
        private Label label7;
        private Label label6;
        private TextBox txt_IdUsuario;
        private Button btn_AsignarRolSeleccionado;
        private Button btn_QuitarRolSeleccionado;
        private GroupBox groupBox_Rol;
        private TextBox txt_NombreRol;
        private TextBox txt_IdRol;
        private Label label9;
        private Label label10;
        private GroupBox groupBox_Permiso;
        private Label label12;
        private Label label11;
        private CheckBox checkBox_EsHoja;
        private TextBox txt_NombrePermiso;
        private TextBox txt_IdPermiso;
        private Button btn_AsignarPermiso;
        private Button btn_QuitarPermiso;
        private Button btn_AltaRol;
        private Button btn_BajaRol;
        private Label label13;
        private GroupBox groupBox1;
        private TextBox txt_NombreRolAlta;
    }
}