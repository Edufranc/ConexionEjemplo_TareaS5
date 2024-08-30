using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionEjemplo
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread] // Indica que el modelo de subprocesamiento es de un único subproceso de apartamento (STA).
        static void Main()
        {
            // Habilita los estilos visuales para la aplicación.
            Application.EnableVisualStyles();

            // Establece si la aplicación debe usar la compatibilidad de representación de texto predeterminada.
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la aplicación y abre el formulario principal (Form1).
            Application.Run(new Form1());
        }
    }
}
