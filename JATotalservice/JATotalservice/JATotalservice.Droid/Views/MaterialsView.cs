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
        private FloatingActionButton fabMain;
        private DialogMaterial dialogSign;
        private Material tomMaterial;
        GridView gridview;
        View view;
        private Android.Support.V4.App.FragmentManager transaction;
        protected override int FragmentId => Resource.Layout.MaterialsView;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = base.OnCreateView(inflater, container, savedInstanceState);

            tomMaterial = new Material();
            Console.WriteLine("---------------------hejsa med dig, jeg er her---------------------");
            //  testTextView = FindViewById(Resource.Id.text) as TextView;



            gridview = view.FindViewById<GridView>(Resource.Id.gridview);



            materialAdapter = new MaterialAdapter(ViewModel.Materials, view.Context);

            gridview.Adapter = materialAdapter;

            dialogSign = new DialogMaterial();

            transaction = this.FragmentManager;

            fabMain = view.FindViewById<FloatingActionButton>(Resource.Id.fab_main);
            fabMain.Click += (object sender, EventArgs e) =>
             {

                 //FM = FragmentManager.BeginTransaction();
                 //FM.BeginTransaction();
                 //dialogSign.Show(FM, "fkekfme");

                 //transaction.BeginTransaction();
                 var dialogMaterial = new DialogMaterial();
                 dialogMaterial.DialogClosed += OnDialogClosed;
                 dialogMaterial.Show(transaction, "Dialog fragment");



             };
            setupBindings();
            return view;

        }

        internal void setupBindings()
        {
            var set = this.CreateBindingSet<MaterialsView, MaterialsViewModel>();

            //set.Bind(materialAdapter).For(m => m.Materials).To(vm => vm.Materials);

            set.Apply();
        }

        void OnDialogClosed(object sender, DialogEventArgs e)
        {
            tomMaterial = e.ReturnValue;

            ViewModel.PostMaterial(tomMaterial); gridview.Adapter = new MaterialAdapter(ViewModel.Materials, view.Context);
        }

        //    private void DialogQuantity_DialogClosed(object sender, EventArgs e)
        //{

        //    //stuff to do
        //}
    }

}