using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using ModelLayer;
using RestSharp;

namespace JATotalservice.Core.Service
{
    public class TimeRegistartionService
    {
        private static readonly HttpClient _Client = new HttpClient();

        static RestClient client = new RestClient("http://jatotalservice.slund.info/api/TimeRegistration/");

        public static TimeRegistartion getTimeInfo(int id)
        {
            IRestRequest request = new RestRequest("Get{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());
            return client.Execute<TimeRegistartion>(request).Data;
        }

        public static bool PostTimeInfo(TimeRegistartion timeregistration)
        {
            IRestRequest request = new RestRequest("Post", Method.POST);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(timeregistration);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            return Convert.ToBoolean(response.Content);
        }
        public static void PutTimeInfo(TimeRegistartion timeregistration1)
        {
            var json1 = Newtonsoft.Json.JsonConvert.SerializeObject(timeregistration1);

            string url1 = "http://jatotalservice.slund.info/api/TimeRegistration/Put";

            var httpWebRequest1 = (HttpWebRequest)WebRequest.Create(url1);
            httpWebRequest1.ContentType = "application/json";
            httpWebRequest1.Method = "Put";

            using (var streamWriter = new StreamWriter(httpWebRequest1.GetRequestStream()))
            {
                streamWriter.Write(json1);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest1.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
        public static void DeleteTimeInfo(int id)
        {
            IRestRequest request = new RestRequest("Delete{id}", Method.DELETE);
            request.AddUrlSegment("id", id.ToString());
            client.Execute<TimeRegistartion>(request);
        }

        public static List<TimeRegistartion> GetAllTimeInfo()
        {
            IRestRequest request = new RestRequest("GetAll", Method.GET);
            return client.Execute<List<TimeRegistartion>>(request).Data;
        }

    }
}


