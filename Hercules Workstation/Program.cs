using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hercules_Workstation
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

            Hercules_Workstation_Authentication loginForm = new Hercules_Workstation_Authentication();
            Application.Run(loginForm);

            if (loginForm.loginSuccessful)
            {
                Application.Run(new HerculesWorkstation());
            }
            
        }
    }
}
