using System;
using System.Collections.Specialized;

namespace AIUB.FingerPrintSync.Framework.SettingsHandler
{
    public class IniHelper
    {
        public static string IniDirectoryPath = AppDomain.CurrentDomain.BaseDirectory + "\\";
        public static string IniFileName = "settings.ini";
        public static string IniFileAbsulatePath = IniDirectoryPath + IniFileName;
        public static string IniSection = "Settings";

        private ReadWriteIni _IniHandler =null;
        private bool sttingsNotFountFlug=false;
        public IniHelper(string IniFileAbulatePath)
        {
            _IniHandler = new ReadWriteIni(IniFileAbulatePath);
        }

        

        private NameValueCollection _SettingList = new NameValueCollection();

        public void SetSettings(string key, string value)
        {
            if (_SettingList[key] == null)
            {
                _SettingList.Add(key, value);
            }
            else
            {
                _SettingList[key] = value;
            }
        }


        public string GetSettings(string settingskey)
        {
            if (_SettingList.Count > 0 && settingskey!=null)
            {
                return _SettingList[settingskey];
            }
             
            return null;
        }
        public bool Load(string IniSection)
        {
            bool success = false;
            sttingsNotFountFlug = false;
            if (_IniHandler.IsIniFileExist())
            {
                foreach (string key in _SettingList.AllKeys)
                {
                    string value = _IniHandler.ReadIni(IniSection, key);
                    if(value != "" )
                    {
                        _SettingList[key] =value;
                    }
                    else
                    {
                        _SettingList[key] =_SettingList[key];
                        sttingsNotFountFlug = true;
                    }

                }
                success = true;
            }
            else Save(IniSection);


            if (sttingsNotFountFlug)
            Save(IniSection);
            return success;
        }

        public bool Save(string IniSection)
        {
            bool success = false;
            foreach (string key in _SettingList.AllKeys)
            {
                _IniHandler.UpdateIni(IniSection, key, _SettingList[key]); ;
            }
            success = true;
            return success;
        }
    }
}
