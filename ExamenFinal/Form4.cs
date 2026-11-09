using System;
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
                            datos[6].Trim()
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
    }
}