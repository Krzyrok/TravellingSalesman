using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravellingSalesman
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
            TravellingSalesmanGui gui = new TravellingSalesmanGui();
            TravellingSalesmanController controller = new TravellingSalesmanController(gui);
            Application.Run(gui);
        }
    }
}
