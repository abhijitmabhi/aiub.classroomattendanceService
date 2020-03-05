using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace AIUB.FingerPrintSync.Framework.Helpers.AppSettings
{
    public class ExportImportManager : IDisposable
    {
        public static bool SaveToXml(Objects.AppSettings objSettings, string fullFilePath, out string message)
        {
            if (objSettings!=null)
            {
                //string st = Path.GetDirectoryName(fullFilePath);
                if (fullFilePath != null)
                {
                    Directory.CreateDirectory( Path.GetDirectoryName(fullFilePath));
                    using (var os = new ObjecSerializer())
                    {
                        lock (os)
                        {
                            return os.SerializeObject(objSettings, fullFilePath, out message);
                        }
                       
                    }
                }
            }
            message = "settings empty";
            return false;
        }

        public static Objects.AppSettings ImportFromXml(string fullFilePath, out string message)
        {
            Objects.AppSettings objSettings = null;
            using (var os = new ObjecSerializer())
            {
                objSettings=os.DeSerializeObject<Objects.AppSettings>(fullFilePath, out message);
                return objSettings;
            }
        }

        private void CreateFolders(string fullFilePath,bool allUsers)
        {
            DirectoryInfo directoryInfo;
            DirectorySecurity directorySecurity;
            //FileSecurity
            AccessRule rule;
            SecurityIdentifier securityIdentifier = new SecurityIdentifier
                (WellKnownSidType.BuiltinUsersSid, null);
            if (!Directory.Exists(Path.GetFullPath(fullFilePath)))
            {
                directoryInfo = Directory.CreateDirectory(Path.GetFullPath(fullFilePath));

                bool modified;
                directorySecurity = directoryInfo.GetAccessControl();
                rule = new FileSystemAccessRule(
                    securityIdentifier,
                    FileSystemRights.Write |
                    FileSystemRights.ReadAndExecute |
                    FileSystemRights.Modify,
                    AccessControlType.Allow);
                directorySecurity.ModifyAccessRule(AccessControlModification.Add, rule, out modified);
                directoryInfo.SetAccessControl(directorySecurity);
            }
            //if (!Directory.Exists(ApplicationFolderPath))
            //{
            //    directoryInfo = Directory.CreateDirectory(ApplicationFolderPath);
            //    if (allUsers)
            //    {
            //        bool modified;
            //        directorySecurity = directoryInfo.GetAccessControl();
            //        rule = new FileSystemAccessRule(
            //            securityIdentifier,
            //            FileSystemRights.Write |
            //            FileSystemRights.ReadAndExecute |
            //            FileSystemRights.Modify,
            //            InheritanceFlags.ContainerInherit |
            //            InheritanceFlags.ObjectInherit,
            //            PropagationFlags.InheritOnly,
            //            AccessControlType.Allow);
            //        directorySecurity.ModifyAccessRule(AccessControlModification.Add, rule, out modified);
            //        directoryInfo.SetAccessControl(directorySecurity);
            //    }
            //}
        }

        public void Dispose()
        {

        }
    }
}
