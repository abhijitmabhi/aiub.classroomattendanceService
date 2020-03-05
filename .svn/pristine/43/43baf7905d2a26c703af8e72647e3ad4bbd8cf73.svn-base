using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AIUB.FingerPrintSync.Framework.Helpers.AppSettings;
using AIUB.FingerPrintSync.Framework.Helpers.EventLogHelper;
using AIUB.FingerPrintSync.Framework.WcfComunication.Client;

namespace AIUB.FingerPrintSync.Framework.Helpers
{
    public class Utils
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }
        public static bool PingHostAddress(string ipAddress)
        {
            try
            {
                lock (ipAddress)
                {
                    string PingResult = "";
                    //lblStatus.Text = null;
                    Ping ping = new Ping();

                    PingReply pingreply = ping.Send(ipAddress);
                    PingResult += "Address: " + pingreply.Address + "\r\n";
                    PingResult += "Status: " + pingreply.Status.ToString() + "\r\n";
                    PingResult += "Roundtrip Time: " + pingreply.RoundtripTime + "\r\n";
                    //PingResult += "TTL (Time To Live): " + pingreply.Options.Ttl + "\r\n";
                    PingResult += "Buffer Size: " + pingreply.Buffer.Length.ToString() + "\r\n";
                    if (pingreply.Status.ToString() == "Success")
                    {
                        //ShowMbox.Success("Device IP '" + IPAddress + "' is available or alive.\n" + PingResult, "Device IP Ping Succesfull.");

                        //Log(MessageTypeEnum.Information, "Device IP '" + ipAddress + "' Ping Succesfull. " + AppDomain.GetCurrentThreadId().ToString());
                        return true;
                    }
                    else
                    {
                        //ShowMbox.Stop("Host Address '" + IPAddress + "' not available or Ping disabled.\nPlease check Server Host Address.\n" + PingResult, "Host Address Ping Failed.");

                        //Log(MessageTypeEnum.Error, "Device IP '" + ipAddress + "' not available. Ping Failed.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // lblStatus.Text = err.Message;
                //ShowMbox.Error("Host Address '" + IPAddress + "' not available or Ping disabled.\nPlease check Server Host Address.", "Host Address Ping Failed.");

                //Log(MessageTypeEnum.Error, "Device IP '" + ipAddress + "' not available. Ping Failed.");
                return false;
            }
        }
        public static EmailHelper.SmtpClientSettings GetSmtpClientSettings()
        {
            return new EmailHelper.SmtpClientSettings()
            {
                Email = new MailAddress(AppSettingsHelper.SettingsInstance.EmailUserName, "Aiub Fingerprint Service"),//naabsfeedback@gmail.com
                Password = AppSettingsHelper.SettingsInstance.EmailPassword,//n@@b$P@$$word
                Port = AppSettingsHelper.SettingsInstance.EmailSmtpPort,
                EnableSsl = AppSettingsHelper.SettingsInstance.EmailEnableSsl,
                ServerAddress = AppSettingsHelper.SettingsInstance.EmailSmtpServer
            };

        }
        public static MailAddressCollection GetEmailToAddress()
        {
            try
            {
                string[] toAddress = AppSettingsHelper.SettingsInstance.EmailToAddress.Split(';');
                if (toAddress.Any())
                {
                    MailAddressCollection toMailAddress = new MailAddressCollection();
                    foreach (var address in toAddress)
                    {
                        toMailAddress.Add(new MailAddress(address.Trim(), address));
                    }

                    //toAddress.Add(new MailAddress("hkpavel@gmail.com", "Pavel"));
                    //toAddress.Add(new MailAddress("bassam146@gmail.com", "Bassam"));
                    return toMailAddress;
                }
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception.ToString());
                WcfClient.SendMessage(exception.ToString());
                return null;

            }
            return null;

        }
        public static MailAddressCollection GetSenderAddress(string emailAddress)
        {
            //if (String.IsNullOrEmpty(emailAddress))
            //    return null;
            try
            {
                var email = String.IsNullOrEmpty(emailAddress) ? "test@email.com" : emailAddress;
                var senderAddress = new MailAddressCollection { new MailAddress(email, email) };
                return senderAddress;
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception.ToString());
                WcfClient.SendMessage(exception.ToString());
                return null;
            }

        }
    }
}
