﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AIUB.FingerPrintSync.Framework.Facade;
using AIUB.FingerPrintSync.Framework.Helpers.AppSettings;
using AIUB.FingerPrintSync.Framework.Helpers.EventLogHelper;
using AIUB.FingerPrintSync.Framework.WcfComunication;
using AIUB.FingerPrintSync.Framework.WcfComunication.Client;
using AIUB.FingerPrintSync.ServiceManager;
using AIUB.FingerPrintSync.ServiceManager.AttendanceService;
using AIUB.FingerPrintSync.WinService.Properties;

namespace AIUB.FingerPrintSync.WinService
{
    public class ServiceTask:IDisposable
    {
        int _totalLog = 0;
        int _completed = 0;
        int _success = 0;
        public ServiceTask()
        {
            InitializeSheduler();
        }

        private void DoPendingTask()
        {
             string error;
            if (AppSettingsHelper.SettingsInstance.EnableAutoRemoveLog)
            {
                LogHelper.Clear();
                LogHelper.LogInfo("Previous Log cleared.");
                WcfClient.SendMessage("Previous Log cleared.");
            }

            if(AppSettingsHelper.SettingsInstance.AttendanceEnableAutoSync)
            {
                if (IsTimeToRun(AppSettingsHelper.SettingsInstance.AttendanceSyncLastOccured,
                    AppSettingsHelper.SettingsInstance.AttendanceSyncIntervalInMinute))
                {
                    AppSettingsHelper.ReloadSettings();
                    AppSettingsHelper.SettingsInstance.AttendanceSyncLastOccured = DateTime.Now;
                    AppSettingsHelper.SaveSettings(out error);
                    //call Sheduled task
                    LogHelper.LogInfo("Attendance Sync Start...");
                    WcfClient.SendMessage("Attendance Sync Start...");
                    SyncAttendance();
                }
                //Console.WriteLine(String.Format("({0}).", DateTime.Now.ToString("hh:mm:ss tt dd-MM-yy")));
            }
            if (AppSettingsHelper.SettingsInstance.EnableAutoEmailDeviceStatus)
            {
                if (IsTimeToRun(AppSettingsHelper.SettingsInstance.EmailSendLastOccured,
                    AppSettingsHelper.SettingsInstance.EmailDeviceStatusIntervalInHour*60))
                {
                    AppSettingsHelper.ReloadSettings();
                    AppSettingsHelper.SettingsInstance.EmailSendLastOccured = DateTime.Now;
                    AppSettingsHelper.SaveSettings(out error);
                    SendEmailDeviceStatusAsync();
                }
                
            }
            
        }

