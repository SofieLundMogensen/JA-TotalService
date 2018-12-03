using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class TaskTest
    {
        [TestClass]
        public class TaskTests
        {

            [TestMethod]
            public void CreateTest()
            {
                //Arrange
                DBTask TaskDB = new DBTask();
                var create = new Task();
                create.description = "lille";
                create.name = "snerydning";
                create.isComplete = true;

                //Act
                var sucess = TaskDB.Create(create);

                //Assert
                Assert.IsTrue(sucess);
            }

            [TestMethod]
            public void GetTest()
            {
                //Arrange
                DBTask TaskDB = new DBTask();
                int id = 1;
                var expected = new Task();
                expected.id = 1;
                expected.name = "Hans";
                expected.isComplete = false;

                //Act
                var sucess = TaskDB.Get(id);

                //Assert
                Assert.AreEqual(expected.id, sucess.id);
                Assert.AreEqual(expected.name, sucess.name);
                Assert.AreEqual(expected.isComplete, sucess.isComplete);
            }

            [TestMethod]
            public void UpdateTest()
            {
                //Arrange
                DBTask TaskDB = new DBTask();
                var update = new Task();
                update.id = 3;
                update.name = "Håndvask";
                update.description = "En hvid en";
                update.isComplete = true;

                //Act
                var sucess = TaskDB.Update(update);

                //Assert
                Assert.IsTrue(sucess);
            }

            [TestMethod]
            public void DeleteTest()
            {
                //Arrange
                DBTask task = new DBTask();
                int id = 5; //OPS - Sæt ny værdi inden test køres eller bliver intet slettet

                //Act
                var succes = task.Delete(id);

                //Assert
                Assert.AreNotEqual(succes, false);


            }
        }

    }
    
}