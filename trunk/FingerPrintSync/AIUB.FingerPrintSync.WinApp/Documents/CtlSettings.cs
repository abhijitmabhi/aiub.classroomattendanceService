﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIUB.FingerPrintSync.Framework;
using AIUB.FingerPrintSync.Framework.Data;
using AIUB.FingerPrintSync.Framework.Helpers.AppSettings;
using AIUB.FingerPrintSync.Framework.Helpers.EventLogHelper;
using AIUB.FingerPrintSync.Framework.Helpers.RestApiHelper;
using AIUB.FingerPrintSync.WinApp.Utils;

namespace AIUB.FingerPrintSync.WinApp.Documents
{
    public partial class CtlSettings : BaseUserControl{
        public CtlSettings()
        {
            InitializeComponent();
        }



        private void CtlSettings_Load(object sender, EventArgs e)
        {
            if (!IsDesignerHosted)
                Populate();
        }

        private void Populate()
        {
            try
            {
                txtSqlServerName.Text = AppSettingsHelper.SettingsInstance.SqlServerName;
                txtSqlDBName.Text = AppSettingsHelper.SettingsInstance.SuprimaDBName;
                cbIsSqlAthun.Checked = AppSettingsHelper.SettingsInstance.IsSqlAuthentication;
                txtSqlUser.Text = AppSettingsHelper.SettingsInstance.SqlServerUserName;
                txtSqlPass.Text = AppSettingsHelper.SettingsInstance.SqlServerPassword;

                cbUseSqlCon.Checked = AppSettingsHelper.SettingsInstance.UseSqlConnectionString;
                txtSqlConString.Text = AppSettingsHelper.SettingsInstance.SqlConnectionString;

                txtSqlDBName.Enabled = txtSqlServerName.Enabled = txtSqlUser.Enabled = txtSqlPass.Enabled = !AppSettingsHelper.SettingsInstance.UseSqlConnectionString;
                txtSqlConString.Enabled = AppSettingsHelper.SettingsInstance.UseSqlConnectionString;
          


                txtHrService.Text = AppSettingsHelper.SettingsInstance.HRServiceUrl;
                AuthUrl.Text = AppSettingsHelper.SettingsInstance.AuthUrl;
                cbEnableServiceAutoSync.Checked = AppSettingsHelper.SettingsInstance.AttendanceEnableAutoSync;
                nbAtendanceSyncInterval.Value = (decimal)AppSettingsHelper.SettingsInstance.AttendanceSyncIntervalInMinute;

                cbLogError.Checked = AppSettingsHelper.SettingsInstance.EnableErrorLog;
                cbLogSuccess.Checked = AppSettingsHelper.SettingsInstance.EnableSuccessLog;
                cbLogInfo.Checked = AppSettingsHelper.SettingsInstance.EnableInfoLog;
                cbLogWarning.Checked = AppSettingsHelper.SettingsInstance.EnableWarningLog;
                cbLogDebug.Checked = AppSettingsHelper.SettingsInstance.EnableDebugLog;

                cbEnableAutoRemoveLog.Checked = AppSettingsHelper.SettingsInstance.EnableAutoRemoveLog;
                nbLogRemoveInterval.Value = (decimal)AppSettingsHelper.SettingsInstance.RemoveLogAfterInHour;


                tbWebApiPassword.Text = AppSettingsHelper.SettingsInstance.WebApiPassword;
                tbWebapiUserName.Text = AppSettingsHelper.SettingsInstance.WebApiUserName;
                IsUseWebApiCheckBox.Checked = AppSettingsHelper.SettingsInstance.IsUseWebApi;

            }
            catch (Exception ex)
            {

                 ShowMbox.Error(ex.ToString());
            }
   


        }

