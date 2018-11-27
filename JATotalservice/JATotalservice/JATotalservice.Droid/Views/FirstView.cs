using Android;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using JATotalservice.Core.ViewModels;

using System;
using ModelLayer;
using System.Collections.Generic;
using JATotalservice.Core.Service;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace JATotalservice.Droid.Views
{

    [MvxActivityPresentation]
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxAppCompatActivity<FirstViewModel>
    {
        TextView textView;

        //View button;
       // protected override int LayoutResource => Resource.Layout.FirstView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
            //var dt = new DateTime(2010, 10, 12);   
            //var dt1 = new DateTime(2011, 08, 06);    

            //TimeRegistartion tr = new TimeRegistartion();   
            //tr.startTime = dt; 
            //tr.endTime = dt1;
            //tr.Id = 123456;
            //tr.task = new ModelLayer.Task();
            //tr.task.id = 1;
            //tr.task.name = "snerydning";
            //tr.task.materials = new List<Material>();
            //tr.employee = new Employee();
            //tr.task.timeRegistrations = new List<TimeRegistartion>();
            //tr.task.description = "bla bla bla";
            //tr.employee.Id = 1;
            //TimeRegistartionService.postTimeInfoAsync(tr);
            //var ttt = TimeRegistartionService.GetAllTimeInfo();
            //var tt = TimeRegistartionService.getTimeInfo(300);
            //TimeRegistartionService.DeleteTimeInfo(300);

            //EstimatedPrice estimatedPrice = new EstimatedPrice();
            //estimatedPrice.Id = 11;
            //estimatedPrice.estimatedTime = 987654321;
            //estimatedPrice.materials = null;
            //Console.WriteLine("------------------------POST-------------------------------------");
            ////EstimatedPriceService.PostEstimatedPrice(estimatedPrice);
            //Console.WriteLine("----------------------------GET---------------------------------");
            //var tt = EstimatedPriceService.GetEstimatedPrice(11);
            //Console.WriteLine("-------------------------------PUT------------------------------");
            ////estimatedPrice.estimatedTime = 99999999;
            ////EstimatedPriceService.PutEstimatedPrice(estimatedPrice);
            //Console.WriteLine("----------------------GETALL---------------------------------------");
            //var ttt = EstimatedPriceService.GetAllEstimatedPrices();
            //Console.WriteLine("----------------------------DELETE---------------------------------");
            //EstimatedPriceService.DeleteEstimatedPrice(123456789);
            //Console.WriteLine("-------------------------------------------------------------");
            

           // SupportActionBar.SetDisplayHomeAsUpEnabled(false);


            textView = FindViewById(Resource.Id.textView1) as TextView;

            FindViewById(Resource.Id.button1).Click += (o, e) =>
            textView.Text = "Dennis er awesome";

            FirstViewModel t = new FirstViewModel();
            Button navigateToMaterialsButton = FindViewById<Button>(Resource.Id.navigateToNextView); //Finds the button
            navigateToMaterialsButton.Click += delegate { StartActivity(typeof(MaterialsView)); }; //Navigates to the next view
            //navigateToMaterialsButton.Click += delegate { t.navigateCommand.Execute(); };
            
            //t.navigateCommand.Execute();

            Button navigateToTimeButton = FindViewById<Button>(Resource.Id.navigateToTimeView);
            navigateToTimeButton.Click += delegate { ViewModel.NavigateToTimeRegistrationCommand.Execute(); };

            Button navigateToEstimateButton = FindViewById<Button>(Resource.Id.navigateToEstimateView);
            navigateToEstimateButton.Click += delegate { ViewModel.NavigateToEstimatePriceCommand.Execute(); };
        }
    }
}
