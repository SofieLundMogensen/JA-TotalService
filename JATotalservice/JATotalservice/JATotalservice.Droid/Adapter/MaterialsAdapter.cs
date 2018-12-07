using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JATotalservice.Core.ViewModels;
using JATotalservice.Droid.Views;
using Java.Lang;
using ModelLayer;

namespace JATotalservice.Droid.Adapter
{
    public class MaterialAdapter : BaseAdapter<Material>
    {
        private DialogMaterial dialogSign;
        private Android.Support.V4.App.FragmentManager transaction;
        public List<Material> Materials;
        Context context;
        private Material material = new Material();
        MaterialsViewModel materialsViewModel;
        public event EventHandler UpdateList;
        MaterialsView materialsView;


        public MaterialAdapter(MaterialsView materialsView, MaterialsViewModel materialViewModel, List<Material> Materials, Context context, Android.Support.V4.App.FragmentManager fragmentManager)
        {
            this.materialsViewModel = materialViewModel;
            this.Materials = Materials;
            this.context = context;
            this.transaction = fragmentManager;
            this.materialsView = materialsView;
        }

        public override Material this[int position]
        {
            get { return Materials[position]; }
        }
        public override int Count
        {
            get { return Materials.Count; }
        }

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
            //sætter udsennet på Gridviewt
            Button button = null;

            button = new Button(context);
            button.LayoutParameters = new GridView.LayoutParams(300, 300);
            button.SetPadding(8, 8, 8, 8);
            button.SetBackgroundColor(Color.DarkGray);
            button.SetTextColor(Color.White);




            button.Text = Materials[position].name + "\n" + Materials[position].price + " kr";
            Console.WriteLine(Materials[position].name);
            button.Click += delegate
            {

                var dialogMaterial = new DialogMaterial("Ændre", Materials[position]);
                dialogMaterial.DialogClosed += (object sender, DialogEventArgs e) =>
                {
                    materialsViewModel.Materials[position] = e.ReturnValue; materialsViewModel.Edit(e.ReturnValue);
                    materialsView.UpdateList();                     
                };
                dialogMaterial.Show(transaction, "Dialog fragment");
            };

            return button;
        }


    }
}
