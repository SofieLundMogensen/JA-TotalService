using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class EstimatedPriceController : IController<EstimatedPrice>
    {
        IDB<EstimatedPrice> db = new DBEstimatedPrice();

        public void Create(EstimatedPrice obj)
        {
            db.Create(obj);
        }
        public void Delete(int id)
        {
            db.Delete(id);
        }
        public EstimatedPrice Get(int id)
        {
            return db.Get(id);
        }
        public List<EstimatedPrice> GetAll()
        {
            return db.GetAll();
        }
        public void Update(EstimatedPrice obj)
        {
            db.Update(obj);
        }
    }
}
