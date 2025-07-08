namespace UI
{
    partial class FormDashboardGeneral
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartVuelosPorMes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartFacturasCobradas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartSimulacionesPorMes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            cbVuelosFiltro = new ComboBox();
            lblVueloFiltros = new Label();
            cbMesesFiltroVuelos = new ComboBox();
            lblMesFiltroVuelos = new Label();
            cbSemanaFiltroVuelo = new ComboBox();
            lblSemanaFiltroVuelo = new Label();
            lblSemanaFiltroSimuladores = new Label();
            cbSemanasFiltroSimuladores = new ComboBox();
            lblMesFiltroSimuladores = new Label();
            cbMesesFiltroSimuladores = new ComboBox();
            LblFiltroSImuladores = new Label();
            cbFiltroSimuladores = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)chartVuelosPorMes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartFacturasCobradas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartSimulacionesPorMes).BeginInit();
            SuspendLayout();
            // 
            // chartVuelosPorMes
            // 
            chartArea4.Name = "ChartArea1";
            chartVuelosPorMes.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chartVuelosPorMes.Legends.Add(legend4);
            chartVuelosPorMes.Location = new Point(63, 87);
            chartVuelosPorMes.Name = "chartVuelosPorMes";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chartVuelosPorMes.Series.Add(series4);
            chartVuelosPorMes.Size = new Size(475, 300);
            chartVuelosPorMes.TabIndex = 0;
            chartVuelosPorMes.Text = "chart1";
            // 
            // chartFacturasCobradas
            // 
            chartArea5.Name = "ChartArea1";
            chartFacturasCobradas.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            chartFacturasCobradas.Legends.Add(legend5);
            chartFacturasCobradas.Location = new Point(83, 457);
            chartFacturasCobradas.Name = "chartFacturasCobradas";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            chartFacturasCobradas.Series.Add(series5);
            chartFacturasCobradas.Size = new Size(681, 300);
            chartFacturasCobradas.TabIndex = 1;
            chartFacturasCobradas.Text = "t";
            // 
            // chartSimulacionesPorMes
            // 
            chartArea6.Name = "ChartArea1";
            chartSimulacionesPorMes.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            chartSimulacionesPorMes.Legends.Add(legend6);
            chartSimulacionesPorMes.Location = new Point(701, 87);
            chartSimulacionesPorMes.Name = "chartSimulacionesPorMes";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            chartSimulacionesPorMes.Series.Add(series6);
            chartSimulacionesPorMes.Size = new Size(475, 300);
            chartSimulacionesPorMes.TabIndex = 2;
            chartSimulacionesPorMes.Text = "chart1";
            // 
            // cbVuelosFiltro
            // 
            cbVuelosFiltro.FormattingEnabled = true;
            cbVuelosFiltro.Location = new Point(125, 46);
            cbVuelosFiltro.Name = "cbVuelosFiltro";
            cbVuelosFiltro.Size = new Size(74, 23);
            cbVuelosFiltro.TabIndex = 3;
            cbVuelosFiltro.SelectedIndexChanged += cbVuelosFiltro_SelectedIndexChanged;
            // 
            // lblVueloFiltros
            // 
            lblVueloFiltros.AutoSize = true;
            lblVueloFiltros.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVueloFiltros.Location = new Point(83, 49);
            lblVueloFiltros.Name = "lblVueloFiltros";
            lblVueloFiltros.Size = new Size(36, 15);
            lblVueloFiltros.TabIndex = 4;
            lblVueloFiltros.Text = "Filtro";
            // 
            // cbMesesFiltroVuelos
            // 
            cbMesesFiltroVuelos.FormattingEnabled = true;
            cbMesesFiltroVuelos.Location = new Point(282, 46);
            cbMesesFiltroVuelos.Name = "cbMesesFiltroVuelos";
            cbMesesFiltroVuelos.Size = new Size(74, 23);
            cbMesesFiltroVuelos.TabIndex = 5;
            cbMesesFiltroVuelos.Visible = false;
            cbMesesFiltroVuelos.SelectedIndexChanged += cbMesesFiltroVuelos_SelectedIndexChanged;
            // 
            // lblMesFiltroVuelos
            // 
            lblMesFiltroVuelos.AutoSize = true;
            lblMesFiltroVuelos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMesFiltroVuelos.Location = new Point(246, 49);
            lblMesFiltroVuelos.Name = "lblMesFiltroVuelos";
            lblMesFiltroVuelos.Size = new Size(30, 15);
            lblMesFiltroVuelos.TabIndex = 6;
            lblMesFiltroVuelos.Text = "Mes";
            lblMesFiltroVuelos.Visible = false;
            // 
            // cbSemanaFiltroVuelo
            // 
            cbSemanaFiltroVuelo.FormattingEnabled = true;
            cbSemanaFiltroVuelo.Location = new Point(455, 46);
            cbSemanaFiltroVuelo.Name = "cbSemanaFiltroVuelo";
            cbSemanaFiltroVuelo.Size = new Size(74, 23);
            cbSemanaFiltroVuelo.TabIndex = 7;
            cbSemanaFiltroVuelo.Visible = false;
            cbSemanaFiltroVuelo.SelectedIndexChanged += cbSemanaFiltroVuelo_SelectedIndexChanged;
            // 
            // lblSemanaFiltroVuelo
            // 
            lblSemanaFiltroVuelo.AutoSize = true;
            lblSemanaFiltroVuelo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSemanaFiltroVuelo.Location = new Point(398, 49);
            lblSemanaFiltroVuelo.Name = "lblSemanaFiltroVuelo";
            lblSemanaFiltroVuelo.Size = new Size(51, 15);
            lblSemanaFiltroVuelo.TabIndex = 8;
            lblSemanaFiltroVuelo.Text = "Semana";
            lblSemanaFiltroVuelo.Visible = false;
            // 
            // lblSemanaFiltroSimuladores
            // 
            lblSemanaFiltroSimuladores.AutoSize = true;
            lblSemanaFiltroSimuladores.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSemanaFiltroSimuladores.Location = new Point(1030, 49);
            lblSemanaFiltroSimuladores.Name = "lblSemanaFiltroSimuladores";
            lblSemanaFiltroSimuladores.Size = new Size(51, 15);
            lblSemanaFiltroSimuladores.TabIndex = 14;
            lblSemanaFiltroSimuladores.Text = "Semana";
            lblSemanaFiltroSimuladores.Visible = false;
            // 
            // cbSemanasFiltroSimuladores
            // 
            cbSemanasFiltroSimuladores.FormattingEnabled = true;
            cbSemanasFiltroSimuladores.Location = new Point(1087, 46);
            cbSemanasFiltroSimuladores.Name = "cbSemanasFiltroSimuladores";
            cbSemanasFiltroSimuladores.Size = new Size(74, 23);
            cbSemanasFiltroSimuladores.TabIndex = 13;
            cbSemanasFiltroSimuladores.Visible = false;
            cbSemanasFiltroSimuladores.SelectedIndexChanged += cbSemanasFiltroSimuladores_SelectedIndexChanged;
            // 
            // lblMesFiltroSimuladores
            // 
            lblMesFiltroSimuladores.AutoSize = true;
            lblMesFiltroSimuladores.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMesFiltroSimuladores.Location = new Point(878, 49);
            lblMesFiltroSimuladores.Name = "lblMesFiltroSimuladores";
            lblMesFiltroSimuladores.Size = new Size(30, 15);
            lblMesFiltroSimuladores.TabIndex = 12;
            lblMesFiltroSimuladores.Text = "Mes";
            lblMesFiltroSimuladores.Visible = false;
            // 
            // cbMesesFiltroSimuladores
            // 
            cbMesesFiltroSimuladores.FormattingEnabled = true;
            cbMesesFiltroSimuladores.Location = new Point(914, 46);
            cbMesesFiltroSimuladores.Name = "cbMesesFiltroSimuladores";
            cbMesesFiltroSimuladores.Size = new Size(74, 23);
            cbMesesFiltroSimuladores.TabIndex = 11;
            cbMesesFiltroSimuladores.Visible = false;
            cbMesesFiltroSimuladores.SelectedIndexChanged += cbMesesFiltroSimuladores_SelectedIndexChanged;
            // 
            // LblFiltroSImuladores
            // 
            LblFiltroSImuladores.AutoSize = true;
            LblFiltroSImuladores.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            LblFiltroSImuladores.Location = new Point(715, 49);
            LblFiltroSImuladores.Name = "LblFiltroSImuladores";
            LblFiltroSImuladores.Size = new Size(36, 15);
            LblFiltroSImuladores.TabIndex = 10;
            LblFiltroSImuladores.Text = "Filtro";
            // 
            // cbFiltroSimuladores
            // 
            cbFiltroSimuladores.FormattingEnabled = true;
            cbFiltroSimuladores.Location = new Point(757, 46);
            cbFiltroSimuladores.Name = "cbFiltroSimuladores";
            cbFiltroSimuladores.Size = new Size(74, 23);
            cbFiltroSimuladores.TabIndex = 9;
            cbFiltroSimuladores.SelectedIndexChanged += cbFiltroSimuladores_SelectedIndexChanged;
            // 
            // FormDashboardGeneral
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 785);
            Controls.Add(lblSemanaFiltroSimuladores);
            Controls.Add(cbSemanasFiltroSimuladores);
            Controls.Add(lblMesFiltroSimuladores);
            Controls.Add(cbMesesFiltroSimuladores);
            Controls.Add(LblFiltroSImuladores);
            Controls.Add(cbFiltroSimuladores);
            Controls.Add(lblSemanaFiltroVuelo);
            Controls.Add(cbSemanaFiltroVuelo);
            Controls.Add(lblMesFiltroVuelos);
            Controls.Add(cbMesesFiltroVuelos);
            Controls.Add(lblVueloFiltros);
            Controls.Add(cbVuelosFiltro);
            Controls.Add(chartSimulacionesPorMes);
            Controls.Add(chartFacturasCobradas);
            Controls.Add(chartVuelosPorMes);
            Name = "FormDashboardGeneral";
            Text = "FormDashboardGeneral";
            ((System.ComponentModel.ISupportInitialize)chartVuelosPorMes).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartFacturasCobradas).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartSimulacionesPorMes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartVuelosPorMes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFacturasCobradas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSimulacionesPorMes;
        private ComboBox cbVuelosFiltro;
        private Label lblVueloFiltros;
        private ComboBox cbMesesFiltroVuelos;
        private Label lblMesFiltroVuelos;
        private ComboBox cbSemanaFiltroVuelo;
        private Label lblSemanaFiltroVuelo;
        private Label lblSemanaFiltroSimuladores;
        private ComboBox cbSemanasFiltroSimuladores;
        private Label lblMesFiltroSimuladores;
        private ComboBox cbMesesFiltroSimuladores;
        private Label LblFiltroSImuladores;
        private ComboBox cbFiltroSimuladores;
    }
}