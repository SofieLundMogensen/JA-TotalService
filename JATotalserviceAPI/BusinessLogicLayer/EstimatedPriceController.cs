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
    }
}
