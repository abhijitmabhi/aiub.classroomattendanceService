using System;
using System.IO;

namespace AIUB.FingerPrintSync.Framework.SettingsHandler
{
    public sealed class ReadWriteIni
    {
        public ReadWriteIni(string iniFileAbulatePath)
        {
            IniFileAbulatePath = iniFileAbulatePath;
        }
        private string IniDirectoryPath{get;set;}
        private string IniFileName { get; set; }

        private string _iniFileAbulatePath;
        public string IniFileAbulatePath
        {
            get
            {
                return _iniFileAbulatePath;
            }
            set
            {
                _iniFileAbulatePath = value;
                IniDirectoryPath = Path.GetDirectoryName(_iniFileAbulatePath);
                IniFileName = Path.GetFileName(_iniFileAbulatePath);
            }
        }

        public bool IsIniFileExist()
        {
            
            if (File.Exists(IniFileAbulatePath))
            {
                return true;
            }
            return false;

        }
        private void CreateIniFile()
        {
            try
            {
                if (!Directory.Exists(IniDirectoryPath))
                {
                    Directory.CreateDirectory(IniDirectoryPath);
                }
                FileStream st= File.Create(IniFileAbulatePath);
              
                st.Close();
                
            }
            catch (Exception exp)
            {
                throw new Exception(IniFileAbulatePath + " creating failed.", exp);
            }

        }
        public bool ValidateIniFile()
        {
            if (!IsIniFileExist())
            {
                CreateIniFile();
                return true;
            }
            return true;
        }
        public bool UpdateIni(string section,string key, string value)
        {

            if (ValidateIniFile())
            {
                IniFile ini = new IniFile(IniFileAbulatePath);
                ini.IniWriteValue(section, key, value);
                return true;
            }
            else
            {
                throw new Exception("Ini file " + IniFileAbulatePath + " saving failed.");
            }
        }
        public string ReadIni(string section, string Key)
        {
            if (IsIniFileExist())
            {
                IniFile ini = new IniFile(IniFileAbulatePath);
                return ini.IniReadValue(section, Key);
            }
            else 
            {
                throw new Exception("Ini file "+IniFileAbulatePath + " not exist.");
            }
        }
    }

    
}
