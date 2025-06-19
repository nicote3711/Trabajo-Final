namespace UI
{
    partial class FormRegistrarVuelo
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
            cmBox_Finalidad = new ComboBox();
            dgv_Vuelos = new DataGridView();
            btn_EliminarVuelo = new Button();
            label1 = new Label();
            label2 = new Label();
            cmBox_Instructor = new ComboBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            btn_RegistrarVuelo = new Button();
            txt_HubFinal = new TextBox();
            txt_HubInicial = new TextBox();
            txt_Destino = new TextBox();
            txt_Origen = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            dtv_HoraCorte = new DateTimePicker();
            dtp_HoraPM = new DateTimePicker();
            label6 = new Label();
            label5 = new Label();
            cmBox_Aeronave = new ComboBox();
            label4 = new Label();
            fecha = new Label();
            dtp_Fecha = new DateTimePicker();
            cmBox_Cliente = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgv_Vuelos).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // cmBox_Finalidad
            // 
            cmBox_Finalidad.FormattingEnabled = true;
            cmBox_Finalidad.Location = new Point(115, 253);
            cmBox_Finalidad.Name = "cmBox_Finalidad";
            cmBox_Finalidad.Size = new Size(121, 23);
            cmBox_Finalidad.TabIndex = 0;
            // 
            // dgv_Vuelos
            // 
            dgv_Vuelos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Vuelos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Vuelos.Location = new Point(376, 63);
            dgv_Vuelos.MultiSelect = false;
            dgv_Vuelos.Name = "dgv_Vuelos";
            dgv_Vuelos.ReadOnly = true;
            dgv_Vuelos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Vuelos.Size = new Size(931, 417);
            dgv_Vuelos.TabIndex = 1;
            // 
            // btn_EliminarVuelo
            // 
            btn_EliminarVuelo.Location = new Point(1201, 514);
            btn_EliminarVuelo.Name = "btn_EliminarVuelo";
            btn_EliminarVuelo.Size = new Size(106, 23);
            btn_EliminarVuelo.TabIndex = 2;
            btn_EliminarVuelo.Text = "Eliminar Vuelo";
            btn_EliminarVuelo.UseVisualStyleBackColor = true;
            btn_EliminarVuelo.Click += btn_EliminarVuelo_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 256);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 3;
            label1.Text = "Finalidad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 150);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 4;
            label2.Text = "Instructor";
            // 
            // cmBox_Instructor
            // 
            cmBox_Instructor.FormattingEnabled = true;
            cmBox_Instructor.Location = new Point(115, 153);
            cmBox_Instructor.Name = "cmBox_Instructor";
            cmBox_Instructor.Size = new Size(121, 23);
            cmBox_Instructor.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 185);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 6;
            label3.Text = "Cliente";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_RegistrarVuelo);
            groupBox1.Controls.Add(txt_HubFinal);
            groupBox1.Controls.Add(txt_HubInicial);
            groupBox1.Controls.Add(txt_Destino);
            groupBox1.Controls.Add(txt_Origen);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(dtv_HoraCorte);
            groupBox1.Controls.Add(dtp_HoraPM);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cmBox_Aeronave);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(fecha);
            groupBox1.Controls.Add(dtp_Fecha);
            groupBox1.Controls.Add(cmBox_Cliente);
            groupBox1.Controls.Add(cmBox_Instructor);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cmBox_Finalidad);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(346, 587);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registrar Vuelo";
            // 
            // btn_RegistrarVuelo
            // 
            btn_RegistrarVuelo.Location = new Point(113, 529);
            btn_RegistrarVuelo.Name = "btn_RegistrarVuelo";
            btn_RegistrarVuelo.Size = new Size(136, 23);
            btn_RegistrarVuelo.TabIndex = 24;
            btn_RegistrarVuelo.Text = "Registrar Vuelo";
            btn_RegistrarVuelo.UseVisualStyleBackColor = true;
            btn_RegistrarVuelo.Click += btn_RegistrarVuelo_Click;
            // 
            // txt_HubFinal
            // 
            txt_HubFinal.Location = new Point(115, 477);
            txt_HubFinal.Name = "txt_HubFinal";
            txt_HubFinal.Size = new Size(121, 23);
            txt_HubFinal.TabIndex = 23;
            // 
            // txt_HubInicial
            // 
            txt_HubInicial.Location = new Point(115, 445);
            txt_HubInicial.Name = "txt_HubInicial";
            txt_HubInicial.Size = new Size(121, 23);
            txt_HubInicial.TabIndex = 22;
            // 
            // txt_Destino
            // 
            txt_Destino.Location = new Point(115, 408);
            txt_Destino.Name = "txt_Destino";
            txt_Destino.Size = new Size(121, 23);
            txt_Destino.TabIndex = 21;
            // 
            // txt_Origen
            // 
            txt_Origen.Location = new Point(115, 371);
            txt_Origen.Name = "txt_Origen";
            txt_Origen.Size = new Size(121, 23);
            txt_Origen.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 480);
            label10.Name = "label10";
            label10.Size = new Size(58, 15);
            label10.TabIndex = 19;
            label10.Text = "Hub Final";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 445);
            label9.Name = "label9";
            label9.Size = new Size(64, 15);
            label9.TabIndex = 18;
            label9.Text = "Hub Inicial";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 416);
            label8.Name = "label8";
            label8.Size = new Size(47, 15);
            label8.TabIndex = 17;
            label8.Text = "Destino";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 374);
            label7.Name = "label7";
            label7.Size = new Size(43, 15);
            label7.TabIndex = 16;
            label7.Text = "Origen";
            // 
            // dtv_HoraCorte
            // 
            dtv_HoraCorte.Format = DateTimePickerFormat.Custom;
            dtv_HoraCorte.Location = new Point(115, 327);
            dtv_HoraCorte.Name = "dtv_HoraCorte";
            dtv_HoraCorte.Size = new Size(121, 23);
            dtv_HoraCorte.TabIndex = 15;
            // 
            // dtp_HoraPM
            // 
            dtp_HoraPM.Format = DateTimePickerFormat.Custom;
            dtp_HoraPM.Location = new Point(115, 296);
            dtp_HoraPM.Name = "dtp_HoraPM";
            dtp_HoraPM.Size = new Size(121, 23);
            dtp_HoraPM.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 333);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 13;
            label6.Text = "Hora Corte";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 300);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 12;
            label5.Text = "Hora PM";
            // 
            // cmBox_Aeronave
            // 
            cmBox_Aeronave.FormattingEnabled = true;
            cmBox_Aeronave.Location = new Point(115, 213);
            cmBox_Aeronave.Name = "cmBox_Aeronave";
            cmBox_Aeronave.Size = new Size(121, 23);
            cmBox_Aeronave.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 221);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 10;
            label4.Text = "Aeronave";
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
            cmBox_Cliente.Location = new Point(115, 182);
            cmBox_Cliente.Name = "cmBox_Cliente";
            cmBox_Cliente.Size = new Size(121, 23);
            cmBox_Cliente.TabIndex = 7;
            // 
            // FormRegistrarVuelo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1348, 611);
            Controls.Add(groupBox1);
            Controls.Add(btn_EliminarVuelo);
            Controls.Add(dgv_Vuelos);
            Name = "FormRegistrarVuelo";
            Text = "FormRegistrarVuelo";
            Load += FormRegistrarVuelo_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Vuelos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmBox_Finalidad;
        private DataGridView dgv_Vuelos;
        private Button btn_EliminarVuelo;
        private Label label1;
        private Label label2;
        private ComboBox cmBox_Instructor;
        private Label label3;
        private GroupBox groupBox1;
        private ComboBox cmBox_Cliente;
        private Label fecha;
        private DateTimePicker dtp_Fecha;
        private Label label6;
        private Label label5;
        private ComboBox cmBox_Aeronave;
        private Label label4;
        private DateTimePicker dtp_HoraPM;
        private DateTimePicker dtv_HoraCorte;
        private TextBox txt_HubFinal;
        private TextBox txt_HubInicial;
        private TextBox txt_Destino;
        private TextBox txt_Origen;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Button btn_RegistrarVuelo;
    }
}