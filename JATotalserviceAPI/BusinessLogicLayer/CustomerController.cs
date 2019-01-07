using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class CustomerController : IController<Customer>
    {
        DBCustomer db = new DBCustomer();

        public bool Create(Customer obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            return db.GetAll();
        }

        public bool Update(Customer obj)
        {
            throw new NotImplementedException();
        }
    }
}
