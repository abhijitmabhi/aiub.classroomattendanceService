using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIUB.FingerPrintSync.Framework.WcfComunication;
using AIUB.FingerPrintSync.Framework.WcfComunication.Client;

namespace WcfServerTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(Process.GetCurrentProcess().ProcessName); 
            //WcfClient.SendMessage(textBox1.Text);

            //WcfClient.Connect();
            DateTime firstDateTime = new DateTime(2014, 07, 13, 14, 00, 00);
            DateTime cur = DateTime.Now;

            if(IsTimeToRun(firstDateTime, 6))
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
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
       
    }
}
