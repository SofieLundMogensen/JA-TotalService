using JATotalservice.Core.Service;
using ModelLayer;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JATotalservice.Core.ViewModels
{
    public class TaskViewModel : MvxViewModel
    {
        public override void Prepare()
        {
            base.Prepare();
        }

        List<Task> tasks;
        Task task;

        public Task Task
        {
            get { return task; }
            set { SetProperty(ref task, value); }
        }

        public List<Task> Tasks
        {
            get { return tasks; }
            set { SetProperty(ref tasks, value); }
        }

        public TaskViewModel()
        {
            GetTasks();
        }

        public void PostTask(Task task)
        {
            TaskService.PostTask(task);
            GetTasks();
                     
        }
        public void Edit(Task task)
        {
            TaskService.PutTask(task);
            GetTasks();

        }
        public void delete(int id)
        {
            TaskService.DeleteTask(id);
            GetTasks();
        }

        //Function that gets a list of task from api, and returns a list of task
        public void GetTasks()
        {
          Tasks =  TaskService.GetAllTasks();
           // Tasks = new List<Task>();

           /* //TODO: Get tasks
            for (int i = 0; i < 10; i++)
            {
                Task task = new Task();
                task.id = i;
                task.name = "task" + i;
                task.description = "Noget beskrivesle som der bare skal stå random her....";
                task.isComplete = false;
                task.timeRegistrations = new List<TimeRegistartion>();
                task.materials = new List<Tuple<Material, int>>();


                for (int t = 0; t < 10; t++)
                {
                    TimeRegistartion timeRegistartion = new TimeRegistartion
                    {
                        startTime = DateTime.Now,
                        endTime = new DateTime(2018, 12, 13, 20, 00, 00),
                        employee = new Employee { Id = 1 }
                    };
                    task.timeRegistrations.Add(timeRegistartion);
                }
                for (int v = 0; v < 14; v++)
                {
                    Material material = new Material
                    {
                        id = v,
                        name = "material " + v,
                        price = 200
                       
                    };
                    Random rnd = new Random();
                    int n = rnd.Next(1, 50);
                  task.materials.Add(Tuple.Create(material, n));
                }
                Tasks.Add(task);*/
            }
        }

        public void CreatePdf()
        {

        }
      
    }
