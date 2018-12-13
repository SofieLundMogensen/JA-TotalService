using JATotalservice.Core.Service;
using ModelLayer;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JATotalservice.Core.ViewModels
{
    public class EstimateViewModel : MvxViewModel
    {
        //public IMvxCommand PostEstimated => new MvxCommand<EstimatedPrice>(PostEstimatedPrice);
        List<Material> materials;
        List<MaterialTask> materialTasks;

        List<Tuple<Material, int>> materialsAmounts;
        public List<Material> Materials
        {
            get { return materials; }
            set { SetProperty(ref materials, value); }
        }
        public List<Tuple<Material, int>> MaterialsAmount
        {
            get { return materialsAmounts; }
            set { SetProperty(ref materialsAmounts, value); }
        }

        public List<MaterialTask> MaterialTasks
        {
            get { return materialTasks; }
            set { SetProperty(ref materialTasks, value); }
        }

        public EstimateViewModel()
        {
            GetMaterials();

            MaterialsAmount = new List<Tuple<Material, int>>();
        }

        public void GetMaterials()
        {

            Materials = MaterialService.GetAllMaterials();
        }

        public void AddMaterials(int amount, Material material)
        {
            //Til når du klikker på tilføje mere matrialer (+ ikon)
            var Material = Tuple.Create(material, amount);
            MaterialsAmount.Add(Material);
        }
        public void PostEstimatedPrice(EstimatedPrice estimatedPrice)
        {
            estimatedPrice.materials = MaterialsAmount;
            
            //Kalder EstimatedPrice service og poster Estimated price til db
            var didsucced = EstimatedPriceService.PostEstimatedPrice(estimatedPrice);

            MaterialsAmount.Clear();
            
        }
        
        public double CalculatePrice(EstimatedPrice estimatedPrice)
        {
            estimatedPrice.materials = MaterialsAmount;
            return EstimatedPriceService.CalculatePrice(estimatedPrice);
        }

    }
}
