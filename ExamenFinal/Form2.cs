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
    public partial class FormDashboard : System.Windows.Forms.Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void CargarExpedientesEnTabla()
        {
            try
            {
                string rutaArchivo = "expediente_olivos.txt";

                if (!File.Exists(rutaArchivo))
                {
                    return;
                }

                dataGridView1.Rows.Clear();

                string[] lineas = File.ReadAllLines(rutaArchivo);

                foreach (string linea in lineas)
                {
                    if (!string.IsNullOrWhiteSpace(linea))
                    {
                        string[] datos = linea.Split('|');

                        if (datos.Length >= 7)
                        {
                            dataGridView1.Rows.Add(datos[0], datos[1], datos[2], datos[3], datos[4], datos[5], datos[6]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en cargar los expedientes : " + ex.Message "Error de lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            FormRegistro formRegistro = new FormRegistro();

            formRegistro.ShowDialog();

            CargarExpedientesEnTabla();
        }
    }
}
