using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace ExamenFinal
{
    public partial class Form5 : Form
    {
        private const string RutaArchivo = "expedientes_olivos.dat";
        private Expediente expedienteEncontrado;
        private bool hayExpedienteCargado = false;

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            ConfigurarColumnasTablas();
            CargarTodosLosTickets();
        }

        private void ConfigurarColumnasTablas()
        {
            dgvResultadoTicket.Columns.Clear();
            dgvResultadoTicket.Columns.Add("Código", "Código Ticket");
            dgvResultadoTicket.Columns.Add("Ciudadano", "Ciudadano");
            dgvResultadoTicket.Columns.Add("DNI", "DNI");
            dgvResultadoTicket.Columns.Add("Tipo", "Tipo Trámite");
            dgvResultadoTicket.Columns.Add("Dirección", "Dirección");
            dgvResultadoTicket.Columns.Add("Descripción", "Descripción");
            dgvResultadoTicket.Columns.Add("Fecha", "Fecha Registro");
            dgvResultadoTicket.Columns.Add("Estado", "Estado");

            dgvResultadoTicket.DefaultCellStyle.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            dgvResultadoTicket.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10F, FontStyle.Bold);

            dgvResultadoTicket.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultadoTicket.ReadOnly = true;
            dgvResultadoTicket.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvResultadoTicket.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (dgvResultadoTicket.Columns["Descripción"] != null)
            {
                dgvResultadoTicket.Columns["Descripción"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }

        private void CargarTodosLosTickets()
        {
            dgvResultadoTicket.Rows.Clear();
            hayExpedienteCargado = false;

            if (!File.Exists(RutaArchivo)) return;

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

                    dgvResultadoTicket.Rows.Add(
                        exp.codigo,
                        exp.ciudadano,
                        exp.dni.ToString("D8"),
                        exp.tipodeTramite,
                        exp.direccion,
                        exp.descripcion,
                        exp.fecha,
                        exp.estado
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar expedientes binarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (br != null) br.Close();
            }
        }

        private void btnBuscarTicket_Click(object sender, EventArgs e)
        {
            string CodigoBuscado = txtBuscarTicket.Text.Trim().ToUpper().Replace(" ", "");

            if (string.IsNullOrWhiteSpace(CodigoBuscado))
            {
                MessageBox.Show("Ingrese un código de expediente para buscar.", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscarTicket.Focus();
                return;
            }

            if (int.TryParse(CodigoBuscado, out _))
            {
                CodigoBuscado = "EXP-" + CodigoBuscado;
            }

            if (!File.Exists(RutaArchivo))
            {
                MessageBox.Show("Aún no existen expedientes registrados en el sistema.", "Sin Registros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvResultadoTicket.Rows.Clear();
            hayExpedienteCargado = false;

            BinaryReader br = null;
            bool band = false;

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

                    if (exp.codigo.ToUpper().Replace(" ", "") == CodigoBuscado)
                    {
                        band = true;
                        expedienteEncontrado = exp;
                        hayExpedienteCargado = true;

                        dgvResultadoTicket.Rows.Add(
                            exp.codigo,
                            exp.ciudadano,
                            exp.dni.ToString("D8"),
                            exp.tipodeTramite,
                            exp.direccion,
                            exp.descripcion,
                            exp.fecha,
                            exp.estado
                        );
                        break;
                    }
                }

                if (!band)
                {
                    MessageBox.Show($"No se encontró ningún expediente con el código '{CodigoBuscado}'.", "Búsqueda Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar en el archivo binario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (br != null) br.Close();
            }
        }
        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscarTicket.Clear();
            CargarTodosLosTickets();
            txtBuscarTicket.Focus();
        }

        private void dgvResultadoTicket_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                expedienteEncontrado.codigo = dgvResultadoTicket.Rows[e.RowIndex].Cells[0].Value.ToString();
                expedienteEncontrado.ciudadano = dgvResultadoTicket.Rows[e.RowIndex].Cells[1].Value.ToString();
                expedienteEncontrado.dni = int.Parse(dgvResultadoTicket.Rows[e.RowIndex].Cells[2].Value.ToString());
                expedienteEncontrado.tipodeTramite = dgvResultadoTicket.Rows[e.RowIndex].Cells[3].Value.ToString();
                expedienteEncontrado.direccion = dgvResultadoTicket.Rows[e.RowIndex].Cells[4].Value.ToString();
                expedienteEncontrado.descripcion = dgvResultadoTicket.Rows[e.RowIndex].Cells[5].Value.ToString();
                expedienteEncontrado.fecha = dgvResultadoTicket.Rows[e.RowIndex].Cells[6].Value.ToString();
                expedienteEncontrado.estado = dgvResultadoTicket.Rows[e.RowIndex].Cells[7].Value.ToString();
                expedienteEncontrado.esUrgente = expedienteEncontrado.tipodeTramite.IndexOf("Reclamo", StringComparison.OrdinalIgnoreCase) >= 0;
                hayExpedienteCargado = true;

                MessageBox.Show($"Expediente {expedienteEncontrado.codigo} seleccionado para imprimir constancia.", "Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnImprimirConstancia_Click(object sender, EventArgs e)
        {
            if (!hayExpedienteCargado)
            {
                MessageBox.Show("Primero busque o seleccione con doble clic un expediente válido antes de imprimir su constancia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += ImprimirConstancia_PrintPage;

            PrintPreviewDialog vistaPrevia = new PrintPreviewDialog();
            vistaPrevia.Document = pd;
            vistaPrevia.Width = 800;
            vistaPrevia.Height = 600;
            vistaPrevia.ShowDialog();
        }

        private void ImprimirConstancia_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fuenteTitulo = new Font("Segoe UI", 16, FontStyle.Bold);
            Font fuenteSubtitulo = new Font("Segoe UI", 11, FontStyle.Bold);
            Font fuenteCuerpo = new Font("Segoe UI", 10, FontStyle.Regular);
            Font fuenteNegrita = new Font("Segoe UI", 10, FontStyle.Bold);

            int x = 60;
            int y = 60;

            g.DrawString("MUNICIPALIDAD DISTRITAL DE LOS OLIVOS", fuenteTitulo, Brushes.DarkBlue, x, y);
            y += 30;
            g.DrawString("MESA DE PARTES DIGITAL - CONSTANCIA DE TRÁMITE", fuenteSubtitulo, Brushes.DimGray, x, y);
            y += 25;
            g.DrawLine(Pens.Black, x, y, 750, y);
            y += 25;

            g.DrawString($"Código de Expediente: {expedienteEncontrado.codigo}", fuenteNegrita, Brushes.Black, x, y);
            y += 25;
            g.DrawString($"Fecha y Hora de Ingreso: {expedienteEncontrado.fecha}", fuenteCuerpo, Brushes.Black, x, y);
            y += 25;
            g.DrawString($"Estado Actual: {expedienteEncontrado.estado}", fuenteNegrita, Brushes.DarkGreen, x, y);
            y += 25;
            g.DrawString($"Prioridad: {(expedienteEncontrado.esUrgente ? "URGENTE" : "NORMAL")}", fuenteCuerpo, Brushes.Black, x, y);
            y += 35;

            g.DrawString("DATOS DEL SOLICITANTE", fuenteSubtitulo, Brushes.DarkBlue, x, y);
            y += 25;
            g.DrawString($"Ciudadano: {expedienteEncontrado.ciudadano}", fuenteCuerpo, Brushes.Black, x, y);
            y += 25;
            g.DrawString($"DNI: {expedienteEncontrado.dni:D8}", fuenteCuerpo, Brushes.Black, x, y);
            y += 25;
            g.DrawString($"Dirección: {expedienteEncontrado.direccion}", fuenteCuerpo, Brushes.Black, x, y);
            y += 35;

            g.DrawString("DETALLE DEL EXPEDIENTE", fuenteSubtitulo, Brushes.DarkBlue, x, y);
            y += 25;
            g.DrawString($"Tipo de Trámite: {expedienteEncontrado.tipodeTramite}", fuenteCuerpo, Brushes.Black, x, y);
            y += 25;
            g.DrawString($"Descripción / Asunto: {expedienteEncontrado.descripcion}", fuenteCuerpo, Brushes.Black, x, y);
            y += 50;

            g.DrawLine(Pens.Gray, x, y, 750, y);
            y += 15;
            g.DrawString("Documento generado electrónicamente por el Sistema de Trámite Documentario.", fuenteCuerpo, Brushes.Gray, x, y);
        }
    }
}