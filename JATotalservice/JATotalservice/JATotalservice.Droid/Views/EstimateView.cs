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

namespace JATotalservice.Droid.Views
{
    [MvxFragmentPresentation(typeof(FirstViewModel), Resource.Id.content_frame, true)]
    [Activity(Label = "View for EstimateViewModel")]
    public class EstimateView : BaseFragment<EstimateViewModel>
    {
        protected override int FragmentId => Resource.Layout.EstimateView;

        NumberPicker estimatedTimeNumberPicker;

        ListView Materials;
        MaterialsListViewAdapter materialsListViewAdapter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);


            //Floating botton add material
            var add = view.FindViewById<FloatingActionButton>(Resource.Id.Add);
            add.Click += delegate { AddMaterial(); };

            //MaterialList 
            materialsListViewAdapter = new MaterialsListViewAdapter(ViewModel.MaterialTasks, view.Context);
            Materials = view.FindViewById<ListView>(Resource.Id.MaterialsListView);
            Materials.Adapter = materialsListViewAdapter;
            Utility.setListViewHeightBasedOnChildren(Materials); //Hack maybe it works when we are using bindings - Read something about it?

            //Setup for estimated time picker
            estimatedTimeNumberPicker = view.FindViewById<NumberPicker>(Resource.Id.estimatedTimePicker);
            estimatedTimeNumberPicker.MinValue = 0;
            estimatedTimeNumberPicker.MaxValue = 1000;


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
    }
}