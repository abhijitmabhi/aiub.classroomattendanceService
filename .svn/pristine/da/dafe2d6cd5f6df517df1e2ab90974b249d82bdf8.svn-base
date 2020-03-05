///
/// http://tech.pro/tutorial/855/wcf-tutorial-basic-interprocess-communication

using System;
using System.ServiceModel;
using System.Threading;
using AIUB.FingerPrintSync.Framework.Facade;
using AIUB.FingerPrintSync.Framework.Helpers.EventLogHelper;

namespace AIUB.FingerPrintSync.Framework.WcfComunication.Server
{

    public class WcfServer:IDisposable
    {
        private static ServiceHost _host;

        public static void StartHostAsync()
        {
            string error;
            Thread thread = new Thread(() => StartHost());
            thread.Start();
        }

        public static void StartHost()
        {


            var ser = new MessageService();
            _host = new ServiceHost(typeof(MessageService),
                new Uri("net.pipe://localhost"));
   
                //host.AddServiceEndpoint(typeof (IMessageService),
                //    new BasicHttpBinding(),
                //    "Reverse");

            _host.AddServiceEndpoint(typeof(IMessageService),
                    new NetNamedPipeBinding(),
                    "PipeMessage");

            try
            {
                //_host.Close();
                if (_host.State != CommunicationState.Opened)
                    _host.Open();

                LogHelper.LogInfo("Wcf server started.");
            }
            catch (CommunicationObjectFaultedException ex)
            {
                //log exception or do something appropriate
                LogHelper.LogError("Wcf server start failed." + ex.ToString());
            }
            catch (TimeoutException ex)
            {
                //log exception or do something appropriate
                LogHelper.LogError("Wcf server start failed." + ex.ToString());
            }
            catch (Exception ex)
            {
                LogHelper.LogError("Wcf server start failed." + ex.ToString());
            }
        }

        public static void CloseHost()
        {
            if (_host != null && _host.State == CommunicationState.Opened)
            {
                _host.Abort();
            }
            _host = null;
        }

        public void Dispose()
        {
            CloseHost();
        }
    }
}

















//new Uri[]{
//          new Uri("http://localhost:8000"),
//          new Uri("net.pipe://localhost")
//        }


        //private void StartHost1()
        //{
        //    var group =
        //        ServiceModelSectionGroup.GetSectionGroup(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None));

        //    if (group != null)
        //    {
        //        var service = group.Services.Services[0];

        //        var baseAddress = service.Endpoints[0].Address.AbsoluteUri.

        //Replace(service.Endpoints[0].Address.AbsolutePath, String.Empty);

        //        var messageService = new MessageService();

        //        var host = new ServiceHost(typeof (MessageService, new[] { new Uri(baseAddress) });

        //        host.AddServiceEndpoint(typeof(IMessageService),new NetNamedPipeBinding(),
        //                                service.Endpoints[0].Address.AbsolutePath);
        //        try
        //        {
        //            host.Open();
        //        }
        //        catch (CommunicationObjectFaultedException cofe)
        //        {
        //            //log exception or do something appropriate
        //        }
        //        catch (TimeoutException te)
        //        {
        //            //log exception or do something appropriate
        //        }
        //    }
        //}