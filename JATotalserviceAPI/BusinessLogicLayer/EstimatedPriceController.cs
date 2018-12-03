﻿using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class EstimatedPriceController : IController<EstimatedPrice>
    {
        IDB<EstimatedPrice> db = new DBEstimatedPrice();

        public bool Create(EstimatedPrice obj)
        {
            return db.Create(obj);
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
