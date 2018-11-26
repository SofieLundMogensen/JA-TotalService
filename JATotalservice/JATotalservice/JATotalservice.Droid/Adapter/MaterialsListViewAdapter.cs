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
using ModelLayer;
using static Android.Support.V7.Widget.RecyclerView;

namespace JATotalservice.Droid.Adapter
{
    public class MaterialsListViewAdapter : BaseAdapter<MaterialTask>
    {
        List<MaterialTask> materials;
        Context context;
        public MaterialsListViewAdapter(List<MaterialTask> materials, Context context)
        {
            this.materials = materials;
            this.context = context;
        }
        public override MaterialTask this[int position]
        {
            get
            {
                return materials[position];
            }
        }
        public override int Count
        {
            get
            {
                return materials.Count;
            }
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            return GetCustomView(position, convertView, parent, false);
        }
        private View GetCustomView(int position, View convertView, ViewGroup parent, bool Bool)
        {
            //Opsætning af hvordan listen skal se ud
            var view = convertView;


            if (view == null)
            {
                var inflater = LayoutInflater.From(context);
                view = convertView ?? inflater.Inflate((Bool ? Resource.Layout.SpinnerItemDropdown : Resource.Layout.MaterialsListView), parent, false);
            }
            var Material = view.FindViewById<Spinner>(Resource.Id.dropdown);
            var count = view.FindViewById<TextView>(Resource.Id.Text);

            //TODO: Have mulige materialer med ud fra viewet?? eller finde en måde at kalde dem på?
            List<Material> tempMaterials = new List<Material>();

            for (int i = 1; i <= 10; i++)
            {
                Material material = new Material
                {
                    id = i,
                    name = "item" + i,
                    description = "jaja",
                    price = 200
                };
                tempMaterials.Add(material);
            }
            //Sætter adapter på en ny liste i listen
            Material.Adapter = new MaterialsDropdownAdapter(tempMaterials, context);
            count.Text = "200";

            return view;
        }
    }
}