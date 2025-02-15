﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AIUB.FingerPrintSync.Framework.Data;
using AIUB.FingerPrintSync.Framework.Helpers;
using AIUB.FingerPrintSync.Framework.Helpers.AppSettings;
using AIUB.FingerPrintSync.Framework.Helpers.EventLogHelper;
using AIUB.FingerPrintSync.Framework.WcfComunication;
using AIUB.FingerPrintSync.Framework.WcfComunication.Client;

namespace AIUB.FingerPrintSync.Framework.Facade
{
    public class DeviceFacade
    {
        public static List<TB_READER> GetDeviceList()
        {
//            var allDevice = DataManager.Instance2.TB_READER.ToList();
//            var activeIds = AppSettingsHelper.SettingsInstance.ActiveDeviceList;
//            foreach (var device in allDevice.Where(device => activeIds.IndexOf(device.nReaderIdn) != -1))
//            {
//                device.IsActive = true;
//            }
            var allDevice = new  List<TB_READER>();
            return allDevice;
        }

        public static List<roomIP> GetActiveDeviceList()
        {
            var allDevice = DataManager.Instance.roomIPs.ToList();
            var activeIds = AppSettingsHelper.SettingsInstance.ActiveDeviceList.Select(id => allDevice.SingleOrDefault(dv => dv.id == id)).ToList();

            if (activeIds.Count > 0 && activeIds[0] !=null)
            activeIds.ForEach(x => x.IsEnabled = true);
            //foreach (var id in activeIds)
            //{ 
            //    var activeDevice = allDevice.SingleOrDefault(dv => dv.nReaderIdn == id);
            //    activeList.Add(activeDevice);
            //}

            return activeIds;
        }

        public static List<TB_READER> GetReaderListWithOnlineStatus()
        {
            var allDevice = GetDeviceList();

            Parallel.ForEach(allDevice, currentDevice =>
            {
//                if (!Utils.PingHostAddress(currentDevice.sIP))
//                {
//                    currentDevice.Status2 = TB_READER.ReaderStatusEnum.Offline;
//                    if (currentDevice.IsActive)
//                    {
//                        LogHelper.LogWarning(string.Format("Alert! Device offline Id:{0},\tName :{1},\tIP:{2}", currentDevice.nReaderIdn, currentDevice.sName, currentDevice.sIP));
//                        WcfClient.SendMessage(string.Format("Alert! Device offline Id:{0},\tName :{1},\tIP:{2}",
//                            currentDevice.nReaderIdn, currentDevice.sName, currentDevice.sIP));
//                    }
//
//                }
//                else
//                {
//                    currentDevice.Status2 = TB_READER.ReaderStatusEnum.Online;
//                }
            });
            return allDevice;
        }

        public static bool SaveDeviceList(List<TB_READER> allDevice, out string error)
        {
            //BioStarEntities context = DataManager.Instance;
            //context.SaveChanges();

           
//            var activeIds = (from device in allDevice where device.IsActive select device.nReaderIdn).ToList(); //AppSettingsHelper.SettingsInstance.ActiveDeviceList;
//             error = "";
            var activeIds = new List<int>();
            AppSettingsHelper.SettingsInstance.ActiveDeviceList = activeIds;
            return AppSettingsHelper.SaveSettings(out error);

        }
        public static void SendEmailOfActiveDeviceStatusAsync()
        {
            string error;
            Thread thread = new Thread(() => DeviceFacade.SendEmailOfActiveDeviceStatus(out error));
            thread.Start();
        }
        public static bool SendEmailOfActiveDeviceStatus(out string message)
        {
            message = "";

            if (GetActiveDeviceList().Count == 0)
            {
                message = "No active device found to check. (no email need to  send)";
                LogHelper.LogSuccess(message);
                WcfClient.SendMessage(message);
                //AppSettingsHelper.SettingsInstance.EmailLastSendSuccess = DateTime.Now;
                //AppSettingsHelper.SaveSettings(out message);
                return true;

            }

            List<TB_READER> allDevice = GetReaderListWithOnlineStatus().Where(dv => dv.IsActive && dv.Status2 == TB_READER.ReaderStatusEnum.Offline).ToList();
            if (allDevice.Count == 0)
            {
                message = "All selected Fingerprint Devices are Online. (no email need to  send)";
                LogHelper.LogSuccess(message);
                WcfClient.SendMessage(message);
                //AppSettingsHelper.SettingsInstance.EmailLastSendSuccess = DateTime.Now;
                //AppSettingsHelper.SaveSettings(out message);
                return true;
            }


            bool success = false;
            string subject = "Some Fingerprint device not responding! (from AIUB SD)";

            MailAddressCollection senderAddress = Utils.GetSenderAddress(AppSettingsHelper.SettingsInstance.EmailUserName);

            MailAddressCollection toAddress = Utils.GetEmailToAddress();

            string body = allDevice.Count+" fingerprint Device not found in network, please take necessery action.\n";
            int no = 1; 
            foreach (var reader in allDevice)
            {
//                body += string.Format("\n{3}. Device :{0}; IP:{1}; Id:{2}", reader.sName, reader.sIP, reader.nReaderIdn, no++);
            }
            body += "\n\nAIUB Software Division";
            body += "\nCampus-4, Ext:421";
            body += "\n\n==============================================================";
            body += "\n(This is an auto generated email, please ignore if you are not concern person)";


            using (var em = new EmailHelper(Utils.GetSmtpClientSettings()))
            {
                success = em.SendMail(toAddress, subject, body, senderAddress, out message);
            }
            if (!success)
            {
                message = "Email sending failed for device status! " + message;
                LogHelper.LogError(message);
                WcfClient.SendMessage(message);
                return false;
            }
            else
            {
                AppSettingsHelper.SettingsInstance.EmailLastSendSuccess = DateTime.Now;
                AppSettingsHelper.SaveSettings(out message);
                message = "Email send success for device status.";
                LogHelper.LogSuccess(message + body);
                WcfClient.SendMessage(message);
                return true;
            }


        }
    }
}
