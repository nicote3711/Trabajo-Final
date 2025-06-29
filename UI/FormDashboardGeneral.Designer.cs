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
            chartFacturasCobradas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartSimulacionesPorMes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            cbVuelosFiltro = new ComboBox();
            lblVueloFiltros = new Label();
            ((System.ComponentModel.ISupportInitialize)chartVuelosPorMes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartFacturasCobradas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartSimulacionesPorMes).BeginInit();
            SuspendLayout();
            // 
            // chartVuelosPorMes
            // 
            chartArea1.Name = "ChartArea1";
            chartVuelosPorMes.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartVuelosPorMes.Legends.Add(legend1);
            chartVuelosPorMes.Location = new Point(83, 55);
            chartVuelosPorMes.Name = "chartVuelosPorMes";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartVuelosPorMes.Series.Add(series1);
            chartVuelosPorMes.Size = new Size(300, 300);
            chartVuelosPorMes.TabIndex = 0;
            chartVuelosPorMes.Text = "chart1";
            // 
            // chartFacturasCobradas
            // 
            chartArea2.Name = "ChartArea1";
            chartFacturasCobradas.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartFacturasCobradas.Legends.Add(legend2);
            chartFacturasCobradas.Location = new Point(838, 55);
            chartFacturasCobradas.Name = "chartFacturasCobradas";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartFacturasCobradas.Series.Add(series2);
            chartFacturasCobradas.Size = new Size(681, 300);
            chartFacturasCobradas.TabIndex = 1;
            chartFacturasCobradas.Text = "t";
            // 
            // chartSimulacionesPorMes
            // 
            chartArea3.Name = "ChartArea1";
            chartSimulacionesPorMes.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartSimulacionesPorMes.Legends.Add(legend3);
            chartSimulacionesPorMes.Location = new Point(457, 55);
            chartSimulacionesPorMes.Name = "chartSimulacionesPorMes";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chartSimulacionesPorMes.Series.Add(series3);
            chartSimulacionesPorMes.Size = new Size(300, 300);
            chartSimulacionesPorMes.TabIndex = 2;
            chartSimulacionesPorMes.Text = "chart1";
            // 
            // cbVuelosFiltro
            // 
            cbVuelosFiltro.FormattingEnabled = true;
            cbVuelosFiltro.Location = new Point(123, 24);
            cbVuelosFiltro.Name = "cbVuelosFiltro";
            cbVuelosFiltro.Size = new Size(150, 23);
            cbVuelosFiltro.TabIndex = 3;
            cbVuelosFiltro.SelectedIndexChanged += cbVuelosFiltro_SelectedIndexChanged;
            // 
            // lblVueloFiltros
            // 
            lblVueloFiltros.AutoSize = true;
            lblVueloFiltros.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVueloFiltros.Location = new Point(83, 27);
            lblVueloFiltros.Name = "lblVueloFiltros";
            lblVueloFiltros.Size = new Size(36, 15);
            lblVueloFiltros.TabIndex = 4;
            lblVueloFiltros.Text = "Filtro";
            // 
            // FormDashboardGeneral
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1563, 636);
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
    }
}