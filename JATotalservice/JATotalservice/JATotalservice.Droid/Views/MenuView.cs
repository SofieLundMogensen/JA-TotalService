using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.Graphics.Drawable;
using Android.Views;
using Android.Widget;
using JATotalservice.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace JATotalservice.Droid.Views
{
    [Register("JATotalservice.droid.views.MenuView")]
    public class MenuFragment : MvxFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        private NavigationView _navigationView;
        private IMenuItem _previousMenuItem;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.MenuView, null);

            _navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
            _navigationView.SetNavigationItemSelectedListener(this);
            _navigationView.Menu.FindItem(Resource.Id.Time).SetChecked(true);

            var iconPlanets = _navigationView.Menu.FindItem(Resource.Id.Time);
            iconPlanets.SetTitle("Time");
            iconPlanets.SetCheckable(false);
            iconPlanets.SetChecked(true);
            //var imgPlanet = VectorDrawableCompat.Create(Resources, Resource.Drawable.planet, Activity.Theme);
           // iconPlanets.SetIcon(imgPlanet);

            _previousMenuItem = iconPlanets;

            var iconPeople = _navigationView.Menu.FindItem(Resource.Id.Estimated);
            iconPeople.SetTitle("Overslag");
            iconPeople.SetCheckable(false);
            //var imgPeople = VectorDrawableCompat.Create(Resources, Resource.Drawable, Activity.Theme);
            //iconPeople.SetIcon(imgPeople);

            var iconStatistics = _navigationView.Menu.FindItem(Resource.Id.Material);
            iconStatistics.SetTitle("Material");
            iconStatistics.SetCheckable(false);
           // var imgStatistics = VectorDrawableCompat.Create(Resources, Resource.Drawable.statistics, Activity.Theme);
            //iconStatistics.SetIcon(imgStatistics);

            return view;
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            if (_previousMenuItem != null)
                _previousMenuItem.SetChecked(false);

            item.SetCheckable(true);
            item.SetChecked(true);

            _previousMenuItem = item;

            Navigate(item.ItemId);

            return true;
        }

        private async Task Navigate(int itemId)
        {
            ((FirstView)Activity).DrawerLayout.CloseDrawers();
            await Task.Delay(TimeSpan.FromMilliseconds(250));

            switch (itemId)
            {
                case Resource.Id.Time:
                    ViewModel.ShowTimeCommand.Execute(null);
                    break;
                case Resource.Id.Material:
                    ViewModel.ShowEstimatedCommand.Execute(null);
                    break;
                case Resource.Id.Estimated:
                    ViewModel.ShowMaterialsCommand.Execute(null);
                    break;
            }
        }
    }

}