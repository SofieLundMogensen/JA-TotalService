using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
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


            var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottomNavigation);

            bottomNavigation.NavigationItemReselected += (s, e) =>
            {
                //switch (e.Item.ItemId)
                //{
                //    case Resource.Id.action_dennis:
                //        Toast.MakeText(this, "Dennis er sej", ToastLength.Short).Show();
                //        break;
                //    case Resource.Id.action_marc:
                //        Toast.MakeText(this, "Marc er sej", ToastLength.Short).Show();
                //        break;
                //    case Resource.Id.action_sofie:
                //        Toast.MakeText(this, "Sofie er sej", ToastLength.Short).Show();
                //        break;
                //}
            };

        }
    }
}
