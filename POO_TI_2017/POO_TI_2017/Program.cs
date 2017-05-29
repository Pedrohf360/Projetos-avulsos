using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using POO_TI;

namespace POO_TI_2017
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Choice());
        }
    }
}
