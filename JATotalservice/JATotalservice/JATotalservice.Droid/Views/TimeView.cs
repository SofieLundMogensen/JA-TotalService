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

           

            hour = FindViewById<NumberPicker>(Resource.Id.numberPickerHour);
            minute = FindViewById<NumberPicker>(Resource.Id.numberPickerMinute);
            hour.MaxValue = 23;
            hour.MinValue = 0;
            //hour.Value = DateTime.UtcNow;
            minute.MaxValue = 59;
            minute.MinValue = 0;
            // minute.Value = this.time.Minute
            List<MaterialTask> materialTasks = new List<MaterialTask>();
            MaterialTask materialTask = new MaterialTask()
            {
                Material = new Material
                {
                    name = "noget"

                },
                Count = 200
                
            };
            materialTasks.Add(materialTask);
            Materials = FindViewById<ListView>(Resource.Id.MaterialsListView);
            Materials.Adapter = new MaterialsListViewAdapter(materialTasks, this);

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