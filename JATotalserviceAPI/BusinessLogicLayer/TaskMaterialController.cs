using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class TaskMaterialController : IController<Task>
    {
        IDB<Task> db = new DBTaskMaterial();

        public bool Create(Task obj)
        {
            return db.Create(obj);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetAll()
        {
            var taskMaterials = db.GetAll();
            List<Task> returnTaskMaterial = new List<Task>();


            //TODO: Virker ikke, man skal samle dataen i en liste sådan listen kun indeholder en af den samme task

            ////Skal gøres, for ellers virker for loopene ikke, det den gør er at lægge en task i den nye liste
            //if (returnTaskMaterial.Count < 1)
            //{
            //    returnTaskMaterial.Add(taskMaterials[0]);
            //    taskMaterials.RemoveAt(0);

            //}



            ////Samler alle materialerne der tilhører en task, i taskens liste
            //for (int i = 0; i < taskMaterials.Count; i++)
            //{
            //    for (int ii = 0; ii < returnTaskMaterial.Count; ii++)
            //    {
            //        if (returnTaskMaterial[ii].id == taskMaterials[i].id)
            //        {
            //            returnTaskMaterial[ii].materials.Add(taskMaterials[i].materials[0]);
            //        }
            //        else
            //        {
            //            returnTaskMaterial.Add(taskMaterials[i]);
            //            taskMaterials.RemoveAt(i); //Skal fjernes ellers for man mærkelig data

            //        }
            //    }
            //}




            return returnTaskMaterial;
        }

        public bool Update(Task obj)
        {
            throw new NotImplementedException();
        }
    }
}
