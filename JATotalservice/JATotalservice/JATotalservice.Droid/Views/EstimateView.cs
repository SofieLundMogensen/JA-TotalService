using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JATotalservice.Core.ViewModels;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using JATotalservice.Droid.Adapter;
using ModelLayer;
using Android.Support.Design.Widget;
using MvvmCross;

namespace JATotalservice.Droid.Views
{
    [MvxFragmentPresentation(typeof(FirstViewModel), Resource.Id.content_frame, true)]
    [Activity(Label = "View for EstimateViewModel")]
    public class EstimateView : BaseFragment<EstimateViewModel>
    {
        protected override int FragmentId => Resource.Layout.EstimateView;

        Button sendTimeRegistration;
        NumberPicker estimatedTimeNumberPicker;
        TextView estimatedTimeName;
        ListView Materials;
        MaterialsListViewAdapter materialsListViewAdapter;
        private Android.Support.V7.Widget.Toolbar _toolbar;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            _toolbar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            _toolbar.Title = "Pris overslag";

            //Floating botton add material
            var add = view.FindViewById<FloatingActionButton>(Resource.Id.Add);
            add.Click += delegate { AddMaterial(); };
            
            //Der er ikke gjort brug af bindings fordi det kan man ikke gøre på lister
            materialsListViewAdapter = new MaterialsListViewAdapter(ViewModel.MaterialsAmount, view.Context, ViewModel); //Laver en ny adapter til listen, og får dataen med fra viewModellen, da det er den som laver cellerne
            Materials = view.FindViewById<ListView>(Resource.Id.MaterialsListView); //Finder listviewet fra designet
            Materials.Adapter = materialsListViewAdapter; //Sætter adapteren på listview'et
            //Det er den der opdatere listen sådan den ser pæn ud ihenhold til højde ol.
            Utility.setListViewHeightBasedOnChildren(Materials); //Hack maybe it works when we are using bindings - Read something about it?

            estimatedTimeName = view.FindViewById<TextView>(Resource.Id.taskNameEditText);

            //Setup for estimated time picker
            estimatedTimeNumberPicker = view.FindViewById<NumberPicker>(Resource.Id.estimatedTimePicker);
            estimatedTimeNumberPicker.MinValue = 0;
            estimatedTimeNumberPicker.MaxValue = 1000;

            //Send Timeregistration
            sendTimeRegistration = view.FindViewById<Button>(Resource.Id.Submit);
            sendTimeRegistration.Click += delegate { CalculatePriceButtonPressed(view.Context); };

            return view;
        }

        private void CalculatePriceButtonPressed(Context context)
        {
            EstimatedPrice estimatedPrice = new EstimatedPrice();
            estimatedPrice.Name = estimatedTimeName.Text;
            estimatedPrice.estimatedTime = estimatedTimeNumberPicker.Value;

            double calculatedPrice = ViewModel.CalculatePrice(estimatedPrice);
            
            Toast.MakeText(context, "Det vil koste " + calculatedPrice + "kroner", ToastLength.Long).Show();
        }

        private void AddMaterial()
        {
            ////Adds a material to the MaterialTask list
            //MaterialTask materialTask = new MaterialTask();
            //ViewModel.AddMaterials(materialTask);
            //Materials.Adapter = materialsListViewAdapter;
            //Utility.setListViewHeightBasedOnChildren(Materials); //Hack maybe it works when we are using bindings - Read something about it?

            //Adds a material to the MaterialTask list

            ViewModel.AddMaterials(1, new Material { id = 1});
            materialsListViewAdapter = new MaterialsListViewAdapter(ViewModel.MaterialsAmount,Context, ViewModel);

            Materials.Adapter = materialsListViewAdapter;
            Utility.setListViewHeightBasedOnChildren(Materials); //Hack maybe it works when we are using bindings - Read something about it?
        }
    }
}