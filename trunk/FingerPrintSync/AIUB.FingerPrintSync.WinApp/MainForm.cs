


using AIUB.FingerPrintSync.Framework.Facade;
using AIUB.FingerPrintSync.Framework.Helpers;
using AIUB.FingerPrintSync.Framework.Helpers.AppSettings;
using AIUB.FingerPrintSync.Framework.WcfComunication;
using AIUB.FingerPrintSync.Framework.WcfComunication.Server;
using AIUB.FingerPrintSync.ServiceManager;
using AIUB.FingerPrintSync.ServiceManager.AttendanceService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIUB.FingerPrintSync.WinApp.Properties;

namespace AIUB.FingerPrintSync.WinApp
{
    public partial class MainForm : Form
    {
        int _totalLog = 0;
        int _completed = 0;
        int _success = 0;
        int _invalid = 0;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Populate();
            InitializeSheduler();
        }

        private void Populate()
        {
            lblLastSync.Text = "Last Sync at:" + AppSettingsHelper.SettingsInstance.AppLastSyncTime.ToString("hh:mm:ss tt dd-MM-yy");
            cbAutoSync.Checked = AppSettingsHelper.SettingsInstance.AppEnableAutoSync;
            nbInterval.Enabled = AppSettingsHelper.SettingsInstance.AppEnableAutoSync;
            nbInterval.Value = (decimal)AppSettingsHelper.SettingsInstance.AppSchedulerIntervalInMinute;

        }
        private void LogMessage(string msg)
        {
            if (this.txtTesult.InvokeRequired)
            {
                this.txtTesult.BeginInvoke(
                    new MethodInvoker(delegate { txtTesult.Text = msg+"\n"; }));
            }
            else
            {
                txtTesult.Text =  msg + "\n";
            }
        }

     

