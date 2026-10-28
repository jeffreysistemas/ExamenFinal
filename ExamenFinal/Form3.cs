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
    public partial class FormRegistro : System.Windows.Forms.Form

    {
        private const string RutaArchivo = "expediente_olivos.txt";
        public FormRegistro()
        {
            InitializeComponent();
        }

        private string GenerarCodigoTicket()
        {
            Random rand = new Random();
            int numeroAleatorio = rand.Next(1000, 9999);
            return $"EXP - {numeroAleatorio}";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            string nombre = txtCiudadano.Text.Trim();
            string dni = txtDni.Text.Trim();
            string tipoTramite = cmbTipodeTramite.SelectedItem != null ? cmbTipodeTramite.SelectedItem.ToString() : "";
            string direccion = txtDireccion.Text.Trim();
            string descripcion  = txtDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(tipoTramite) || string.IsNullOrWhiteSpace(direccion) || string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios antes de registrar" , "Campos incompletos" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string codigoTicket = GenerarCodigoTicket();

            string fechaRegistro = DateTime.Now.ToString("yyyy-MM--dd  HH:mm");

            string lineaExpediente = $"{codigoTicket} |  {nombre} | {dni} | {tipoTramite} | {direccion} | {descripcion} | {fechaRegistro}";

            try
            {
                File.AppendAllText(RutaArchivo, lineaExpediente + Environment.NewLine);

                MessageBox.Show($"Expediente registrado con éxito! \n\n Código asignado : {codigoTicket}", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar el archivo : " + ex.Message, "Error de Persistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
