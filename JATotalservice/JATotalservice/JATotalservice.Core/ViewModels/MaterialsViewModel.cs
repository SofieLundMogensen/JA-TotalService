﻿using JATotalservice.Core.Service;
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
        private readonly MvvmCross.Navigation.IMvxNavigationService _navigationService;
        public IMvxCommand GoBackCommand => new MvxAsyncCommand(goBack);


        public override void Prepare()
        {
            base.Prepare();
        }

        List<Material> materials;
        Material material;

        public Material Material
        {
            get { return material; }
            set { SetProperty(ref material, value); }
        }

        public List<Material> Materials
        {
            get { return materials; }
            set { SetProperty(ref materials, value); }
        }
        
     
        public MaterialsViewModel(MvvmCross.Navigation.IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            GetMaterials();
        }
        public void GetMaterial()
        {
            Materials = MaterialService.GetAllMaterials();
        }
        
        public void PostMaterial(Material material)
        {
            //Adds the material to the list of materials
           
            Materials.Add(material);
            var didSucced = MaterialService.PostMaterial(material);
            GetMaterials();
        }
        public void Edit(Material material)
        {
            //Puts the material into the database
            MaterialService.PutMaterial(material);
            GetMaterials();
        }

        //Function that gets a list of materials from api, and returns a list of materials
        public void GetMaterials()
        {
            Materials = MaterialService.GetAllMaterials();
        }

        public void DeleteMaterial(int id)
        {
            MaterialService.DeleteMaterial(id);
            GetMaterials();
        }
        public async System.Threading.Tasks.Task goBack()
        {
            await _navigationService.Close(this);
        }
    }
}
