using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Helpers;
using AIUB.FingerPrintSync.Framework.Objects;
namespace AIUB.FingerPrintSync.Framework.Helpers.RestApiHelper
{

    public class RestWebapi
    {
        private static HttpClient client;
        static readonly string appKey = "AiubPortalMobileAppBy$DD2019";
        public static string GetAuthenticationToken(string username, string password, string url,out string error)
        {
            error = "";
            
            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                //new KeyValuePair<string, string>("AppKey", appKey)
            };

            var content = new FormUrlEncodedContent(pairs);

            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(url);
            }
            
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // call sync
            var response = client.PostAsync(url+"/Token", content).Result;
            dynamic data = "";
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                data = Newtonsoft.Json.JsonConvert.DeserializeObject(res);
                if (data.access_token != null)
                {
                    return data.access_token;
                }
                return "";
            }
            else {
                error = response.StatusCode.ToString();
            }
            return data;
        }



        public static async Task<bool> PostAttendence(int userId, DateTime logTime, string url, string token, string deviceId, string ipAddress, string roomNumber, string appKey = "")
        {

            Result<Entry> resultEntry = CreateAsync(new Entry() 
                    { 
                        LogTime = logTime,
                        UserId = userId, 
                        DeviceId = deviceId,
                        IpAddress = ipAddress,
                        RoomNumber = roomNumber

                    }, url + "/api/ClassRoomAttendanceTracker/SaveClassRoomAttendance", token, appKey);
            
            if (resultEntry.Messages.Count > 0)
            {
                resultEntry.HasError = true;
            }
            return !resultEntry.HasError;
            /* if (client == null)
            {
                client = new HttpClient();
            }
            
                var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("key", key.ToString()),
                new KeyValuePair<string, string>("entryTime", entryTime.ToString())
            };

                var content = new FormUrlEncodedContent(pairs);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync(url + "/api/EmpAttendance/SaveAutoAttendance",content);
                // Parse JSON response.
                dynamic data = Json.Decode(response.Content.ReadAsStringAsync().Result);
                return response.IsSuccessStatusCode;*/

        }
      



        public static Result<T> CreateAsync<T>(T obj, string requesturl, string token,string appKey="")
        {
            Result<T> resObj = new Result<T>();
            if (client == null)
            {
                client = new HttpClient();
            }
            if (!string.IsNullOrWhiteSpace(token))
            {


                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                if (!string.IsNullOrEmpty(appKey))
                {
                    client.DefaultRequestHeaders.Add("AppKey", appKey);
                }
                
                try
                {
                    HttpResponseMessage response = client.PostAsJsonAsync(requesturl, obj).Result;
                    response.EnsureSuccessStatusCode();
                    var res = response.Content.ReadAsStringAsync().Result;
                    resObj = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<T>>(res);
                }
                catch (Exception e)
                {
                    resObj.HasError = true;
                    resObj.Messages.Add(e.Message);
                }
            }
            // Return the URI of the created resource.
            return resObj;
        }
    }

    public class Entry
    {
        public int UserId { get; set; }
        public DateTime LogTime { get; set; }
        public string DeviceId { get; set; }
        public string IpAddress { get; set; }
        public string RoomNumber { get; set; }

    }
}