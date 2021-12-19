using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Basit_Ajanda
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Cls.SQLConnectionClass.Baglanti(); 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Anaform());
        }
    }
}
