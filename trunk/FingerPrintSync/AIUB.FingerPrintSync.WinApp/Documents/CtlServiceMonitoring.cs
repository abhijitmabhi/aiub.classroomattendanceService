using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIUB.FingerPrintSync.Framework.WcfComunication;
using AIUB.FingerPrintSync.Framework.WcfComunication.Server;
using AIUB.FingerPrintSync.WinApp.Utils;

namespace AIUB.FingerPrintSync.WinApp.Documents
{
    public partial class CtlServiceMonitoring : BaseUserControl
    {
        public CtlServiceMonitoring()
        {
            InitializeComponent();
        }

        private void CtlServiceMonitoring_Load(object sender, EventArgs e)
        {
            if (!IsDesignerHosted && !DesignMode)
            {
                InitService();
                cbEnableMonitoring.Checked = Properties.Settings.Default.MonitorLog;
            }
        }

        void InitService()
        {
            WcfServer.StartHostAsync();
            MessageService.OnWriteLogRequest += MessageService_OnWriteLogRequest;
        }
        void MessageService_OnWriteLogRequest(string message)
        {
            if (this.txtLog.InvokeRequired)
            {
                this.txtLog.BeginInvoke(new MethodInvoker(delegate { WriteLog(message); }));
                
            }
            else
                WriteLog(message);
           

        }

        private void WriteLog(string message)
        {
            try
            {
                if (Properties.Settings.Default.MonitorLog)
                {
                    message = string.Format("{0}->\t{1}", DateTime.Now.ToString("hh:mm:ss.fff tt dd-MM"), message);
                    this.txtLog.AppendText(message + Environment.NewLine);
                    this.txtLog.ScrollToCaret();
                }
            }
            catch (System.OutOfMemoryException ex)
            {
                this.txtLog.Clear();
            }
            catch (Exception ex)
            {
                this.txtLog.Clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtLog.Clear();
        }

        private void cbEnableMonitoring_CheckedChanged(object sender, EventArgs e)
        {

            Properties.Settings.Default.MonitorLog = cbEnableMonitoring.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
