using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ExamenFinal
{
    public partial class Form5 : Form
    {

        private const string RutaArchivo = "expediente_olivos.txt";
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

            if (File.Exists(RutaArchivo))
            {
                string[] lineas = File.ReadAllLines(RutaArchivo);

                foreach (string linea in lineas)
                {

                    if (!string.IsNullOrWhiteSpace(linea))
                    {
                        string[] datos = linea.Split('|');

                        if (datos.Length >= 7)
                        {
                            string estado = datos.Length >= 8 ? datos[7].Trim() : "Ingresado";
                            dgvResultadoTicket.Rows.Add(
                                datos[0].Trim(),
                                datos[1].Trim(),
                                datos[2].Trim(),
                                datos[3].Trim(),
                                datos[4].Trim(),
                                datos[5].Trim(),
                                datos[6].Trim(),
                                estado
                                );

                        }
                    }

                }
            }

        }

        private void btnBuscarTicket_Click(object sender, EventArgs e)
        {
            string CodigoBuscado = txtBuscarTicket.Text.Trim();

            if (string.IsNullOrWhiteSpace(CodigoBuscado))
            {
                MessageBox.Show("Por favor Ingrese un Código de Ticket para realizar la Búsqueda", "Campo Vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscarTicket.Focus();
                return;

            }
            string busquedaLimpia = CodigoBuscado.Replace(" ", "");

            dgvResultadoTicket.Rows.Clear();
            bool encontrado = false;

            if (File.Exists(RutaArchivo))
            {
                string[] lineas = File.ReadAllLines(RutaArchivo);

                foreach (string linea in lineas)
                {
                    if (!string.IsNullOrWhiteSpace(linea))
                    {
                        string[] datos = linea.Split('|');

                        if (datos.Length >= 7)
                        {


                            string codigoEnArchivo = datos[0].Trim();
                            string codigoSinEspacios = codigoEnArchivo.Replace(" ", "");


                            if (codigoSinEspacios.Equals(busquedaLimpia, StringComparison.OrdinalIgnoreCase) ||
                                codigoEnArchivo.IndexOf(CodigoBuscado, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                string estado = datos.Length >= 8 ? datos[7].Trim() : "Ingresado";
                                dgvResultadoTicket.Rows.Add(
                                    datos[0].Trim(),
                                    datos[1].Trim(),
                                    datos[2].Trim(),
                                    datos[3].Trim(),
                                    datos[4].Trim(),
                                    datos[5].Trim(),
                                    datos[6].Trim(),
                                    estado
                                    );


                                encontrado = true;

                            }
                        }
                    }
                }
            }
            if (!encontrado)
            {
                MessageBox.Show($"No se encontraron ningún expediente registrado con el código '{CodigoBuscado}'.", "Sin coincidencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTodosLosTickets();
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscarTicket.Clear();
            CargarTodosLosTickets();
            txtBuscarTicket.Focus();

        }
        private void btnImprimirConstancia_Click(object sender, EventArgs e)
        {
            if (dgvResultadoTicket.CurrentRow == null || dgvResultadoTicket.CurrentRow.Index < 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un expediente de la tabla para generar su constancia.",
                    "Selección Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DataGridViewRow fila = dgvResultadoTicket.CurrentRow;

            string codigo = fila.Cells[0].Value != null ? fila.Cells[0].Value.ToString() : "";
            string ciudadano = fila.Cells[1].Value != null ? fila.Cells[1].Value.ToString() : "";
            string dni = fila.Cells[2].Value != null ? fila.Cells[2].Value.ToString() : "";
            string tipo = fila.Cells[3].Value != null ? fila.Cells[3].Value.ToString() : "";
            string direccion = fila.Cells[4].Value != null ? fila.Cells[4].Value.ToString() : "";
            string descripcion = fila.Cells[5].Value != null ? fila.Cells[5].Value.ToString() : "";
            string fecha = fila.Cells[6].Value != null ? fila.Cells[6].Value.ToString() : "";


            string estado = fila.Cells.Count >= 8 && fila.Cells[7].Value != null
                    ? fila.Cells[7].Value.ToString()
                    : "Ingresado";

            string ticketTexto =
          "=======================================\n" +
          "        MUNICIPALIDAD DE LOS OLIVOS\n" +
          "    MESA DE PARTES DIGITAL - CONSTANCIA OFICIAL\n" +
          "=======================================\n" +
          $" CÓDIGO TICKET : {codigo}\n" +
          $" FECHA REGISTRO: {fecha}\n" +
          $" ESTADO ACTUAL : {estado}\n\n" +
          " DATOS DEL CIUDADANO:\n" +
          " ---------------------------------------\n" +
          $" Nombre        : {ciudadano}\n" +
          $" DNI           : {dni}\n" +
          $" Dirección     : {direccion}\n\n" +
          " DETALLE DE LA SOLICITUD:\n" +
          " ---------------------------------------\n" +
          $" Tipo Trámite  : {tipo}\n" +
          $" Descripción   : {descripcion}\n\n" +
          "=======================================\n" +
          " Conserve este documento para realizar el seguimiento\n" +
          " de su trámite en la plataforma institucional.\n" +
          "=======================================";


            MessageBox.Show(ticketTexto, $"Constancia Oficial - {codigo}", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dgvResultadoTicket_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string codigo = dgvResultadoTicket.Rows[e.RowIndex].Cells["Código"].Value?.ToString();
                string ciudadano = dgvResultadoTicket.Rows[e.RowIndex].Cells["Ciudadano"].Value?.ToString();
                string descripcion = dgvResultadoTicket.Rows[e.RowIndex].Cells["Descripción"].Value?.ToString();


                string detalle = $"CÓDIGO: {codigo}\n" +
                                 $"CIUDADANO: {ciudadano}\n\n" +
                                 $"DESCRIPCIÓN COMPLETA:\n{descripcion}";

                MessageBox.Show(detalle, "Detalle completo del expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
     }
}