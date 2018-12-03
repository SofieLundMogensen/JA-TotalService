using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
        public class TaskController : IController<Task>
        {
            IDB<Task> db = new DBTask();

            public bool Create(Task obj)
            {
                return db.Create(obj);
            }

            public bool Delete(int id)
            {
                return db.Delete(id);
            }

            public Task Get(int id)
            {
                return db.Get(id);
            }

            public List<Task> GetAll()
            {
                return db.GetAll();
            }

            public bool Update(Task obj)
            {
                return db.Update(obj);
            }
    }
}

