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
        ListView Materials;
        TextView testTextView;
        TextView timeDisplay;
        Button timeSelectButton;
        NumberPicker hour;
        NumberPicker minute;
        NumberPicker hour1;
        NumberPicker minute1;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetupTime();
            //testTextView = FindViewById<TextView>(Resource.Id.testTextView);
            var som = FindViewById<Spinner>(Resource.Id.dropdown);
            Task task = new Task();
            var test = new List<Task>();
            test.Add(new Task { name = "Hans HANSEN VEJ"});
            test.Add(new Task { name = "Ib" });
            test.Add(new Task { name = "Bo" });
            som.Adapter = new DropDownTaskAdapter(test, this);
            List<MaterialTask> materialTasks = new List<MaterialTask>();
            for (int i = 0; i < 5; i++)
            {
                MaterialTask materialTask = new MaterialTask()
                {
                 
                    Count = 200

                };
                materialTasks.Add(materialTask);
            } 
            Materials = FindViewById<ListView>(Resource.Id.MaterialsListView);
            Materials.Adapter = new MaterialsListViewAdapter(materialTasks, this);

            SetupBindings();
        }
     
        private void SetupTime()
        {
            hour = FindViewById<NumberPicker>(Resource.Id.numberPickerHour);
            minute = FindViewById<NumberPicker>(Resource.Id.numberPickerMinute);
            hour.MaxValue = 23;
            hour.MinValue = 0;
            hour.Value = DateTime.Now.Hour;
            minute.MaxValue = 59;
            minute.MinValue = 0;
            minute.Value = DateTime.Now.Minute;

            hour1 = FindViewById<NumberPicker>(Resource.Id.numberPickerHour2);
            minute1 = FindViewById<NumberPicker>(Resource.Id.numberPickerMinute2);
            hour1.MaxValue = 23;
            hour1.MinValue = 0;
            hour1.Value = DateTime.Now.Hour;
            minute1.MaxValue = 59;
            minute1.MinValue = 0;
            minute1.Value = DateTime.Now.Minute;
        }
        protected void SetupBindings()
        {
            var set = this.CreateBindingSet<TimeView, TimeViewModel>(); //Creates the binding between the view and viewModel

            set.Bind(testTextView).For(m => m.Text).To(vm => vm.TestString); //Binds the test from the viewModel til the view's textView

            set.Apply();
        }
    }
}