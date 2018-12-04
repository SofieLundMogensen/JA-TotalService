using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class EstimatedPriceController : IController<EstimatedPrice>
    {
        DBEstimatedPrice db = new DBEstimatedPrice();
        EstimatedPriceMaterialController estimatedPriceMaterialController = new EstimatedPriceMaterialController();
        MaterialController materialController = new MaterialController();

        public bool Create(EstimatedPrice obj)
        {
            var succes = db.Create(obj);
            obj.Id = succes;
            if (succes != -1)
            {
                return estimatedPriceMaterialController.Create(obj);
            }
            return false;
        }
        public bool Delete(int id)
        {
           return db.Delete(id);
        }
        public EstimatedPrice Get(int id)
        {
            return db.Get(id);
        }
        public List<EstimatedPrice> GetAll()
        {
            return db.GetAll();
        }
        public bool Update(EstimatedPrice obj)
        {
           return db.Update(obj);
        }

        public double CalculatePrice(EstimatedPrice estimatedPrice)
        {
            double returnPrice = 0;
            double hourPrice = 300;

            returnPrice += hourPrice * estimatedPrice.estimatedTime; //Finder timeprisen på opgaven

            foreach (var item in estimatedPrice.materials)
            {
                Material material = materialController.Get(item.Item1.id); //Henter den nye version af materiale
                returnPrice += material.price * item.Item2; //Udregner prisen med antal materialer
            }
            
            return returnPrice;
        }
    }
}
