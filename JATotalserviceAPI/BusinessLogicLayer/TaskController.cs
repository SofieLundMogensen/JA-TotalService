using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class TaskController : IController<Task>
    {
        BusinessLogicLayer.TimeRegistrationController timeRegistrationController = new BusinessLogicLayer.TimeRegistrationController();
        BusinessLogicLayer.MaterialController materialController = new BusinessLogicLayer.MaterialController();
        BusinessLogicLayer.TaskMaterialController taskMaterialController = new BusinessLogicLayer.TaskMaterialController();
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
            /* En alternativ til koden, er at lave en left join i da kaldet, sql koden er nedenfor, hvor man left joiner task sammen med timeRegistrations
              SELECT `Task`.`Id`, `Task`.`Name`, `Task`.`Description`, `Task`.`IsComplete`, 
                  `TimeRegistration`.`Id`, `TimeRegistration`.`TaskId`, `TimeRegistration`.`StartTime`, `TimeRegistration`.`EndTime`, `TimeRegistration`.`EmployeeId`
              FROM
                  `Task`
              LEFT JOIN
                  `TimeRegistration` ON `Task`.`Id` = `TimeRegistration`.`TaskId`
              ORDER BY `Task`.`Id`
          */
            var taskList = db.GetAll();

            var timeList = timeRegistrationController.GetAll();
            var materialList = materialController.GetAll();

            //Tilføjer task og timeRegistrations sammen
            for (int i = 0; i < taskList.Count; i++) //Man kan ikke bruge foreach ved denne løsning
            {
                taskList[i].timeRegistrations = new List<TimeRegistartion>(); //Instansiere listen timeRegistrations på listen af task
                foreach (var time in timeList)
                {
                    if (taskList[i].id == time.task.id) //Spørger om id'erne er det samme, og tilføjer dem hvis de er
                    {
                        taskList[i].timeRegistrations.Add(time);
                    }
                }
            }

            //Tilføjer materialer til tasklist
            foreach (var task in taskList)
            {
                task.materials = taskMaterialController.GetTaskMaterial(task.id);
            }

            return taskList;
        }

        public bool Update(Task obj)
        {
            bool succes = false;
            //var b = taskMaterialController.Delete(obj.id);
            //if (b)
            //{
            //    foreach (var time in obj.timeRegistrations)
            //    {
            //       timeRegistrationController.Update(time);
            //    }

            //    succes = taskMaterialController.Update(obj);
            //}

            succes = db.Update(obj);

            return succes;
        }
    }
}

