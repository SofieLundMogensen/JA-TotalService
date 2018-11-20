using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class TimeRegistrationController : IController<TimeRegistartion>
    {
        public void Create(TimeRegistartion obj)
        {
            IDB<TimeRegistartion> db = new DBTimeRegistration();
            var timeregistration = db.Create(obj);
        }

        public void Delete(int id)
        {
            IDB<TimeRegistartion> db = new DBTimeRegistration();
            db.Delete(id);
        }

        public TimeRegistartion Get(int id)
        {
            DBTimeRegistration db = new DBTimeRegistration();
            var timeregistration = db.Get(id);

            //TODO: Get Task and Employee, kan først gøres engang når der er lavet DBLag til dem
            return timeregistration;
        }

        public List<TimeRegistartion> GetAll()
        {
            IDB<TimeRegistartion> db = new DBTimeRegistration();
            var getall = db.GetAll();
            //TODO: Get Task and Employee, kan først gøres engang når der er lavet DBLag til dem
            return getall;
        }

        public void Update(TimeRegistartion obj)
        {
            IDB<TimeRegistartion> db = new DBTimeRegistration();
            var timeregistration = db.Update(obj);
        }
    }
}
