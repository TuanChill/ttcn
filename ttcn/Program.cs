using System;
using System.Globalization;
using System.Windows.Forms;

namespace ttcn
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo.CurrentCulture = new CultureInfo("vi-VN");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new DangNhap());
            // Application.Run(new NL());
             Application.Run(new formNL());;
          // Application.Run(new formNguyenlieu());
        }
    }
}
