using EMS___SCNE.UserControls___SuperAdmin;
using System;
using System.Windows.Forms;

namespace EMS___SCNE
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SuperAdmin());
            //Application.Run(new Dashboard());
            Application.Run(new Login());
            
        }
    }
}
