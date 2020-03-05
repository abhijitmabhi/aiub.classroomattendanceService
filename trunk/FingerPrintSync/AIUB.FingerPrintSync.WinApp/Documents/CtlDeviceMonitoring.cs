using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIUB.FingerPrintSync.Framework.Data;
using AIUB.FingerPrintSync.Framework.Facade;
using AIUB.FingerPrintSync.WinApp.Utils;

namespace AIUB.FingerPrintSync.WinApp.Documents
{
    public partial class CtlDeviceMonitoring : BaseUserControl
    {
        public CtlDeviceMonitoring()
        {
            InitializeComponent();
        }

        private void CtlDeviceMonitoring_Load(object sender, EventArgs e)
        {
            if (!IsDesignerHosted && !DesignMode)
            {
                PopulateAsync();
            }
        }

        void PopulateAsync()
        {
            DisableControls();
            if (!backgroundWorker1.IsBusy)
            backgroundWorker1.RunWorkerAsync();
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var deviceList = gvDeviceList.DataSource as List<TB_READER>;
           string message;
            if (DeviceFacade.SaveDeviceList(deviceList,out message))
                ShowMbox.Success(this, @"Settings saved, please restart windows service to take effect.");
            else
            {
                ShowMbox.Error(this, @"Settings not saved! " + message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateAsync();
        }

        private List<TB_READER> deviceList;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
//             deviceList = DeviceFacade.GetReaderListWithOnlineStatus();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gvDeviceList.DataSource = deviceList;
            EnableControls();
        }

        private void DisableControls()
        {

            btnSave.Enabled = false;
            btnRefresh.Enabled = false;

            gvDeviceList.MasterTemplate.ReadOnly = true;
            progressBar1.Value = 3;
            progressBar1.Visible = true;

        }
        private void EnableControls()
        {
            btnSave.Enabled = true;
            btnRefresh.Enabled = true;

            gvDeviceList.MasterTemplate.ReadOnly = false;
            progressBar1.Visible = false;

        }
    }
}
