namespace UI
{
    partial class FormAeronaveABM
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
            checkBox_VerNoDisp = new CheckBox();
            btn_BajaAeronave = new Button();
            btn_ModAeronave = new Button();
            dgv_Aeronave = new DataGridView();
            label = new Label();
            label6 = new Label();
            txt_Revision100Hs = new TextBox();
            label5 = new Label();
            txt_Ano = new TextBox();
            label4 = new Label();
            txt_Modelo = new TextBox();
            label3 = new Label();
            txt_Marca = new TextBox();
            label2 = new Label();
            txt_Matricula = new TextBox();
            label1 = new Label();
            btn_AltaAeronave = new Button();
            dtp_RevisionAnual = new DateTimePicker();
            cmbox_Dueno = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgv_Aeronave).BeginInit();
            SuspendLayout();
            // 
            // checkBox_VerNoDisp
            // 
            checkBox_VerNoDisp.AutoSize = true;
            checkBox_VerNoDisp.Location = new Point(1118, 200);
            checkBox_VerNoDisp.Name = "checkBox_VerNoDisp";
            checkBox_VerNoDisp.Size = new Size(125, 19);
            checkBox_VerNoDisp.TabIndex = 88;
            checkBox_VerNoDisp.Text = "Ver No Disponibles";
            checkBox_VerNoDisp.UseVisualStyleBackColor = true;
            checkBox_VerNoDisp.CheckedChanged += checkBox_VerNoDisp_CheckedChanged;
            // 
            // btn_BajaAeronave
            // 
            btn_BajaAeronave.Location = new Point(1037, 197);
            btn_BajaAeronave.Name = "btn_BajaAeronave";
            btn_BajaAeronave.Size = new Size(75, 23);
            btn_BajaAeronave.TabIndex = 87;
            btn_BajaAeronave.Text = "Baja ";
            btn_BajaAeronave.UseVisualStyleBackColor = true;
            btn_BajaAeronave.Click += btn_BajaAeronave_Click;
            // 
            // btn_ModAeronave
            // 
            btn_ModAeronave.Location = new Point(502, 200);
            btn_ModAeronave.Name = "btn_ModAeronave";
            btn_ModAeronave.Size = new Size(122, 23);
            btn_ModAeronave.TabIndex = 86;
            btn_ModAeronave.Text = "Modificar Aeronave";
            btn_ModAeronave.UseVisualStyleBackColor = true;
            btn_ModAeronave.Click += btn_ModAeronave_Click;
            // 
            // dgv_Aeronave
            // 
            dgv_Aeronave.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Aeronave.Location = new Point(502, 32);
            dgv_Aeronave.MultiSelect = false;
            dgv_Aeronave.Name = "dgv_Aeronave";
            dgv_Aeronave.ReadOnly = true;
            dgv_Aeronave.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Aeronave.Size = new Size(741, 157);
            dgv_Aeronave.TabIndex = 85;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(102, 299);
            label.Name = "label";
            label.Size = new Size(42, 15);
            label.TabIndex = 81;
            label.Text = "Dueño";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(102, 250);
            label6.Name = "label6";
            label6.Size = new Size(94, 15);
            label6.TabIndex = 77;
            label6.Text = "Fecha Rev Anual";
            // 
            // txt_Revision100Hs
            // 
            txt_Revision100Hs.Location = new Point(231, 205);
            txt_Revision100Hs.Name = "txt_Revision100Hs";
            txt_Revision100Hs.Size = new Size(140, 23);
            txt_Revision100Hs.TabIndex = 76;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(102, 208);
            label5.Name = "label5";
            label5.Size = new Size(86, 15);
            label5.TabIndex = 75;
            label5.Text = "Revision 100Hs";
            // 
            // txt_Ano
            // 
            txt_Ano.Location = new Point(231, 166);
            txt_Ano.Name = "txt_Ano";
            txt_Ano.Size = new Size(142, 23);
            txt_Ano.TabIndex = 74;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(102, 163);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 73;
            label4.Text = "Año";
            // 
            // txt_Modelo
            // 
            txt_Modelo.Location = new Point(231, 124);
            txt_Modelo.Name = "txt_Modelo";
            txt_Modelo.Size = new Size(140, 23);
            txt_Modelo.TabIndex = 72;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(102, 124);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 71;
            label3.Text = "Modelo";
            // 
            // txt_Marca
            // 
            txt_Marca.Location = new Point(233, 81);
            txt_Marca.Name = "txt_Marca";
            txt_Marca.Size = new Size(138, 23);
            txt_Marca.TabIndex = 70;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 86);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 69;
            label2.Text = "Marca";
            // 
            // txt_Matricula
            // 
            txt_Matricula.Location = new Point(231, 37);
            txt_Matricula.Name = "txt_Matricula";
            txt_Matricula.Size = new Size(140, 23);
            txt_Matricula.TabIndex = 68;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 37);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 67;
            label1.Text = "Matricula";
            // 
            // btn_AltaAeronave
            // 
            btn_AltaAeronave.Location = new Point(231, 350);
            btn_AltaAeronave.Name = "btn_AltaAeronave";
            btn_AltaAeronave.Size = new Size(140, 23);
            btn_AltaAeronave.TabIndex = 66;
            btn_AltaAeronave.Text = "Alta Aeronave";
            btn_AltaAeronave.UseVisualStyleBackColor = true;
            btn_AltaAeronave.Click += btn_AltaAeronave_Click;
            // 
            // dtp_RevisionAnual
            // 
            dtp_RevisionAnual.Format = DateTimePickerFormat.Short;
            dtp_RevisionAnual.Location = new Point(233, 250);
            dtp_RevisionAnual.Name = "dtp_RevisionAnual";
            dtp_RevisionAnual.Size = new Size(138, 23);
            dtp_RevisionAnual.TabIndex = 91;
            // 
            // cmbox_Dueno
            // 
            cmbox_Dueno.FormattingEnabled = true;
            cmbox_Dueno.Location = new Point(233, 296);
            cmbox_Dueno.Name = "cmbox_Dueno";
            cmbox_Dueno.Size = new Size(138, 23);
            cmbox_Dueno.TabIndex = 92;
            // 
            // FormAeronaveABM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1276, 391);
            Controls.Add(cmbox_Dueno);
            Controls.Add(dtp_RevisionAnual);
            Controls.Add(checkBox_VerNoDisp);
            Controls.Add(btn_BajaAeronave);
            Controls.Add(btn_ModAeronave);
            Controls.Add(dgv_Aeronave);
            Controls.Add(label);
            Controls.Add(label6);
            Controls.Add(txt_Revision100Hs);
            Controls.Add(label5);
            Controls.Add(txt_Ano);
            Controls.Add(label4);
            Controls.Add(txt_Modelo);
            Controls.Add(label3);
            Controls.Add(txt_Marca);
            Controls.Add(label2);
            Controls.Add(txt_Matricula);
            Controls.Add(label1);
            Controls.Add(btn_AltaAeronave);
            Name = "FormAeronaveABM";
            Text = "FormAeronavaABM";
            Load += FormAeronaveABM_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Aeronave).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private TextBox txt_DireccionTaller;
        private CheckBox checkBox_VerNoDisp;
        private Button btn_BajaAeronave;
        private Button btn_ModAeronave;
        private DataGridView dgv_Aeronave;
        private TextBox txt_MatriculaTecnica;
        private Label label;
        private TextBox txt_Email;
        private Label label6;
        private TextBox txt_Revision100Hs;
        private Label label5;
        private TextBox txt_Ano;
        private Label label4;
        private TextBox txt_Modelo;
        private Label label3;
        private TextBox txt_Marca;
        private Label label2;
        private TextBox txt_Matricula;
        private Label label1;
        private Button btn_AltaAeronave;
        private DateTimePicker dtp_RevisionAnual;
        private ComboBox cmbox_Dueno;
    }
}