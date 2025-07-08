using BLL;
using ENTITY.Enum;
using Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class FormDashboardGeneral : Form
    {
        List<string> MesesDelAnio = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
        int CantidadSemanasPorMes = 4;
        public FormDashboardGeneral()
        {
            InitializeComponent();
            InicializarFiltros();
            GenerarGraficoFacturasCobro();
        }

        private void InicializarFiltros()
        {
            InicializarFiltrosVuelos();
            InicializarFiltrosSimuladores();
        }
        private void InicializarFiltrosSimuladores() 
        {

            cbFiltroSimuladores.Items.Clear();
            cbSemanasFiltroSimuladores.Items.Clear();
            cbMesesFiltroSimuladores.Items.Clear();


            foreach (EnumFiltrosDashboard filtro in Enum.GetValues(typeof(EnumFiltrosDashboard)))
            {
                var item = new ComboBoxItem
                {
                    Text = filtro.ToString(),
                    Value = (int)filtro
                };

                cbFiltroSimuladores.Items.Add(item);
            }
            cbFiltroSimuladores.SelectedIndex = 0;

            foreach (string mes in MesesDelAnio)
            {
                var item = new ComboBoxItem
                {
                    Text = mes,
                    Value = MesesDelAnio.IndexOf(mes) + 1
                };

                cbMesesFiltroSimuladores.Items.Add(item);
            }

            cbMesesFiltroSimuladores.SelectedIndex = DateTime.Now.Month - 1;

            for (int i = 1; i <= CantidadSemanasPorMes; i++)
            {
                var item = new ComboBoxItem
                {
                    Text = "Semana " + i,
                    Value = i
                };

                cbSemanasFiltroSimuladores.Items.Add(item);
            }

            cbSemanasFiltroSimuladores.SelectedIndex = 0;

            GenerarGraficoSimulaciones();
        }

        private void InicializarFiltrosVuelos()
        {
            cbVuelosFiltro.Items.Clear();
            cbSemanaFiltroVuelo.Items.Clear();
            cbMesesFiltroVuelos.Items.Clear();


            foreach (EnumFiltrosDashboard filtro in Enum.GetValues(typeof(EnumFiltrosDashboard)))
            {
                var item = new ComboBoxItem
                {
                    Text = filtro.ToString(),
                    Value = (int)filtro
                };

                cbVuelosFiltro.Items.Add(item);
            }
            cbVuelosFiltro.SelectedIndex = 0;

            foreach (string mes in MesesDelAnio)
            {
                var item = new ComboBoxItem
                {
                    Text = mes,
                    Value = MesesDelAnio.IndexOf(mes) + 1
                };

                cbMesesFiltroVuelos.Items.Add(item);
            }

            cbMesesFiltroVuelos.SelectedIndex = DateTime.Now.Month - 1;

            for (int i = 1; i <= CantidadSemanasPorMes; i++)
            {
                var item = new ComboBoxItem
                {
                    Text = "Semana " + i,
                    Value = i
                };

                cbSemanaFiltroVuelo.Items.Add(item);
            }

            cbSemanaFiltroVuelo.SelectedIndex = 0;

            GenerarGraficoVuelos();

        }

        private void GenerarGraficoVuelos()
        {
            var itemSeleccionado = (ComboBoxItem)cbVuelosFiltro.SelectedItem;
            chartVuelosPorMes.Series.Clear();

            var datosVuelos = new Dictionary<string, int>();
            DashboardFiltroPeriodo filtroVuelo = new DashboardFiltroPeriodo();
            filtroVuelo.TipoFiltro = itemSeleccionado.Value;
            filtroVuelo.Anio = 2025;
            filtroVuelo.Mes = ((ComboBoxItem)cbMesesFiltroVuelos.SelectedItem) == null ? 1 : ((ComboBoxItem)cbMesesFiltroVuelos.SelectedItem).Value;
            filtroVuelo.Semana = ((ComboBoxItem)cbSemanaFiltroVuelo.SelectedItem) == null ? 1 : ((ComboBoxItem)cbSemanaFiltroVuelo.SelectedItem).Value;

            datosVuelos = new VueloBLL().BuscarVuelosPorFiltro(filtroVuelo);

            Series serieTorta = new Series("Vuelos por Mes");
            serieTorta.ChartType = SeriesChartType.Pie;

            serieTorta["PieLabelStyle"] = "Outside"; 
            serieTorta["PieLineColor"] = "Black"; 
            serieTorta.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold);
            serieTorta.LabelFormat = "{0} ({1:P0})"; 

            foreach (var item in datosVuelos)
            {
                DataPoint punto = new DataPoint();
                punto.SetValueY(item.Value);
                punto.Label = item.Value.ToString();
                punto.LegendText = item.Key;
                punto.ToolTip = $"Vuelos en {item.Key}: {item.Value}";
                serieTorta.Points.Add(punto);
            }

            chartVuelosPorMes.Series.Add(serieTorta);

            chartVuelosPorMes.ChartAreas[0].Area3DStyle.Enable3D = true;
            chartVuelosPorMes.ChartAreas[0].Area3DStyle.Inclination = 30;
            chartVuelosPorMes.ChartAreas[0].Area3DStyle.Rotation = 0;

            chartVuelosPorMes.Titles.Clear();
            chartVuelosPorMes.Titles.Add("Vuelos por Mes");
            chartVuelosPorMes.Titles[0].Font = new System.Drawing.Font("Arial", 14f, System.Drawing.FontStyle.Bold);

            chartVuelosPorMes.Legends[0].Docking = Docking.Bottom;
            chartVuelosPorMes.Legends[0].Alignment = System.Drawing.StringAlignment.Center;
            chartVuelosPorMes.Legends[0].IsTextAutoFit = true;
            chartVuelosPorMes.Legends[0].Title = "Meses";
        }
        private void GenerarGraficoSimulaciones()
        {
            chartSimulacionesPorMes.Series.Clear();

            var itemSeleccionado = (ComboBoxItem)cbFiltroSimuladores.SelectedItem;
            var datosVuelos = new Dictionary<string, int>();
            DashboardFiltroPeriodo filtroSimuladores = new DashboardFiltroPeriodo();
            filtroSimuladores.TipoFiltro = itemSeleccionado.Value;
            filtroSimuladores.Anio = 2025;
            filtroSimuladores.Mes = ((ComboBoxItem)cbMesesFiltroSimuladores.SelectedItem) == null ? 1 : ((ComboBoxItem)cbMesesFiltroSimuladores.SelectedItem).Value;
            filtroSimuladores.Semana = ((ComboBoxItem)cbSemanasFiltroSimuladores.SelectedItem) == null ? 1 : ((ComboBoxItem)cbSemanasFiltroSimuladores.SelectedItem).Value;

            if (itemSeleccionado != null)
            {
                var datosSimulaciones = new SimuladorBLL().BuscarSimuladoresPorFiltro(filtroSimuladores);


                Series serieTorta = new Series("Simulaciones por Mes");
                serieTorta.ChartType = SeriesChartType.Pie;

                serieTorta["PieLabelStyle"] = "Outside";
                serieTorta["PieLineColor"] = "Black";
                serieTorta.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold);
                serieTorta.LabelFormat = "{0} ({1:P0})";

                foreach (var item in datosSimulaciones)
                {
                    DataPoint punto = new DataPoint();
                    punto.SetValueY(item.Value);
                    punto.Label = item.Value.ToString();
                    punto.LegendText = item.Key;
                    punto.ToolTip = $"Vuelos en {item.Key}: {item.Value}";
                    serieTorta.Points.Add(punto);
                }

                chartSimulacionesPorMes.Series.Add(serieTorta);


                chartSimulacionesPorMes.ChartAreas[0].Area3DStyle.Enable3D = true;
                chartSimulacionesPorMes.ChartAreas[0].Area3DStyle.Inclination = 30;
                chartSimulacionesPorMes.ChartAreas[0].Area3DStyle.Rotation = 0;

                chartSimulacionesPorMes.Titles.Clear();
                chartSimulacionesPorMes.Titles.Add("Distribución de Vuelos por Mes");
                chartSimulacionesPorMes.Titles[0].Font = new System.Drawing.Font("Arial", 14f, System.Drawing.FontStyle.Bold);

                chartSimulacionesPorMes.Legends[0].Docking = Docking.Bottom;
                chartSimulacionesPorMes.Legends[0].Alignment = System.Drawing.StringAlignment.Center;
                chartSimulacionesPorMes.Legends[0].IsTextAutoFit = true;
                chartSimulacionesPorMes.Legends[0].Title = "Meses";
            }
        }

        private void GenerarGraficoFacturasCobro()
        {
            chartFacturasCobradas.Series.Clear();
            chartFacturasCobradas.Titles.Clear();
            chartFacturasCobradas.ChartAreas.Clear();
            chartFacturasCobradas.Legends.Clear();

            // 2. Definir los datos de ejemplo
            var datosFacturas = new Dictionary<string, Dictionary<string, int>>()
            {
                { "Enero", new Dictionary<string, int> { { "Vuelo", 80 }, { "Simulador", 30 } } },
                { "Febrero", new Dictionary<string, int> { { "Vuelo", 95 }, { "Simulador", 40 } } },
                { "Marzo", new Dictionary<string, int> { { "Vuelo", 110 }, { "Simulador", 45 } } },
                { "Abril", new Dictionary<string, int> { { "Vuelo", 85 }, { "Simulador", 35 } } },
                { "Mayo", new Dictionary<string, int> { { "Vuelo", 120 }, { "Simulador", 50 } } },
                { "Junio", new Dictionary<string, int> { { "Vuelo", 100 }, { "Simulador", 42 } } },
                { "Julio", new Dictionary<string, int> { { "Vuelo", 105 }, { "Simulador", 48 } } },
                { "Agosto", new Dictionary<string, int> { { "Vuelo", 90 }, { "Simulador", 38 } } },
                { "Septiembre", new Dictionary<string, int> { { "Vuelo", 115 }, { "Simulador", 52 } } },
                { "Octubre", new Dictionary<string, int> { { "Vuelo", 100 }, { "Simulador", 44 } } },
                { "Noviembre", new Dictionary<string, int> { { "Vuelo", 88 }, { "Simulador", 36 } } },
                { "Diciembre", new Dictionary<string, int> { { "Vuelo", 130 }, { "Simulador", 55 } } }
            };

            // 3. Crear y configurar el área del gráfico
            ChartArea area = new ChartArea("MainArea");
            chartFacturasCobradas.ChartAreas.Add(area);

            // Configuración del Eje X (Categorías)
            area.AxisX.Title = "Mes";
            area.AxisX.Interval = 1; // Asegura que se muestre una etiqueta para cada punto
            area.AxisX.LabelStyle.Angle = -45; // Rotar etiquetas para evitar superposición
            area.AxisX.IsLabelAutoFit = true;
            area.AxisX.MajorGrid.Enabled = false; // Ocultar líneas de grid verticales
            area.AxisX.IsStartedFromZero = true; // Asegura que el eje X comience desde el primer punto

            // Configuración del Eje Y (Valores)
            area.AxisY.Title = "Cantidad de Facturas";
            area.AxisY.Minimum = 0;
            area.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount; // Permite al gráfico determinar el mejor intervalo
            area.AxisY.MajorGrid.LineColor = Color.LightGray; // Color de las líneas de grid horizontales

            // 4. Crear una serie para las facturas de Vuelo
            Series serieVuelo = new Series("Horas Vuelo Cobradas");
            serieVuelo.ChartType = SeriesChartType.Column;
            serieVuelo.Color = Color.SteelBlue;
            serieVuelo.IsValueShownAsLabel = true;
            serieVuelo.LabelFormat = "{0}";
            serieVuelo.ChartArea = "MainArea";
            serieVuelo.XValueType = ChartValueType.String; // **EXPLÍCITO: El tipo de valor X es una cadena**
            serieVuelo.IsXValueIndexed = true; // **EXPLÍCITO: Tratar los valores X como índices de puntos**

            // 5. Crear una serie para las facturas de Simulador
            Series serieSimulador = new Series("Horas Simulador Cobradas");
            serieSimulador.ChartType = SeriesChartType.Column;
            serieSimulador.Color = Color.Orange;
            serieSimulador.IsValueShownAsLabel = true;
            serieSimulador.LabelFormat = "{0}";
            serieSimulador.ChartArea = "MainArea";
            serieSimulador.XValueType = ChartValueType.String; // **EXPLÍCITO: El tipo de valor X es una cadena**
            serieSimulador.IsXValueIndexed = true; // **EXPLÍCITO: Tratar los valores X como índices de puntos**

            // 6. Agregar los puntos de datos a ambas series
            // Es importante que el orden de adición de los puntos sea consistente
            // para que los meses se alineen correctamente.
            foreach (var mes in datosFacturas.Keys)
            {
                // Agregar punto para horas de Vuelo
                serieVuelo.Points.AddXY(mes, datosFacturas[mes]["Vuelo"]);

                // Agregar punto para horas de Simulador
                serieSimulador.Points.AddXY(mes, datosFacturas[mes]["Simulador"]);
            }

            // 7. Agregar las series al control Chart
            chartFacturasCobradas.Series.Add(serieVuelo);
            chartFacturasCobradas.Series.Add(serieSimulador);

            // 8. Configurar el título del gráfico
            chartFacturasCobradas.Titles.Add("Facturas Cobradas de Vuelos y Simulador por Mes");
            chartFacturasCobradas.Titles[0].Font = new Font("Arial", 14f, FontStyle.Bold);

            // 9. Configurar la leyenda
            Legend legend = new Legend("MyLegend");
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
            legend.Font = new Font("Arial", 10f);
            chartFacturasCobradas.Legends.Add(legend);
            serieVuelo.Legend = "MyLegend";
            serieSimulador.Legend = "MyLegend";

            // Opcional: Ajustar el ancho de las columnas
            // Puedes ajustar este valor para que las barras se vean mejor
            chartFacturasCobradas.Series["Horas Vuelo Cobradas"]["PointWidth"] = "0.8";
            chartFacturasCobradas.Series["Horas Simulador Cobradas"]["PointWidth"] = "0.8";
        }

        #region GraficoVuelos
        private void cbVuelosFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVuelosFiltro.SelectedItem != null)
            {

                if (((ComboBoxItem)cbVuelosFiltro.SelectedItem).Value > 2)
                {
                    lblSemanaFiltroVuelo.Visible = true;
                    cbSemanaFiltroVuelo.Visible = true;
                }

                if (((ComboBoxItem)cbVuelosFiltro.SelectedItem).Value > 1)
                {
                    lblMesFiltroVuelos.Visible = true;
                    cbMesesFiltroVuelos.Visible = true;
                }
                else
                {
                    lblSemanaFiltroVuelo.Visible = false;
                    cbSemanaFiltroVuelo.Visible = false;
                    lblMesFiltroVuelos.Visible = false;
                    cbMesesFiltroVuelos.Visible = false;
                }

                GenerarGraficoVuelos();
            }
        }

        private void cbMesesFiltroVuelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMesesFiltroVuelos.SelectedItem != null)
            {
                GenerarGraficoVuelos();
            }
        }

        private void cbSemanaFiltroVuelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSemanaFiltroVuelo.SelectedItem != null)
            {
                GenerarGraficoVuelos();
            }
        }

        #endregion

        #region


        private void cbFiltroSimuladores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBoxItem)cbFiltroSimuladores.SelectedItem).Value > 2)
            {
                lblSemanaFiltroSimuladores.Visible = true;
                cbSemanasFiltroSimuladores.Visible = true;
            }

            if (((ComboBoxItem)cbFiltroSimuladores.SelectedItem).Value > 1)
            {
                lblMesFiltroSimuladores.Visible = true;
                cbMesesFiltroSimuladores.Visible = true;
            }
            else
            {
                lblSemanaFiltroSimuladores.Visible = false;
                cbSemanasFiltroSimuladores.Visible = false;
                cbMesesFiltroSimuladores.Visible = false;
                lblMesFiltroSimuladores.Visible = false;
            }

            GenerarGraficoSimulaciones();
        }

        private void cbMesesFiltroSimuladores_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerarGraficoSimulaciones();
        }

        private void cbSemanasFiltroSimuladores_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerarGraficoSimulaciones();
        }

        #endregion
        private class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text; // Esto asegura que el ComboBox muestre el texto
            }
        }

    }
}