        private void Save()
        {
            AppSettingsHelper.SettingsInstance.SqlServerName=txtSqlServerName.Text ;
            AppSettingsHelper.SettingsInstance.SuprimaDBName=txtSqlDBName.Text;
            AppSettingsHelper.SettingsInstance.SqlServerUserName=txtSqlUser.Text;
            AppSettingsHelper.SettingsInstance.SqlServerPassword=txtSqlPass.Text;

            AppSettingsHelper.SettingsInstance.UseSqlConnectionString = cbUseSqlCon.Checked;
            AppSettingsHelper.SettingsInstance.SqlConnectionString=txtSqlConString.Text ;

            AppSettingsHelper.SettingsInstance.HRServiceUrl=txtHrService.Text;
            AppSettingsHelper.SettingsInstance.AuthUrl=AuthUrl.Text;
            AppSettingsHelper.SettingsInstance.AttendanceEnableAutoSync=cbEnableServiceAutoSync.Checked;
           AppSettingsHelper.SettingsInstance.AttendanceSyncIntervalInMinute=(double)nbAtendanceSyncInterval.Value;

            AppSettingsHelper.SettingsInstance.EnableErrorLog=cbLogError.Checked;
            AppSettingsHelper.SettingsInstance.EnableSuccessLog=cbLogSuccess.Checked;
            AppSettingsHelper.SettingsInstance.EnableInfoLog=cbLogInfo.Checked;
            AppSettingsHelper.SettingsInstance.EnableWarningLog=cbLogWarning.Checked;
            AppSettingsHelper.SettingsInstance.EnableDebugLog = cbLogDebug.Checked;

            AppSettingsHelper.SettingsInstance.EnableAutoRemoveLog=cbEnableAutoRemoveLog.Checked;
            AppSettingsHelper.SettingsInstance.RemoveLogAfterInHour = (double)nbLogRemoveInterval.Value;

            AppSettingsHelper.SettingsInstance.WebApiPassword = tbWebApiPassword.Text;
            AppSettingsHelper.SettingsInstance.WebApiUserName = tbWebapiUserName.Text;
            AppSettingsHelper.SettingsInstance.IsUseWebApi = IsUseWebApiCheckBox.Checked;
            
             
            string message;
            if (AppSettingsHelper.SaveSettings(out message))
                ShowMbox.Success(this,@"Settings saved, please restart windows service to take effect.");
            else
            {
                ShowMbox.Error(this, @"Settings not saved! " + message);
            }
        }

        private void btnSqlServerTest_Click(object sender, EventArgs e)
        {
            string message;
            if(DataManager.TestEntityConnection(cbUseSqlCon.Checked,txtSqlServerName.Text, txtSqlDBName.Text, txtSqlUser.Text, txtSqlPass.Text,txtSqlConString.Text, out message))
                ShowMbox.Success(this, message);
            else
            {
                ShowMbox.Error(this, message);
            }


        }
        private void btnTestHrService_Click(object sender, EventArgs e)
        {

        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            LogHelper.Clear();
            ShowMbox.Success("Event Log Cleared.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            AppSettingsHelper.ReloadSettings();
            Populate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtSqlDBName.Enabled = txtSqlServerName.Enabled = txtSqlUser.Enabled = txtSqlPass.Enabled = !cbUseSqlCon.Checked;
            txtSqlConString.Enabled = cbUseSqlCon.Checked;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
             DialogResult dr = ShowMbox.QuestionYesNo(this,
                "This will replase all current settings to application default settings, press yes to continue!");
            if (dr == DialogResult.Yes)
            {
                AppSettingsHelper.RestoreDefaultSettings();
                Populate();
            }
        }

        private void btnWebapiAuthoinfoSave_Click(object sender, EventArgs e)
        {
            string error = "";
            var AuthUrltxt = AuthUrl.Text;
            var token = RestWebapi.GetAuthenticationToken(tbWebapiUserName.Text, tbWebApiPassword.Text, AuthUrltxt, out error);
           
           if (!string.IsNullOrEmpty(token))
            {
                AppSettingsHelper.SettingsInstance.WebApiToken = token;
                btnWebapiAuthoinfoSave.Text = "Authenticated";
            }
           else
           {
                MessageBox.Show("Authentication Failed : "+ error);
           }
           
            
        }
    }
}
