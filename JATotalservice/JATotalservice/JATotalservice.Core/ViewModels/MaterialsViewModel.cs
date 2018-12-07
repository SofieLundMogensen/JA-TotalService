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

        List<Material> materials;

        public List<Material> Materials
        {
            get { return materials; }
            set { SetProperty(ref materials, value); }
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
        public void Edit(Material material)
        {
            //Puts the material into the database
            MaterialService.PutMaterial(material);
        }

        //Function that gets a list of materials from api, and returns a list of materials
        public void GetMaterials()
        {
            Materials = MaterialService.GetAllMaterials();
        }

        //public static void DeleteMaterial()
        //{
        //    MaterialService.DeleteMaterial(3);
        //}

    }
}
