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
    public class MaterialTest
    {
       
        [TestMethod]
        public void CreateTest()
        {
            //Arrange
            DBMaterial MaterialDB = new DBMaterial();
            var create = new Material();
            create.description = "Noget";
            create.name = "Et navn";
            create.price = 2000;

            //Act
            var sucess = MaterialDB.Create(create);

            //Assert
            Assert.IsTrue(sucess);
        }

        [TestMethod]
        public void GetTest()
        {
            //Arrange
            DBMaterial materialDb = new DBMaterial();
            int id = 1;
            var expected = new Material();
            expected.id = 1;
            expected.name = "Træ";
            expected.price = 200;

            //Act
            var sucess = materialDb.Get(id);

            //Assert
            Assert.AreEqual(expected.id, sucess.id);
            Assert.AreEqual(expected.name, sucess.name);
            Assert.AreEqual(expected.price, sucess.price);
        }

        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            DBMaterial DbMaterial = new DBMaterial();
            var update = new Material();
            update.id = 2;
            update.name = "Sten";
            update.price = 200;

            //Act
            var sucess = DbMaterial.Update(update);

            //Assert
            Assert.IsTrue(sucess);
        }

        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            DBMaterial material = new DBMaterial();
            int id = 7; //OPS - Sæt ny værdi inden test køres eller bliver intet slettet

            //Act
            var succes = material.Delete(id);

            //Assert
            Assert.AreNotEqual(succes, false);
         
         
        }
    }
}