        private void SyncAttendance()
        {
            try
            {
               
                //throw new Exception("test");
                LogHelper.LogInfo("Collecting new attendance from suprima DB...");
                WcfClient.SendMessage("Collecting new attendance from suprima DB...");

                var logs = AttendanceFacade.GetUnsyncAttendance();

                _totalLog = logs.Count;
                if (_totalLog>0)
                { 
                    LogHelper.LogInfo(string.Format("{0} log Uploading to HR...", _totalLog));
                    WcfClient.SendMessage(string.Format("{0} log Uploading to HR...", _totalLog));
                }

                string message="";
                foreach (var log in logs)
                {
                    //safe to cancel task here
                    //if ((CancellationPending))
                    //{
                    //    break;
                    //}
                    SubmitResult2Ofstring result = AttandanceServiceManager.PostFingerPrintAttendance(Convert.ToInt32(log.UserId),
                        log.LogTime, log.DeviceId, log.IpAddress, log.RoomNumber);

                    if (result.IsSuccess)
                    {
                        log.IsSynced = true;
                        _success++;
                    }
                    else
                    {

                    }

                    message += string.Format("id:{0} -> Time:{1}\n", log.UserId,
                        log.LogTime.ToString("g"));
                   
                    _completed++;
                    //int cc=completed/totalLog*100;
                   //PrintMessage("Uploading to HR " + _completed + "/" + _totalLog);

                }
                //WcfClient.SendMessage(message);
                LogHelper.LogDebug(message);
               
                if (_success > 0)
                {
                    //LogHelper.LogInfo("Updating Suprima DB status, please wait...");
                    //WcfClient.SendMessage("Updating Suprima DB status, please wait...");
                    bool success = AttendanceFacade.UpdateLogsStatus(logs);
                }
                SyncAttendanceCompleted();
            }
            catch (Exception ex)
            {
                string message = string.Format("Exception: {0} \n\nStack: {1}", ex.Message, ex.StackTrace);
                WcfClient.SendMessage(message);
                LogHelper.LogError(message);
            }
            finally
            {
                //GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }

        private void SyncAttendanceCompleted()
        {
            string msg = "";
           if (_totalLog == 0)
            {
                LogHelper.LogSuccess(String.Format("No new attendance pending to synchronize, Task finished({0}).", DateTime.Now.ToString("hh:mm:ss tt dd-MM-yy")));
                WcfClient.SendMessage(String.Format("No new attendance pending to synchronize, Task finished({0}).", DateTime.Now.ToString("hh:mm:ss tt dd-MM-yy")));
            }
            else
            {
                if (_success > 0)
                {
                    LogHelper.LogSuccess(String.Format("Total {0}/{1} attendace synchronized.Task finished({2}).", _success, _totalLog, DateTime.Now.ToString("hh:mm:ss tt dd-MM-yy")));
                    WcfClient.SendMessage(String.Format("Total {0}/{1} attendace synchronized.Task finished({2}).", _success, _totalLog, DateTime.Now.ToString("hh:mm:ss tt dd-MM-yy")));
                    //AppSettingsHelper.SettingsInstance.ServiceLastSyncTime = DateTime.Now; AppSettingsHelper.SaveSettings(out msg);
                }
                else
                {
                    LogHelper.LogWarning(String.Format("All Attendance({0}/{1}) failed to upload HR server, please check attendance service. Task finished({2}).", _success, _totalLog, DateTime.Now.ToString("hh:mm:ss tt dd-MM-yy")));
                    WcfClient.SendMessage(String.Format("All Attendance({0}/{1}) failed to upload HR server, please check attendance service. Task finished({2}).", _success, _totalLog, DateTime.Now.ToString("hh:mm:ss tt dd-MM-yy")));
                }

            }
            _totalLog = 0;
            _completed = 0;
            _success = 0;
        }

        private void SendEmailDeviceStatusAsync()
        {
            
            {
                WcfClient.SendMessage("Sending email of device status start...");
                DeviceFacade.SendEmailOfActiveDeviceStatusAsync();
            }
        }
        private static DateTime IntToDateTime(int intDate)
        {
           // According to Suprima Logic
            return new DateTime(1970, 1, 1).AddSeconds(intDate);
        }
        private bool IsTimeToRun(DateTime lastOccured, double intervalInMinute)
        {
            double intervalSecond = intervalInMinute * 60;
            double occuredBefore = (DateTime.Now - lastOccured).TotalSeconds;

            if (occuredBefore >= intervalSecond)
            {
                return true;
            }
            return false;
        }

        #region Auto Sheduler Methods

        private System.Timers.Timer _Timer1 = new System.Timers.Timer();

        /// <summary>
        /// interval in milisecond
        /// </summary>
        private double _RunInterval
        {
            get
            {
                return (double)(2 * 1000); //* (double)(60* 1000), 1000ms=1sec}}
            }

        }

        private void InitializeSheduler()
        {
            this._Timer1.Elapsed += _Timer1_Elapsed;
            this._Timer1.AutoReset = true;
            this._Timer1.Interval = _RunInterval;
            this._Timer1.Enabled = true;
            //StopTimer();
            LogHelper.LogInfo("Sheduler initialized.");
            WcfClient.SendMessage("Sheduler initialized.");
        }
        public void RestartScheduler()
        {
            StopScheduler();
            this._Timer1.Interval = _RunInterval;
            StartScheduler();
            LogHelper.LogInfo("Sheduler started for task, Interval:" + (_RunInterval / 1000) + " sec");
            WcfClient.SendMessage("Sheduler started for task, Interval:" + (_RunInterval / 1000) + " sec");
        }
        public void StartScheduler()
        {
            this._Timer1.Interval = _RunInterval;
            StartTimer();
        }
        public void StopScheduler()
        {
            StopTimer();
            LogHelper.LogInfo("Sheduler stopped.");
            WcfClient.SendMessage("Sheduler stopped.");
        }
        private void _Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            StopTimer();
            this._Timer1.Interval = _RunInterval;
            //Do needed task here
            DoPendingTask();
            StartTimer();
        }


        private void StartTimer()
        {
            if (this._Timer1 != null)
            {
                if (!this._Timer1.Enabled)
                {
                    //this._Timer1.Enabled = true;
                    this._Timer1.Start();
                }
            }
        }
        private void StopTimer()
        {
            if (this._Timer1 != null)
            {
                //this._Timer1.Enabled = false;
                this._Timer1.Stop();
            }
        }
        
        #endregion

        ////private void SendMessage(string msg)
        //{
        //    LogHelper.EventLog.WriteEntry(msg);
        //}

        public void Dispose()
        {
            if (_Timer1 != null)
            {
                StopTimer();
                _Timer1.Dispose();
                _Timer1 = null;
            }
            LogHelper.LogInfo("Sheduler Disposed.");
        }
    }
}
