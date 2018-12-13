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
            //Post her
           
        }
        public void Edit(Task task)
        {
            // edit her
     
        }

        //Function that gets a list of task from api, and returns a list of task
        public void GetTasks()
        {
            Tasks = new List<Task>();
            //TODO: Get tasks
            for (int i = 0; i < 10; i++)
            {
                Task task = new Task();
                task.id = i;
                task.name = "task" + i;

                Tasks.Add(task);
            }
        }

      
    }
}