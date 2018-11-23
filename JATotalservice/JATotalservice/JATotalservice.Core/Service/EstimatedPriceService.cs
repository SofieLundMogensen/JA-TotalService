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
    public class EstimatedPriceService
    {
        private static readonly HttpClient _Client = new HttpClient();

        static RestClient client = new RestClient("http://jatotalservice.slund.info/api/EstimatedPrice/");

        public static EstimatedPrice GetEstimatedPrice(int id)
        {
            IRestRequest request = new RestRequest("Get{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString()); //Tilføjer det rigtige id, som man får med ind i metoden
            return client.Execute<EstimatedPrice>(request).Data; //Får et response fra api, og laver det om til data og returnerer det
        }

        public static List<EstimatedPrice> GetAllEstimatedPrices()
        {
            var request = new RestRequest("GetAll", Method.GET);
            return client.Execute<List<EstimatedPrice>>(request).Data;
        }
        
        public static void PostEstimatedPrice(EstimatedPrice estimatedPrice)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(estimatedPrice);

            string url = "http://jatotalservice.slund.info/api/EstimatedPrice/Post";

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

        public static void PutEstimatedPrice(EstimatedPrice estimatedPrice)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(estimatedPrice);

            string url = "http://jatotalservice.slund.info/api/EstimatedPrice/Put";

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

        public static void DeleteEstimatedPrice(int id)
        {
            IRestRequest request = new RestRequest("Delete{id}", Method.DELETE);
            request.AddUrlSegment("id", id.ToString()); //Tilføjer det rigtige id, som man får med ind i metoden
            client.Execute<EstimatedPrice>(request); //Sender den request
        }
    }
}
