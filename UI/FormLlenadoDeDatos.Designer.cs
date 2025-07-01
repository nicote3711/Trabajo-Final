namespace UI
{
    partial class FormLlenadoDeDatos
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
            btnGenerarVuelos = new Button();
            btnGenerarLiquidaciones = new Button();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            button2 = new Button();
            label5 = new Label();
            button3 = new Button();
            button4 = new Button();
            label6 = new Label();
            label7 = new Label();
            button5 = new Button();
            label9 = new Label();
            button7 = new Button();
            label10 = new Label();
            button8 = new Button();
            label11 = new Label();
            button9 = new Button();
            label12 = new Label();
            button10 = new Button();
            label13 = new Label();
            button11 = new Button();
            label8 = new Label();
            button6 = new Button();
            SuspendLayout();
            // 
            // btnGenerarVuelos
            // 
            btnGenerarVuelos.BackColor = Color.SteelBlue;
            btnGenerarVuelos.FlatAppearance.BorderColor = Color.SteelBlue;
            btnGenerarVuelos.FlatStyle = FlatStyle.Flat;
            btnGenerarVuelos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerarVuelos.ForeColor = Color.White;
            btnGenerarVuelos.Location = new Point(63, 170);
            btnGenerarVuelos.Name = "btnGenerarVuelos";
            btnGenerarVuelos.Size = new Size(213, 48);
            btnGenerarVuelos.TabIndex = 0;
            btnGenerarVuelos.Text = "Generar Vuelos";
            btnGenerarVuelos.UseVisualStyleBackColor = false;
            btnGenerarVuelos.Click += GenerarVuelos_Click;
            // 
            // btnGenerarLiquidaciones
            // 
            btnGenerarLiquidaciones.BackColor = Color.SandyBrown;
            btnGenerarLiquidaciones.FlatAppearance.BorderColor = Color.SandyBrown;
            btnGenerarLiquidaciones.FlatStyle = FlatStyle.Flat;
            btnGenerarLiquidaciones.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerarLiquidaciones.ForeColor = Color.White;
            btnGenerarLiquidaciones.Location = new Point(63, 311);
            btnGenerarLiquidaciones.Name = "btnGenerarLiquidaciones";
            btnGenerarLiquidaciones.Size = new Size(213, 48);
            btnGenerarLiquidaciones.TabIndex = 1;
            btnGenerarLiquidaciones.Text = "Generar Liquidaciones";
            btnGenerarLiquidaciones.UseVisualStyleBackColor = false;
            btnGenerarLiquidaciones.Click += GenerarLiquidaciones_Click;
            // 
            // label1
            // 
            label1.Location = new Point(63, 243);
            label1.Name = "label1";
            label1.Size = new Size(213, 41);
            label1.TabIndex = 2;
            label1.Text = "Generara vuelos por mes desde un año atras hata el mes en curso";
            // 
            // label2
            // 
            label2.Location = new Point(63, 384);
            label2.Name = "label2";
            label2.Size = new Size(213, 53);
            label2.TabIndex = 3;
            label2.Text = "Generar las liquidaciones de todos los vuelos que no correspondan al mes en curso. Esas deberan generarse desde la opcion Generar Liquidaciones en menu Liquidaciones";
            // 
            // button1
            // 
            button1.BackColor = Color.DarkSeaGreen;
            button1.FlatAppearance.BorderColor = Color.DarkSeaGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(343, 311);
            button1.Name = "button1";
            button1.Size = new Size(213, 48);
            button1.TabIndex = 4;
            button1.Text = "Generar Cobros por Factura";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // label3
            // 
            label3.Location = new Point(343, 384);
            label3.Name = "label3";
            label3.Size = new Size(213, 53);
            label3.TabIndex = 5;
            label3.Text = "Generara cobros random para todas las liquidaciones menos las del mes en curso";
            // 
            // label4
            // 
            label4.Location = new Point(1108, 99);
            label4.Name = "label4";
            label4.Size = new Size(213, 41);
            label4.TabIndex = 7;
            label4.Text = "Generara mantenimientos de todos los vuelos incluyendo los del mes en curso";
            // 
            // button2
            // 
            button2.BackColor = Color.DarkOrchid;
            button2.FlatAppearance.BorderColor = Color.DarkOrchid;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(1108, 26);
            button2.Name = "button2";
            button2.Size = new Size(213, 48);
            button2.TabIndex = 6;
            button2.Text = "Generar Aeronaves";
            button2.UseVisualStyleBackColor = false;
            button2.Click += GenerarAeronaves_Click;
            // 
            // label5
            // 
            label5.Location = new Point(343, 243);
            label5.Name = "label5";
            label5.Size = new Size(213, 41);
            label5.TabIndex = 9;
            label5.Text = "Generara simulaciones por mes desde un año atras hata el mes en curso";
            // 
            // button3
            // 
            button3.BackColor = Color.SteelBlue;
            button3.FlatAppearance.BorderColor = Color.SteelBlue;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(343, 170);
            button3.Name = "button3";
            button3.Size = new Size(213, 48);
            button3.TabIndex = 8;
            button3.Text = "Generar Simulaciones";
            button3.UseVisualStyleBackColor = false;
            button3.Click += GenerarSimulaciones_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.SandyBrown;
            button4.FlatAppearance.BorderColor = Color.SandyBrown;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Location = new Point(861, 170);
            button4.Name = "button4";
            button4.Size = new Size(213, 48);
            button4.TabIndex = 10;
            button4.Text = "Generar Solicitudes";
            button4.UseVisualStyleBackColor = false;
            button4.Click += GenerarSolicitudes_Click;
            // 
            // label6
            // 
            label6.Location = new Point(861, 243);
            label6.Name = "label6";
            label6.Size = new Size(213, 41);
            label6.TabIndex = 11;
            label6.Text = "Generara solicitudes por mes desde un año atras hata el mes en curso";
            // 
            // label7
            // 
            label7.Location = new Point(623, 384);
            label7.Name = "label7";
            label7.Size = new Size(213, 53);
            label7.TabIndex = 13;
            label7.Text = "Generara Pagos random para todas las liquidaciones menos las del mes en curso";
            // 
            // button5
            // 
            button5.BackColor = Color.DarkSeaGreen;
            button5.FlatAppearance.BorderColor = Color.DarkSeaGreen;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button5.ForeColor = Color.White;
            button5.Location = new Point(623, 311);
            button5.Name = "button5";
            button5.Size = new Size(213, 48);
            button5.TabIndex = 12;
            button5.Text = "Generar Pagos por Factura";
            button5.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.Location = new Point(602, 99);
            label9.Name = "label9";
            label9.Size = new Size(213, 41);
            label9.TabIndex = 17;
            label9.Text = "Generara mantenimientos de todos los vuelos incluyendo los del mes en curso";
            // 
            // button7
            // 
            button7.BackColor = Color.DarkOrchid;
            button7.FlatAppearance.BorderColor = Color.DarkOrchid;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button7.ForeColor = Color.White;
            button7.Location = new Point(602, 26);
            button7.Name = "button7";
            button7.Size = new Size(213, 48);
            button7.TabIndex = 16;
            button7.Text = "Generar Clientes";
            button7.UseVisualStyleBackColor = false;
            button7.Click += btnGenerarClientes_Click;
            // 
            // label10
            // 
            label10.Location = new Point(343, 99);
            label10.Name = "label10";
            label10.Size = new Size(213, 41);
            label10.TabIndex = 19;
            label10.Text = "Generara mantenimientos de todos los vuelos incluyendo los del mes en curso";
            // 
            // button8
            // 
            button8.BackColor = Color.DarkOrchid;
            button8.FlatAppearance.BorderColor = Color.DarkOrchid;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button8.ForeColor = Color.White;
            button8.Location = new Point(343, 26);
            button8.Name = "button8";
            button8.Size = new Size(213, 48);
            button8.TabIndex = 18;
            button8.Text = "Generar Instructores";
            button8.UseVisualStyleBackColor = false;
            button8.Click += GenerarInstructores_Click;
            // 
            // label11
            // 
            label11.Location = new Point(63, 99);
            label11.Name = "label11";
            label11.Size = new Size(213, 38);
            label11.TabIndex = 21;
            label11.Text = "Generara mantenimientos de todos los vuelos incluyendo los del mes en curso";
            label11.Click += label11_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.DarkOrchid;
            button9.FlatAppearance.BorderColor = Color.DarkOrchid;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button9.ForeColor = Color.White;
            button9.Location = new Point(63, 26);
            button9.Name = "button9";
            button9.Size = new Size(213, 45);
            button9.TabIndex = 20;
            button9.Text = "Generar Dueños";
            button9.UseVisualStyleBackColor = false;
            button9.Click += GenerarDueños_Click;
            // 
            // label12
            // 
            label12.Location = new Point(861, 99);
            label12.Name = "label12";
            label12.Size = new Size(213, 41);
            label12.TabIndex = 23;
            label12.Text = "Generara mantenimientos de todos los vuelos incluyendo los del mes en curso";
            // 
            // button10
            // 
            button10.BackColor = Color.DarkOrchid;
            button10.FlatAppearance.BorderColor = Color.DarkOrchid;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button10.ForeColor = Color.White;
            button10.Location = new Point(861, 26);
            button10.Name = "button10";
            button10.Size = new Size(213, 48);
            button10.TabIndex = 22;
            button10.Text = "Generar Mecanicos";
            button10.UseVisualStyleBackColor = false;
            button10.Click += GenerarMecanicos_Click;
            // 
            // label13
            // 
            label13.Location = new Point(602, 243);
            label13.Name = "label13";
            label13.Size = new Size(213, 41);
            label13.TabIndex = 25;
            label13.Text = "Generara simulaciones por mes desde un año atras hata el mes en curso";
            // 
            // button11
            // 
            button11.BackColor = Color.SteelBlue;
            button11.FlatAppearance.BorderColor = Color.SteelBlue;
            button11.FlatStyle = FlatStyle.Flat;
            button11.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button11.ForeColor = Color.White;
            button11.Location = new Point(602, 170);
            button11.Name = "button11";
            button11.Size = new Size(213, 48);
            button11.TabIndex = 24;
            button11.Text = "Generar Recargas Combustibles";
            button11.UseVisualStyleBackColor = false;
            button11.Click += GenerarRecargasCombustible_Click;
            // 
            // label8
            // 
            label8.Location = new Point(1108, 243);
            label8.Name = "label8";
            label8.Size = new Size(213, 41);
            label8.TabIndex = 27;
            label8.Text = "Genera facturas de mantenimiento y le cambia el estado a finalizado liberando las aeronaves.";
            // 
            // button6
            // 
            button6.BackColor = Color.SandyBrown;
            button6.FlatAppearance.BorderColor = Color.SandyBrown;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button6.ForeColor = Color.White;
            button6.Location = new Point(1108, 170);
            button6.Name = "button6";
            button6.Size = new Size(213, 48);
            button6.TabIndex = 26;
            button6.Text = "Registrar Facturas Mantenimientos";
            button6.UseVisualStyleBackColor = false;
            button6.Click += RegistrarFacturasMantenimientos_Click;
            // 
            // FormLlenadoDeDatos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1385, 641);
            Controls.Add(label8);
            Controls.Add(button6);
            Controls.Add(label13);
            Controls.Add(button11);
            Controls.Add(label12);
            Controls.Add(button10);
            Controls.Add(label11);
            Controls.Add(button9);
            Controls.Add(label10);
            Controls.Add(button8);
            Controls.Add(label9);
            Controls.Add(button7);
            Controls.Add(label7);
            Controls.Add(button5);
            Controls.Add(label6);
            Controls.Add(button4);
            Controls.Add(label5);
            Controls.Add(button3);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGenerarLiquidaciones);
            Controls.Add(btnGenerarVuelos);
            Name = "FormLlenadoDeDatos";
            Text = "FormLlenadoDeDatos";
            Load += FormLlenadoDeDatos_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnGenerarVuelos;
        private Button btnGenerarLiquidaciones;
        private Label label1;
        private Label label2;
        private Button button1;
        private Label label3;
        private Label label4;
        private Button button2;
        private Label label5;
        private Button button3;
        private Button button4;
        private Label label6;
        private Label label7;
        private Button button5;
        private Label label9;
        private Button button7;
        private Label label10;
        private Button button8;
        private Label label11;
        private Button button9;
        private Label label12;
        private Button button10;
        private Label label13;
        private Button button11;
        private Label label8;
        private Button button6;
    }
}