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
            var view = convertView;
           
            try
            {
                if (view == null)
                {
                    var inflater = LayoutInflater.From(context);
                    view = convertView ?? inflater.Inflate((Bool ? Resource.Layout.SpinnerItemDropdown : Resource.Layout.MaterialsListView), parent, false);

                    //view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.MaterialsListView, parent, false);
                }
                var Material = view.FindViewById<Spinner>(Resource.Id.dropdown);
                var count = view.FindViewById<TextView>(Resource.Id.Text);
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
                Material.Adapter = new MaterialsDropdownAdapter(tempMaterials, context);
                // Material.Adapter = 
                count.Text = "200";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally { }
            return view;

        }
    }
}