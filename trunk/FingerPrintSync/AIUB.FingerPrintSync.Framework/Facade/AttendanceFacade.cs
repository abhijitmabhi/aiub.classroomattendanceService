using AIUB.FingerPrintSync.Framework.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using AIUB.FingerPrintSync.Framework.Helpers.AppSettings;
using AIUB.FingerPrintSync.Framework.Helpers.RestApiHelper;
using AIUB.FingerPrintSync.Framework.Objects;

namespace AIUB.FingerPrintSync.Framework.Facade
{
    public class AttendanceFacade
    {
        public static List<LogDTO> GetUnsyncAttendance()
        {
            if (DateTime.Now.ToString("HH:mm") == "11:30")
            {
                string error = "";

                var token = RestWebapi.GetAuthenticationToken(AppSettingsHelper.SettingsInstance.WebApiUserName, AppSettingsHelper.SettingsInstance.WebApiPassword, AppSettingsHelper.SettingsInstance.AuthUrl, out error);

                if (!string.IsNullOrEmpty(token))
                {
                    AppSettingsHelper.SettingsInstance.WebApiToken = token;
                }
            }
            
            var context = DataManager.Instance;

            DateTime cutOffSemester = Convert.ToDateTime("2019-09-15 00:00:00.000");

            var log = new List<LogDTO>();
            try
            {
                log = (from a in context.Logs
                       join b in context.roomIPs on a.ipAddress equals b.ipAddress
                       where b.IsEnabled == true && a.IsSynced == false && a.IsInvalid == false && a.userId.Trim().Length > 2
                           && a.logTime > cutOffSemester
                       orderby a.id descending 
                       select new LogDTO()
                    {
                        id = a.id,
                        IpAddress = a.ipAddress,
                        LogTime = a.logTime,
                        UserId = a.userId,
                        DeviceId = a.deviceId,
                        RoomNumber = b.roomNumber,
                        IsSynced = a.IsSynced

                    }).ToList();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return log;
        }

//        public static bool UpdateLogStatus(TB_EVENT_LOG log)
//        {
//            string error = string.Empty;
//            try
//            {
//                TB_EVENT_LOG dbLog = DataManager.Instance.TB_EVENT_LOG.SingleOrDefault(x => x.nEventLogIdn == log.nEventLogIdn);
//                if (dbLog != null)
//                    dbLog.IsSync = log.IsSync;
//
//                DataManager.Instance.SaveChanges();
//                return true;
//            }
//            catch (Exception ex)
//            {
//                error = ex.Message;
//                return false;
//            }
//        }
        public static bool UpdateLogsStatus(List<LogDTO> logs)
        {
            string error = string.Empty;
            try
            {
                Log dbLog = null;
                zkEntities2 context = DataManager.Instance;//taking one inctace
                foreach (var log in logs.Where(x => x.IsSynced == true))
                {
                    dbLog = context.Logs.SingleOrDefault(x => x.id == log.id);
                    if (dbLog != null)
                        dbLog.IsSynced = log.IsSynced;
                }
               
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public static void UpdateInvalidUsersLog(List<LogDTO> logs)
        {
            try
            {
                var context = DataManager.Instance;
                foreach (var log in logs.Where(x => x.IsInvalid == true))
                {
                   var  dbLog = context.Logs.SingleOrDefault(x => x.id == log.id);
                    if (dbLog != null)
                        dbLog.IsInvalid = true;
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public static bool DeleteUpdatedLogs()
        {
            string error = string.Empty;
            try
            {
                //taking one inctace
                zkEntities2 context = DataManager.Instance;
                List<Log>  logs = context.Logs.Where(dt => dt.IsSynced == true ).ToList();

                foreach (var log in logs.Where(x => x.IsSynced == true))
                {
                     context.Logs.Remove(log);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public static bool ResetLogsStatus()
        {
            string error = string.Empty;
            try
            {
                zkEntities2 context = DataManager.Instance;//taking one inctace

                context.Logs.Where(dt => dt.IsSynced == true)
                        .ToList().ForEach(x => x.IsSynced = false);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

    }
}
