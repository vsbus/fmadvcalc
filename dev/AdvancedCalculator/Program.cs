using System;
using System.Windows.Forms;

namespace AdvancedCalculator
{
    // ReSharper disable InconsistentNaming
    static class Program
    // ReSharper restore InconsistentNaming
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fmAdvancedCalculator());
        }
    }
}