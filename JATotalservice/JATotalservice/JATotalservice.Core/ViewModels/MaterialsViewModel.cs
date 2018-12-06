using JATotalservice.Core.Service;
using ModelLayer;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using JATotalservice.Core.Service;

namespace JATotalservice.Core.ViewModels
{
    public class MaterialsViewModel : MvxViewModel
    {
        public override void Prepare()
        {
            base.Prepare();
        }

        //public override async Task Initialize()
        //{
        //    await base.Initialize();
        //}

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
        
        public void PostMaterial(Material material)
        {
            //Adds the material to the list of materials
            Materials.Add(material);
            MaterialService.PostMaterial(material);
        }

        //Function that gets a list of materials from api, and returns a list of materials
        public void GetMaterials()
        {
            
            //List<Material> tempMaterials = new List<Material>();

            //for (int i = 1; i <= 10; i++)
            //{

            //    Material material = new Material
            //    {
            //        id = i,
            //        name = "item" + i,
            //        description = "jaja",
            //        price = 200
            //    };
            //    tempMaterials.Add(material);
            //}


            //TODO: Call api and get the list of materials 

            Materials = MaterialService.GetAllMaterials();
        }

        public static void DeleteMaterial()
        {
            MaterialService.DeleteMaterial(3);
        }
        
        //public static void PutMaterial()
        //{
        //    MaterialService.PutMaterial();
        //}
    }
}
