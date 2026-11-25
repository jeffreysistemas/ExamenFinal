using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenFinal
{
    public struct Expediente
    {
        public string codigo;
        public string ciudadano;
        public int dni;
        public string tipoTramite;
        public string direccion;
        public string descripcion;
        public string fecha;
        public string estado;
        public bool esUrgente;


    }

    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
