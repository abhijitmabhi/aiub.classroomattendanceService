using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AIUB.FingerPrintSync.Framework.Helpers
{
    public class WinServiceHelper
    {
        public static string ServiceName
        {
            get { return ConfigurationManager.AppSettings["WinServiceName"]; }
        }

        public static string GetServiceDisplayName(string serviceName)
        {
            try
            {
                using (ServiceController service = new ServiceController(serviceName))
                {
                    return service.DisplayName;
                }
            }
            catch (Exception)
            {
                return "\"Service Not found\"";
            }
            
        }

        public static bool IsServiceRunning(string serviceName)
        {
            try
            {
                using (ServiceController service = new ServiceController(serviceName))
                {
                    if (service.Status.ToString() == "Running")
                        return true;
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public static string GetServiceStatus(string serviceName)
        {
            try
            {
                using (ServiceController service = new ServiceController(serviceName))
                {
                    return service.Status.ToString();
                }
            }
            catch (Exception)
            {

                return "\"Service Not found\"";
            }
            
        }

        public static bool StartService(string serviceName, int timeoutSeconds, out string message)
        {
            message = "";
            try
            {
                using (ServiceController service = new ServiceController(serviceName))
                {
                    // string svcStatus = service.Status.ToString();
                    if (service.Status.ToString() == "Running")
                        return true;


                    TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutSeconds*1000);

                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                    if (service.Status.ToString() == "Running")
                        return true;
                    return false;
                }
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                return false;
                // ...
            }
        }
      
           

        public static bool StopService(string serviceName, int timeoutSeconds,out string message)
        {
            message = "";
            using (ServiceController service = new ServiceController(serviceName))
            {
                if (service.Status.ToString() == "Stopped")
                    return true;
                try
                {
                    TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutSeconds*1000);

                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                    if (service.Status.ToString() == "Stopped")
                        return true;

                    return false;
                }
                catch (Exception ex)
                {
                    message = ex.ToString();
                    // ...
                    return false;
                }
            }
        }
        public static bool RestartService(string serviceName, int timeoutSeconds, out string message)
        {
            message = "";
            using (ServiceController service = new ServiceController(serviceName))
            {

                try
                {
                    int millisec1 = Environment.TickCount;
                    TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutSeconds * 1000);

                    if (service.Status.ToString() == "Running")
                    { 
                        service.Stop();
                        service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                    }
                    

                    // count the rest of the timeout
                    int millisec2 = Environment.TickCount;
                    timeout = TimeSpan.FromMilliseconds((timeoutSeconds * 1000) - (millisec2 - millisec1));

                    if (service.Status.ToString() == "Stopped")
                    {
                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                    }

                    if (service.Status.ToString() == "Running")
                        return true;

                    return false;
                }
                catch (Exception ex)
                {
                    message = ex.ToString();
                    // ...
                    return false;
                }
            }
        }
    }
}
