using ModelLayer;

using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JATotalservice.Core.ViewModels
{
    public class MaterialsViewModel : MvxViewModel
    {
        List<Material> materials;
        string hello = "Virker det her?";

        public List<Material> Materials
        {
            get { return materials; }
            set { SetProperty(ref materials, value); }
        }

        public string Hello
        {
            get { return hello; }
            set { SetProperty(ref hello, value); }
        }
        public MaterialsViewModel()
        {
            GetMaterials();
        }
        
        public void AddMaterial(Material material)
        {
            //Adds the material to the list of materials
            Materials.Add(material);
        }

        //Function that gets a list of materials from api, and returns a list of materials
        public void GetMaterials()
        {
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


            //TODO: Call api and get the list of materials 

            Materials = tempMaterials;
        }
    }
}
