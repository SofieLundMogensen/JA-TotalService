using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class TaskMaterialTest
    {
        [TestMethod]
        public void CreateTest()
        {
            //Arrange
            DBTaskMaterial taskMaterial = new DBTaskMaterial();
            var Create = new ModelLayer.Task();
            Create.id = 1;
            Create.materials = new List<Tuple<Material, int>>();
            var item = Tuple.Create(new Material {id = 1}, 200);
            var item2 = Tuple.Create(new Material { id = 2 }, 400);
            Create.materials.Add(item);
            Create.materials.Add(item2);


            //Act
            var succes = taskMaterial.Create(Create);
            //Assert
            Assert.IsTrue(succes);
        }
    }
}
