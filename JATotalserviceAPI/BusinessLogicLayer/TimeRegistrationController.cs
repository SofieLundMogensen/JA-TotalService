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

        public void Create(TimeRegistartion obj)
        {
            db.Create(obj);
        }

        public void Delete(int id)
        {
            db.Delete(id);
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

        public void Update(TimeRegistartion obj)
        {
            db.Update(obj);
        }
    }
}
