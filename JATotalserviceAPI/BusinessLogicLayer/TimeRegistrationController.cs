using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class TimeRegistrationController : IController<TimeRegistartion>
    {
        IDB<TimeRegistartion> db = new DBTimeRegistration();
        TaskMaterialController taskMaterialController = new TaskMaterialController();

        public bool Create(TimeRegistartion obj)
        {
           
            var succes = db.Create(obj);
            if (succes)
            {
               return taskMaterialController.Create(obj.task);
            }
            return false;
          
          
        }
        public bool Delete(int id)
        {
           return db.Delete(id);
             
        }

        public TimeRegistartion Get(int id)
        {
            return db.Get(id);
            //TODO: Get Task and Employee, kan først gøres engang når der er lavet DBLag til dem
        }

        public List<TimeRegistartion> GetAll()
        {
            return db.GetAll();
            //TODO: Get Task and Employee, kan først gøres engang når der er lavet DBLag til dem
        }

        public bool Update(TimeRegistartion obj)
        {
           return db.Update(obj);
           
        }
    }
}
