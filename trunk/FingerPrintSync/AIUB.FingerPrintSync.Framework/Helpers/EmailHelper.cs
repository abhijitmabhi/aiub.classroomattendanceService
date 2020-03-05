using System;
using System.Net;
using System.Net.Mail;

namespace AIUB.FingerPrintSync.Framework.Helpers
{
    public class EmailHelper : IDisposable
    {

        SmtpClientSettings _SmtpClientSettings { get; set; }

        public EmailHelper(SmtpClientSettings smtpClientSettings)
        {
            _SmtpClientSettings = smtpClientSettings;
        }
        public bool SendMail(MailAddress toAddress, string subject, string body, MailAddressCollection senderAddress)
        {
            try
            {
                //var toAddress = new MailAddress(toEmail, toName);

                var smtp = GetSmtpClient();

                using (var message = new MailMessage(_SmtpClientSettings.Email, toAddress)
                {
                    Subject = subject,
                    Body = body

                })
                {
                    foreach (var item in senderAddress)
                    {
                        message.ReplyToList.Add(item);
                    }
                    //message.To.Add(toAddress);
                    //message.From = _HostAddress;
                    // message.Sender = senderAddress.FirstOrDefault();

                    // message.Subject = subject;
                    // message.Body = body;

                    message.IsBodyHtml = false;
                    message.Priority = MailPriority.High;

                    smtp.Send(message);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SendMail(MailAddressCollection toAddress, string subject, string body, MailAddressCollection senderAddress,out string error)
        {
            error = "";
            try
            {
                //var toAddress = new MailAddress(toEmail, toName);

                var smtp = GetSmtpClient();

                using (var message = new MailMessage() { Subject = subject, Body = body })
                {
                    if (senderAddress != null)
                    {
                        foreach (var item in senderAddress)
                        {
                            message.ReplyToList.Add(item);
                        }
                    }
                    foreach (var item in toAddress)
                    {
                        message.To.Add(item);
                    }
                    //message.To.Add(toAddress);
                    message.From = _SmtpClientSettings.Email;
                   
                    // message.Sender = senderAddress.FirstOrDefault();
                    // message.Subject = subject;
                    // message.Body = body;

                    message.IsBodyHtml = false;
                    message.Priority = MailPriority.High;

                    smtp.Send(message);
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                return false;
            }
        }
        private SmtpClient GetSmtpClient()
        {
            return new SmtpClient
            {
                Host = _SmtpClientSettings.ServerAddress, //"smtp.gmail.com",
                Port = _SmtpClientSettings.Port,//587,
                EnableSsl =_SmtpClientSettings.EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_SmtpClientSettings.Email.Address, _SmtpClientSettings.Password)
            };
        }

        public void Dispose()
        {
            _SmtpClientSettings = null;
        }
        public class SmtpClientSettings
        {
            //private int _timeout=;
            private bool _enableSsl=true;
            public string ServerAddress { get; set; }
            public int Port { get; set; }
            public MailAddress Email { get; set; }
            public string Password { get; set; }
            public bool EnableSsl
            {
                get { return _enableSsl; }
                set { _enableSsl = value; }
            }

            //public int Timeout
            //{
            //    get { return _timeout; }
            //    set { _timeout = value; }
            //}
        }
    }
}