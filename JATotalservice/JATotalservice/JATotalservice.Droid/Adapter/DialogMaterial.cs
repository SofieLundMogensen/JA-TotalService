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

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            var view = inflater.Inflate(Resource.Layout.DialogMaterial, container, false);
            this.Dialog.SetTitle("fefwe");
            material = new Material();

            materialName = view.FindViewById<TextView>(Resource.Id.name);
            materialDescription = view.FindViewById<TextView>(Resource.Id.description);
            materialPrice = view.FindViewById<TextView>(Resource.Id.price);
            opretBtn = view.FindViewById<Button>(Resource.Id.button1);


       



            opretBtn.Click += delegate (object sender, EventArgs e)
            {
                jifjewijf();
            };

            void jifjewijf()
            {
                material.name = materialName.Text;
                material.description = materialDescription.Text;
                var MP = materialPrice.Text.Replace('.', ',');
                double.TryParse(MP, out materialDouble);
                material.price = materialDouble;
                this.Dismiss();
            }

            return view;
        }

        public event EventHandler<DialogEventArgs> DialogClosed;

        public override void OnDismiss(IDialogInterface dialog)
        {
            base.OnDismiss(dialog);
            if (DialogClosed != null)
            {
                DialogClosed(this, new DialogEventArgs { ReturnValue = material });
            }

        }









      // public event EventHandler DialogClosed;

        //public override void OnDismiss(IDialogInterface dialog)
        // {
        //     base.OnDismiss(dialog);
        //     if (DialogClosed != null)
        //     {
        //         DialogClosed(this, null);
        //     }
        // }
        ////public override void OnActivityCreated(Bundle savedInstanceState)
        ////{
        ////    Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
        ////    base.OnActivityCreated(savedInstanceState);
        ////    Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        //}
    }
}
         public class DialogEventArgs
        {
            //you can put other properties here that may be relevant to check from activity
            //for example: if a cancel button was clicked, other text values, etc.

            public Material ReturnValue { get; set; }
        } 
