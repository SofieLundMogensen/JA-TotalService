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
    [Activity(Label = "View for MaterialsViewModel")]
    public class MaterialsView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.MaterialsView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //SupportActionBar.SetDisplayHomeAsUpEnabled(false);

            //SetContentView(Resource.Layout.MaterialsView);
        }
    }
}