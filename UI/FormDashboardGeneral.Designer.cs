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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartVuelosPorMes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartTransaccionesRealizadas = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            lblSemanaFiltroTransacciones = new Label();
            cbSemanaFiltroTransacciones = new ComboBox();
            lblMesFiltroTransacciones = new Label();
            cbMesesTransaccionesFiltro = new ComboBox();
            label3 = new Label();
            cbTransaccionesFiltro = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)chartVuelosPorMes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartTransaccionesRealizadas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartSimulacionesPorMes).BeginInit();
            SuspendLayout();
            // 
            // chartVuelosPorMes
            // 
            chartArea1.Name = "ChartArea1";
            chartVuelosPorMes.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartVuelosPorMes.Legends.Add(legend1);
            chartVuelosPorMes.Location = new Point(63, 87);
            chartVuelosPorMes.Name = "chartVuelosPorMes";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartVuelosPorMes.Series.Add(series1);
            chartVuelosPorMes.Size = new Size(475, 300);
            chartVuelosPorMes.TabIndex = 0;
            chartVuelosPorMes.Text = "chart1";
            // 
            // chartTransaccionesRealizadas
            // 
            chartArea2.Name = "ChartArea1";
            chartTransaccionesRealizadas.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartTransaccionesRealizadas.Legends.Add(legend2);
            chartTransaccionesRealizadas.Location = new Point(63, 516);
            chartTransaccionesRealizadas.Name = "chartTransaccionesRealizadas";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartTransaccionesRealizadas.Series.Add(series2);
            chartTransaccionesRealizadas.Size = new Size(1561, 300);
            chartTransaccionesRealizadas.TabIndex = 1;
            chartTransaccionesRealizadas.Text = "t";
            // 
            // chartSimulacionesPorMes
            // 
            chartArea3.Name = "ChartArea1";
            chartSimulacionesPorMes.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartSimulacionesPorMes.Legends.Add(legend3);
            chartSimulacionesPorMes.Location = new Point(644, 87);
            chartSimulacionesPorMes.Name = "chartSimulacionesPorMes";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chartSimulacionesPorMes.Series.Add(series3);
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
            lblSemanaFiltroSimuladores.Location = new Point(973, 49);
            lblSemanaFiltroSimuladores.Name = "lblSemanaFiltroSimuladores";
            lblSemanaFiltroSimuladores.Size = new Size(51, 15);
            lblSemanaFiltroSimuladores.TabIndex = 14;
            lblSemanaFiltroSimuladores.Text = "Semana";
            lblSemanaFiltroSimuladores.Visible = false;
            // 
            // cbSemanasFiltroSimuladores
            // 
            cbSemanasFiltroSimuladores.FormattingEnabled = true;
            cbSemanasFiltroSimuladores.Location = new Point(1030, 46);
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
            lblMesFiltroSimuladores.Location = new Point(821, 49);
            lblMesFiltroSimuladores.Name = "lblMesFiltroSimuladores";
            lblMesFiltroSimuladores.Size = new Size(30, 15);
            lblMesFiltroSimuladores.TabIndex = 12;
            lblMesFiltroSimuladores.Text = "Mes";
            lblMesFiltroSimuladores.Visible = false;
            // 
            // cbMesesFiltroSimuladores
            // 
            cbMesesFiltroSimuladores.FormattingEnabled = true;
            cbMesesFiltroSimuladores.Location = new Point(857, 46);
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
            LblFiltroSImuladores.Location = new Point(658, 49);
            LblFiltroSImuladores.Name = "LblFiltroSImuladores";
            LblFiltroSImuladores.Size = new Size(36, 15);
            LblFiltroSImuladores.TabIndex = 10;
            LblFiltroSImuladores.Text = "Filtro";
            // 
            // cbFiltroSimuladores
            // 
            cbFiltroSimuladores.FormattingEnabled = true;
            cbFiltroSimuladores.Location = new Point(700, 46);
            cbFiltroSimuladores.Name = "cbFiltroSimuladores";
            cbFiltroSimuladores.Size = new Size(74, 23);
            cbFiltroSimuladores.TabIndex = 9;
            cbFiltroSimuladores.SelectedIndexChanged += cbFiltroSimuladores_SelectedIndexChanged;
            // 
            // lblSemanaFiltroTransacciones
            // 
            lblSemanaFiltroTransacciones.AutoSize = true;
            lblSemanaFiltroTransacciones.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSemanaFiltroTransacciones.Location = new Point(398, 479);
            lblSemanaFiltroTransacciones.Name = "lblSemanaFiltroTransacciones";
            lblSemanaFiltroTransacciones.Size = new Size(51, 15);
            lblSemanaFiltroTransacciones.TabIndex = 20;
            lblSemanaFiltroTransacciones.Text = "Semana";
            lblSemanaFiltroTransacciones.Visible = false;
            // 
            // cbSemanaFiltroTransacciones
            // 
            cbSemanaFiltroTransacciones.FormattingEnabled = true;
            cbSemanaFiltroTransacciones.Location = new Point(455, 476);
            cbSemanaFiltroTransacciones.Name = "cbSemanaFiltroTransacciones";
            cbSemanaFiltroTransacciones.Size = new Size(74, 23);
            cbSemanaFiltroTransacciones.TabIndex = 19;
            cbSemanaFiltroTransacciones.Visible = false;
            cbSemanaFiltroTransacciones.SelectedIndexChanged += cbSemanaFiltroTransacciones_SelectedIndexChanged;
            // 
            // lblMesFiltroTransacciones
            // 
            lblMesFiltroTransacciones.AutoSize = true;
            lblMesFiltroTransacciones.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMesFiltroTransacciones.Location = new Point(246, 479);
            lblMesFiltroTransacciones.Name = "lblMesFiltroTransacciones";
            lblMesFiltroTransacciones.Size = new Size(30, 15);
            lblMesFiltroTransacciones.TabIndex = 18;
            lblMesFiltroTransacciones.Text = "Mes";
            lblMesFiltroTransacciones.Visible = false;
            // 
            // cbMesesTransaccionesFiltro
            // 
            cbMesesTransaccionesFiltro.FormattingEnabled = true;
            cbMesesTransaccionesFiltro.Location = new Point(282, 476);
            cbMesesTransaccionesFiltro.Name = "cbMesesTransaccionesFiltro";
            cbMesesTransaccionesFiltro.Size = new Size(74, 23);
            cbMesesTransaccionesFiltro.TabIndex = 17;
            cbMesesTransaccionesFiltro.Visible = false;
            cbMesesTransaccionesFiltro.SelectedIndexChanged += cbMesesTransaccionesFiltro_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(83, 479);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 16;
            label3.Text = "Filtro";
            // 
            // cbTransaccionesFiltro
            // 
            cbTransaccionesFiltro.FormattingEnabled = true;
            cbTransaccionesFiltro.Location = new Point(125, 476);
            cbTransaccionesFiltro.Name = "cbTransaccionesFiltro";
            cbTransaccionesFiltro.Size = new Size(74, 23);
            cbTransaccionesFiltro.TabIndex = 15;
            cbTransaccionesFiltro.SelectedIndexChanged += cbTransaccionesFiltro_SelectedIndexChanged;
            // 
            // FormDashboardGeneral
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1697, 875);
            Controls.Add(lblSemanaFiltroTransacciones);
            Controls.Add(cbSemanaFiltroTransacciones);
            Controls.Add(lblMesFiltroTransacciones);
            Controls.Add(cbMesesTransaccionesFiltro);
            Controls.Add(label3);
            Controls.Add(cbTransaccionesFiltro);
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
            Controls.Add(chartTransaccionesRealizadas);
            Controls.Add(chartVuelosPorMes);
            Name = "FormDashboardGeneral";
            Text = "FormDashboardGeneral";
            ((System.ComponentModel.ISupportInitialize)chartVuelosPorMes).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartTransaccionesRealizadas).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartSimulacionesPorMes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartVuelosPorMes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTransaccionesRealizadas;
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
        private Label lblSemanaFiltroTransacciones;
        private ComboBox cbSemanaFiltroTransacciones;
        private Label lblMesFiltroTransacciones;
        private ComboBox cbMesesTransaccionesFiltro;
        private Label label3;
        private ComboBox cbTransaccionesFiltro;
    }
}