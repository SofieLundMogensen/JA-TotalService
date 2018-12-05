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
        private Dialog_Sign dialogSign;
        private FragmentManager FM;
        protected override int FragmentId => Resource.Layout.MaterialsView;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

           
            Console.WriteLine("---------------------hejsa med dig, jeg er her---------------------");
            //  testTextView = FindViewById(Resource.Id.text) as TextView;



            GridView gridview = view.FindViewById<GridView>(Resource.Id.gridview);
            materialAdapter = new MaterialAdapter(ViewModel.Materials, view.Context);

            gridview.Adapter = materialAdapter;

            dialogSign = new Dialog_Sign();
            fabMain = view.FindViewById<FloatingActionButton>(Resource.Id.fab_main);
            Material material = new Material { id = 200, name = "træ", price = 100, description = "noget" };
            fabMain.Click += (object sender, EventArgs e) =>
             {
                 dialogSign.Show(FM, "fkekfme");
                 //var transaction = FragmentManager.BeginTransaction();
                 //var dialogSign = new Dialog_Sign();
                 //dialogSign.Show(transaction, "Dialog fragment");
                 //ViewModel.PostMaterial(material); gridview.Adapter = new MaterialAdapter(ViewModel.Materials, view.Context);

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
    }
}