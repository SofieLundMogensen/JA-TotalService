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

        public ModelLayer.Task CheckIfLocationTaskExist(LocationModel locationModel) //Finder den sidste i listen af tasks som passer bedst og returnerer den
        {
            int bigFound = 0;
            ModelLayer.Task returnTask = new ModelLayer.Task();

            List<ModelLayer.Task> tempTasks = Tasks;

            foreach (var task in tempTasks)
            {
                if (locationModel.address.postcode != null && task.zipcode != null)
                {
                    if (task.zipcode.ToLower() == locationModel.address.postcode.ToLower()) //Hvis postnummeret er ens
                    {
                        if (bigFound < 2)
                        {
                            bigFound = 1;
                            returnTask = task;
                        }

                        if (locationModel.address.road != null && task.road != null)
                        {
                            if (task.road.ToLower() == locationModel.address.road.ToLower()) //Hvis postnummer og vej er ens
                            {
                                //Hvis postnummer og vej passer
                                if (bigFound < 3)
                                {
                                    bigFound = 2;
                                    returnTask = task;
                                }

                                if (locationModel.address.house_number != null && task.houseNumber != null)
                                {
                                    if (task.houseNumber.ToLower() == locationModel.address.house_number.ToLower()) //Hvis postnummer, vej og husnummer alle passer sammen
                                    {
                                        //Hvis postnummer, vej og husnummer alle passer sammen
                                        bigFound = 3;
                                        returnTask = task;
                                    }
                                }
                            }

                            
                        }

                    }

                    
                }
                
                if (bigFound < 1) //Hvis der ikke er nogen der passer, så tag den sidste
                {
                    returnTask = task;
                }



            }


            return returnTask;
        }
    }
}
