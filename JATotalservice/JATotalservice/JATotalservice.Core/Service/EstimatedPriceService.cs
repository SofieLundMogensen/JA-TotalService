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
        
        public static EstimatedPrice GetEstimatedPrice(int id)
        {
            RestClient client = new RestClient("http://jatotalservice.slund.info/api/EstimatedPrice/Get{id}");
            IRestRequest request = new RestRequest(Method.GET);
            request.AddUrlSegment("id", id.ToString()); //Tilføjer det rigtige id, som man får med ind i metoden
            IRestResponse<EstimatedPrice> response = client.Execute<EstimatedPrice>(request); //Får et response fra api
            return response.Data; //Returnerer dataen i obj format
        }

        public static List<EstimatedPrice> GetAllEstimatedPrices()
        {
            //RestClient client = new RestClient("http://jatotalservice.slund.info/api/EstimatedPrice/GetAll");
            //IRestRequest request = new RestRequest(Method.GET);
            //return client.Execute<List<EstimatedPrice>>(request).Data; //Får et response fra api, og returnerer dataen fra den.

            var client = new RestClient("http://jatotalservice.slund.info/api/EstimatedPrice/");
            var request = new RestRequest("GetAll", Method.GET);
            var queryResult = client.Execute<List<EstimatedPrice>>(request);
            return queryResult.Data;
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
            RestClient client = new RestClient("http://jatotalservice.slund.info/api/EstimatedPrice/Delete{id}");
            IRestRequest request = new RestRequest(Method.DELETE);
            request.AddUrlSegment("id", id.ToString()); //Tilføjer det rigtige id, som man får med ind i metoden
            client.Execute<EstimatedPrice>(request); //Sender den request
        }
    }
}
