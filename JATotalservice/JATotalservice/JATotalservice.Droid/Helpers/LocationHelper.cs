using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;

namespace JATotalservice.Droid.Helpers
{
    class LocationHelper
    {
        LocationManager locationManager;

        public Location GetLocation(Context context)
        {
            //Tjekker om der er adgang til location services
            if (ContextCompat.CheckSelfPermission(context, Manifest.Permission.AccessFineLocation) == Permission.Granted)
            {
                locationManager = (LocationManager)context.GetSystemService(Context.LocationService); //Initilaizing locationManager

                //StartRequestingLocationUpdates();
                //isRequestingLocationUpdates = true;
                
                var criteria = new Criteria { PowerRequirement = Power.Medium };

                var bestProvider = locationManager.GetBestProvider(criteria, true);
                var location = locationManager.GetLastKnownLocation(bestProvider);

                return location;
            }
            else //Hvis der ikker er adgang til location services
            {
                // The app does not have permission ACCESS_FINE_LOCATION 
                return null;
            }
            
        }
        
    }
}