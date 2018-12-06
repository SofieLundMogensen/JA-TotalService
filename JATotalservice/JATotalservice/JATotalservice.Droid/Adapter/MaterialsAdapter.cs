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
using Java.Lang;
using ModelLayer;

namespace JATotalservice.Droid.Adapter
{
    public class MaterialAdapter : BaseAdapter<Material>
    {
        public List<Material> Materials;
        Context context;
        private Material material = new Material();

        public MaterialAdapter(List<Material> Materials, Context context)
        {
            this.Materials = Materials;
            this.context = context;
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
            button.Click += delegate { Toast.MakeText(context, Materials[position].description, ToastLength.Short).Show(); };
            
            return button;
        }
        
    }
}
