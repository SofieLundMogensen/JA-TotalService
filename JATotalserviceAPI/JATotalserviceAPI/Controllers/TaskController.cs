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
        BusinessLogicLayer.TimeRegistrationController timeRegistrationController = new BusinessLogicLayer.TimeRegistrationController();
        BusinessLogicLayer.MaterialController materialController = new BusinessLogicLayer.MaterialController();

        // Get api/Tasks
        [HttpGet("GetAll")]
        public List<Task> GetAll()
        {
            /* En alternativ til koden, er at lave en left join i da kaldet, sql koden er nedenfor, hvor man left joiner task sammen med timeRegistrations
                SELECT `Task`.`Id`, `Task`.`Name`, `Task`.`Description`, `Task`.`IsComplete`, 
                    `TimeRegistration`.`Id`, `TimeRegistration`.`TaskId`, `TimeRegistration`.`StartTime`, `TimeRegistration`.`EndTime`, `TimeRegistration`.`EmployeeId`
                FROM
                    `Task`
                LEFT JOIN
                    `TimeRegistration` ON `Task`.`Id` = `TimeRegistration`.`TaskId`
                ORDER BY `Task`.`Id`
            */

            var taskList = taskcontroller.GetAll();
            var timeList = timeRegistrationController.GetAll();
            var materialList = materialController.GetAll();
            //Tilføjer task og timeRegistrations sammen
            for (int i = 0; i < taskList.Count; i++) //Man kan ikke bruge foreach ved denne løsning
            {
                taskList[i].timeRegistrations = new List<TimeRegistartion>(); //Instansiere listen timeRegistrations på listen af task
                foreach (var time in timeList)
                {
                    if (taskList[i].id == time.task.id) //Spøreger om id'erne er det samme, og tilføjer dem hvis de er
                    {
                        taskList[i].timeRegistrations.Add(time);
                    }
                }
            }

  
            return taskList;
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
        [HttpDelete(("Delete") + ("{id}"))]
        public bool Delete(int id)
        {
            return taskcontroller.Delete(id);
        }
    }
}