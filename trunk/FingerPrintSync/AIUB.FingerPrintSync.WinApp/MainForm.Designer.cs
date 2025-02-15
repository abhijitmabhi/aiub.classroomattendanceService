﻿namespace AIUB.FingerPrintSync.WinApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.lblLastSync = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cbAutoSync = new System.Windows.Forms.CheckBox();
            this.nbInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRepost = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctlSettings1 = new AIUB.FingerPrintSync.WinApp.Documents.CtlSettings();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTesult = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ctlDeviceMonitoring1 = new AIUB.FingerPrintSync.WinApp.Documents.CtlDeviceMonitoring();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ctlEmailSettings1 = new AIUB.FingerPrintSync.WinApp.Documents.CtlEmailSettings();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ctlServiceMonitoring1 = new AIUB.FingerPrintSync.WinApp.Documents.CtlServiceMonitoring();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.ctlAttendanceMonitoring1 = new AIUB.FingerPrintSync.WinApp.Documents.CtlAttendanceMonitoring();
            ((System.ComponentModel.ISupportInitialize)(this.nbInterval)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sync Attendance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(11, 119);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(468, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(115, 360);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 39);
            this.button2.TabIndex = 3;
            this.button2.Text = "Stop Sync";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblLastSync
            // 
            this.lblLastSync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastSync.Location = new System.Drawing.Point(41, 86);
            this.lblLastSync.Name = "lblLastSync";
            this.lblLastSync.Size = new System.Drawing.Size(404, 20);
            this.lblLastSync.TabIndex = 2;
            this.lblLastSync.Text = "Last Sync at:";
            this.lblLastSync.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Click To Open";
            this.notifyIcon1.BalloonTipTitle = "Fingerprint Attendance Synchronizer Tool";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Fingerprint Attendance Synchronizer Tool";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // cbAutoSync
            // 
            this.cbAutoSync.AutoSize = true;
            this.cbAutoSync.Location = new System.Drawing.Point(11, 28);
            this.cbAutoSync.Name = "cbAutoSync";
            this.cbAutoSync.Size = new System.Drawing.Size(237, 17);
            this.cbAutoSync.TabIndex = 4;
            this.cbAutoSync.Text = "Auto attendance sync from this app at every ";
            this.cbAutoSync.UseVisualStyleBackColor = true;
            this.cbAutoSync.CheckedChanged += new System.EventHandler(this.cbAutoSync_CheckedChanged);
            // 
            // nbInterval
            // 
            this.nbInterval.DecimalPlaces = 1;
            this.nbInterval.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nbInterval.Location = new System.Drawing.Point(254, 28);
            this.nbInterval.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nbInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nbInterval.Name = "nbInterval";
            this.nbInterval.Size = new System.Drawing.Size(44, 20);
            this.nbInterval.TabIndex = 5;
            this.nbInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbInterval.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "min";
            // 
            // btnRepost
            // 
            this.btnRepost.Location = new System.Drawing.Point(275, 358);
            this.btnRepost.Name = "btnRepost";
            this.btnRepost.Size = new System.Drawing.Size(103, 38);
            this.btnRepost.TabIndex = 7;
            this.btnRepost.Text = "Repost All Log";
            this.btnRepost.UseVisualStyleBackColor = true;
            this.btnRepost.Click += new System.EventHandler(this.btnRepost_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 469);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctlSettings1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctlSettings1
            // 
            this.ctlSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlSettings1.Location = new System.Drawing.Point(3, 3);
            this.ctlSettings1.Name = "ctlSettings1";
            this.ctlSettings1.Size = new System.Drawing.Size(770, 437);
            this.ctlSettings1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Manual Task";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTesult);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lblLastSync);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.cbAutoSync);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.btnRepost);
            this.groupBox1.Controls.Add(this.nbInterval);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 402);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manual Sync";
            // 
            // txtTesult
            // 
            this.txtTesult.Location = new System.Drawing.Point(12, 148);
            this.txtTesult.Name = "txtTesult";
            this.txtTesult.Size = new System.Drawing.Size(467, 204);
            this.txtTesult.TabIndex = 8;
            this.txtTesult.Text = "0/0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "(before enable this must disable Auto sync option of windows service)";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(334, 24);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(384, 358);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 38);
            this.button3.TabIndex = 7;
            this.button3.Text = "Delete All Posted Log From Suprima";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ctlDeviceMonitoring1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(776, 443);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Reader Device ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ctlDeviceMonitoring1
            // 
            this.ctlDeviceMonitoring1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlDeviceMonitoring1.Location = new System.Drawing.Point(3, 3);
            this.ctlDeviceMonitoring1.Name = "ctlDeviceMonitoring1";
            this.ctlDeviceMonitoring1.Size = new System.Drawing.Size(770, 437);
            this.ctlDeviceMonitoring1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ctlEmailSettings1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(776, 443);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Email Settings";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ctlEmailSettings1
            // 
            this.ctlEmailSettings1.Location = new System.Drawing.Point(3, 3);
            this.ctlEmailSettings1.Name = "ctlEmailSettings1";
            this.ctlEmailSettings1.Size = new System.Drawing.Size(526, 432);
            this.ctlEmailSettings1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ctlServiceMonitoring1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(776, 443);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "View Event Log ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ctlServiceMonitoring1
            // 
            this.ctlServiceMonitoring1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlServiceMonitoring1.Location = new System.Drawing.Point(0, 0);
            this.ctlServiceMonitoring1.Name = "ctlServiceMonitoring1";
            this.ctlServiceMonitoring1.Size = new System.Drawing.Size(776, 443);
            this.ctlServiceMonitoring1.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.ctlAttendanceMonitoring1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(776, 443);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Attendance Review";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // ctlAttendanceMonitoring1
            // 
            this.ctlAttendanceMonitoring1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlAttendanceMonitoring1.Location = new System.Drawing.Point(0, 0);
            this.ctlAttendanceMonitoring1.Name = "ctlAttendanceMonitoring1";
            this.ctlAttendanceMonitoring1.Size = new System.Drawing.Size(776, 443);
            this.ctlAttendanceMonitoring1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(784, 469);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClassRoom Attendance Synchronizer Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.nbInterval)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblLastSync;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox cbAutoSync;
        private System.Windows.Forms.NumericUpDown nbInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRepost;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Documents.CtlSettings ctlSettings1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private Documents.CtlDeviceMonitoring ctlDeviceMonitoring1;
        private Documents.CtlEmailSettings ctlEmailSettings1;
        private System.Windows.Forms.TabPage tabPage6;
        private Documents.CtlServiceMonitoring ctlServiceMonitoring1;
        private Documents.CtlAttendanceMonitoring ctlAttendanceMonitoring1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox txtTesult;
    }
}

