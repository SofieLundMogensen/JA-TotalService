using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace JATotalservice.Droid.Views
{
    [Activity(Label = "View for TimeViewModel")]
    public class TimeView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.TimeView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }
    }
}