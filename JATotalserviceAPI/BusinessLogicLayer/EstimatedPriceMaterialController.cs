using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class EstimatedPriceMaterialController : IController<EstimatedPrice>
    {
        IDB<EstimatedPrice> db = new DBEstimatedPriceMaterial();

        public bool Create(EstimatedPrice obj)
        {
            return db.Create(obj);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public EstimatedPrice Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<EstimatedPrice> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(EstimatedPrice obj)
        {
            throw new NotImplementedException();
        }
    }
}
