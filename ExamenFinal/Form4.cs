using System;
using System.IO;
using System.Windows.Forms;

namespace ExamenFinal
{
    public partial class Form4 : Form
    {
        private const string RutaArchivo = "expedientes_olivos.dat";

        public Form4()
        {
            InitializeComponent();
            CargarExpedientesEnTabla();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if (cmbFiltroCategoria.Items.Count > 0 && cmbFiltroCategoria.SelectedIndex == -1)
            {
                cmbFiltroCategoria.SelectedIndex = 0;
            }

            CargarExpedientesEnTabla();
        }

        public void CargarExpedientesEnTabla()
        {
            dataGridView1.Rows.Clear();

            if (!File.Exists(RutaArchivo)) return;

            string filtro = cmbFiltroCategoria.SelectedItem != null
                            ? cmbFiltroCategoria.SelectedItem.ToString()
                            : "[Todos]";

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

                    if (filtro == "[Todos]" || exp.tipodeTramite.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        dataGridView1.Rows.Add(
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer expedientes binarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (br != null) br.Close();
            }
        }

        private void cmbFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarExpedientesEnTabla();
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila de la tabla para cambiar su estado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(RutaArchivo)) return;

            string codigoObjetivo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string estadoActual = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

            string nuevoEstado = "Ingresado";
            if (estadoActual == "Ingresado") nuevoEstado = "En Proceso";
            else if (estadoActual == "En Proceso") nuevoEstado = "Finalizado";
            else
            {
                MessageBox.Show("Este expediente ya se encuentra Finalizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BinaryReader br = null;
            BinaryWriter bw_aux = null;
            string fic_temp = "temporal.dat";
            bool bandera = false;

            try
            {
                br = new BinaryReader(new FileStream(RutaArchivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                bw_aux = new BinaryWriter(new FileStream(fic_temp, FileMode.Create, FileAccess.Write));

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

                    if (exp.codigo == codigoObjetivo)
                    {
                        exp.estado = nuevoEstado;
                        bandera = true;
                    }

                    bw_aux.Write(exp.codigo);
                    bw_aux.Write(exp.ciudadano);
                    bw_aux.Write(exp.dni);
                    bw_aux.Write(exp.tipodeTramite);
                    bw_aux.Write(exp.direccion);
                    bw_aux.Write(exp.descripcion);
                    bw_aux.Write(exp.fecha);
                    bw_aux.Write(exp.estado);
                    bw_aux.Write(exp.esUrgente);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (br != null) br.Close();
                if (bw_aux != null) bw_aux.Close();

                if (File.Exists(fic_temp))
                {
                    File.Delete(RutaArchivo);
                    File.Move(fic_temp, RutaArchivo);
                }
            }

            if (bandera)
            {
                MessageBox.Show($"Estado del expediente {codigoObjetivo} actualizado a: {nuevoEstado}", "Estado Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarExpedientesEnTabla();
            }
        }

        private void btnEliminarFinalizados_Click(object sender, EventArgs e)
        {
            if (!File.Exists(RutaArchivo)) return;

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de eliminar permanentemente todos los expedientes con estado 'Finalizado'?",
                "Confirmar Depuración", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            BinaryReader br = null;
            BinaryWriter bw_aux = null;
            string fic_temp = "temporal.dat";
            int eliminados = 0;

            try
            {
                br = new BinaryReader(new FileStream(RutaArchivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                bw_aux = new BinaryWriter(new FileStream(fic_temp, FileMode.Create, FileAccess.Write));

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

                    if (exp.estado == "Finalizado")
                    {
                        eliminados++;
                    }
                    else
                    {
                        bw_aux.Write(exp.codigo);
                        bw_aux.Write(exp.ciudadano);
                        bw_aux.Write(exp.dni);
                        bw_aux.Write(exp.tipodeTramite);
                        bw_aux.Write(exp.direccion);
                        bw_aux.Write(exp.descripcion);
                        bw_aux.Write(exp.fecha);
                        bw_aux.Write(exp.estado);
                        bw_aux.Write(exp.esUrgente);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al depurar registros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (br != null) br.Close();
                if (bw_aux != null) bw_aux.Close();

                if (File.Exists(fic_temp))
                {
                    File.Delete(RutaArchivo);
                    File.Move(fic_temp, RutaArchivo);
                }
            }

            if (eliminados > 0)
            {
                MessageBox.Show($"Se eliminaron {eliminados} expediente(s) finalizado(s).", "Depuración Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarExpedientesEnTabla();
            }
            else
            {
                MessageBox.Show("No hay expedientes en estado 'Finalizado' para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}