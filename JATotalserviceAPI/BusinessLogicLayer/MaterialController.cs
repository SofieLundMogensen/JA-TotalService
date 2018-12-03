using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class MaterialController : IController<Material>
    {
        IDB<Material> db = new DBMaterial();
       
        public bool Create(Material obj)
        {
            return db.Create(obj);
        }

        public bool Delete(int id)
        {
            return db.Delete(id);
        }

        public Material Get(int id)
        {
            return db.Get(id);
        }

        public List<Material> GetAll()
        {
            return db.GetAll();
        }

        public bool Update(Material obj)
        {
            return db.Update(obj);
        }
    }
}
