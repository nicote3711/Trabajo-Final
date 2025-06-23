namespace UI
{
    partial class FormRegistrarSimulador
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
            groupBox1 = new GroupBox();
            btn_RegistrarSimulador = new Button();
            dtv_HoraFin = new DateTimePicker();
            dtp_HoraInicio = new DateTimePicker();
            label6 = new Label();
            label5 = new Label();
            fecha = new Label();
            dtp_Fecha = new DateTimePicker();
            cmBox_Cliente = new ComboBox();
            cmBox_Instructor = new ComboBox();
            label3 = new Label();
            cmBox_Finalidad = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            btn_EliminarSimulador = new Button();
            dgv_Simus = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Simus).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_RegistrarSimulador);
            groupBox1.Controls.Add(dtv_HoraFin);
            groupBox1.Controls.Add(dtp_HoraInicio);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(fecha);
            groupBox1.Controls.Add(dtp_Fecha);
            groupBox1.Controls.Add(cmBox_Cliente);
            groupBox1.Controls.Add(cmBox_Instructor);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cmBox_Finalidad);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(13, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(346, 344);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registrar Simulador";
            // 
            // btn_RegistrarSimulador
            // 
            btn_RegistrarSimulador.Location = new Point(115, 280);
            btn_RegistrarSimulador.Name = "btn_RegistrarSimulador";
            btn_RegistrarSimulador.Size = new Size(121, 23);
            btn_RegistrarSimulador.TabIndex = 24;
            btn_RegistrarSimulador.Text = "Registrar Simulador";
            btn_RegistrarSimulador.UseVisualStyleBackColor = true;
            btn_RegistrarSimulador.Click += btn_RegistrarSimulador_Click;
            // 
            // dtv_HoraFin
            // 
            dtv_HoraFin.Format = DateTimePickerFormat.Custom;
            dtv_HoraFin.Location = new Point(115, 232);
            dtv_HoraFin.Name = "dtv_HoraFin";
            dtv_HoraFin.Size = new Size(121, 23);
            dtv_HoraFin.TabIndex = 15;
            // 
            // dtp_HoraInicio
            // 
            dtp_HoraInicio.Format = DateTimePickerFormat.Custom;
            dtp_HoraInicio.Location = new Point(115, 201);
            dtp_HoraInicio.Name = "dtp_HoraInicio";
            dtp_HoraInicio.Size = new Size(121, 23);
            dtp_HoraInicio.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 238);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 13;
            label6.Text = "Hora Fin";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 205);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 12;
            label5.Text = "Hora Inicio";
            // 
            // fecha
            // 
            fecha.AutoSize = true;
            fecha.Location = new Point(6, 39);
            fecha.Name = "fecha";
            fecha.Size = new Size(36, 15);
            fecha.TabIndex = 9;
            fecha.Text = "fecha";
            // 
            // dtp_Fecha
            // 
            dtp_Fecha.Format = DateTimePickerFormat.Short;
            dtp_Fecha.Location = new Point(115, 39);
            dtp_Fecha.Name = "dtp_Fecha";
            dtp_Fecha.Size = new Size(121, 23);
            dtp_Fecha.TabIndex = 8;
            // 
            // cmBox_Cliente
            // 
            cmBox_Cliente.FormattingEnabled = true;
            cmBox_Cliente.Location = new Point(115, 113);
            cmBox_Cliente.Name = "cmBox_Cliente";
            cmBox_Cliente.Size = new Size(121, 23);
            cmBox_Cliente.TabIndex = 7;
            // 
            // cmBox_Instructor
            // 
            cmBox_Instructor.FormattingEnabled = true;
            cmBox_Instructor.Location = new Point(115, 84);
            cmBox_Instructor.Name = "cmBox_Instructor";
            cmBox_Instructor.Size = new Size(121, 23);
            cmBox_Instructor.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 116);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 6;
            label3.Text = "Cliente";
            // 
            // cmBox_Finalidad
            // 
            cmBox_Finalidad.FormattingEnabled = true;
            cmBox_Finalidad.Location = new Point(115, 158);
            cmBox_Finalidad.Name = "cmBox_Finalidad";
            cmBox_Finalidad.Size = new Size(121, 23);
            cmBox_Finalidad.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 161);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 3;
            label1.Text = "Finalidad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 81);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 4;
            label2.Text = "Instructor";
            // 
            // btn_EliminarSimulador
            // 
            btn_EliminarSimulador.Location = new Point(1166, 450);
            btn_EliminarSimulador.Name = "btn_EliminarSimulador";
            btn_EliminarSimulador.Size = new Size(132, 23);
            btn_EliminarSimulador.TabIndex = 9;
            btn_EliminarSimulador.Text = "Eliminar Simulador";
            btn_EliminarSimulador.UseVisualStyleBackColor = true;
            btn_EliminarSimulador.Click += btn_EliminarSimulador_Click;
            // 
            // dgv_Simus
            // 
            dgv_Simus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Simus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Simus.Location = new Point(377, 12);
            dgv_Simus.MultiSelect = false;
            dgv_Simus.Name = "dgv_Simus";
            dgv_Simus.ReadOnly = true;
            dgv_Simus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Simus.Size = new Size(931, 417);
            dgv_Simus.TabIndex = 8;
            // 
            // FormRegistrarSimulador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1353, 519);
            Controls.Add(groupBox1);
            Controls.Add(btn_EliminarSimulador);
            Controls.Add(dgv_Simus);
            Name = "FormRegistrarSimulador";
            Text = "FormRegistrarSimulador";
            Load += FormRegistrarSimulador_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Simus).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btn_RegistrarSimulador;
        private DateTimePicker dtv_HoraFin;
        private DateTimePicker dtp_HoraInicio;
        private Label label6;
        private Label label5;
        private Label fecha;
        private DateTimePicker dtp_Fecha;
        private ComboBox cmBox_Cliente;
        private ComboBox cmBox_Instructor;
        private Label label3;
        private ComboBox cmBox_Finalidad;
        private Label label1;
        private Label label2;
        private Button btn_EliminarSimulador;
        private DataGridView dgv_Simus;
    }
}