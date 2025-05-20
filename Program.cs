using System;
using System.Windows.Forms;

namespace Rendeleskezelo
{
//asda
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); //asd
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}