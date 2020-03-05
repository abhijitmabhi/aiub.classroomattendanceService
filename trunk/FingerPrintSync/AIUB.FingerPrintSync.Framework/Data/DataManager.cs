using System;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using AIUB.FingerPrintSync.Framework.Helpers.AppSettings;

namespace AIUB.FingerPrintSync.Framework.Data
{
    public class DataManager
    {

        // private static BioStarEntities entities=null;

//        private static string EntityDataModelName = ConfigurationManager.AppSettings["EntityDataModelName"];
        private static string EntityDataModelName = "ClassRoomAttendanceModel2";

        public static string GetEntityConnectionString()
        {
            var entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.Provider = "System.Data.SqlClient";



            if (!AppSettingsHelper.SettingsInstance.UseSqlConnectionString)
            {
                var sqlBuilder = new SqlConnectionStringBuilder();

                //common
                sqlBuilder.DataSource = @"" + AppSettingsHelper.SettingsInstance.SqlServerName;
                sqlBuilder.InitialCatalog = AppSettingsHelper.SettingsInstance.SuprimaDBName;
                sqlBuilder.MultipleActiveResultSets = true;

                //for windows logins
                //sqlBuilder.IntegratedSecurity = true;
                //sqlBuilder.UserInstance = true;

                //sql logins
                sqlBuilder.PersistSecurityInfo = true;
                sqlBuilder.UserID = AppSettingsHelper.SettingsInstance.SqlServerUserName;
                sqlBuilder.Password = AppSettingsHelper.SettingsInstance.SqlServerPassword;
                entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
            }
            else
            {
                entityBuilder.ProviderConnectionString = AppSettingsHelper.SettingsInstance.SqlConnectionString;
            }
            //res://*/Data.BioStarModel.csdl|

            entityBuilder.Metadata = string.Format("res://{0}/Data.{1}.csdl|res://{0}/Data.{1}.ssdl|res://{0}/Data.{1}.msl",
               "*", EntityDataModelName);
            //typeof(BioStarEntities).Assembly.FullName


            return entityBuilder.ToString();
        }

        public static bool TestEntityConnection(out string error)
        {
            try
            {
                using (var conn = new EntityConnection(GetEntityConnectionString()))
                {
                    conn.Open();
                    conn.Close();
                    error = ("Connection Success.");
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ("Can not open connection ! " + ex.ToString());
                return false;
            }


        }
        public static bool TestEntityConnection(bool useSqlContionString, string serverName, string dataBaseName, string userName, string password,string sqlConString, out string error)
        {
            try
            {
                var entityBuilder = new EntityConnectionStringBuilder();
                entityBuilder.Provider = "System.Data.SqlClient";



                if (!useSqlContionString)
                {
                    var sqlBuilder = new SqlConnectionStringBuilder();

                    //common
                    sqlBuilder.DataSource = @"" + serverName;
                    sqlBuilder.InitialCatalog = dataBaseName;
                    sqlBuilder.MultipleActiveResultSets = true;

                    //for windows logins
                    //sqlBuilder.IntegratedSecurity = true;
                    //sqlBuilder.UserInstance = true;

                    //sql logins
                    sqlBuilder.PersistSecurityInfo = true;
                    sqlBuilder.UserID = userName;
                    sqlBuilder.Password = password;
                    entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
                }
                else
                {
                    entityBuilder.ProviderConnectionString = sqlConString;
                }
                //res://*/Data.BioStarModel.csdl|

                entityBuilder.Metadata = string.Format("res://{0}/Data.{1}.csdl|res://{0}/Data.{1}.ssdl|res://{0}/Data.{1}.msl",
                   "*", EntityDataModelName);
                //typeof(BioStarEntities).Assembly.FullName
                using (var conn = new EntityConnection(entityBuilder.ToString()))
                {
                    conn.Open();
                    conn.Close();
                    error = ("Connection Success.");
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ("Can not open connection, please check server settings carefully. " + ex.Message.ToString());
                return false;
            }


        }
//        public static BioStarEntities Instance2
//        {
//            get
//            {
//                string connectionString = GetEntityConnectionString();
//                return new BioStarEntities(GetEntityConnectionString());
//            }
//        }

        public static zkEntities2 Instance
        {
            get
            {
                string connectionString = GetEntityConnectionString();
                return new zkEntities2(GetEntityConnectionString());
            }
        }



        /// <summary> temp data
        ///     <add name="BioStarEntities1" 
        /// connectionString="metadata=res://*/Data.Model1.csdl|res://*/Data.Model1.ssdl|res://*/Data.Model1.msl;
        /// provider=System.Data.SqlClient;
        /// provider connection string=&quot;
        /// data source=PAVEL\BSSERVER;
        /// initial catalog=BioStar;
        /// persist security info=True;
        /// user id=test;password=1234;
        /// MultipleActiveResultSets=True;
        /// App=EntityFramework&quot;" 
        /// providerName="System.Data.EntityClient" />
        /// 
        ///  <add name="BioStarEntities" 
        /// connectionString="metadata=res://*/Data.BioStarModel.csdl|res://*/Data.BioStarModel.ssdl|res://*/Data.BioStarModel.msl;
        /// provider=System.Data.SqlClient;
        /// provider connection string=&quot;
        /// data source=PAVEL\BSSERVER;
        /// initial catalog=BioStar;
        /// integrated security=True;
        /// MultipleActiveResultSets=True;
        /// App=EntityFramework&quot;" 
        /// providerName="System.Data.EntityClient" />
        /// </summary>
        /// <returns></returns>


    }
}