        #region  Task Attendance Sync
        private void SyncAttendanceAsync()
        {
            //calling invoker because of this method called from timer thrade sometimes
            if (this.InvokeRequired)
            {
                this.BeginInvoke(
                    new MethodInvoker(delegate
                    {
                        button1.Enabled = false;
                        btnRepost.Enabled = false;
                    }));
            }
            else
            {
                button1.Enabled = false;
                btnRepost.Enabled = false;
            }

            // DateTime dt = IntToDateTime(1401030424); //= new DateTime(1398165739);
            //progressBar1.Show();

            if (!bgWorker.IsBusy)
                bgWorker.RunWorkerAsync();
        }
        string _message = "";
        void SyncAttandance(DoWorkEventArgs e)
        {
            try
            {
                if (WinServiceHelper.IsServiceRunning(WinServiceHelper.ServiceName))
                {
                    throw new Exception("To make work this task properly please stop windows Service(" + WinServiceHelper.GetServiceDisplayName(WinServiceHelper.ServiceName) + ")  and disable auto sync option of windows service from settings tab.");
                    return;

                }//throw new Exception("test");
                LogMessage("Collecting new attendance from ZK DB...");

                var logs = AttendanceFacade.GetUnsyncAttendance();

                _totalLog = logs.Count;
                LogMessage("0/" + _totalLog.ToString());


                try
                {
                    foreach (var log in logs)
                    {

                        if ((bgWorker.CancellationPending))
                        {
                            e.Cancel = true;
                            break;

                        }

                        int userId = 0;
                        var isParsed = Int32.TryParse(log.UserId, out userId);
                        if (!isParsed)
                        {
                            _invalid++;
                            log.IsInvalid = true;
                            continue;
                            
                        }

                        SubmitResult2Ofstring result = AttandanceServiceManager.PostFingerPrintAttendance(userId,
                            log.LogTime, log.DeviceId, log.IpAddress, log.RoomNumber);

                        if (result.IsSuccess)
                        {
                            log.IsSynced = true;
                            _success++;
                            _message += string.Format("id:{0} -> Time:\n", log.UserId);
                            log.LogTime.ToString("g");
                            //                        log.logTime.ToString("g");
                        }
                        else
                        {
                            _message += string.Format("Failed id:{0} -> Time: {1}->Reason {2}\n", log.UserId, log.LogTime, result.Errors);
                            //                      log.logTime.ToString("g"), result.Errors);
                        }

                        //message += string.Format("id:{0} -> Time:{1}\n", log.nUserID.ToString(),
                        //    IntToDateTime(log.nDateTime).ToString("g"));


                        _completed++;
                        //int cc=completed/totalLog*100;
                        bgWorker.ReportProgress(_completed);

                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }

                if (_invalid > 0)
                {
                    LogMessage("Invalid Users Detected, please wait... ");
                    AttendanceFacade.UpdateInvalidUsersLog(logs);
                }
                
                if (_success > 0)
                {
                    LogMessage("Updating ZK DB status, please wait... ");
                    bool success = AttendanceFacade.UpdateLogsStatus(logs);

                }

            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
            finally
            {

                //GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }


        }

        public static DateTime IntToDateTime(int intDate)
        {
            // According to Suprima Logic
            return new DateTime(1970, 1, 1).AddSeconds(intDate);
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SyncAttandance(e);
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Console.WriteLine(String.Format("{0} / {1}={2} * 100", _completed, _totalLog, (int)((((double)_completed / _totalLog)) * 100)));
            var progress = (int)(((double)_completed / _totalLog) * 100);
            if (this.InvokeRequired)
            {
                this.BeginInvoke(
                    new MethodInvoker(delegate
                    {
                        progressBar1.Value = progress < 0 ? 0 : progress;
                    }));
            }
            else
            {
                progressBar1.Value = progress < 0 ? 0 : progress;
            }

            LogMessage("Uploading to HR " + _completed + "/" + _totalLog);
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string message;
            if (!e.Cancelled && e.Error == null && e.Result is Exception)
            {
                Exception ex = e.Result as Exception;
                LogMessage("Task Failed! " + ex.ToString());
            }
            else if (_totalLog == 0)
            {
                LogMessage(String.Format("No new attendance pending to synchronize, Task finished({0}).", DateTime.Now.ToString("hh:mm:ss tt dd-MM-yy")));
                //MessageBox.Show("No new attendance pending to sync");
            }
            else
            {

                if (_success > 0)
                {
                    LogMessage(_message);
                    LogMessage(String.Format("Total {0}/{1} attendace synchronized.Task finished({2}).", _success, _totalLog, DateTime.Now.ToString("hh:mm:ss tt dd-MM-yy")));
                    AppSettingsHelper.SettingsInstance.AppLastSyncTime = DateTime.Now;
                    AppSettingsHelper.SaveSettings(out message);

                    //calling invoker because of bgworker called from timer thrade sometimes
                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke(
                            new MethodInvoker(delegate
                            {
                                lblLastSync.Text = "Last Sync at:" + AppSettingsHelper.SettingsInstance.AppLastSyncTime.ToString("hh:mm:ss tt dd-MM-yy");
                            }));
                    }
                    else
                    {
                        lblLastSync.Text = "Last Sync at:" + AppSettingsHelper.SettingsInstance.AppLastSyncTime.ToString("hh:mm:ss tt dd-MM-yy");
                    }
                }
                else
                {
                    LogMessage(String.Format("All Attendance({0}/{1}) failed to upload HR server, please check attendance service. Task finished({2}).", _success, _totalLog, DateTime.Now.ToString("hh:mm:ss tt dd-MM-yy")));
                }

            }
            if (this.InvokeRequired)
            {
                this.BeginInvoke(
                    new MethodInvoker(delegate
                    {
                        progressBar1.Value = 0;
                        button1.Enabled = true;
                        btnRepost.Enabled = true;
                    }));
            }
            else
            {
                progressBar1.Value = 0;
                button1.Enabled = true;
                btnRepost.Enabled = true;
            }

            _totalLog = 0;
            _completed = 0;
            _success = 0;
        }

        #endregion

        #region Auto Sheduler Methods

        private System.Timers.Timer _Timer1 = new System.Timers.Timer();

        private double _RunInterval
        {
            get
            {
                return (double)(AppSettingsHelper.SettingsInstance.AppSchedulerIntervalInMinute * (double)(60 * 1000)); //* (double)(60* 1000)1000=1sec}}
            }

        }

        private void InitializeSheduler()
        {
            this._Timer1.Elapsed += _Timer1_Elapsed;
            this._Timer1.AutoReset = true;
            this._Timer1.Interval = _RunInterval;
            this._Timer1.Enabled = true;
            //StopTimer();
        }
        private void RestartScheduler()
        {
            StopScheduler();
            this._Timer1.Interval = _RunInterval;
            StartScheduler();
        }
        private void StartScheduler()
        {
            this._Timer1.Interval = _RunInterval;
            StartTimer();
        }
        private void StopScheduler()
        {
            StopTimer();
        }
        private void _Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            StopTimer();
            this._Timer1.Interval = _RunInterval;
            if (AppSettingsHelper.SettingsInstance.AppEnableAutoSync)
            {
                //call Sheduled task
                SyncAttendanceAsync();
                Console.WriteLine(String.Format("({0}).", DateTime.Now.ToString("hh:mm:ss tt dd-MM-yy")));
            }
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
        private bool IsTimeToRun(DateTime lastOccured, double interval)
        {
            double intervalSecond = interval * 60;
            double occuredBefore = (DateTime.Now - lastOccured).TotalSeconds;

            if (occuredBefore >= intervalSecond)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Other Events

        private void button1_Click(object sender, EventArgs e)
        {
            //var App = AppSettingsHelper.SettingsInstance;
            SyncAttendanceAsync();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (bgWorker.WorkerSupportsCancellation == true)
            {
                bgWorker.CancelAsync();
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgWorker.IsBusy)
            {
                e.Cancel = true;
                return;
            }
            

            if (AppSettingsHelper.SettingsInstance.AppEnableAutoSync)
            {
                DialogResult dr = ShowMbox.QuestionYesNo(this,
                "Auto Sync attendance is running from this app, closing this app attendance will not sync automatically.\n Are you sure close this app?");
                if (dr == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            //disposing timer component
            if (_Timer1 != null)
            {
                StopTimer();
                _Timer1.Dispose();
                _Timer1 = null;
            }
            string message;
            //AppSettingsHelper.SaveSettings(out message);
            WcfServer.CloseHost();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cbAutoSync_CheckedChanged(object sender, EventArgs e)
        {
            string message;
            nbInterval.Enabled = cbAutoSync.Checked;
            
            if (!AppSettingsHelper.SettingsInstance.AppEnableAutoSync)
                StopScheduler();
            else
            {
                StartScheduler();
            }
        }
        #endregion

        #region Handle Window State
        void HideToTray()
        {

            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            this.notifyIcon1.ShowBalloonTip(40, this.notifyIcon1.BalloonTipTitle, "Click Here To Show", ToolTipIcon.Info);

        }
        void ShowWindow()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.ShowBalloonTip(40, this.notifyIcon1.BalloonTipTitle, "Showed Normally", ToolTipIcon.Info);
            this.BringToFront();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                HideToTray();
            }
        }
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
                ShowWindow();
        }
        #endregion

        private void btnRepost_Click(object sender, EventArgs e)
        {
            if (WinServiceHelper.IsServiceRunning(WinServiceHelper.ServiceName))
            {
                LogMessage("Task failed! To make work this task please stop windows Service(" + WinServiceHelper.GetServiceDisplayName(WinServiceHelper.ServiceName) + ")  properly and disable auto sync option of windows service from settings tab.");
                return;
            }
            DialogResult dr = ShowMbox.QuestionYesNo(this,
                "This will repost all previous posted attendance log to HR Server from Suprima DB, press yes to continue!");
            if (dr == DialogResult.Yes)
            {
                LogMessage("Changing all log status of suprima DB...");
                AttendanceFacade.ResetLogsStatus();
                SyncAttendanceAsync();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (WinServiceHelper.IsServiceRunning(WinServiceHelper.ServiceName))
            {
                LogMessage("Task failed! To make work this task please stop windows Service(" + WinServiceHelper.GetServiceDisplayName(WinServiceHelper.ServiceName) + ")  properly and disable auto sync option of windows service from settings tab.");
                return;
            }
            DialogResult dr = ShowMbox.QuestionYesNo(this,
                "This will delete all posted attendance log from suprima DB, press yes to continue!");
            if (dr == DialogResult.Yes)
                if (AttendanceFacade.DeleteUpdatedLogs())
                    ShowMbox.Success(this, "All uploaded log deleted from suprima DB");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string message;
            AppSettingsHelper.SettingsInstance.AppEnableAutoSync = cbAutoSync.Checked;

            AppSettingsHelper.SettingsInstance.AppSchedulerIntervalInMinute = (double)nbInterval.Value;
            AppSettingsHelper.SaveSettings(out message);
            RestartScheduler();
        }
    }
}
