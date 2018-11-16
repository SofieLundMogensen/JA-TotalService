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

        TextView testTextView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Console.WriteLine("---------------------hejsa med dig, jeg er her---------------------");
            testTextView = FindViewById(Resource.Id.text) as TextView;

        }

        internal void setupBindings()
        {
            var set = this.CreateBindingSet<MaterialsView, MaterialsViewModel>();
            
            set.Bind(testTextView).For(m => m.Text).To(vm => vm.Hello);

            set.Apply();
        }
    }
}