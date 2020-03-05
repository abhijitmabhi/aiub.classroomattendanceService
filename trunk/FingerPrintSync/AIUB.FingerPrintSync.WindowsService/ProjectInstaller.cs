using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using AIUB.FingerPrintSync.Framework.Helpers.AppSettings;
using AIUB.FingerPrintSync.Framework.Helpers.EventLogHelper;
using AIUB.FingerPrintSync.WinService;


///read http://support.microsoft.com/kb/816169/en-us
/// 
namespace AIUB.FingerPrintSync.WinService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
       //private const string _ServiceName = "";
        TimeSpan _waitTime = new TimeSpan(0, 1, 0);
        public ProjectInstaller()
        {
            InitializeComponent();
            LogHelper.IniEventLog();
            LogHelper.EventLog.Source = "AIUB Fingerprint Service Installer";
            
        }
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Install(IDictionary stateSaver)
        {
            StopService();
            base.Install(stateSaver);
        }
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
           
            base.Commit(savedState);
            StartService();
        }
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);
        }
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {
            StopService();
            LogHelper.EventLog.Clear();
            base.Uninstall(savedState);
        }
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        protected override void OnAfterUninstall(IDictionary savedState)
        {

            AppSettingsHelper.DeleteSettingsFile();
            base.OnAfterUninstall(savedState);
        }



        private bool StartService()
        {
            try
            {
                using (ServiceController service = new ServiceController(serviceInstaller1.ServiceName))
                {
                    if (service.Status != ServiceControllerStatus.Running)
                    {
                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running, _waitTime);
                    
                    }
                    service.Refresh();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("Exception: {0} \n\nStack: {1}", ex.Message, ex.StackTrace);
                LogHelper.LogError(message);
                return false;
            }

        }
        private bool StopService()
        {
            try
            {
                using (ServiceController service = new ServiceController(serviceInstaller1.ServiceName))
                {

                    if (service.Status == ServiceControllerStatus.Running)
                    {
                        service.Stop();
                        service.WaitForStatus(ServiceControllerStatus.Stopped, _waitTime);
                    }
                    service.Refresh();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("Exception: {0} \n\nStack: {1}", ex.Message, ex.StackTrace);
                LogHelper.EventLog.WriteEntry(message, EventLogEntryType.Error);
                return false;
            }
        }

    }
    
}
