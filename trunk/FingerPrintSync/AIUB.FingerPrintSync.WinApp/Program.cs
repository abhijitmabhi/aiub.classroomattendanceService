using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIUB.FingerPrintSync.Framework.Helpers.EventLogHelper;

namespace AIUB.FingerPrintSync.WinApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LogHelper.IniEventLog();
            LogHelper.EventLog.Source = "AIUB Fingerprint Service Installer";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
         
            Application.Run(new MainForm());

            
        }
    }
}
