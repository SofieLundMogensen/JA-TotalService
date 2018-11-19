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

namespace JATotalservice.Droid.Views
{
    [Activity(Label = "View for MaterialsViewModel")]
    public class MaterialsView : BaseView
    {

        List<Material> materials = new List<Material>();
        TextView testTextView;
        MaterialAdapter materialAdapter;
        private FloatingActionButton fabMain;
     
        protected override int LayoutResource => Resource.Layout.MaterialsView;
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            Console.WriteLine("---------------------hejsa med dig, jeg er her---------------------");
            //  testTextView = FindViewById(Resource.Id.text) as TextView;


            MaterialsViewModel materials = new MaterialsViewModel();


            GridView gridview = FindViewById<GridView>(Resource.Id.gridview);
            materialAdapter = new MaterialAdapter(materials.Materials, this);

            gridview.Adapter = materialAdapter;


            fabMain = FindViewById<FloatingActionButton>(Resource.Id.fab_main);
            Material material = new Material { id = 200, name = "træ", price = 100, description = "noget" };
            fabMain.Click += delegate { materials.AddMaterial(material); gridview.Adapter = materialAdapter; };

            setupBindings();

        }

        internal void setupBindings()
        {
            var set = this.CreateBindingSet<MaterialsView, MaterialsViewModel>();

            set.Bind(materialAdapter).For(m => m.Materials).To(vm => vm.Materials);

            set.Apply();
        }
    }
}