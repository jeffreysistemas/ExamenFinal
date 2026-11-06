using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExamenFinal
{
    public partial class Form6 : Form
    {
        private const string RutaArchivo = "expediente_olivos.txt";
        public Form6()
        {
            InitializeComponent();
            CargarEstadisticas();
        }
       

        private void CargarEstadisticas()
        {
            if (!File.Exists(RutaArchivo))
            {
                MessageBox.Show("Aún no existen expedientes registrados para generar estadísticas.", "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string[] lineas = File.ReadAllLines(RutaArchivo);

            int totalLicencias = 0;
            int totalReclamos = 0;
            int totalSolicitudes = 0;
            int totalOtros = 0;

            foreach (string linea in lineas)
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    string[] datos = linea.Split('|');
                    if (datos.Length >= 4)
                    {
                        string tipo = datos[3].Trim();

                        if (tipo.StartsWith("Licencia", StringComparison.OrdinalIgnoreCase))
                            totalLicencias++;
                        else if (tipo.StartsWith("Reclamo", StringComparison.OrdinalIgnoreCase))
                            totalReclamos++;
                        else if (tipo.StartsWith("Solicitud", StringComparison.OrdinalIgnoreCase))
                            totalSolicitudes++;
                        else
                            totalOtros++;
                    }
                }
            }
            ConfigurarGraficoPie(totalLicencias, totalReclamos, totalSolicitudes, totalOtros);
            GenerarGraficoBarras(totalLicencias, totalReclamos, totalSolicitudes, totalOtros);
        }
        private void ConfigurarGraficoPie(int licencias, int reclamos, int solicitudes, int otros)
        {
            chartTipoTramite.Series.Clear();
            chartTipoTramite.Titles.Clear();

            chartTipoTramite.Titles.Add("Distribución de Trámites por Categoria");

            Series serie = new Series("Tramites")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };

            if (licencias > 0) serie.Points.AddXY("Licencias", licencias);
            if (reclamos > 0) serie.Points.AddXY("Reclamos", reclamos);
            if (solicitudes > 0) serie.Points.AddXY("Solicitudes", solicitudes);
            if (otros > 0) serie.Points.AddXY("Otros", otros);


            chartTipoTramite.Series.Add(serie);
        }


        private void GenerarGraficoBarras(int licencias, int reclamos, int solicitudes, int otros)
        {
            chartEstados.Series.Clear();
            chartEstados.Titles.Clear();

            chartEstados.Titles.Add("Conteo Total de Expedientes");

            Series serieBarras = new Series("Cantidades")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            serieBarras.Points.AddXY("Licencias", licencias);
            serieBarras.Points.AddXY("Reclamos", reclamos);
            serieBarras.Points.AddXY("Solicitudes", solicitudes);
            if (otros > 0) serieBarras.Points.AddXY("Otros", otros);

            chartEstados.Series.Add(serieBarras);
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            CargarEstadisticas();
        }
    }
}
