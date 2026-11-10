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
                dgvResultadoTicket.Columns["Descripción"].DefaultCellStyle.WrapMode= DataGridViewTriState.True;
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

        private void dgvResultadoTicket_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string codigo = dgvResultadoTicket.Rows[e.RowIndex].Cells["Código"].Value?.ToString();
                string ciudadano = dgvResultadoTicket.Rows[e.RowIndex].Cells["Ciudadano"].Value?.ToString();
                string descripcion = dgvResultadoTicket.Rows[e.RowIndex].Cells["Descripción"].Value?.ToString();


                string detalle = $"CÓDIGO: {codigo}\n" +
                                 $"CIUDADANO: {ciudadano}\n\n"+
                                 $"DESCRIPCIÓN COMPLETA:\n{descripcion}";

                MessageBox.Show(detalle, "Detalle completo del expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
