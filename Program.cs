using System;
using System.Windows.Forms;

namespace Журнал_V_Dip
{
    static class Data
    {
        public static bool Loading { get; set; }
        public static int Rows { get; set; }
        public static int Colum { get; set; }
    }


    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Enter());
        }
    }
}
