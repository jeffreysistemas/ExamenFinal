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
using System.Runtime.InteropServices;

namespace ExamenFinal
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();  
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void MoverVentana()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panelCabecera_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoverVentana();
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (usuario == "admin" && password == "1234")
            {
                MessageBox.Show("¡ Acceso correcto ! Bienvenido al sistema.");

                AbrirDashboardUnico();
                
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta. Intente nuevamente");

                txtUser.Clear();
                txtPassword.Clear();
                txtUser.Focus();
            }

        }
        public void LimpiarYEnfocar()
        {
            txtUser.Clear();
            txtPassword.Clear();
            txtUser.Focus();
        }



        private void AbrirDashboardUnico()
        {
            FormDashboard dashboardExistente = Application.OpenForms.OfType<FormDashboard>().FirstOrDefault();

            if (dashboardExistente != null)
            {
                dashboardExistente.BringToFront();
                dashboardExistente.Focus();

            }
            else
            {
                FormDashboard nuevoDashboard = new FormDashboard();
                nuevoDashboard.Show();
            }

            this.Hide();
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de Salir de la Aplicación ?", "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}