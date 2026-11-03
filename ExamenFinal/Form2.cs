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




        public void AbrirFormularioEnPanel<T>() where T : Form, new()
        {
            Form formExistente = panelContenedor.Controls.OfType<T>().FirstOrDefault();

            if (formExistente != null)
            {
                formExistente.BringToFront();
                return;
            }
            if (panelContenedor.Controls.Count > 0)
            {
                panelContenedor.Controls.Clear();
            }


            T nuevoFomr = new T();
            nuevoFomr.TopLevel = false;

            nuevoFomr.FormBorderStyle = FormBorderStyle.None;
            nuevoFomr.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(nuevoFomr);
            panelContenedor.Tag = nuevoFomr;
            nuevoFomr.Show();
            nuevoFomr.BringToFront();
        }


        private void btnNuevoTramite_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel<FormRegistro>();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form1 formLogin = Application.OpenForms.OfType<Form1>().FirstOrDefault();

            if (formLogin != null)
            {
                formLogin.LimpiarYEnfocar();
                formLogin.Show();
                formLogin.BringToFront();
                formLogin.Focus();
            }
            else
            {
                Form1 nuevoLogin = new Form1();
                nuevoLogin.Show();
            }
            this.Close();
        }

        private void btnConsultarTicket_Click(object sender, EventArgs e)
        {
               
        }

        private void btnVerTabla_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel<Form4>();
        }
    }
}

