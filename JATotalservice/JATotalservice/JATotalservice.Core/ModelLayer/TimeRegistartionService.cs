using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using ModelLayer;
using RestSharp;

namespace JATotalservice.Core.ModelLayer
{
    public class TimeRegistartionService
    {
        private static readonly HttpClient _Client = new HttpClient();
        
        public static TimeRegistartion getTimeInfo(int id)
        {
            RestClient client = new RestClient("http://jatotalservice.slund.info/api/TimeRegistration/Get{id}");
            IRestRequest request = new RestRequest(Method.GET);
            request.AddUrlSegment("id", id.ToString());
            IRestResponse<TimeRegistartion> response = client.Execute<TimeRegistartion>(request);
            TimeRegistartion timeRegistartion = response.Data;
            return timeRegistartion;
        }

        public static async System.Threading.Tasks.Task postTimeInfoAsync(TimeRegistartion timeregistration)
        {
         /*   RestClient client = new RestClient("http://jatotalservice.slund.info/api/TimeRegistration/Post");
             var reguest = new RestRequest();
             reguest.Method = Method.POST;
             reguest.AddHeader("Accept", "application/json");
            
             reguest.AddObject(timeregistration);
             var response = client.Execute(reguest);
            /* IRestRequest request = new RestRequest(Method.POST);
             request.AddHeader("Accept", "application/Json");
             request.AddObject(timeregistration);
             request.RequestFormat = DataFormat.Json;
             request.JsonSerializer.ContentType = "text/Json";
             var response = client.Execute(request);*/

          var json = Newtonsoft.Json.JsonConvert.SerializeObject(timeregistration);


            string url = "http://jatotalservice.slund.info/api/TimeRegistration/Post";


            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
        public static void putTimeInfo(TimeRegistartion timeregistration1)
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
                RestClient client = new RestClient("http://jatotalservice.slund.info/api/TimeRegistration/Delete{id}");
                IRestRequest request = new RestRequest(Method.DELETE);
                request.AddUrlSegment("id", id.ToString());
                client.Execute<TimeRegistartion>(request);
            }

        public static List<TimeRegistartion> GetAllTimeInfo()
        {
            RestClient client = new RestClient("http://jatotalservice.slund.info/api/TimeRegistration/GetAll");
            IRestRequest request = new RestRequest(Method.GET);
            return client.Execute <List<TimeRegistartion>>(request).Data;          
        }

    }
}


