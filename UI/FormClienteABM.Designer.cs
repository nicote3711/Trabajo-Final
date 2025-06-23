namespace UI
{
    partial class FormClienteABM
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
            dgvClientesAMB = new DataGridView();
            btn_AltaCliente = new Button();
            btn_ModCliente = new Button();
            btn_BajaCli = new Button();
            label1 = new Label();
            txtDni = new TextBox();
            txtCuil = new TextBox();
            label2 = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            txtApellido = new TextBox();
            label4 = new Label();
            txtTelefono = new TextBox();
            label5 = new Label();
            txtEmail = new TextBox();
            label6 = new Label();
            label7 = new Label();
            txtLicencia = new TextBox();
            Licencia = new Label();
            dtp_FechaNacimiento = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvClientesAMB).BeginInit();
            SuspendLayout();
            // 
            // dgvClientesAMB
            // 
            dgvClientesAMB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientesAMB.Location = new Point(376, 88);
            dgvClientesAMB.Name = "dgvClientesAMB";
            dgvClientesAMB.Size = new Size(412, 157);
            dgvClientesAMB.TabIndex = 0;
            // 
            // btn_AltaCliente
            // 
            btn_AltaCliente.Location = new Point(105, 405);
            btn_AltaCliente.Name = "btn_AltaCliente";
            btn_AltaCliente.Size = new Size(151, 23);
            btn_AltaCliente.TabIndex = 1;
            btn_AltaCliente.Text = "Alta Cliente";
            btn_AltaCliente.UseVisualStyleBackColor = true;
            btn_AltaCliente.Click += btn_AltaCliente_Click;
            // 
            // btn_ModCliente
            // 
            btn_ModCliente.Location = new Point(376, 251);
            btn_ModCliente.Name = "btn_ModCliente";
            btn_ModCliente.Size = new Size(122, 23);
            btn_ModCliente.TabIndex = 2;
            btn_ModCliente.Text = "Modificar Cliente";
            btn_ModCliente.UseVisualStyleBackColor = true;
            btn_ModCliente.Click += btn_ModCliente_Click;
            // 
            // btn_BajaCli
            // 
            btn_BajaCli.Location = new Point(516, 251);
            btn_BajaCli.Name = "btn_BajaCli";
            btn_BajaCli.Size = new Size(75, 23);
            btn_BajaCli.TabIndex = 3;
            btn_BajaCli.Text = "Baja ";
            btn_BajaCli.UseVisualStyleBackColor = true;
            btn_BajaCli.Click += btn_BajaCli_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 36);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 4;
            label1.Text = "DNI";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(131, 33);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(125, 23);
            txtDni.TabIndex = 5;
            // 
            // txtCuil
            // 
            txtCuil.Location = new Point(131, 77);
            txtCuil.Name = "txtCuil";
            txtCuil.Size = new Size(125, 23);
            txtCuil.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 85);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 6;
            label2.Text = "CUIT/CUIL";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(131, 120);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 23);
            txtNombre.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 123);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 8;
            label3.Text = "Nombre";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(131, 162);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(125, 23);
            txtApellido.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 162);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 10;
            label4.Text = "Apellido";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(131, 238);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(125, 23);
            txtTelefono.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 238);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 12;
            label5.Text = "Telefono";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(131, 283);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 23);
            txtEmail.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 286);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 14;
            label6.Text = "Email";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 205);
            label7.Name = "label7";
            label7.Size = new Size(103, 15);
            label7.TabIndex = 16;
            label7.Text = "Fecha Nacimiento";
            // 
            // txtLicencia
            // 
            txtLicencia.Location = new Point(133, 327);
            txtLicencia.Name = "txtLicencia";
            txtLicencia.Size = new Size(125, 23);
            txtLicencia.TabIndex = 19;
            // 
            // Licencia
            // 
            Licencia.AutoSize = true;
            Licencia.Location = new Point(23, 335);
            Licencia.Name = "Licencia";
            Licencia.Size = new Size(50, 15);
            Licencia.TabIndex = 18;
            Licencia.Text = "Licencia";
            // 
            // dtp_FechaNacimiento
            // 
            dtp_FechaNacimiento.Format = DateTimePickerFormat.Short;
            dtp_FechaNacimiento.Location = new Point(131, 199);
            dtp_FechaNacimiento.Name = "dtp_FechaNacimiento";
            dtp_FechaNacimiento.Size = new Size(125, 23);
            dtp_FechaNacimiento.TabIndex = 20;
            // 
            // FormClienteABM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtp_FechaNacimiento);
            Controls.Add(txtLicencia);
            Controls.Add(Licencia);
            Controls.Add(label7);
            Controls.Add(txtEmail);
            Controls.Add(label6);
            Controls.Add(txtTelefono);
            Controls.Add(label5);
            Controls.Add(txtApellido);
            Controls.Add(label4);
            Controls.Add(txtNombre);
            Controls.Add(label3);
            Controls.Add(txtCuil);
            Controls.Add(label2);
            Controls.Add(txtDni);
            Controls.Add(label1);
            Controls.Add(btn_BajaCli);
            Controls.Add(btn_ModCliente);
            Controls.Add(btn_AltaCliente);
            Controls.Add(dgvClientesAMB);
            Name = "FormClienteABM";
            Text = "FormAMBCliente";
            Load += FormAMBCliente_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientesAMB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClientesAMB;
        private Button btn_AltaCliente;
        private Button btn_ModCliente;
        private Button btn_BajaCli;
        private Label label1;
        private TextBox txtDni;
        private TextBox txtCuil;
        private Label label2;
        private TextBox txtNombre;
        private Label label3;
        private TextBox txtApellido;
        private Label label4;
        private TextBox txtTelefono;
        private Label label5;
        private TextBox txtEmail;
        private Label label6;
        private Label label7;
        private TextBox txtLicencia;
        private Label Licencia;
        private DateTimePicker dtp_FechaNacimiento;
    }
}