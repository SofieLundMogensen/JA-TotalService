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
        List<Material> materials;
        List<Tuple<Material, int>> materialsAmounts;

        public IMvxCommand PostTime => new MvxCommand<TimeRegistartion>(PostTimeRegistration);

        public List<Material> Materials
        {
            get { return materials; }
            set { SetProperty(ref materials, value); }
        }
        public List<ModelLayer.Task> Tasks
        {
            get { return tasks; }
            set { SetProperty(ref tasks, value); }
        }
        public List<Tuple<Material, int>> MaterialsAmount
        {
            get { return materialsAmounts; }
            set { SetProperty(ref materialsAmounts, value); }
        }

        public TimeViewModel()
        {
            //Kalder alle tasks
            GetTasks();
            GetMaterials();
            MaterialsAmount = new List<Tuple<Material, int>>();
        }
        
        public void GetTasks()
        {
            //var tasks = new List<ModelLayer.Task>();
            //tasks.Add(new ModelLayer.Task { name = "Hans HANSEN VEJ", id = 1});
            //tasks.Add(new ModelLayer.Task { name = "Ib", id = 1  });
            //tasks.Add(new ModelLayer.Task { name = "Bo", id = 1 });
            //Tasks = tasks;
            Tasks = TaskService.GetAllTasks();
        }

        public void PostTimeRegistration(TimeRegistartion timeRegistartion)
        {
            timeRegistartion.task.materials = MaterialsAmount;
            //Kalder timeregistration service og poster timeregistration
            var didSucced = TimeRegistartionService.PostTimeInfo(timeRegistartion);
            MaterialsAmount.Clear();
        }

        public void AddMaterials(Tuple<Material, int> materialAmount)
        {
            //tilføjer en materialertask til matrialertask listen
            MaterialsAmount.Add(materialAmount);
        }

        public void GetMaterials()
        {
           Materials = MaterialService.GetAllMaterials();
        }

        public Material CheckIfLocationTaskExist(LocationModel locationModel)
        {
            List<ModelLayer.Task> tempTasks = Tasks;

            foreach (var task in tempTasks)
            {
                if (task.road.Contains(locationModel.address.road))
                {
                    Console.WriteLine("ehheheh");
                }
                else
                {
                    Console.WriteLine("fe,wfewå");
                }
            }


            return null;
        }
    }
}
