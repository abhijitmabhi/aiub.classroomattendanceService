using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIUB.FingerPrintSync.Framework.Helpers;
using AIUB.FingerPrintSync.WinApp.Utils;

namespace AIUB.FingerPrintSync.WinApp.Documents
{
    public partial class CtlServiceControler : BaseUserControl
    {

        //public static string ServiceName = ConfigurationManager.AppSettings["WinServiceName"];
        public CtlServiceControler()
        {
            InitializeComponent();
        }
        private void CtlServiceControler_Load(object sender, EventArgs e)
        {
            if(!IsDesignerHosted)
            Populate();
        }

        private void Populate()
        {
            lblServiceName.Text = WinServiceHelper.GetServiceDisplayName(WinServiceHelper.ServiceName);
            lblStatus.Text = WinServiceHelper.GetServiceStatus(WinServiceHelper.ServiceName);

            btnStartStop.Text = WinServiceHelper.IsServiceRunning(WinServiceHelper.ServiceName) ? "Stop" : "Start";

        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
          
            string message;
            if (WinServiceHelper.IsServiceRunning(WinServiceHelper.ServiceName))
            {
                if (WinServiceHelper.StopService(WinServiceHelper.ServiceName, 30, out  message))
                {
                    btnStartStop.Text = "Start";
                    
                }
                else
                {
                    ShowMbox.Error(this, "Service stop failed." + message);
                }
            }
            else
            {
                if (WinServiceHelper.StartService(WinServiceHelper.ServiceName, 30, out  message))
                {
                    btnStartStop.Text = "Stop";
                }
                else
                {
                    ShowMbox.Error("Service start failed." + message);
                }
               
            }
            lblStatus.Text = WinServiceHelper.GetServiceStatus(WinServiceHelper.ServiceName);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            string message;
            if (WinServiceHelper.RestartService(WinServiceHelper.ServiceName, 30, out  message))
            {
                ShowMbox.Success("Service Restarted.");
                
            }
            else
            {
                ShowMbox.Error("Service restrat failed." + message);
            }
            btnStartStop.Text = WinServiceHelper.IsServiceRunning(WinServiceHelper.ServiceName) ? "Stop" : "Start";
            lblStatus.Text = WinServiceHelper.GetServiceStatus(WinServiceHelper.ServiceName);
        }

       
    }
}
