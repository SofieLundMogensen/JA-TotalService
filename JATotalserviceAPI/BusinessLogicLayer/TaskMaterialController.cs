using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class TaskMaterialController : IController<Task>
    {
        IDB<Task> db = new DBTaskMaterial();

        public void Create(Task obj)
        {
            db.Create(obj);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Task obj)
        {
            throw new NotImplementedException();
        }
    }
}
