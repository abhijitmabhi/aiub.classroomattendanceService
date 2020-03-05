using System;
using System.Diagnostics;
using AIUB.FingerPrintSync.Framework.Annotations;
using AIUB.FingerPrintSync.Framework.Helpers.AppSettings;

namespace AIUB.FingerPrintSync.Framework.Helpers.EventLogHelper
{
    public class LogHelper:IDisposable
    {
        public static EventLog EventLog = new EventLog();

        public LogHelper()
       {
       }
       public static void IniEventLog()
       {
           if (EventLog==null)
               EventLog = new EventLog();

           // string SourceName = "WindowsService.ExceptionLog";
           if (!EventLog.SourceExists("AIUB Fingerprint Service"))
           {
               EventLog.CreateEventSource(
                  "AIUB Fingerprint Service", "AIUB Fingerprint Service Log");
           }
           EventLog.Source = "AIUB Fingerprint Service";
           EventLog.Log = "AIUB Fingerprint Service Log";//"Application"
   
       }

       public static void LogError(string message)
       {
           if (AppSettingsHelper.SettingsInstance.EnableErrorLog)
           {
               SendToWcfListener(message);
               EventLog.WriteEntry(message, EventLogEntryType.Error);
           }

          
       }
       public static void LogInfo(string message)
       {
           if (AppSettingsHelper.SettingsInstance.EnableInfoLog)
           {
              
               EventLog.WriteEntry(message, EventLogEntryType.Information);
               SendToWcfListener(message);
           }
       }
       public static void LogDebug(string message)
       {
           if (AppSettingsHelper.SettingsInstance.EnableDebugLog)
           {

               EventLog.WriteEntry(message, EventLogEntryType.Information);
               SendToWcfListener(message);
           }
       }
       public static void LogSuccess(string message)
       {
           if (AppSettingsHelper.SettingsInstance.EnableSuccessLog)
           {
             
               EventLog.WriteEntry(message, EventLogEntryType.SuccessAudit);
               SendToWcfListener(message);
           }
       }
       public static void LogWarning(string message)
       {
           if (AppSettingsHelper.SettingsInstance.EnableWarningLog)
           {
              
               EventLog.WriteEntry(message, EventLogEntryType.Warning);
               SendToWcfListener(message);
           }
       }
       public static void LogFailure(string message)
       {
           if (AppSettingsHelper.SettingsInstance.EnableErrorLog)
           {
              
               EventLog.WriteEntry(message, EventLogEntryType.FailureAudit);
               SendToWcfListener(message);
           }
       }

       public static void SendToWcfListener(string message)
       {
           //string appName = "AIUB.FingerPrintSync.WinService";//AIUB.FingerPrintSync.WinService
           //if (Process.GetCurrentProcess().ProcessName.Equals(appName))
               
       }
        public static void Clear()
        {
                EventLog.Clear();
           
        }

        public void Dispose()
       {
           if (EventLog != null)
               EventLog.Close();
       }
    }
}
