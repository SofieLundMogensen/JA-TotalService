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
using JATotalservice.Droid.Adapter;
using ModelLayer;
using MvvmCross.Binding.BindingContext;

namespace JATotalservice.Droid.Views
{
    [Activity(Label = "View for TimeViewModel")]
    public class TimeView : BaseView
    {

        protected override int LayoutResource => Resource.Layout.TimeView;

        TextView testTextView;
        TextView timeDisplay;
        Button timeSelectButton;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //testTextView = FindViewById<TextView>(Resource.Id.testTextView);
            var som = FindViewById<Spinner>(Resource.Id.dropdown);
            Task task = new Task();
            var test = new List<Task>();
            test.Add(new Task { name = "Hans HANSEN VEJ"});
            test.Add(new Task { name = "Ib" });
            test.Add(new Task { name = "Bo" });
            som.Adapter = new DropDownTaskAdapter(test, this);

            timeDisplay = FindViewById<TextView>(Resource.Id.time_display);
           timeSelectButton = FindViewById<Button>(Resource.Id.select_button);

            timeSelectButton.Click += TimeSelectOnClick;

            SetupBindings();
        }
        void TimeSelectOnClick(object sender, EventArgs eventArgs)
        {
            TimePickerFragment frag = TimePickerFragment.NewInstance(
                delegate (DateTime time)
                {
                    timeDisplay.Text = time.ToShortTimeString();
                });
        
            frag.Show(FragmentManager, TimePickerFragment.TAG);
           
        }

        protected void SetupBindings()
        {
            var set = this.CreateBindingSet<TimeView, TimeViewModel>(); //Creates the binding between the view and viewModel

            set.Bind(testTextView).For(m => m.Text).To(vm => vm.TestString); //Binds the test from the viewModel til the view's textView

            set.Apply();
        }
    }
}