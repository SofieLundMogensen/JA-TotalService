using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        BusinessLogicLayer.TaskController taskcontroller = new BusinessLogicLayer.TaskController();

        // Get api/Tasks
        [HttpGet("GetAll")]
         public List<Task> GetAll()
        {
            return taskcontroller.GetAll();
        }

        //GET api/Task
        [HttpGet(("get") + "{id}")]
        public Task Get(int id)
        {
            return taskcontroller.Get(id);
        }

        // POST api/Task
        [HttpPost("Post")]
            public bool Post(Task task)
        {
            return taskcontroller.Create(task);
        }

        //Put api/Task
        [HttpPost("Put")]
        public bool Put(Task task)
        {
            return taskcontroller.Update(task);
        }

        // Delete api/Task
        [HttpDelete(("Delete")+("{id}"))]
        public bool Delete(int id)
        {
        return taskcontroller.Delete(id);
        }
    }
}