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
        BusinessLogicLayer.TimeRegistrationController timeRegistrationController = new BusinessLogicLayer.TimeRegistrationController();

        // GET api/TimeRegistrations
        [HttpGet("GetAll")]
        public List<TimeRegistartion> Getall()
        {
            return timeRegistrationController.GetAll();
        }

        // GET api/TimeRegistration/5
        [HttpGet(("Get") + "{id}")]
        public TimeRegistartion Get(int id)
        {
            return timeRegistrationController.Get(id);
        }
        // POST api/TimeRegistration
        [HttpPost("Post")]
        public void Post(TimeRegistartion timeRegistartion)
        {
            timeRegistrationController.Create(timeRegistartion);
        }
        // PUT api/TimeRegistration/5
        [HttpPut("Put")]
        public void Put(TimeRegistartion timeRegistartion)
        {
            timeRegistrationController.Update(timeRegistartion);
        }
        // DELETE api/TimeRegistration/5
        [HttpDelete(("Delete")+("{id}"))]
        public void Delete(int id)
        {
            timeRegistrationController.Delete(id);
        }
    }
}
