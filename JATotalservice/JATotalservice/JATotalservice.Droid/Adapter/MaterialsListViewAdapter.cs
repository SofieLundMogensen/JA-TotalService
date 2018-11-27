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
    public class MaterialsListViewAdapter :  BaseAdapter<Tuple<Material, int>>
    {
        List<Material> tempMaterials;
        public Spinner Material;
        public List<Tuple<Material, int>> materials;
        Context context;
        TimeViewModel TimeViewModel;
        public MaterialsListViewAdapter(List<Tuple<Material, int>> materials, Context context, TimeViewModel timeViewModel)
        {
            this.TimeViewModel = timeViewModel;
            this.materials = materials;
            this.context = context;
        }
        public override Tuple<Material, int> this[int position]
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
            Material = view.FindViewById<Spinner>(Resource.Id.dropdown);
            var count = view.FindViewById<TextView>(Resource.Id.Text);

            //TODO: Have mulige materialer med ud fra viewet?? eller finde en måde at kalde dem på?
            tempMaterials = new List<Material>();

            for (int i = 1; i <= 2; i++)
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
           // Material.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            Material.ItemSelected += delegate { spinner_ItemSelected(position); };
            count.Text = materials[position].Item2.ToString();
            count.AfterTextChanged += delegate {
                TimeViewModel.MaterialsAmount.Add(Tuple.Create(materials[position].Item1, Int32.Parse(count.Text)));
                TimeViewModel.MaterialsAmount.Remove(materials[position]);
            };
            return view;
        }

      
            private void spinner_ItemSelected(int pos)
        {
            int MPos = int.Parse(Material.SelectedItemId.ToString());
            
            var M = tempMaterials[MPos];


            var testt = TimeViewModel.MaterialsAmount[pos];
            TimeViewModel.MaterialsAmount[pos].Item1.id = M.id;

            /*
            var count = TimeViewModel.MaterialsAmount;
            TimeViewModel.MaterialsAmount.Add(Tuple.Create(M, testt.Item2));
            TimeViewModel.MaterialsAmount.Remove(testt);
            var countafter = TimeViewModel.MaterialsAmount;*/

        }
    }
}