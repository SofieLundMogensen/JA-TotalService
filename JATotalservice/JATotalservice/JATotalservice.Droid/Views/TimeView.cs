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
using JATotalservice.Core.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace JATotalservice.Droid.Views
{
    [Activity(Label = "View for TimeViewModel")]
    public class TimeView : BaseView
    {
        
        protected override int LayoutResource => Resource.Layout.TimeView;

        TextView testTextView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            testTextView = FindViewById<TextView>(Resource.Id.testTextView);

            SetupBindings();
        }

        protected void SetupBindings()
        {
            var set = this.CreateBindingSet<TimeView, TimeViewModel>(); //Creates the binding between the view and viewModel

            set.Bind(testTextView).For(m => m.Text).To(vm => vm.TestString); //Binds the test from the viewModel til the view's textView

            set.Apply();
        }
    }
}