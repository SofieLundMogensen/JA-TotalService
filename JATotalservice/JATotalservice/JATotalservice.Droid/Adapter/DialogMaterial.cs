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

namespace JATotalservice.Droid
{
    public class DialogMaterial : Android.Support.V4.App.DialogFragment
    {
        Button opretBtn;
        TextView materialPrice;
        TextView materialName;
        TextView materialDescription;
        Material material;
        double materialDouble;
        
        public event EventHandler<DialogEventArgs> DialogClosed;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            var view = inflater.Inflate(Resource.Layout.DialogMaterial, container, false);
            this.Dialog.SetTitle("Opret Materiale");
            material = new Material();

            materialName = view.FindViewById<TextView>(Resource.Id.name);
            materialDescription = view.FindViewById<TextView>(Resource.Id.description);
            materialPrice = view.FindViewById<TextView>(Resource.Id.price);
            opretBtn = view.FindViewById<Button>(Resource.Id.button1);

            opretBtn.Click += delegate (object sender, EventArgs e)
            {
                material.name = materialName.Text;
                material.description = materialDescription.Text;
                double.TryParse(materialPrice.Text.Replace('.', ','), out materialDouble); //Converterer string fra user til en double
                material.price = materialDouble;
                this.Dismiss();
            };

            return view;
        }
        
        public override void OnDismiss(IDialogInterface dialog)
        {
            base.OnDismiss(dialog);
            if (DialogClosed != null)
            {
                DialogClosed(this, new DialogEventArgs { ReturnValue = material });
            }

        }

    }
}

//Klasse til at fortælle hvad vi vil dende retur med dismiss på dialig
public class DialogEventArgs
{
    //you can put other properties here that may be relevant to check from activity
    //for example: if a cancel button was clicked, other text values, etc.
    public Material ReturnValue { get; set; }
}
