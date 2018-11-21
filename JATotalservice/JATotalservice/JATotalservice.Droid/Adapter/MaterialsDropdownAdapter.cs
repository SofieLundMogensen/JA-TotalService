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
using ModelLayer;

namespace JATotalservice.Droid.Adapter
{
   public class MaterialsDropdownAdapter : BaseAdapter, ISpinnerAdapter
    {
        private readonly IList<View> _views = new List<View>();
        public List<Material> Materials;
        Context context;

        public MaterialsDropdownAdapter(List<Material> Materials, Context context)
        {
            this.Materials = Materials;
            this.context = context;
        }
        public override int Count
        { get { return Materials.Count; } }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            return GetCustomView(position, convertView, parent, false);
        }

        private View GetCustomView(int position, View convertView, ViewGroup parent, bool dropdown)
        {

            //Switch your layout as you like it

            var item = Materials[position];

            var inflater = LayoutInflater.From(context);
            var view = convertView ?? inflater.Inflate((dropdown ? Resource.Layout.SpinnerItemDropdown : Resource.Layout.SpinnerItemText), parent, false);

            var text = view.FindViewById<TextView>(Resource.Id.text);

            if (text != null)
                text.Text = item.name;

            if (!_views.Contains(view))
                _views.Add(view);

            return view;
        }
        private void ClearViews()
        {
            foreach (var view in _views)
            {
                view.Dispose();
            }
            _views.Clear();
        }

        protected override void Dispose(bool disposing)
        {
            ClearViews();
            base.Dispose(disposing);
        }
    }
}