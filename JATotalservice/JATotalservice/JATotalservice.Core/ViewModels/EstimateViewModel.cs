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
        public int PostEstimatedPrice(EstimatedPrice estimatedPrice)
        {
            estimatedPrice.materials = MaterialsAmount;
            
            //Kalder EstimatedPrice service og poster Estimated price til db
            EstimatedPriceService.PostEstimatedPrice(estimatedPrice);

            //Kalder GetPrice metode
            var price = getPrice(estimatedPrice);

            MaterialsAmount.Clear();

            return price;
        }
        public int getPrice(EstimatedPrice estimatedPrice)
        {
            int TimePrice = 300;
            var EstimedTimePrice = estimatedPrice.estimatedTime * TimePrice;
            //TODO: MANGLER UDREGNING AF MATRIALER...
            
            return EstimedTimePrice;
        }

        public double CalculatePrice(EstimatedPrice estimatedPrice)
        {
            estimatedPrice.materials = MaterialsAmount;
            return EstimatedPriceService.CalculatePrice(estimatedPrice);
        }

    }
}
