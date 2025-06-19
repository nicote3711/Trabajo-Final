namespace UI
{
    partial class FormAeronaveMod
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
            cmbox_Dueno = new ComboBox();
            dtp_RevisionAnual = new DateTimePicker();
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
            btn_Modificar = new Button();
            label7 = new Label();
            txt_IdAeronave = new TextBox();
            cmbox_Estado = new ComboBox();
            Estado = new Label();
            SuspendLayout();
            // 
            // cmbox_Dueno
            // 
            cmbox_Dueno.FormattingEnabled = true;
            cmbox_Dueno.Location = new Point(144, 317);
            cmbox_Dueno.Name = "cmbox_Dueno";
            cmbox_Dueno.Size = new Size(138, 23);
            cmbox_Dueno.TabIndex = 106;
            // 
            // dtp_RevisionAnual
            // 
            dtp_RevisionAnual.Format = DateTimePickerFormat.Short;
            dtp_RevisionAnual.Location = new Point(144, 271);
            dtp_RevisionAnual.Name = "dtp_RevisionAnual";
            dtp_RevisionAnual.Size = new Size(138, 23);
            dtp_RevisionAnual.TabIndex = 105;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(13, 320);
            label.Name = "label";
            label.Size = new Size(42, 15);
            label.TabIndex = 104;
            label.Text = "Dueño";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 271);
            label6.Name = "label6";
            label6.Size = new Size(94, 15);
            label6.TabIndex = 103;
            label6.Text = "Fecha Rev Anual";
            // 
            // txt_Revision100Hs
            // 
            txt_Revision100Hs.Location = new Point(142, 226);
            txt_Revision100Hs.Name = "txt_Revision100Hs";
            txt_Revision100Hs.Size = new Size(140, 23);
            txt_Revision100Hs.TabIndex = 102;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 229);
            label5.Name = "label5";
            label5.Size = new Size(86, 15);
            label5.TabIndex = 101;
            label5.Text = "Revision 100Hs";
            // 
            // txt_Ano
            // 
            txt_Ano.Location = new Point(142, 187);
            txt_Ano.Name = "txt_Ano";
            txt_Ano.Size = new Size(142, 23);
            txt_Ano.TabIndex = 100;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 184);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 99;
            label4.Text = "Año";
            // 
            // txt_Modelo
            // 
            txt_Modelo.Location = new Point(142, 145);
            txt_Modelo.Name = "txt_Modelo";
            txt_Modelo.Size = new Size(140, 23);
            txt_Modelo.TabIndex = 98;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 145);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 97;
            label3.Text = "Modelo";
            // 
            // txt_Marca
            // 
            txt_Marca.Location = new Point(144, 102);
            txt_Marca.Name = "txt_Marca";
            txt_Marca.Size = new Size(138, 23);
            txt_Marca.TabIndex = 96;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 107);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 95;
            label2.Text = "Marca";
            // 
            // txt_Matricula
            // 
            txt_Matricula.Location = new Point(142, 58);
            txt_Matricula.Name = "txt_Matricula";
            txt_Matricula.Size = new Size(140, 23);
            txt_Matricula.TabIndex = 94;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 58);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 93;
            label1.Text = "Matricula";
            // 
            // btn_Modificar
            // 
            btn_Modificar.Location = new Point(144, 415);
            btn_Modificar.Name = "btn_Modificar";
            btn_Modificar.Size = new Size(138, 23);
            btn_Modificar.TabIndex = 107;
            btn_Modificar.Text = "Modificar";
            btn_Modificar.UseVisualStyleBackColor = true;
            btn_Modificar.Click += btn_Modificar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 20);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 108;
            label7.Text = "Id_Aeronave";
            // 
            // txt_IdAeronave
            // 
            txt_IdAeronave.Location = new Point(144, 14);
            txt_IdAeronave.Name = "txt_IdAeronave";
            txt_IdAeronave.Size = new Size(138, 23);
            txt_IdAeronave.TabIndex = 109;
            // 
            // cmbox_Estado
            // 
            cmbox_Estado.FormattingEnabled = true;
            cmbox_Estado.Location = new Point(144, 353);
            cmbox_Estado.Name = "cmbox_Estado";
            cmbox_Estado.Size = new Size(138, 23);
            cmbox_Estado.TabIndex = 111;
            // 
            // Estado
            // 
            Estado.AutoSize = true;
            Estado.Location = new Point(13, 356);
            Estado.Name = "Estado";
            Estado.Size = new Size(42, 15);
            Estado.TabIndex = 110;
            Estado.Text = "Estado";
            // 
            // FormAeronaveMod
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 460);
            Controls.Add(cmbox_Estado);
            Controls.Add(Estado);
            Controls.Add(txt_IdAeronave);
            Controls.Add(label7);
            Controls.Add(btn_Modificar);
            Controls.Add(cmbox_Dueno);
            Controls.Add(dtp_RevisionAnual);
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
            Name = "FormAeronaveMod";
            Text = "FormAeronaveMod";
            Load += FormAeronaveMod_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbox_Dueno;
        private DateTimePicker dtp_RevisionAnual;
        private Label label;
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
        private Button btn_Modificar;
        private Label label7;
        private TextBox txt_IdAeronave;
        private ComboBox cmbox_Estado;
        private Label Estado;
    }
}