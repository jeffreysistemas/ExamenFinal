using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenFinal
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            if(usuario == "admin" && password == "1234")
            {
                MessageBox.Show("¡ Acceso correcto ! Bienvenido al sistema.");

                FormDashboard dashboard = new FormDashboard();

                dashboard.Show();

                this.Hide();

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta. Intente nuevamente");

                txtUser.Clear();
                txtPassword.Clear();
                txtUser.Focus();
            }

                    
        }
    }
