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
   public class MaterialService
    {
        private static readonly HttpClient _Client = new HttpClient();

        static RestClient client = new RestClient("http://jatotalservice.slund.info/api/Material/");

        public static Material GetMaterial(int id)
        {
            IRestRequest request = new RestRequest("Get{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString()); //Tilføjer det rigtige id, som man får med ind i metoden
            return client.Execute<Material>(request).Data; //Får et response fra api, og laver det om til data og returnerer det
        }

        public static List<Material> GetAllMaterials()
        {
            var request = new RestRequest("GetAll", Method.GET);
            return client.Execute<List<Material>>(request).Data;
        }

        public static void PostMaterial(Material material)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(material);

            string url = "http://jatotalservice.slund.info/api/Material/Post";
         

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

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
            }
        }

        public static void PutMaterial(Material material)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(material);
            string url = "http://jatotalservice.slund.info/api/Material/Put";

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
            }
        }

        public static void DeleteMaterial(int id)
        {
            IRestRequest request = new RestRequest("Delete{id}", Method.DELETE);
            request.AddUrlSegment("id", id.ToString()); //Tilføjer det rigtige id, som man får med ind i metoden
            client.Execute<Material>(request); //Sender den request
        }
    }
}

