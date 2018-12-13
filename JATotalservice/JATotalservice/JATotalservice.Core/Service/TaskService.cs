using ModelLayer;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace JATotalservice.Core.Service
{
    public class TaskService
    {
        private static readonly HttpClient _Client = new HttpClient();

        static RestClient client = new RestClient("http://jatotalservice.slund.info/api/Task/");

        public static Task GetTask(int id)
        {
            IRestRequest request = new RestRequest("Get{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString()); //Tilføjer det rigtige id, som man får med ind i metoden
            return client.Execute<Task>(request).Data; //Får et response fra api, og laver det om til data og returnerer det
        }

        public static List<Task> GetAllTasks()
        {
            var request = new RestRequest("GetAll", Method.GET);
            return client.Execute<List<Task>>(request).Data;
        }

        public static void PostTask(Task task)
        {
            IRestRequest request = new RestRequest("Post", Method.POST);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(task);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            bool test = Convert.ToBoolean(response.Content);
        }

        public static void PutTask(Task task)
        {

            IRestRequest request = new RestRequest("Put", Method.POST); //Virker ikke med put så post er brugt i stedet
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(task);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            bool test = Convert.ToBoolean(response.Content);



          /*  var json = Newtonsoft.Json.JsonConvert.SerializeObject(task);
            string url = "http://jatotalservice.slund.info/api/Task/Put";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            //Sending the request
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            //Getting the response
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }*/
        }

        public static void DeleteTask(int id)
        {
            IRestRequest request = new RestRequest("Delete{id}", Method.DELETE);
            request.AddUrlSegment("id", id.ToString()); //Tilføjer det rigtige id, som man får med ind i metoden
            client.Execute<Task>(request); //Sender den request
        }
    }
}

