using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JATotalservice.Core.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace JATotalservice.Droid.Views
{
    [Activity(Label = "View for MaterialsViewModel")]
    public class MaterialsView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.MaterialsView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            MaterialsViewModel vi = new MaterialsViewModel();
          var s=  vi.Hello;
            var set = this.CreateBindingSet<MaterialsView, MaterialsViewModel>();
            var text = FindViewById(Resource.Id.text) as TextView;
         
            set.Bind(text).For(m => m.Text).To(vm => vm.Hello);
            set.Apply();
            //SupportActionBar.SetDisplayHomeAsUpEnabled(false);

            //SetContentView(Resource.Layout.MaterialsView);
        }
    }
}