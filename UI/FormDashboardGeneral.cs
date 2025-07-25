using BLL;
using ENTITY;
using ENTITY.Enum;
using Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        List<string> DiasDelAnio = ["Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado"];
        int CantidadSemanasPorMes = 4;
        List<TransaccionFinanciera> listaTransacciones;
        List<TransaccionFinanciera> listaCobros;
        List<TransaccionFinanciera> listaPagos;
        public FormDashboardGeneral()
        {
            InitializeComponent();
            InicializarFiltros();
            InicializarFiltrosTransacciones();
            //GenerarGraficoFacturasCobro();
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

        private void InicializarFiltrosTransacciones()
        {

            cbTransaccionesFiltro.Items.Clear();
            cbSemanaFiltroTransacciones.Items.Clear();
            cbMesesTransaccionesFiltro.Items.Clear();


            foreach (EnumFiltrosDashboard filtro in Enum.GetValues(typeof(EnumFiltrosDashboard)))
            {
                var item = new ComboBoxItem
                {
                    Text = filtro.ToString(),
                    Value = (int)filtro
                };

                cbTransaccionesFiltro.Items.Add(item);
            }
            cbTransaccionesFiltro.SelectedIndex = 0;

            foreach (string mes in MesesDelAnio)
            {
                var item = new ComboBoxItem
                {
                    Text = mes,
                    Value = MesesDelAnio.IndexOf(mes) + 1
                };

                cbMesesTransaccionesFiltro.Items.Add(item);
            }

            cbMesesTransaccionesFiltro.SelectedIndex = DateTime.Now.Month - 1;

            for (int i = 1; i <= CantidadSemanasPorMes; i++)
            {
                var item = new ComboBoxItem
                {
                    Text = "Semana " + i,
                    Value = i
                };

                cbSemanaFiltroTransacciones.Items.Add(item);
            }

            cbSemanaFiltroTransacciones.SelectedIndex = 0;

            GenerarGraficoFacturasCobro();
        }

        private void GenerarGraficoVuelos()
        {
            var itemSeleccionado = (ComboBoxItem)cbVuelosFiltro.SelectedItem;
            chartVuelosPorMes.Series.Clear();

            var datosVuelos = new Dictionary<string, int>();
            DashboardFiltroPeriodo filtroVuelo = new DashboardFiltroPeriodo();
            filtroVuelo.TipoFiltro = itemSeleccionado.Value;
            filtroVuelo.Anio = 2025; //en el futuro se puede hacer filtro de año
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
                chartSimulacionesPorMes.Titles.Add("Simulaciones por Mes");
                chartSimulacionesPorMes.Titles[0].Font = new System.Drawing.Font("Arial", 14f, System.Drawing.FontStyle.Bold);

                chartSimulacionesPorMes.Legends[0].Docking = Docking.Bottom;
                chartSimulacionesPorMes.Legends[0].Alignment = System.Drawing.StringAlignment.Center;
                chartSimulacionesPorMes.Legends[0].IsTextAutoFit = true;
                chartSimulacionesPorMes.Legends[0].Title = "Meses";
            }
        }

        private void GenerarGraficoFacturasCobro()
        {
            chartTransaccionesRealizadas.Series.Clear();
            chartTransaccionesRealizadas.Titles.Clear();
            chartTransaccionesRealizadas.ChartAreas.Clear();
            chartTransaccionesRealizadas.Legends.Clear();

            var itemSeleccionado = (ComboBoxItem)cbTransaccionesFiltro.SelectedItem;
            Dictionary<string, decimal> montosTotalIngresos;
            Dictionary<string, decimal> montosTotalEgresos;
            var datosFacturas = new Dictionary<string, Dictionary<string, decimal>>();

            listaTransacciones = new TransaccionFinancieraBLL().ObtenerTodas();
            listaCobros = listaTransacciones.Where(t => t.TipoTransaccion.IdTipoTransaccion.Equals((int)EnumTipoTransaccion.CobroSolicitudHoras)).ToList();
            listaPagos = listaTransacciones.Where(t => !t.TipoTransaccion.IdTipoTransaccion.Equals((int)EnumTipoTransaccion.CobroSolicitudHoras)).ToList();

            if (itemSeleccionado != null)
            {

                switch (itemSeleccionado.Value)
                {

                    case (int)EnumFiltrosDashboard.Semanal:
                        {
                            int mesSeleccionado = ((ComboBoxItem)cbMesesTransaccionesFiltro.SelectedItem).Value;

                            var cobrosDelMes = listaCobros.Where(c => c.FechaTransaccion.Month.Equals(mesSeleccionado));
                            var pagosDelMes = listaPagos.Where(c => c.FechaTransaccion.Month.Equals(mesSeleccionado));

                            var ingresosSemana1 = cobrosDelMes.Where(c => ObtenerSemanaDelMes(c.FechaTransaccion).Equals(1)).Sum(c => c.MontoTransaccion);
                            var ingresosSemana2 = cobrosDelMes.Where(c => ObtenerSemanaDelMes(c.FechaTransaccion).Equals(2)).Sum(c => c.MontoTransaccion);
                            var ingresosSemana3 = cobrosDelMes.Where(c => ObtenerSemanaDelMes(c.FechaTransaccion).Equals(3)).Sum(c => c.MontoTransaccion);
                            var ingresosSemana4 = cobrosDelMes.Where(c => ObtenerSemanaDelMes(c.FechaTransaccion).Equals(4)).Sum(c => c.MontoTransaccion);

                            var egresosSemana1 = pagosDelMes.Where(c => ObtenerSemanaDelMes(c.FechaTransaccion).Equals(1)).Sum(c => c.MontoTransaccion);
                            var egresosSemana2 = pagosDelMes.Where(c => ObtenerSemanaDelMes(c.FechaTransaccion).Equals(2)).Sum(c => c.MontoTransaccion);
                            var egresosSemana3 = pagosDelMes.Where(c => ObtenerSemanaDelMes(c.FechaTransaccion).Equals(3)).Sum(c => c.MontoTransaccion);
                            var egresosSemana4 = pagosDelMes.Where(c => ObtenerSemanaDelMes(c.FechaTransaccion).Equals(4)).Sum(c => c.MontoTransaccion);

                            datosFacturas.Add("Semana 1", new Dictionary<string, decimal> { { "Ingresos", ingresosSemana1 }, { "Egresos", egresosSemana1 } });
                            datosFacturas.Add("Semana 2", new Dictionary<string, decimal> { { "Ingresos", ingresosSemana2 }, { "Egresos", egresosSemana2 } });
                            datosFacturas.Add("Semana 3", new Dictionary<string, decimal> { { "Ingresos", ingresosSemana3 }, { "Egresos", egresosSemana3 } });
                            datosFacturas.Add("Semana 4", new Dictionary<string, decimal> { { "Ingresos", ingresosSemana4 }, { "Egresos", egresosSemana4 } });

                            break;
                        }
                    case (int)EnumFiltrosDashboard.Diario:
                        {
                            int mesSeleccionado = ((ComboBoxItem)cbMesesTransaccionesFiltro.SelectedItem).Value;
                            int semanaSeleccionada = ((ComboBoxItem)cbSemanaFiltroTransacciones.SelectedItem).Value;
                            var cobrosDelMes = listaCobros.Where(c => c.FechaTransaccion.Month.Equals(mesSeleccionado) && ObtenerSemanaDelMes(c.FechaTransaccion).Equals(semanaSeleccionada));
                            var pagosDelMes = listaPagos.Where(c => c.FechaTransaccion.Month.Equals(mesSeleccionado) && ObtenerSemanaDelMes(c.FechaTransaccion).Equals(semanaSeleccionada));

                            montosTotalIngresos = cobrosDelMes.GroupBy(c => c.FechaTransaccion.ToString("dddd", CultureInfo.CurrentCulture)).ToDictionary(g => g.Key, g => g.Sum(c => c.MontoTransaccion));
                            montosTotalEgresos = pagosDelMes.GroupBy(c => c.FechaTransaccion.ToString("dddd", CultureInfo.CurrentCulture)).ToDictionary(g => g.Key, g => g.Sum(c => c.MontoTransaccion));

                            foreach (string dia in DiasDelAnio)
                            {
                                var ingresoMensual = montosTotalIngresos.FirstOrDefault(c => c.Key.ToLower().Equals(dia.ToLower()), new KeyValuePair<string, decimal>(dia, 0));
                                var egresoMensual = montosTotalEgresos.FirstOrDefault(c => c.Key.ToLower().Equals(dia.ToLower()), new KeyValuePair<string, decimal>(dia, 0));
                                datosFacturas.Add(dia, new Dictionary<string, decimal> { { "Ingresos", ingresoMensual.Value }, { "Egresos", egresoMensual.Value } });
                            }

                            break;
                        }
                    default:
                        {
                            montosTotalIngresos = listaCobros.OrderBy(c => c.FechaTransaccion.Month).GroupBy(c => c.FechaTransaccion.ToString("MMMM", CultureInfo.CurrentCulture)).ToDictionary(g => g.Key, g => g.Sum(c => c.MontoTransaccion));
                            montosTotalEgresos = listaPagos.OrderBy(c => c.FechaTransaccion.Month).GroupBy(c => c.FechaTransaccion.ToString("MMMM", CultureInfo.CurrentCulture)).ToDictionary(g => g.Key, g => g.Sum(c => c.MontoTransaccion));

                            foreach (string mes in MesesDelAnio)
                            {
                                var ingresoMensual = montosTotalIngresos.FirstOrDefault(c => c.Key.ToLower().Equals(mes.ToLower()), new KeyValuePair<string, decimal>(mes, 0));
                                var egresoMensual = montosTotalEgresos.FirstOrDefault(c => c.Key.ToLower().Equals(mes.ToLower()), new KeyValuePair<string, decimal>(mes, 0));
                                datosFacturas.Add(mes, new Dictionary<string, decimal> { { "Ingresos", ingresoMensual.Value }, { "Egresos", egresoMensual.Value } });
                            }

                            break;
                        }
                }

                ChartArea area = new ChartArea("MainArea");
                chartTransaccionesRealizadas.ChartAreas.Add(area);

                area.AxisX.Title = "Mes";
                area.AxisX.Interval = 1;
                area.AxisX.LabelStyle.Angle = -45;
                area.AxisX.IsLabelAutoFit = true;
                area.AxisX.MajorGrid.Enabled = false;
                area.AxisX.IsStartedFromZero = true;

                area.AxisY.Title = "Cantidad de dinedo en $";
                area.AxisY.Minimum = 0;
                area.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
                area.AxisY.MajorGrid.LineColor = Color.LightGray;

                Series cobros = new Series("Cobros realizados");
                cobros.ChartType = SeriesChartType.Column;
                cobros.Color = Color.SteelBlue;
                cobros.IsValueShownAsLabel = true;
                cobros.LabelFormat = "{0,00}";
                cobros.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Bold);
                cobros.ChartArea = "MainArea";
                cobros.XValueType = ChartValueType.String;
                cobros.IsXValueIndexed = true;

                Series pagos = new Series("Pagos Realizados");
                pagos.ChartType = SeriesChartType.Column;
                pagos.Color = Color.Orange;
                pagos.IsValueShownAsLabel = true;
                pagos.LabelFormat = "{0,00}";
                pagos.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Bold);
                pagos.ChartArea = "MainArea";
                pagos.XValueType = ChartValueType.String;
                pagos.IsXValueIndexed = true;

                foreach (var mes in datosFacturas.Keys)
                {
                    cobros.Points.AddXY(mes, datosFacturas[mes]["Ingresos"]);
                    pagos.Points.AddXY(mes, datosFacturas[mes]["Egresos"]);
                }

                chartTransaccionesRealizadas.Series.Add(cobros);
                chartTransaccionesRealizadas.Series.Add(pagos);

                chartTransaccionesRealizadas.Titles.Add("Transacciones realizadas");
                chartTransaccionesRealizadas.Titles[0].Font = new Font("Arial", 14f, FontStyle.Bold);

                Legend legend = new Legend("MyLegend");
                legend.Docking = Docking.Bottom;
                legend.Alignment = StringAlignment.Center;
                legend.Font = new Font("Arial", 10f);
                chartTransaccionesRealizadas.Legends.Add(legend);
                cobros.Legend = "MyLegend";
                pagos.Legend = "MyLegend";

                chartTransaccionesRealizadas.Series["Cobros realizados"]["PointWidth"] = "0.8";
                chartTransaccionesRealizadas.Series["Pagos Realizados"]["PointWidth"] = "0.8";
            }
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

        private void cbTransaccionesFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemSeleccionado = (ComboBoxItem)cbTransaccionesFiltro.SelectedItem;

            if (itemSeleccionado != null)
            {

                if (((ComboBoxItem)cbTransaccionesFiltro.SelectedItem).Value > 2)
                {
                    lblSemanaFiltroTransacciones.Visible = true;
                    cbSemanaFiltroTransacciones.Visible = true;
                }

                if (((ComboBoxItem)cbTransaccionesFiltro.SelectedItem).Value > 1)
                {
                    lblMesFiltroTransacciones.Visible = true;
                    cbMesesTransaccionesFiltro.Visible = true;
                }
                else
                {
                    lblSemanaFiltroTransacciones.Visible = false;
                    cbSemanaFiltroTransacciones.Visible = false;
                    lblMesFiltroTransacciones.Visible = false;
                    cbMesesTransaccionesFiltro.Visible = false;
                }

                GenerarGraficoFacturasCobro();
            }
        }

        private static int ObtenerSemanaDelMes(DateTime date)
        {
            // Calcula el día del mes
            int diaDelMes = date.Day;

            int semana = (diaDelMes - 1) / 7 + 1;

            // Limitar a las 4 primeras semanas.
            // Las fechas en la 5ta semana (días 29-31) no cumplirán el filtro si weekOfMonth es 1-4. por tanto resuelvo asi
            return semana <= 4 ? semana : 0; // Devolvemos 0 para indicar que está fuera de las 4 primeras semanas.
        }

        private void cbMesesTransaccionesFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMesesTransaccionesFiltro.SelectedItem != null)
            {
                GenerarGraficoFacturasCobro();
            }
        }

        private void cbSemanaFiltroTransacciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSemanaFiltroTransacciones.SelectedItem != null)
            {
                GenerarGraficoFacturasCobro();
            }
        }
    }
}
