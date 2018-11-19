using Android;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;


namespace JATotalservice.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : BaseView
    {
        TextView textView;

        //View button;
        protected override int LayoutResource => Resource.Layout.FirstView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SupportActionBar.SetDisplayHomeAsUpEnabled(false);

            textView = FindViewById(Resource.Id.textView1) as TextView;

            FindViewById(Resource.Id.button1).Click += (o, e) =>
            textView.Text = "Dennis er awesome";


            Button navigateToMaterialsButton = FindViewById<Button>(Resource.Id.navigateToNextView); //Finds the button
            navigateToMaterialsButton.Click += delegate { StartActivity(typeof(MaterialsView)); }; //Navigates to the next view
            //navigateToMaterialsButton.Click += ViewModel //Navigates to the next view

            Button navigateToTimeButton = FindViewById<Button>(Resource.Id.navigateToTimeView);
            navigateToTimeButton.Click += delegate { StartActivity(typeof(TimeView)); };

            Button navigateToEstimateButton = FindViewById<Button>(Resource.Id.navigateToEstimateView);
            navigateToEstimateButton.Click += delegate { StartActivity(typeof(EstimateView)); };
        }
    }
}
