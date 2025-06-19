namespace UI
{
    partial class FormMecanicosABM
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
            txt_MatriculaTecnica = new TextBox();
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
            btn_AltaMecanico = new Button();
            checkedListBox_Alta = new CheckedListBox();
            label8 = new Label();
            btn_BajaMecanico = new Button();
            btn_ModMecanico = new Button();
            dgv_MecanicosABM = new DataGridView();
            checkBox_VerInactivos = new CheckBox();
            txt_DireccionTaller = new TextBox();
            label9 = new Label();
            checkedListBox_Mostrar = new CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)dgv_MecanicosABM).BeginInit();
            SuspendLayout();
            // 
            // txt_MatriculaTecnica
            // 
            txt_MatriculaTecnica.Location = new Point(149, 314);
            txt_MatriculaTecnica.Name = "txt_MatriculaTecnica";
            txt_MatriculaTecnica.Size = new Size(140, 23);
            txt_MatriculaTecnica.TabIndex = 56;
            // 
            // Licencia
            // 
            Licencia.AutoSize = true;
            Licencia.Location = new Point(18, 319);
            Licencia.Name = "Licencia";
            Licencia.Size = new Size(100, 15);
            Licencia.TabIndex = 55;
            Licencia.Text = "Matricula Tecnica";
            // 
            // txt_FechaNac
            // 
            txt_FechaNac.Location = new Point(147, 184);
            txt_FechaNac.Name = "txt_FechaNac";
            txt_FechaNac.Size = new Size(140, 23);
            txt_FechaNac.TabIndex = 54;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 189);
            label7.Name = "label7";
            label7.Size = new Size(103, 15);
            label7.TabIndex = 53;
            label7.Text = "Fecha Nacimiento";
            // 
            // txt_Email
            // 
            txt_Email.Location = new Point(147, 270);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(140, 23);
            txt_Email.TabIndex = 52;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 270);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 51;
            label6.Text = "Email";
            // 
            // txt_Telefono
            // 
            txt_Telefono.Location = new Point(147, 225);
            txt_Telefono.Name = "txt_Telefono";
            txt_Telefono.Size = new Size(140, 23);
            txt_Telefono.TabIndex = 50;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 222);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 49;
            label5.Text = "Telefono";
            // 
            // txt_Apellido
            // 
            txt_Apellido.Location = new Point(147, 149);
            txt_Apellido.Name = "txt_Apellido";
            txt_Apellido.Size = new Size(142, 23);
            txt_Apellido.TabIndex = 48;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 146);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 47;
            label4.Text = "Apellido";
            // 
            // txt_Nombre
            // 
            txt_Nombre.Location = new Point(147, 107);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new Size(140, 23);
            txt_Nombre.TabIndex = 46;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 107);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 45;
            label3.Text = "Nombre";
            // 
            // txt_Cuil
            // 
            txt_Cuil.Location = new Point(149, 64);
            txt_Cuil.Name = "txt_Cuil";
            txt_Cuil.Size = new Size(138, 23);
            txt_Cuil.TabIndex = 44;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 69);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 43;
            label2.Text = "CUIT/CUIL";
            // 
            // txt_Dni
            // 
            txt_Dni.Location = new Point(147, 20);
            txt_Dni.Name = "txt_Dni";
            txt_Dni.Size = new Size(140, 23);
            txt_Dni.TabIndex = 42;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 20);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 41;
            label1.Text = "DNI";
            // 
            // btn_AltaMecanico
            // 
            btn_AltaMecanico.Location = new Point(147, 535);
            btn_AltaMecanico.Name = "btn_AltaMecanico";
            btn_AltaMecanico.Size = new Size(140, 23);
            btn_AltaMecanico.TabIndex = 40;
            btn_AltaMecanico.Text = "Alta Mecanico";
            btn_AltaMecanico.UseVisualStyleBackColor = true;
            btn_AltaMecanico.Click += btn_AltaMecanico_Click;
            // 
            // checkedListBox_Alta
            // 
            checkedListBox_Alta.FormattingEnabled = true;
            checkedListBox_Alta.Location = new Point(145, 406);
            checkedListBox_Alta.Name = "checkedListBox_Alta";
            checkedListBox_Alta.Size = new Size(142, 94);
            checkedListBox_Alta.TabIndex = 57;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 415);
            label8.Name = "label8";
            label8.Size = new Size(121, 15);
            label8.TabIndex = 58;
            label8.Text = "Tipos Mantenimiento";
            // 
            // btn_BajaMecanico
            // 
            btn_BajaMecanico.Location = new Point(558, 229);
            btn_BajaMecanico.Name = "btn_BajaMecanico";
            btn_BajaMecanico.Size = new Size(75, 23);
            btn_BajaMecanico.TabIndex = 61;
            btn_BajaMecanico.Text = "Baja ";
            btn_BajaMecanico.UseVisualStyleBackColor = true;
            btn_BajaMecanico.Click += btn_BajaMecanico_Click;
            // 
            // btn_ModMecanico
            // 
            btn_ModMecanico.Location = new Point(418, 229);
            btn_ModMecanico.Name = "btn_ModMecanico";
            btn_ModMecanico.Size = new Size(122, 23);
            btn_ModMecanico.TabIndex = 60;
            btn_ModMecanico.Text = "Modificar Instructor";
            btn_ModMecanico.UseVisualStyleBackColor = true;
            btn_ModMecanico.Click += btn_ModMecanico_Click;
            // 
            // dgv_MecanicosABM
            // 
            dgv_MecanicosABM.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_MecanicosABM.Location = new Point(418, 66);
            dgv_MecanicosABM.MultiSelect = false;
            dgv_MecanicosABM.Name = "dgv_MecanicosABM";
            dgv_MecanicosABM.ReadOnly = true;
            dgv_MecanicosABM.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_MecanicosABM.Size = new Size(517, 157);
            dgv_MecanicosABM.TabIndex = 59;
            dgv_MecanicosABM.SelectionChanged += dgv_MecanicosABM_SelectionChanged;
            // 
            // checkBox_VerInactivos
            // 
            checkBox_VerInactivos.AutoSize = true;
            checkBox_VerInactivos.Location = new Point(844, 233);
            checkBox_VerInactivos.Name = "checkBox_VerInactivos";
            checkBox_VerInactivos.Size = new Size(92, 19);
            checkBox_VerInactivos.TabIndex = 62;
            checkBox_VerInactivos.Text = "Ver Inactivos";
            checkBox_VerInactivos.UseVisualStyleBackColor = true;
            checkBox_VerInactivos.CheckedChanged += checkBox_VerInactivos_CheckedChanged;
            // 
            // txt_DireccionTaller
            // 
            txt_DireccionTaller.Location = new Point(147, 358);
            txt_DireccionTaller.Name = "txt_DireccionTaller";
            txt_DireccionTaller.Size = new Size(142, 23);
            txt_DireccionTaller.TabIndex = 63;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(18, 363);
            label9.Name = "label9";
            label9.Size = new Size(88, 15);
            label9.TabIndex = 64;
            label9.Text = "Direccion Taller";
            // 
            // checkedListBox_Mostrar
            // 
            checkedListBox_Mostrar.FormattingEnabled = true;
            checkedListBox_Mostrar.Location = new Point(815, 284);
            checkedListBox_Mostrar.Name = "checkedListBox_Mostrar";
            checkedListBox_Mostrar.Size = new Size(120, 94);
            checkedListBox_Mostrar.TabIndex = 65;
            // 
            // FormMecanicosABM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 580);
            Controls.Add(checkedListBox_Mostrar);
            Controls.Add(label9);
            Controls.Add(txt_DireccionTaller);
            Controls.Add(checkBox_VerInactivos);
            Controls.Add(btn_BajaMecanico);
            Controls.Add(btn_ModMecanico);
            Controls.Add(dgv_MecanicosABM);
            Controls.Add(label8);
            Controls.Add(checkedListBox_Alta);
            Controls.Add(txt_MatriculaTecnica);
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
            Controls.Add(btn_AltaMecanico);
            Name = "FormMecanicosABM";
            Text = "FormMecanicosABM";
            Load += FormMecanicosABM_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_MecanicosABM).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_MatriculaTecnica;
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
        private Button btn_AltaMecanico;
        private CheckedListBox checkedListBox_Alta;
        private Label label8;
        private Button btn_BajaMecanico;
        private Button btn_ModMecanico;
        private DataGridView dgv_MecanicosABM;
        private CheckBox checkBox_VerInactivos;
        private TextBox txt_DireccionTaller;
        private Label label9;
        private CheckedListBox checkedListBox_Mostrar;
    }
}