using System.ServiceModel;

namespace AIUB.FingerPrintSync.Framework.WcfComunication.Server
{
    public enum MessageTypeEnum
    {
        Info,
        Error,
        Warning,
        Success,
        Result,
        TaskStarted,
        TaskEnded,
        DebugInfo,
        DebugError,
    };
    [ServiceContract(Namespace = "net.pipe://localhost/PipeMessage")]
    public interface IMessageService
    {
        [OperationContract]
        void LogMessage(string value);
    }

    public class MessageService : IMessageService
    {
        public delegate void WriteLogEvent(string message);
        public static event WriteLogEvent OnWriteLogRequest;

        public void LogMessage(string value)
        {
            if (OnWriteLogRequest != null)
                OnWriteLogRequest(value);
        }
    }
}
