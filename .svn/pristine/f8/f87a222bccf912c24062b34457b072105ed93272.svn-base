using System;
using System.ServiceModel;
using AIUB.FingerPrintSync.Framework.Helpers.EventLogHelper;

namespace AIUB.FingerPrintSync.Framework.WcfComunication.Client
{
    [ServiceContract(Namespace = "net.pipe://localhost/PipeMessage")]
    public interface IMessageService
    {
        [OperationContract]
        void LogMessage(string value);
    }
    public class WcfClient : IDisposable
    {
        private static IMessageService _pipeProxy;
        public static void Connect()
        {
            try
            {
                Close();
                ChannelFactory<IMessageService> pipeFactory =
                    new ChannelFactory<IMessageService>(
                        new NetNamedPipeBinding(),
                        new EndpointAddress(
                            "net.pipe://localhost/PipeMessage"));
                _pipeProxy =
                    pipeFactory.CreateChannel();

                Console.WriteLine(((IClientChannel)_pipeProxy).State);
                
            }
            catch (Exception ex)
            {
               LogHelper.LogError("Wcf client cant send massage." + ex.ToString());
            }
        }

        public static void SendMessage(string message)
        {
           

            //if (pipeProxy != null)
            {
                try
                {
                   //((IClientChannel)pipeProxy).Open();
                   //((IClientChannel)pipeProxy).Close();
                    if (_pipeProxy == null)
                    {
                        Connect();
                    }
                    //else if (((IClientChannel) _pipeProxy).State != CommunicationState.Created && ((IClientChannel)_pipeProxy).State != CommunicationState.Faulted)
                    //{
                    //    Connect();
                    //}
                    else if (((IClientChannel)_pipeProxy).State == CommunicationState.Faulted)
                    {
                        Connect();
                        // call service - everything's fine
                    }
                    else
                    {
                        // channel faulted - re-create your client and then try again
                    }
                    _pipeProxy.LogMessage(message);
                }
                catch (EndpointNotFoundException ex)
                {
                   // LogHelper.LogInfo("Wcf server not open.");
                }
                catch (Exception ex)
                {
                    if (((IClientChannel)_pipeProxy).State != CommunicationState.Faulted)
                    LogHelper.LogError("Wcf client cant send massage." + ex.ToString());
                }

            }
        }
        public static void Close()
        {
            if (_pipeProxy != null)
            {
                if (((IClientChannel) _pipeProxy).State != CommunicationState.Faulted)
                {
                    ((IClientChannel)_pipeProxy).Dispose();
                }
              
                _pipeProxy = null;
            }
        }
        public void Dispose()
        {
            Close();

        }


    }
}


//private void Connect2()
//        {
//            var group = ServiceModelSectionGroup.GetSectionGroup(
//                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None));
//            if (group != null)
//            {
//                //create duplex channel factory
//                pipeFactory = new DuplexChannelFactory<IMessageService>(
//                                              this, group.Client.Endpoints[0].Name);
//                //create a communication channel and register for its events
//                pipeProxy = pipeFactory.CreateChannel();
//                //((IClientChannel)pipeProxy).Faulted += PipeProxyFaulted;
//                //((IClientChannel)pipeProxy).Opened += PipeProxyOpened;
//                try
//                {
//                    //try to open the connection
//                    ((IClientChannel)pipeProxy).Open();
//                    //this.checkConnectionTimer.Stop();
//                    ////register for added products
//                    //pipeProxy.RegisterForAddedProducts();
//                }
//                catch
//                {
//                    //for example show status text or log;
//                }
//            }
//        }
