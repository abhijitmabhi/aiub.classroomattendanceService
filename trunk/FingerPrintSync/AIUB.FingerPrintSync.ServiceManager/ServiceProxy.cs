using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using AIUB.FingerPrintSync.Framework.Helpers.AppSettings;
using AIUB.FingerPrintSync.ServiceManager.AttendanceService;

namespace AIUB.FingerPrintSync.ServiceManager
{
    internal  class ServiceProxy
    {



        public static PrintServiceClient AttendanceServiceProxy
        {
            get
            {
                EndpointAddress es = new EndpointAddress(AppSettingsHelper.SettingsInstance.HRServiceUrl);
                BasicHttpBinding _binding = new BasicHttpBinding() { MaxReceivedMessageSize = 2147483647 };
                
                var service = new PrintServiceClient(_binding,es);
                return service;
            }
        }
    }
}
