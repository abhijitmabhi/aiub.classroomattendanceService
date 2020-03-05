using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using AIUB.FingerPrintSync.Framework.Helpers.EventLogHelper;
using AIUB.FingerPrintSync.WinService;

namespace AIUB.FingerPrintSync.WinService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            try
            {
                LogHelper.IniEventLog();
                //"AIUB Fingerprint Service"

                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] { new AiubFingerprintService() };
                ServiceBase.Run(ServicesToRun);
            }

            catch (Exception ex)
            {
                string SourceName = "WindowsService.ExceptionLog";
                //if (!EventLog.SourceExists(SourceName))
                //{
                //    EventLog.CreateEventSource(SourceName, "Application");
                //}

                //EventLog eventLog = new EventLog();
                //eventLog.Source = SourceName;
                string message = string.Format("Exception: {0} \n\nStack: {1}", ex.Message, ex.StackTrace);
                LogHelper.EventLog.WriteEntry(message, EventLogEntryType.Error);
            }
        }
    }
}
