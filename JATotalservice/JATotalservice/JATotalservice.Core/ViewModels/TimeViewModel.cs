using JATotalservice.Core.Service;
using ModelLayer;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JATotalservice.Core.ViewModels
{
    public class TimeViewModel : MvxViewModel
    {
        List<ModelLayer.Task> tasks;
        List<MaterialTask> materialTasks;
        //private readonly IMvxNavigationService _navigationService;
        public IMvxCommand PostTime => new MvxCommand<TimeRegistartion>(PostTimeRegistration);
       
        public List<ModelLayer.Task> Tasks
        {
            get { return tasks; }
            set { SetProperty(ref tasks, value); }
        }
        public List<MaterialTask> MaterialTasks
        {
            get { return materialTasks; }
            set { SetProperty(ref materialTasks, value); }
        }

        public TimeViewModel()
        {
            //Kalder alle tasks
            GetTasks();
            //TODO: Slettes på et tidpunkt
            MaterialTasks = new List<MaterialTask>();
            for (int i = 0; i < 2; i++)
            {
                MaterialTask materialTask = new MaterialTask()
                {
                    Count = 200
                };
                materialTasks.Add(materialTask);
            }
        }

        public void GetTasks()
        {
            //TODO: KALD Service - Kald de forskellige opgaver fra service
            ModelLayer.Task task = new ModelLayer.Task();
            var tasks = new List<ModelLayer.Task>();
            tasks.Add(new ModelLayer.Task { name = "Hans HANSEN VEJ", id = 1});
            tasks.Add(new ModelLayer.Task { name = "Ib", id = 1  });
            tasks.Add(new ModelLayer.Task { name = "Bo", id = 1 });
            Tasks = tasks;
        }

        public void PostTimeRegistration(TimeRegistartion timeRegistartion)
        {
            //Kalder timeregistration service og poster timeregistration
            TimeRegistartionService.PostTimeInfo(timeRegistartion);
            materialTasks.Clear();
        }
        public void AddMaterials(MaterialTask materialTask)
        {
            //tilføjer en materialertask til matrialertask listen
            MaterialTasks.Add(materialTask);
        }

    }
}
