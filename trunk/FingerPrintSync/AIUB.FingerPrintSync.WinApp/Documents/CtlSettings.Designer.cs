namespace AIUB.FingerPrintSync.WinApp.Documents
{
    partial class CtlSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IsUseWebApiCheckBox = new System.Windows.Forms.CheckBox();
            this.btnTestHrService = new System.Windows.Forms.Button();
            this.txtHrService = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSqlDBName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSqlConString = new System.Windows.Forms.RichTextBox();
            this.btnSqlServerTest = new System.Windows.Forms.Button();
            this.txtSqlPass = new System.Windows.Forms.TextBox();
            this.txtSqlUser = new System.Windows.Forms.TextBox();
            this.cbUseSqlCon = new System.Windows.Forms.CheckBox();
            this.cbIsSqlAthun = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSqlServerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nbAtendanceSyncInterval = new System.Windows.Forms.NumericUpDown();
            this.cbEnableServiceAutoSync = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbLogDebug = new System.Windows.Forms.CheckBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.nbLogRemoveInterval = new System.Windows.Forms.NumericUpDown();
            this.cbLogWarning = new System.Windows.Forms.CheckBox();
            this.cbLogInfo = new System.Windows.Forms.CheckBox();
            this.cbLogSuccess = new System.Windows.Forms.CheckBox();
            this.cbLogError = new System.Windows.Forms.CheckBox();
            this.cbEnableAutoRemoveLog = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ctlServiceControler1 = new AIUB.FingerPrintSync.WinApp.Documents.CtlServiceControler();
            this.btnRestore = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnWebapiAuthoinfoSave = new System.Windows.Forms.Button();
            this.tbWebApiPassword = new System.Windows.Forms.TextBox();
            this.tbWebapiUserName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.AuthUrl = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbAtendanceSyncInterval)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbLogRemoveInterval)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IsUseWebApiCheckBox);
            this.groupBox1.Controls.Add(this.btnTestHrService);
            this.groupBox1.Controls.Add(this.txtHrService);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(372, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HR Service Url";
            // 
            // IsUseWebApiCheckBox
            // 
            this.IsUseWebApiCheckBox.AutoSize = true;
            this.IsUseWebApiCheckBox.Location = new System.Drawing.Point(9, 47);
            this.IsUseWebApiCheckBox.Name = "IsUseWebApiCheckBox";
            this.IsUseWebApiCheckBox.Size = new System.Drawing.Size(91, 17);
            this.IsUseWebApiCheckBox.TabIndex = 11;
            this.IsUseWebApiCheckBox.Text = "Use Web API";
            this.IsUseWebApiCheckBox.UseVisualStyleBackColor = true;
            // 
            // btnTestHrService
            // 
            this.btnTestHrService.Location = new System.Drawing.Point(264, 47);
            this.btnTestHrService.Name = "btnTestHrService";
            this.btnTestHrService.Size = new System.Drawing.Size(75, 23);
            this.btnTestHrService.TabIndex = 10;
            this.btnTestHrService.Text = "Test";
            this.btnTestHrService.UseVisualStyleBackColor = true;
            this.btnTestHrService.Click += new System.EventHandler(this.btnTestHrService_Click);
            // 
            // txtHrService
            // 
            this.txtHrService.Location = new System.Drawing.Point(102, 21);
            this.txtHrService.Name = "txtHrService";
            this.txtHrService.Size = new System.Drawing.Size(237, 20);
            this.txtHrService.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "HR Service URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "DB Name:";
            // 
            // txtSqlDBName
            // 
            this.txtSqlDBName.Location = new System.Drawing.Point(102, 44);
            this.txtSqlDBName.Name = "txtSqlDBName";
            this.txtSqlDBName.Size = new System.Drawing.Size(227, 20);
            this.txtSqlDBName.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSqlConString);
            this.groupBox2.Controls.Add(this.btnSqlServerTest);
            this.groupBox2.Controls.Add(this.txtSqlPass);
            this.groupBox2.Controls.Add(this.txtSqlUser);
            this.groupBox2.Controls.Add(this.cbUseSqlCon);
            this.groupBox2.Controls.Add(this.cbIsSqlAthun);
            this.groupBox2.Controls.Add(this.txtSqlDBName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtSqlServerName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 292);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Suprima Sql Server Connection";
            // 
            // txtSqlConString
            // 
            this.txtSqlConString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSqlConString.Location = new System.Drawing.Point(9, 169);
            this.txtSqlConString.Name = "txtSqlConString";
            this.txtSqlConString.Size = new System.Drawing.Size(320, 84);
            this.txtSqlConString.TabIndex = 11;
            this.txtSqlConString.Text = "";
            // 
            // btnSqlServerTest
            // 
            this.btnSqlServerTest.Location = new System.Drawing.Point(254, 259);
            this.btnSqlServerTest.Name = "btnSqlServerTest";
            this.btnSqlServerTest.Size = new System.Drawing.Size(75, 23);
            this.btnSqlServerTest.TabIndex = 10;
            this.btnSqlServerTest.Text = "Test";
            this.btnSqlServerTest.UseVisualStyleBackColor = true;
            this.btnSqlServerTest.Click += new System.EventHandler(this.btnSqlServerTest_Click);
            // 
            // txtSqlPass
            // 
            this.txtSqlPass.Location = new System.Drawing.Point(102, 119);
            this.txtSqlPass.Name = "txtSqlPass";
            this.txtSqlPass.Size = new System.Drawing.Size(227, 20);
            this.txtSqlPass.TabIndex = 1;
            // 
            // txtSqlUser
            // 
            this.txtSqlUser.Location = new System.Drawing.Point(102, 89);
            this.txtSqlUser.Name = "txtSqlUser";
            this.txtSqlUser.Size = new System.Drawing.Size(227, 20);
            this.txtSqlUser.TabIndex = 1;
            // 
            // cbUseSqlCon
            // 
            this.cbUseSqlCon.AutoSize = true;
            this.cbUseSqlCon.Location = new System.Drawing.Point(9, 145);
            this.cbUseSqlCon.Name = "cbUseSqlCon";
            this.cbUseSqlCon.Size = new System.Drawing.Size(150, 17);
            this.cbUseSqlCon.TabIndex = 7;
            this.cbUseSqlCon.Text = "Use Sql Connection String";
            this.cbUseSqlCon.UseVisualStyleBackColor = true;
            this.cbUseSqlCon.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cbIsSqlAthun
            // 
            this.cbIsSqlAthun.AutoSize = true;
            this.cbIsSqlAthun.Enabled = false;
            this.cbIsSqlAthun.Location = new System.Drawing.Point(102, 70);
            this.cbIsSqlAthun.Name = "cbIsSqlAthun";
            this.cbIsSqlAthun.Size = new System.Drawing.Size(106, 17);
            this.cbIsSqlAthun.TabIndex = 7;
            this.cbIsSqlAthun.Text = "Sql Athuntication";
            this.cbIsSqlAthun.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Password:";
            // 
            // txtSqlServerName
            // 
            this.txtSqlServerName.Location = new System.Drawing.Point(102, 19);
            this.txtSqlServerName.Name = "txtSqlServerName";
            this.txtSqlServerName.Size = new System.Drawing.Size(227, 20);
            this.txtSqlServerName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "DB Server :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.nbAtendanceSyncInterval);
            this.groupBox3.Controls.Add(this.cbEnableServiceAutoSync);
            this.groupBox3.Location = new System.Drawing.Point(372, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 47);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Windows Service Task Settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(249, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "min";
            // 
            // nbAtendanceSyncInterval
            // 
            this.nbAtendanceSyncInterval.DecimalPlaces = 1;
            this.nbAtendanceSyncInterval.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nbAtendanceSyncInterval.Location = new System.Drawing.Point(202, 18);
            this.nbAtendanceSyncInterval.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nbAtendanceSyncInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nbAtendanceSyncInterval.Name = "nbAtendanceSyncInterval";
            this.nbAtendanceSyncInterval.Size = new System.Drawing.Size(44, 20);
            this.nbAtendanceSyncInterval.TabIndex = 8;
            this.nbAtendanceSyncInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbEnableServiceAutoSync
            // 
            this.cbEnableServiceAutoSync.AutoSize = true;
            this.cbEnableServiceAutoSync.Location = new System.Drawing.Point(13, 19);
            this.cbEnableServiceAutoSync.Name = "cbEnableServiceAutoSync";
            this.cbEnableServiceAutoSync.Size = new System.Drawing.Size(174, 17);
            this.cbEnableServiceAutoSync.TabIndex = 7;
            this.cbEnableServiceAutoSync.Text = "Auto sync attendance at every ";
            this.cbEnableServiceAutoSync.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbLogDebug);
            this.groupBox4.Controls.Add(this.btnClearLog);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.nbLogRemoveInterval);
            this.groupBox4.Controls.Add(this.cbLogWarning);
            this.groupBox4.Controls.Add(this.cbLogInfo);
            this.groupBox4.Controls.Add(this.cbLogSuccess);
            this.groupBox4.Controls.Add(this.cbLogError);
            this.groupBox4.Controls.Add(this.cbEnableAutoRemoveLog);
            this.groupBox4.Location = new System.Drawing.Point(372, 263);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(354, 98);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Event Log Settings";
            // 
            // cbLogDebug
            // 
            this.cbLogDebug.AutoSize = true;
            this.cbLogDebug.Location = new System.Drawing.Point(9, 44);
            this.cbLogDebug.Name = "cbLogDebug";
            this.cbLogDebug.Size = new System.Drawing.Size(79, 17);
            this.cbLogDebug.TabIndex = 11;
            this.cbLogDebug.Text = "Log Debug";
            this.cbLogDebug.UseVisualStyleBackColor = true;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(255, 69);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(96, 23);
            this.btnClearLog.TabIndex = 10;
            this.btnClearLog.Text = "Clear Event Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(221, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "hour";
            // 
            // nbLogRemoveInterval
            // 
            this.nbLogRemoveInterval.DecimalPlaces = 1;
            this.nbLogRemoveInterval.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nbLogRemoveInterval.Location = new System.Drawing.Point(171, 64);
            this.nbLogRemoveInterval.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nbLogRemoveInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nbLogRemoveInterval.Name = "nbLogRemoveInterval";
            this.nbLogRemoveInterval.Size = new System.Drawing.Size(44, 20);
            this.nbLogRemoveInterval.TabIndex = 8;
            this.nbLogRemoveInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbLogWarning
            // 
            this.cbLogWarning.AutoSize = true;
            this.cbLogWarning.Location = new System.Drawing.Point(107, 21);
            this.cbLogWarning.Name = "cbLogWarning";
            this.cbLogWarning.Size = new System.Drawing.Size(87, 17);
            this.cbLogWarning.TabIndex = 7;
            this.cbLogWarning.Text = "Log Warning";
            this.cbLogWarning.UseVisualStyleBackColor = true;
            // 
            // cbLogInfo
            // 
            this.cbLogInfo.AutoSize = true;
            this.cbLogInfo.Location = new System.Drawing.Point(107, 44);
            this.cbLogInfo.Name = "cbLogInfo";
            this.cbLogInfo.Size = new System.Drawing.Size(68, 17);
            this.cbLogInfo.TabIndex = 7;
            this.cbLogInfo.Text = "Log Info ";
            this.cbLogInfo.UseVisualStyleBackColor = true;
            // 
            // cbLogSuccess
            // 
            this.cbLogSuccess.AutoSize = true;
            this.cbLogSuccess.Location = new System.Drawing.Point(224, 21);
            this.cbLogSuccess.Name = "cbLogSuccess";
            this.cbLogSuccess.Size = new System.Drawing.Size(88, 17);
            this.cbLogSuccess.TabIndex = 7;
            this.cbLogSuccess.Text = "Log Success";
            this.cbLogSuccess.UseVisualStyleBackColor = true;
            // 
            // cbLogError
            // 
            this.cbLogError.AutoSize = true;
            this.cbLogError.Location = new System.Drawing.Point(9, 21);
            this.cbLogError.Name = "cbLogError";
            this.cbLogError.Size = new System.Drawing.Size(69, 17);
            this.cbLogError.TabIndex = 7;
            this.cbLogError.Text = "Log Error";
            this.cbLogError.UseVisualStyleBackColor = true;
            // 
            // cbEnableAutoRemoveLog
            // 
            this.cbEnableAutoRemoveLog.AutoSize = true;
            this.cbEnableAutoRemoveLog.Location = new System.Drawing.Point(9, 66);
            this.cbEnableAutoRemoveLog.Name = "cbEnableAutoRemoveLog";
            this.cbEnableAutoRemoveLog.Size = new System.Drawing.Size(156, 17);
            this.cbEnableAutoRemoveLog.TabIndex = 7;
            this.cbEnableAutoRemoveLog.Text = "Auto remove log after every";
            this.cbEnableAutoRemoveLog.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(617, 367);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 43);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save All Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(372, 367);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(94, 43);
            this.btnReload.TabIndex = 1;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ctlServiceControler1);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(354, 98);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Windows Service Status";
            // 
            // ctlServiceControler1
            // 
            this.ctlServiceControler1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlServiceControler1.Location = new System.Drawing.Point(3, 16);
            this.ctlServiceControler1.Name = "ctlServiceControler1";
            this.ctlServiceControler1.Size = new System.Drawing.Size(348, 79);
            this.ctlServiceControler1.TabIndex = 2;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(472, 367);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(94, 43);
            this.btnRestore.TabIndex = 1;
            this.btnRestore.Text = "Restore Default";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(17, 413);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(480, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Note: To make ensure any changes take effect, first save settings and must restar" +
    "t windows service.";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.AuthUrl);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.btnWebapiAuthoinfoSave);
            this.groupBox6.Controls.Add(this.tbWebApiPassword);
            this.groupBox6.Controls.Add(this.tbWebapiUserName);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Location = new System.Drawing.Point(372, 144);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(354, 119);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Service User Auth Info";
            // 
            // btnWebapiAuthoinfoSave
            // 
            this.btnWebapiAuthoinfoSave.Location = new System.Drawing.Point(224, 90);
            this.btnWebapiAuthoinfoSave.Name = "btnWebapiAuthoinfoSave";
            this.btnWebapiAuthoinfoSave.Size = new System.Drawing.Size(115, 23);
            this.btnWebapiAuthoinfoSave.TabIndex = 4;
            this.btnWebapiAuthoinfoSave.Text = "Authenticate";
            this.btnWebapiAuthoinfoSave.UseVisualStyleBackColor = true;
            this.btnWebapiAuthoinfoSave.Click += new System.EventHandler(this.btnWebapiAuthoinfoSave_Click);
            // 
            // tbWebApiPassword
            // 
            this.tbWebApiPassword.Location = new System.Drawing.Point(102, 67);
            this.tbWebApiPassword.Name = "tbWebApiPassword";
            this.tbWebApiPassword.PasswordChar = '*';
            this.tbWebApiPassword.Size = new System.Drawing.Size(237, 20);
            this.tbWebApiPassword.TabIndex = 3;
            // 
            // tbWebapiUserName
            // 
            this.tbWebapiUserName.Location = new System.Drawing.Point(102, 41);
            this.tbWebapiUserName.Name = "tbWebapiUserName";
            this.tbWebapiUserName.Size = new System.Drawing.Size(237, 20);
            this.tbWebapiUserName.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Password:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "User Name:";
            // 
            // AuthUrl
            // 
            this.AuthUrl.Location = new System.Drawing.Point(102, 14);
            this.AuthUrl.Name = "AuthUrl";
            this.AuthUrl.Size = new System.Drawing.Size(237, 20);
            this.AuthUrl.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Auth Url: ";
            // 
            // CtlSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Name = "CtlSettings";
            this.Size = new System.Drawing.Size(755, 443);
            this.Load += new System.EventHandler(this.CtlSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbAtendanceSyncInterval)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbLogRemoveInterval)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHrService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSqlDBName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSqlServerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSqlPass;
        private System.Windows.Forms.TextBox txtSqlUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbIsSqlAthun;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nbAtendanceSyncInterval;
        private System.Windows.Forms.CheckBox cbEnableServiceAutoSync;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nbLogRemoveInterval;
        private System.Windows.Forms.CheckBox cbLogWarning;
        private System.Windows.Forms.CheckBox cbLogInfo;
        private System.Windows.Forms.CheckBox cbLogSuccess;
        private System.Windows.Forms.CheckBox cbLogError;
        private System.Windows.Forms.CheckBox cbEnableAutoRemoveLog;
        private System.Windows.Forms.Button btnTestHrService;
        private System.Windows.Forms.Button btnSqlServerTest;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReload;
        private CtlServiceControler ctlServiceControler1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbUseSqlCon;
        private System.Windows.Forms.RichTextBox txtSqlConString;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbLogDebug;
        private System.Windows.Forms.CheckBox IsUseWebApiCheckBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tbWebApiPassword;
        private System.Windows.Forms.TextBox tbWebapiUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnWebapiAuthoinfoSave;
        private System.Windows.Forms.TextBox AuthUrl;
        private System.Windows.Forms.Label label11;
    }
}
