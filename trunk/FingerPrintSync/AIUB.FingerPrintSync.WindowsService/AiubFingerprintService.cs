using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using AIUB.FingerPrintSync.Framework.Helpers.AppSettings;
using AIUB.FingerPrintSync.Framework.Helpers.EventLogHelper;
using AIUB.FingerPrintSync.Framework.WcfComunication;
using AIUB.FingerPrintSync.Framework.WcfComunication.Client;
using AIUB.FingerPrintSync.WinService;

namespace AIUB.FingerPrintSync.WinService
{
    public partial class AiubFingerprintService : ServiceBase
    {
        public AiubFingerprintService()
        {
            InitializeComponent();
            LogHelper.IniEventLog();
           // WcfClient.Connect();
        }

        private ServiceTask _task;
        protected override void OnStart(string[] args)
        {
           
            LogHelper.LogInfo("AIUB Fingerprint Service In OnStart");
            if(!AppSettingsHelper.ReloadSettings())
                LogHelper.LogError("Failed to create settings");

             _task=new ServiceTask();
             _task.RestartScheduler();

             //LogHelper.LogInfo("Process Name: "+Process.GetCurrentProcess().ProcessName);
        }

        protected override void OnStop()
        {
            LogHelper.LogInfo("AIUB Fingerprint Service In onStop.");
            if (_task != null) _task.StopScheduler();

            WcfClient.Close();
        }

        protected override void OnPause()
        {
            LogHelper.LogInfo("AIUB Fingerprint Service In onPause.");
            if (_task != null) _task.StopScheduler();
           
            base.OnPause();
        }

        protected override void OnShutdown()
        {
            
            base.OnShutdown();
        }
    }
}
