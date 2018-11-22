using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using JATotalservice.Core.ViewModels;
using JATotalservice.Droid.Adapter;
using ModelLayer;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace JATotalservice.Droid.Views
{
    [MvxFragmentPresentation(typeof(FirstViewModel), Resource.Id.content_frame, true)]
    [Activity(Label = "View for TimeViewModel")]
    public class TimeView : BaseFragment<TimeViewModel>
    {

        protected override int FragmentId => Resource.Layout.TimeView;
        ListView Materials;
        Button sendTimeRegistration;
        Task task;
        NumberPicker hour;
        NumberPicker minute;
        NumberPicker hour1;
        NumberPicker minute1;
        Spinner TaskDropDown;
        View view;
        MaterialsListViewAdapter materialsListViewAdapter;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = base.OnCreateView(inflater, container, savedInstanceState);
            //Set up time spinners
            SetupTime(); 

            //task drop down liste, create, land listen on itemselected
            TaskDropDown = view.FindViewById<Spinner>(Resource.Id.dropdown);
            TaskDropDown.Adapter = new DropDownTaskAdapter(ViewModel.Tasks, view.Context);
        
            TaskDropDown.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            

            //Floating botton add material
            var add = view.FindViewById<FloatingActionButton>(Resource.Id.Add);
            add.Click += delegate { AddMaterial(); };

            //MaterialList 
            materialsListViewAdapter = new MaterialsListViewAdapter(ViewModel.MaterialTasks, view.Context);
            Materials = view.FindViewById<ListView>(Resource.Id.MaterialsListView);
            Materials.Adapter = materialsListViewAdapter;
            Utility.setListViewHeightBasedOnChildren(Materials); //Hack maybe it works when we are using bindings - Read something about it?

            //Send Timeregistration
            sendTimeRegistration = view.FindViewById<Button>(Resource.Id.Submit);
            sendTimeRegistration.Click += delegate { sendData(view.Context); };

            SetupBindings();
            return view;
        }
        private void AddMaterial()
        {

            //Adds a material to the MaterialTask list
            MaterialTask materialTask = new MaterialTask();
            ViewModel.AddMaterials(materialTask);
            Materials.Adapter = materialsListViewAdapter;
            Utility.setListViewHeightBasedOnChildren(Materials); //Hack maybe it works when we are using bindings - Read something about it?
        }
        private void sendData(Context context)
        {
            //Sends object timeregistartion to Viewmodel
            TimeRegistartion timeRegistartion = new TimeRegistartion();
            var hourS = hour.Value;
            var minS = minute.Value;
            var hourE = hour1.Value;
            var minE = minute1.Value;
            var date = DateTime.Now;
            timeRegistartion.startTime = new DateTime(date.Year, date.Month, date.Day, hourS, minS, 00);
            timeRegistartion.endTime = new DateTime(date.Year, date.Month, date.Day, hourE, minE, 00);
            timeRegistartion.task = task;
            timeRegistartion.Id = 1; //TODO: Slettes når vi har fundet ud af db auto id
            //TODO: Koble de valgte matrialer på med antal
            
            timeRegistartion.employee = new Employee { Id = 1 }; //TODO: Fjernes når vi har styr på en employee - for nu er den presat

            ViewModel.PostTime.Execute(timeRegistartion);
            Materials.Adapter = materialsListViewAdapter;
            Utility.setListViewHeightBasedOnChildren(Materials); //Hack maybe it works when we are using bindings - Read something about it?

            Toast.MakeText(context, "Det er sendt", ToastLength.Long).Show();

        }
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            //tjekker hvilket task der er valgt og sætter den til at være = task
          task = ViewModel.Tasks[e.Position];
        }
        private void SetupTime()
        {
            //Til timepicker - sætter hvad interval klokken skal køre
            hour = view.FindViewById<NumberPicker>(Resource.Id.numberPickerHour);
            minute = view.FindViewById<NumberPicker>(Resource.Id.numberPickerMinute);
            hour.MaxValue = 23;
            hour.MinValue = 0;
            hour.Value = DateTime.Now.Hour;
            minute.MaxValue = 59;
            minute.MinValue = 0;
            minute.Value = DateTime.Now.Minute;
            hour1 = view.FindViewById<NumberPicker>(Resource.Id.numberPickerHour2);
            minute1 = view.FindViewById<NumberPicker>(Resource.Id.numberPickerMinute2);
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
           // set.Bind(Tasks).To(vm => vm.Tasks); //Binds the test from the viewModel til the view's textView
            set.Apply();
        }
    }
}