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
using MvvmCross.ViewModels;
using static Android.Support.V7.Widget.RecyclerView;

namespace JATotalservice.Droid.Adapter
{
    public class MaterialsListViewAdapter : BaseAdapter<Tuple<Material, int>>
    {
        List<Material> tempMaterials;
        public Spinner Material;
        public List<Tuple<Material, int>> materials;
        Context context;
        MvxViewModel ViewModel;
        int selected;

        public MaterialsListViewAdapter(List<Tuple<Material, int>> materials, Context context, TimeViewModel timeViewModel)
        {
            this.ViewModel = timeViewModel;
            this.materials = materials;
            this.context = context;
        }

        public MaterialsListViewAdapter(List<Tuple<Material, int>> materials, Context context, EstimateViewModel estimatedViewModel)
        {
            this.ViewModel = estimatedViewModel;
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
            selected = tempMaterials.FindIndex(m => m.id == materials[position].Item1.id);

            Material.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                var M = tempMaterials[e.Position];
                //ViewModel.MaterialsAmount[position].Item1.id = M.id;
                var tt = ViewModel as TimeViewModel;
                var ff = ViewModel as EstimateViewModel;
                if (tt != null)
                {
                    tt.MaterialsAmount[position].Item1.id = M.id;
                }
                else if (ff != null)
                {
                    ff.MaterialsAmount[position].Item1.id = M.id;
                }

                
            };

            count.Text = materials[position].Item2.ToString();
            count.AfterTextChanged += delegate
            {
                if (Int32.TryParse(count.Text, out int pharsedAmount)) //Tjekker om det angivne antal kan formateres om til en int
                    {
                    
                    //TimeViewModel.MaterialsAmount.Add(Tuple.Create(materials[position].Item1, pharsedAmount)); //Tilføjer den nye tuple
                    //TimeViewModel.MaterialsAmount.Remove(materials[position]); //Fjerne den gamle, da man ikke kan ændre på en tuple

                    //ViewModel.MaterialsAmount[position] = Tuple.Create(materials[position].Item1, pharsedAmount); //Tilføjer den nye tuple
                    var tt = ViewModel as TimeViewModel;
                    var ff = ViewModel as EstimateViewModel;
                    if (tt != null)
                    {
                        tt.MaterialsAmount[position] = Tuple.Create(materials[position].Item1, pharsedAmount);
                    }
                    else if (ff != null)
                    {
                        ff.MaterialsAmount[position] = Tuple.Create(materials[position].Item1, pharsedAmount);
                    }
                }

            };

            Material.SetSelection(selected);
            return view;
        }

    }
}