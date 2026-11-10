using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ExamenFinal
{
    public partial class Form4 : Form
    {

        private const string RutaArchivo = "expediente_olivos.txt";

        public Form4()
        {
            InitializeComponent();
            CargarExpedientesEnTabla();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if (cmbFiltroCategoria.Items.Count > 0)
            {
                cmbFiltroCategoria.SelectedIndex = 0;
            }
            CargarExpedientesEnTabla();
        }

        public void CargarExpedientesEnTabla()
        {
            dataGridView1.Rows.Clear();

            if (!File.Exists(RutaArchivo)) return;

            string[] lineas = File.ReadAllLines(RutaArchivo);
            string filtro = cmbFiltroCategoria.SelectedItem != null ? cmbFiltroCategoria.SelectedItem.ToString() : "[Todos]";



            foreach (string linea in lineas)
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    string[] datos = linea.Split('|');

                    if (datos.Length >= 7)
                    {

                        string tipoTramite = datos[3].Trim();

                        if (filtro == "[Todos]" || tipoTramite.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            string estado = datos.Length >= 8 ? datos[7].Trim() : "Ingresado";

                            dataGridView1.Rows.Add(
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

        private void cmbFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarExpedientesEnTabla();
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Por favor, seleccione un expediente de la tabla.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string codigoSeleccionado = dataGridView1.CurrentRow.Cells[0].Value?.ToString();

            if (string.IsNullOrWhiteSpace(codigoSeleccionado))
            {
                MessageBox.Show("No se pudo obtener el código del expediente seleccionado.", "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string estadoActual = "Ingresado";

            if (dataGridView1.CurrentRow.Cells.Count >= 8 && dataGridView1.CurrentRow.Cells[7].Value != null)
            {
                estadoActual = dataGridView1.CurrentRow.Cells[7].Value.ToString().Trim();
            }


            string nuevoEstado = "Ingresado";

            if (estadoActual.Equals("Ingresado", StringComparison.OrdinalIgnoreCase))
            {
                nuevoEstado = "En Proceso";
            }
            else if (estadoActual.Equals("En Proceso", StringComparison.OrdinalIgnoreCase))
            {
                nuevoEstado = "Finalizado";
            }
            else
            {
                nuevoEstado = "Ingresado";
            }

            if (File.Exists(RutaArchivo))
            {
                string[] lineas = File.ReadAllLines(RutaArchivo);
                for (int i = 0; i < lineas.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(lineas[i]))
                    {
                        string[] datos = lineas[i].Split('|');
                        if (datos.Length >= 7 && datos[0].Trim().Equals(codigoSeleccionado.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            string codigo = datos[0].Trim();
                            string ciudadano = datos[1].Trim();
                            string dni = datos[2].Trim();
                            string tipo = datos[3].Trim();
                            string direccion = datos[4].Trim();
                            string descripcion = datos[5].Trim();
                            string fecha = datos[6].Trim();


                            lineas[i] = $"{codigo}|{ciudadano}|{dni}|{tipo}|{direccion}|{descripcion}|{fecha}|{nuevoEstado}";
                            break;
                        }
                    }
                }
                File.WriteAllLines(RutaArchivo, lineas);

                MessageBox.Show($"El estado del expediente '{codigoSeleccionado}' se actualizó a: [{nuevoEstado}]", "Estado Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarExpedientesEnTabla();
            }
        }

        private void btnEliminarFinalizados_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("Está seguro de que desea eliminar permanentemente todos los expedientes en estado 'Finalizado'?\n\nEsta acción no se puede deshacer", "Confirmación de Eliminación",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            if (File.Exists(RutaArchivo))
            {
                string[] lineas = File.ReadAllLines(RutaArchivo);
                List<string> lineasGuardar = new List<string>();
                int cantidadEliminados = 0;

                foreach (string linea in lineas)
                {
                    if (!string.IsNullOrWhiteSpace(linea))
                    {
                        string[] datos = linea.Split('|');

                        string estado = datos.Length >= 8 ? datos[7].Trim() : "Ingresado";

                        if (estado.Equals("Finalizado", StringComparison.OrdinalIgnoreCase))
                        {
                            cantidadEliminados++;
                        }
                        else
                        {
                            lineasGuardar.Add(linea);
                        }
                    }
                }
                if (cantidadEliminados > 0)
                {
                    File.WriteAllLines(RutaArchivo, lineasGuardar);

                    MessageBox.Show($"Depuración completada con éxito.\n\nSe eliminaron {cantidadEliminados} expediente(s) finalizado(s).", "Mantenimiento Realizado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);


                    CargarExpedientesEnTabla();
                }
                else
                {
                    MessageBox.Show("No se encontraron expedientes en estado 'Finalizado' para eliminar.", "Sin Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
        }
    }
}