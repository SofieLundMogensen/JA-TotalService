using JATotalservice.Core.Service;
using ModelLayer;
using MvvmCross.Commands;
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
        List<Material> materials;

        public Task Task
        {
            get { return task; }
            set { SetProperty(ref task, value); }
        }
        public List<Material> Materials
        {
            get { return materials; }
            set { SetProperty(ref materials, value); }
        }

        public List<Task> Tasks
        {
            get { return tasks; }
            set { SetProperty(ref tasks, value); }
        }

        public TaskViewModel()
        {
            GetTasks();
            Materials = MaterialService.GetAllMaterials();
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
        public void deleteMaterial(Tuple<Material, int> tuple)
        {
            var m = Task.materials.Find(f => f.Item1 == tuple.Item1 && f.Item2 == tuple.Item2);
            Task.materials.Remove(m);
            TaskService.PutTask(Task);
            GetTasks();
        }
        public void editMaterial(Tuple<Material, int> oldtuple, Tuple<Material, int> newtuple)
        {
            var m = Task.materials.FindAll(f => f.Item1 != newtuple.Item1 && f.Item2 != newtuple.Item2);

            m.Add(oldtuple);
            Task.materials = m;
            TaskService.PutTask(Task);
            GetTasks();
        }
        public void addMaterial(Task task)
        {
            TaskService.PutTask(task);
            Task = task;
            GetTasks();
        }
        public void addTime(DateTime startTime, DateTime endTime)
        {
            TimeRegistartion timeRegistartion = new TimeRegistartion();
            timeRegistartion.startTime = startTime;
            timeRegistartion.endTime = endTime;
            timeRegistartion.task = new Task { id = Task.id };
            timeRegistartion.employee = new Employee { Id = 1 };
            TimeRegistartionService.PostTimeInfo(timeRegistartion);
            if (Task.timeRegistrations != null)
            {
                Task.timeRegistrations.Add(timeRegistartion);
            }
            else
            {
                Task.timeRegistrations = new List<TimeRegistartion>();
                Task.timeRegistrations.Add(timeRegistartion);
            }
            GetTasks();
        }
        public void editTime(TimeRegistartion timeRegistartion, DateTime startTime, DateTime endTime)
        {
            Task.timeRegistrations.Find(m => m.Id == timeRegistartion.Id).startTime = startTime;
            Task.timeRegistrations.Find(m => m.Id == timeRegistartion.Id).endTime = endTime;
            
            TaskService.PutTask(Task);
            GetTasks();
        }

        public void deleteTime(TimeRegistartion timeRegistartion)
        {
            TimeRegistartionService.DeleteTimeInfo(timeRegistartion.Id);
            GetTasks();
            task.timeRegistrations.Remove(timeRegistartion);
        }
        //Function that gets a list of task from api, and returns a list of task
        public void GetTasks()
        {
            //   task = TaskService.GetTask(1);
            Tasks = TaskService.GetAllTasks();
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
}
