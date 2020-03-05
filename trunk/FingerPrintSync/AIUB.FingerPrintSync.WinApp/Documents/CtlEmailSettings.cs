using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIUB.FingerPrintSync.Framework.Facade;
using AIUB.FingerPrintSync.Framework.Helpers.AppSettings;
using AIUB.FingerPrintSync.WinApp.Utils;

namespace AIUB.FingerPrintSync.WinApp.Documents
{
    public partial class CtlEmailSettings : BaseUserControl
    {
        public CtlEmailSettings()
        {
            InitializeComponent();
        }

        private void CtlEmailSettings_Load(object sender, EventArgs e)
        {
            if (!IsDesignerHosted)
            {
                Populate();
            }
        }

        void Populate()
        {

            txtPass.Text = AppSettingsHelper.SettingsInstance.EmailPassword;
            txtUserName.Text = AppSettingsHelper.SettingsInstance.EmailUserName;
            cbAutoMail.Checked = AppSettingsHelper.SettingsInstance.EnableAutoEmailDeviceStatus;
            cbEnableSsl.Checked = AppSettingsHelper.SettingsInstance.EmailEnableSsl;

            txtSmtpServer.Text = AppSettingsHelper.SettingsInstance.EmailSmtpServer;

            txtSendTo.Text = AppSettingsHelper.SettingsInstance.EmailToAddress;
            nudPort.Value = AppSettingsHelper.SettingsInstance.EmailSmtpPort;
            nbAutoMailInterval.Value = (decimal)AppSettingsHelper.SettingsInstance.EmailDeviceStatusIntervalInHour;
        }

        private void Save()
        {
            AppSettingsHelper.SettingsInstance.EmailPassword = txtPass.Text;
            AppSettingsHelper.SettingsInstance.EmailUserName = txtUserName.Text;
            AppSettingsHelper.SettingsInstance.EnableAutoEmailDeviceStatus = cbAutoMail.Checked;
            AppSettingsHelper.SettingsInstance.EmailEnableSsl = cbEnableSsl.Checked;

            AppSettingsHelper.SettingsInstance.EmailSmtpServer = txtSmtpServer.Text;

            AppSettingsHelper.SettingsInstance.EmailToAddress = txtSendTo.Text;
            AppSettingsHelper.SettingsInstance.EmailSmtpPort = (int)nudPort.Value;
            AppSettingsHelper.SettingsInstance.EmailDeviceStatusIntervalInHour = (double)nbAutoMailInterval.Value;


            string message;
            if (AppSettingsHelper.SaveSettings(out message))
                ShowMbox.Success(this, @"Settings saved, please restart windows service to take effect.");
            else
            {
                ShowMbox.Error(this, @"Settings not saved! " + message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            TestAsync();

        }
        void TestAsync()
        {
            DisableControls();
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();

        }
  

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
//            string message;
//            if (DeviceFacade.SendEmailOfActiveDeviceStatus(out message))
//            {
//                e.Result = message;
//            }
//            else
//            {
//                throw new Exception(message);
//            }
//

           
          
           
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string message;

            if (!e.Cancelled && e.Error != null)
            {
             ShowMbox.Error( e.Error.Message);
            }
            else
            {
                var res = (string)e.Result ;
                ShowMbox.Success(res);
            }

            EnableControls();
        }

        private void DisableControls()
        {

            btnSave.Enabled = false;
            btnTest.Enabled = false;


            progressBar1.Value = 3;
            progressBar1.Visible = true;

        }
        private void EnableControls()
        {
            btnSave.Enabled = true;
            btnTest.Enabled = true;


            progressBar1.Visible = false;

        }


    }
}
