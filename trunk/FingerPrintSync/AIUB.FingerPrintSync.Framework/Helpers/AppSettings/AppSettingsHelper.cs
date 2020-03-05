using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using AIUB.FingerPrintSync.Framework.Helpers.EventLogHelper;

namespace AIUB.FingerPrintSync.Framework.Helpers.AppSettings
{
    public class AppSettingsHelper
    {
        static AppSettingsHelper()
        {

            //InitSettingFileChangeWatcher();
        }

        #region File change watcher
        private static void InitSettingFileChangeWatcher()
        {
            //watch if settings file chages by other app
            System.IO.FileSystemWatcher watcher = new FileSystemWatcher();
            Directory.CreateDirectory(UserSpecificAppDataDirectory);
            watcher.Path = UserSpecificAppDataDirectory;
            // Only watch xml files.
            watcher.Filter = "*.xml";
            /* Watch for changes in LastAccess and LastWrite times, and
                the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastWrite;// NotifyFilters.LastAccess | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.Changed += OnSettingsFileChanged;
            //watcher.Created += OnSettingsFileChanged;
            //Begin watching.
            watcher.EnableRaisingEvents = true;
            // Add event handlers.
            //watcher.Changed += new FileSystemEventHandler(OnChanged);
            //watcher.Created += new FileSystemEventHandler(OnChanged);
            //watcher.Deleted += new FileSystemEventHandler(OnChanged);
            //watcher.Renamed += new RenamedEventHandler(OnRenamed);
        }

        static void OnSettingsFileChanged(object sender, FileSystemEventArgs e)
        {
            ReloadSettings();
        }
        #endregion
        
        private static Objects.AppSettings _appSettings;


        //AppDomain.CurrentDomain.BaseDirectory "
        // user-specific application data is stored here
        private static readonly string UserSpecificAppDataDirectory = Environment.GetFolderPath(
                                                Environment.SpecialFolder.CommonApplicationData,
                                                Environment.SpecialFolderOption.Create
                                                ) + "\\AIUB\\FingerPrintSync";
        private static readonly string SettingsFilePath = UserSpecificAppDataDirectory + "\\settings.xml";

        public static Objects.AppSettings SettingsInstance
        {
            get
            {
                string error = "";
                //if settings is null for first time
                if (_appSettings == null)
                {
                    _appSettings = ExportImportManager.ImportFromXml(SettingsFilePath, out error);
                    //if settings file xml not created
                    if (_appSettings == null)
                    {
                        _appSettings = GetDefaultSettings();
                        if (SaveSettings(out error))
                        {
                            return _appSettings;
                        }

                    }
                    LogHelper.LogInfo("Settings loaded from-> " + SettingsFilePath);
                }
                return _appSettings;
            }
            set { _appSettings = value; }
        }

        public static bool ReloadSettings()
        {
            
            string error = "";
            _appSettings = ExportImportManager.ImportFromXml(SettingsFilePath, out error);
            //if settings file xml not created
            if (_appSettings == null)
            {
                _appSettings = GetDefaultSettings();
                if (SaveSettings(out error))
                {
                    return true;
                }

                return false;
            }
            LogHelper.LogInfo("Settings loaded from-> " + SettingsFilePath);
            return true;
        }

        public static bool RestoreDefaultSettings()
        {
            string error = "";
            _appSettings = GetDefaultSettings();
            if (SaveSettings(out error))
            {
                return true;
            }
            return false;
        }

        public static void DeleteSettingsFile()
        {
            try
            {
                if (Directory.Exists(UserSpecificAppDataDirectory))
                    Directory.Delete(UserSpecificAppDataDirectory, true);
            }
            catch
            {
                LogHelper.LogError("Settings file delete failed onAfterUninstall. ->" + SettingsFilePath);
            }

        }

        public static bool SaveSettings(out string error)
        {

            error = "";
            if (ExportImportManager.SaveToXml(_appSettings, SettingsFilePath, out error))
            {
                LogHelper.LogInfo("Settings saved to-> " + SettingsFilePath);
                return true;
            }
            LogHelper.LogError("Failed to saved settings to xml." + error);
            return false;
        }

        private static Objects.AppSettings GetDefaultSettings()
        {
            return new Objects.AppSettings()
             {
                 AppEnableAutoSync = false,
                 AppLastSyncTime = new DateTime(2014, 01, 01),
                 AppSchedulerIntervalInMinute = 0.1,

                 EnableAutoRemoveLog = false,
                 EnableErrorLog = true,
                 EnableInfoLog = true,
                 EnableSuccessLog = true,
                 EnableWarningLog = false,
                 EnableDebugLog = true,
                 RemoveLogAfterInHour = 6,

                 HRServiceUrl = @"https://ums.aiub.edu/PrintService.svc",
                 AuthUrl = "https://ums.aiub.edu",
                 IsSqlAuthentication = true,

                 AttendanceEnableAutoSync = true,
                 AttendanceSyncLastSuccess = new DateTime(2014, 01, 01),
                 AttendanceSyncLastOccured = new DateTime(2014, 01, 01),
                 AttendanceSyncIntervalInMinute = 0.1,
                 SqlServerName = @"localhost\BSSERVER",
                 SqlServerPassword = "1234",
                 SqlServerUserName = "bsuser",
                 SuprimaDBName = "BioStar",
                 UseSqlConnectionString = false,
                 SqlConnectionString = @"data source=localhost\BSSERVER; initial catalog=BioStar; integrated security=SSPI; MultipleActiveResultSets=True; App=EntityFramework",

                 ActiveDeviceList= new List<int>{01},
                 EnableAutoEmailDeviceStatus=false,
                 EmailLastSendSuccess= new DateTime(2014, 01, 01),
                 EmailSendLastOccured = new DateTime(2014, 01, 01),
                 EmailDeviceStatusIntervalInHour=.5,
                 EmailSmtpServer = "pod51003.outlook.com",
                 EmailSmtpPort =25, //587,
                 EmailUserName = "error@aiub.edu",
                 EmailPassword = "3rr0r@a1ub14",
                 EmailEnableSsl = true,
                 EmailToAddress = "hkpavel@gmail.com",
                 WebApiUserName = "Admin",
                 IsUseWebApi = true,
                 WebApiPassword = "317857",
                 WebApiToken = ""
             };

        }
    }
}
