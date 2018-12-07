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
    [Register("JATotalservice.droid.views.MaterialsView")]
    public class MaterialsView : BaseFragment<MaterialsViewModel>
    {

        List<Material> materials = new List<Material>();
        TextView testTextView;
        MaterialAdapter materialAdapter;
        private FloatingActionButton addButton;
        private DialogMaterial dialogSign;
        private Material material;
        GridView gridview;
        View view;

        private Android.Support.V4.App.FragmentManager transaction;
        protected override int FragmentId => Resource.Layout.MaterialsView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = base.OnCreateView(inflater, container, savedInstanceState);

            material = new Material();

            gridview = view.FindViewById<GridView>(Resource.Id.gridview);
            addButton = view.FindViewById<FloatingActionButton>(Resource.Id.fab_main);

            transaction = this.FragmentManager;

            materialAdapter = new MaterialAdapter(this, ViewModel, ViewModel.Materials, view.Context, transaction);

            materialAdapter.NotifyDataSetChanged();

            gridview.Adapter = materialAdapter;
            
            //What to do when you press the add button
            addButton.Click += (object sender, EventArgs e) =>
            {
                var dialogMaterial = new DialogMaterial("Opret material", new Material { });
                dialogMaterial.DialogClosed += OnDialogClosed;
                dialogMaterial.Show(transaction, "Dialog fragment");
            };

            SetupBindings();
            return view;
        }

        internal void SetupBindings()
        {
            var set = this.CreateBindingSet<MaterialsView, MaterialsViewModel>();
            //set.Bind(materialAdapter).For(m => m.Materials).To(vm => vm.Materials);

            set.Apply();
        }
        public void UpdateList()
        {
            gridview.Adapter = new MaterialAdapter(this, ViewModel, ViewModel.Materials, view.Context, transaction);
        }

        void OnDialogClosed(object sender, DialogEventArgs e)
        {
            material = e.ReturnValue;

            ViewModel.PostMaterial(material); gridview.Adapter = new MaterialAdapter(this, ViewModel, ViewModel.Materials, view.Context, transaction);
        }

    }

}