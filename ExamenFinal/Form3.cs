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
        private const string RutaArchivo = "expedientes_olivos.dat";
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

        private bool TicketExiste(string codigoBuscado)
        {
            if (!File.Exists(RutaArchivo)) return false;

            BinaryReader br = null;
            bool existe = false;

            try
            {
                br = new BinaryReader(new FileStream(RutaArchivo, FileMode.Open, FileAccess.Read));
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

                    if (exp.codigo == codigoBuscado)
                    {
                        existe = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar ticket: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (br != null) br.Close();
            }

            return existe;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtCiudadano.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                cmbTipodeTramite.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDni.Text.Trim(), out int dniNumero) || txtDni.Text.Trim().Length != 8)
            {
                MessageBox.Show("El DNI debe contener exactamente 8 dígitos numéricos.", "DNI Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return;
            }

            string codigoTicket;
            do
            {
                codigoTicket = GenerarCodigoTicket();
            } while (TicketExiste(codigoTicket));

            Expediente nuevoExp = new Expediente();
            nuevoExp.codigo = codigoTicket;
            nuevoExp.ciudadano = txtCiudadano.Text.Trim();
            nuevoExp.dni = dniNumero;
            nuevoExp.tipodeTramite = cmbTipodeTramite.SelectedItem.ToString();
            nuevoExp.direccion = txtDireccion.Text.Trim();
            nuevoExp.descripcion = txtDescripcion.Text.Trim();
            nuevoExp.fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            nuevoExp.estado = "Ingresado";

            nuevoExp.esUrgente = nuevoExp.tipodeTramite.IndexOf("Reclamo", StringComparison.OrdinalIgnoreCase) >= 0;

            BinaryWriter bw = null;


            try
            {
                bw = new BinaryWriter(new FileStream(RutaArchivo, FileMode.Append, FileAccess.Write));

                bw.Write(nuevoExp.codigo);
                bw.Write(nuevoExp.ciudadano);
                bw.Write(nuevoExp.dni);
                bw.Write(nuevoExp.tipodeTramite);
                bw.Write(nuevoExp.direccion);
                bw.Write(nuevoExp.descripcion);
                bw.Write(nuevoExp.fecha);
                bw.Write(nuevoExp.estado);
                bw.Write(nuevoExp.esUrgente);
                MessageBox.Show($"¡Expediente registrado con éxito!\nCódigo de Ticket: {nuevoExp.codigo}",
                                "Mesa de Partes - Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();

                FormDashboard dashboard = Application.OpenForms.OfType<FormDashboard>().FirstOrDefault();
                if (dashboard != null)
                {
                    dashboard.AbrirFormularioEnPanel<Form4>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al escribir en el archivo binario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (bw != null) bw.Close();
            }
        }

        private void LimpiarCampos()
        {
            txtCiudadano.Clear();
            txtDni.Clear();
            cmbTipodeTramite.SelectedIndex = -1;
            txtDireccion.Clear();
            txtDescripcion.Clear();
            txtCiudadano.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
