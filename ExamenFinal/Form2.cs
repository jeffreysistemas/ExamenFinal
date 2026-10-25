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
    public partial class FormDashboard : System.Windows.Forms.Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRegistro formRegistro = new FormRegistro();

            formRegistro.ShowDialog();

            CargarExpedientesEnTabla();
        }
    }
}
