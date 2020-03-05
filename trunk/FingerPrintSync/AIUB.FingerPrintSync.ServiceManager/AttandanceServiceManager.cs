using System;
using System.Threading.Tasks;
using AIUB.FingerPrintSync.Framework.Helpers.AppSettings;
using AIUB.FingerPrintSync.Framework.Helpers.RestApiHelper;
using AIUB.FingerPrintSync.Framework.Objects;
using AIUB.FingerPrintSync.ServiceManager.AttendanceService;
using WCFUtils.CommonUtils;


namespace AIUB.FingerPrintSync.ServiceManager
{
    public class AttandanceServiceManager : IDisposable
    {
        #region Attandance service
        //new valid employee list according to new rfid inserted or edit



        public static SubmitResult2Ofstring PostFingerPrintAttendance(int userId, DateTime logTime, string deviceId, string ipAddress, string roomNumber)
        {

            SubmitResult2Ofstring result = new SubmitResult2Ofstring();
            try
            {
                if (AppSettingsHelper.SettingsInstance.IsUseWebApi)
                {
                    AIUB.FingerPrintSync.Framework.Helpers.EventLogHelper.LogHelper.LogDebug("Using Web Api");
                    Task<bool> isSuccess = RestWebapi.PostAttendence(userId, logTime, AppSettingsHelper.SettingsInstance.HRServiceUrl,
                        AppSettingsHelper.SettingsInstance.WebApiToken, deviceId.Trim(), ipAddress.Trim(), roomNumber.Trim());

                    result = new SubmitResult2Ofstring()
                    {
                        Errors = new []{String.Empty, String.Empty, },
                        IsSuccess = isSuccess.Result,
                        Item = ""
                    };
                }
                else
                {
                    AIUB.FingerPrintSync.Framework.Helpers.EventLogHelper.LogHelper.LogDebug("Using WCF API");
                    WCFUtils.ClientUtils.ClientContext.CredentialMessageHeader = new CredentialMessageHeader(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                    using (AttendanceService.PrintServiceClient service = ServiceProxy.AttendanceServiceProxy)
                    {
//                        result = service.PostAttenanceLog2(key, entryTime);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                string [] errors = {"Form Attendence Service: "+ex.ToString()};
                AIUB.FingerPrintSync.Framework.Helpers.EventLogHelper.LogHelper.LogDebug(ex.ToString());
                return new SubmitResult2Ofstring() { IsSuccess = false,Errors=errors };
            }
        }

        #endregion



        public void Dispose()
        {

        }
    }
}
