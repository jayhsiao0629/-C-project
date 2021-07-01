using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Menu menu = new Menu();
            Menu menu = new Menu(500, 500);

            menu.forms.Add(new Form1());
            menu.forms.Add(new Form3());
            
            menu.Create_Button();
            menu.Show();
        }
    }
}
