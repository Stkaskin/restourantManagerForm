using restourantManagerForm.DataManager;
using restourantManagerForm.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restourantManagerForm
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
     //       new Fake().addAll();
           Application.Run(new PanelDisplay());
        }
    }
}
