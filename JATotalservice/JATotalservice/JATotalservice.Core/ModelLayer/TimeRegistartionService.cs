using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer;
using RestSharp;


namespace JATotalservice.Core.ModelLayer
{
    public class TimeRegistartionService
    {
        public static TimeRegistartion getTimeInfo(int id)
        {
            RestClient client = new RestClient("http://jatotalservice.slund.info/api/TimeRegistration/Get{id}");
            IRestRequest request = new RestRequest(Method.GET);
            request.AddUrlSegment("id", id.ToString());
            IRestResponse<TimeRegistartion> response = client.Execute<TimeRegistartion>(request);
            TimeRegistartion timeRegistartion = response.Data;
            return timeRegistartion;
        }

        public static void postTimeInfo(TimeRegistartion timeregistration)
        {
            RestClient client = new RestClient("http://jatotalservice.slund.info/api/TimeRegistration/Post");
            var reguest = new RestRequest();
            reguest.Method = Method.POST;
            reguest.AddHeader("Accept", "application/json");
            reguest.Parameters.Clear();
            reguest.AddObject(timeregistration);
            var response = client.Execute(reguest);
           /* IRestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/Json");
            request.AddObject(timeregistration);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer.ContentType = "text/Json";
            var response = client.Execute(request);*/
            
            
        }
    }

}
