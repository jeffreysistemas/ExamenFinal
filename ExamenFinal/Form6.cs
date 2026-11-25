using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExamenFinal
{
    public partial class Form6 : Form
    {
        private const string RutaArchivo = "expedientes_olivos.dat";

        public Form6()
        {
            InitializeComponent();
        }

        private void CargarEstadisticas()
        {
            if (!File.Exists(RutaArchivo))
            {
                MessageBox.Show("Aún no existen expedientes registrados para generar estadísticas.", "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int totalLicencias = 0;
            int totalReclamos = 0;
            int totalSolicitudes = 0;
            int totalOtros = 0;

            BinaryReader br = null;
            try
            {
                br = new BinaryReader(new FileStream(RutaArchivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                Expediente exp = new Expediente();

                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    exp.codigo = br.ReadString();
                    exp.ciudadano = br.ReadString();
                    exp.dni = br.ReadInt32();
                    exp.tipodeTramite = br.ReadString();
                    exp.direccion = br.ReadString();
                    exp.descripcion = br.ReadString();
                    exp.fecha = br.ReadString();
                    exp.estado = br.ReadString();
                    exp.esUrgente = br.ReadBoolean();

                    string tipo = exp.tipodeTramite.Trim();

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
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer estadísticas binarias: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (br != null) br.Close();
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