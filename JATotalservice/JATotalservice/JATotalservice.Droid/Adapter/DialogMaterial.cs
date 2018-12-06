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
    class DialogMaterial : Android.Support.V4.App.DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            var view = inflater.Inflate(Resource.Layout.DialogMaterial, container, false);
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