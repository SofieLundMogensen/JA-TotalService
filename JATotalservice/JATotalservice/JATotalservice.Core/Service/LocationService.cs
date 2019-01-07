using ModelLayer;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace JATotalservice.Core.Service
{
    public class LocationService
    {
        

        public static LocationModel getLocationAddress(double lat, double lon)
        {
            
            //Bliver nødt til at sætte lat og long ind sådan her, da forsøg nedenfor ikek virker
            RestClient client = new RestClient(string.Format("https://nominatim.openstreetmap.org/reverse?format=json&lat={0}&lon={1}", lat.ToString().Replace(",", "."), lon.ToString().Replace(",", ".")));

            IRestRequest request = new RestRequest(Method.GET);
            
            //Forsøget med at indsætte dem som nedenfor virker ikke

            //request.AddUrlSegment("format", "json");
            //request.AddUrlSegment("lat", "52.5487429714954");
            //request.AddUrlSegment("lon", "9.885190");
            request.AddUrlSegment("zoom", "18"); //Fra 0-18 hvor 0 er kun land man finder så
            request.AddUrlSegment("addressdetails", "1"); //Om man vil have daressen brudt ned i detaljer, og det er 0 eller 1

            var address = client.Execute<LocationModel>(request).Data;
            
            return address;
        }
    }
}
