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

namespace JATotalservice.Droid.Views
{
    [MvxFragmentPresentation(typeof(FirstViewModel), Resource.Id.content_frame, true)]
    [Activity(Label = "View for EstimateViewModel")]
    public class EstimateView : BaseFragment<EstimateViewModel>
    {
        protected override int FragmentId => Resource.Layout.EstimateView;
        //  protected override int LayoutResource => Resource.Layout.EstimateView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            return view;


        }
    }
}