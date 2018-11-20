using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeRegistrationController : ControllerBase
    {
        // GET api/TimeRegistrations
        [HttpGet("GetAll")]
        public List<TimeRegistartion> Getall()
        {
            BusinessLogicLayer.TimeRegistrationController timeRegistrationController = new BusinessLogicLayer.TimeRegistrationController();
            return timeRegistrationController.GetAll();

        }

        // GET api/TimeRegistration/5
        [HttpGet(("Get") + "{id}")]
        public TimeRegistartion Get(int id)
        {
            BusinessLogicLayer.TimeRegistrationController timeRegistrationController = new BusinessLogicLayer.TimeRegistrationController();
            var timeRegistration = timeRegistrationController.Get(id);
            return timeRegistration;
        }
        // POST api/TimeRegistration
        [HttpPost("Post")]
        public void Post(TimeRegistartion timeRegistartion)
        {
            BusinessLogicLayer.TimeRegistrationController timeRegistrationController = new BusinessLogicLayer.TimeRegistrationController();
            timeRegistrationController.Create(timeRegistartion);
        }
        // PUT api/TimeRegistration/5
        [HttpPut("Put")]
        public void Put(TimeRegistartion timeRegistartion)
        {
            BusinessLogicLayer.TimeRegistrationController timeRegistrationController = new BusinessLogicLayer.TimeRegistrationController();
            timeRegistrationController.Update(timeRegistartion);
        }
        // DELETE api/TimeRegistration/5
        [HttpDelete(("Delete")+("{id}"))]
        public void Delete(int id)
        {
            BusinessLogicLayer.TimeRegistrationController timeRegistrationController = new BusinessLogicLayer.TimeRegistrationController();
            timeRegistrationController.Delete(id);
        }

    }
}
