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

namespace JATotalservice.Droid
{
    class Dialog_Sign : DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            var view = inflater.Inflate(Resource.Layout.Dialog_Sign, container, false);
            this.Dialog.SetTitle("fefwe");
            return view;
        }

        ////public override void OnActivityCreated(Bundle savedInstanceState)
        ////{
        ////    Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
        ////    base.OnActivityCreated(savedInstanceState);
        ////    Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        //}
    }
}