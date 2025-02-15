﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AIUB.FingerPrintSync.Framework.Objects
{
    [Serializable]
    [DataContract(Name = "AppSettingsEntity", Namespace = "http://www.aiub.edu//entities")]
    public class AppSettings : IDisposable
    {
        #region Private Data Types

        private String _hrServiceUrl;
        private String _suprimaDbName;
        private String _sqlServerName;
        private bool _isSqlAuthentication;
        private String _sqlServerUserName;
        private String _sqlServerPassword;
        private bool _useSqlConnectionString;
        private String _sqlConnectionString;

        private DateTime _attendanceSyncLastSuccess;
        private DateTime _attendanceSyncLastOccured;
        private bool _attendanceEnableAutoSync;
        private double _attendanceSyncIntervalInMinute;

        private DateTime _appLastSyncTime;
        private bool _appEnableAutoSync;
        private double _appSchedulerIntervalInMinute;

        private bool _enableAutoRemoveLog;
        private double _removeLogAfterInHoure;

        private bool _enableSuccessLog;
        private bool _enableErrorLog;
        private bool _enableInfoLog;
        private bool _enableWarningLog;
        private bool _enableDebugLog;

        private List<int> _activeDeviceList;

        private bool _enableAutoEmailDeviceStatus;
        private double _mailDeviceStatusIntervalInHour;
        private DateTime _emailLastSendSuccess;
        private DateTime _emailSendLastOccured;
        private string _emailSmtpServer;
        private int _emailSmtpPort;
        private string _emailUserName;
        private string _emailPassword;
        private bool _emailEnableSsl;
        private string _emailToAddress;
        private string _webApiUserName;
        private string _webApiPassword;
        private bool _isUseWebApi;
        private string _webApiToken;
        private string _authUrl;

        public AppSettings()
        {
            
        }

        #endregion

        #region Properties

        [DataMember]
        public String HRServiceUrl
        {
            get { return _hrServiceUrl; }
            set{_hrServiceUrl = value;}
        }

        [DataMember]
        public String AuthUrl
        {
            get { return _authUrl; }
            set { _authUrl = value; }
        }

        [DataMember]
        public String SuprimaDBName
        {
            get { return _suprimaDbName; }
            set{_suprimaDbName = value;}
        }
        [DataMember]
        public String SqlServerName
        {
            get { return _sqlServerName; }
            set{_sqlServerName = value;}
        }
        [DataMember]
        public bool IsSqlAuthentication
        {
            get { return _isSqlAuthentication; }
            set{_isSqlAuthentication = value;}
        }
        [DataMember]
        public String SqlServerUserName
        {
            get { return _sqlServerUserName; }
            set{_sqlServerUserName = value;}
        }
        [DataMember]
        public String SqlServerPassword
        {
            get { return _sqlServerPassword; }
            set{_sqlServerPassword = value;}
        }
        [DataMember]
        public bool UseSqlConnectionString
        {
            get { return _useSqlConnectionString; }
            set{_useSqlConnectionString = value;}
        }
        [DataMember]
        public String SqlConnectionString
        {
            get { return _sqlConnectionString; }
            set{_sqlConnectionString = value;}
        }
        [DataMember]
        public DateTime AttendanceSyncLastSuccess
        {
            get { return _attendanceSyncLastSuccess; }
            set{_attendanceSyncLastSuccess = value;}
        }
          [DataMember]
        public DateTime AttendanceSyncLastOccured
        {
            get { return _attendanceSyncLastOccured; }
            set { _attendanceSyncLastOccured = value; }
        }
        
        [DataMember]
          public bool AttendanceEnableAutoSync
        {
            get { return _attendanceEnableAutoSync; }
            set
            {
                _attendanceEnableAutoSync = value;
            }
        }

        [DataMember]
        public double AttendanceSyncIntervalInMinute
        {
            get { return _attendanceSyncIntervalInMinute; }
            set{_attendanceSyncIntervalInMinute = value;}
        }
        [DataMember]
        public DateTime AppLastSyncTime
        {
            get { return _appLastSyncTime; }
            set
            {
                _appLastSyncTime = value;
            }
        }
        [DataMember]
        public bool AppEnableAutoSync
        {
            get { return _appEnableAutoSync; }
            set{_appEnableAutoSync = value;}
        }
        [DataMember]
        public double AppSchedulerIntervalInMinute
        {
            get { return _appSchedulerIntervalInMinute; }
            set{_appSchedulerIntervalInMinute = value;}
        }
        [DataMember]
        public bool EnableAutoRemoveLog
        {
            get { return _enableAutoRemoveLog; }
            set{_enableAutoRemoveLog = value;}
        }
        [DataMember]
        public double RemoveLogAfterInHour
        {
            get { return _removeLogAfterInHoure; }
            set { _removeLogAfterInHoure = value; }
        }
        [DataMember]
        public bool EnableSuccessLog
        {
            get { return _enableSuccessLog; }
            set { _enableSuccessLog = value; }
        }
        [DataMember]
        public bool EnableErrorLog
        {
            get { return _enableErrorLog; }
            set { _enableErrorLog = value; }
        }
        [DataMember]
        public bool EnableInfoLog
        {
            get { return _enableInfoLog; }
            set { _enableInfoLog = value; }
        }
        [DataMember]
        public bool EnableDebugLog
        {
            get { return _enableDebugLog; }
            set { _enableDebugLog = value; }
        }
        [DataMember]
        public bool EnableWarningLog
        {
            get { return _enableWarningLog; }
            set { _enableWarningLog = value; }
        }
        [DataMember]
        public List<int> ActiveDeviceList
        {
            get { return _activeDeviceList; }
            set { _activeDeviceList = value; }
        }

        #region Email Config
        [DataMember]
        public DateTime EmailLastSendSuccess
        {
            get { return _emailLastSendSuccess; }
            set { _emailLastSendSuccess = value; }
        }
        [DataMember]
        public DateTime EmailSendLastOccured
        {
            get { return _emailSendLastOccured; }
            set { _emailSendLastOccured = value; }
        }
        [DataMember]
        public double EmailDeviceStatusIntervalInHour
        {
            get { return _mailDeviceStatusIntervalInHour; }
            set { _mailDeviceStatusIntervalInHour = value; }
        }
        [DataMember]
        public bool EnableAutoEmailDeviceStatus
        {
            get { return _enableAutoEmailDeviceStatus; }
            set { _enableAutoEmailDeviceStatus = value; }
        }
        [DataMember]
        public string EmailSmtpServer
        {
            get { return _emailSmtpServer; }
            set { _emailSmtpServer = value; }
        }
        [DataMember]
        public int EmailSmtpPort
        {
            get { return _emailSmtpPort; }
            set { _emailSmtpPort = value; }
        }
        [DataMember]
        public string EmailUserName
        {
            get { return _emailUserName; }
            set { _emailUserName = value; }
        }
        [DataMember]
        public string EmailPassword
        {
            get { return _emailPassword; }
            set { _emailPassword = value; }
        }
        [DataMember]
        public bool EmailEnableSsl
        {
            get { return _emailEnableSsl; }
            set { _emailEnableSsl = value; }
        }
        [DataMember]
        public string EmailToAddress
        {
            get { return _emailToAddress; }
            set { _emailToAddress = value; }
        }

        [DataMember]
        public string WebApiUserName
        {
            get { return _webApiUserName; }
            set { _webApiUserName = value; }
        }
        [DataMember]
        public string WebApiPassword
        {
            get { return _webApiPassword; }
            set { _webApiPassword = value; }
        }

        [DataMember]
        public string WebApiToken
        {
            get { return _webApiToken; }
            set { _webApiToken = value; }
        }

        [DataMember]
        public bool IsUseWebApi
        {
            get { return _isUseWebApi; }
            set { _isUseWebApi = value; }
        }
        #endregion
        

        #endregion

        public void Dispose()
        {
            //GC.SuppressFinalize(this);

        }
    }

    public class ActiveDevice : IDisposable
    {
        public void Dispose()
        {
           
        }
    }
}
