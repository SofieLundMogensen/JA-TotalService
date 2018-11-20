using System;
using BusinessLogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using ModelLayer;

namespace Test
{
    [TestClass]
    public class TimeRegistrationTestcs
    {

        [TestMethod]
        public void CreateTest()
        {
            //Arrange
            DBTimeRegistration timeRegistrationController = new DBTimeRegistration();
           
            var Create = new TimeRegistartion();
            Create.task = new Task();
            Create.task.id = 1;
            Create.employee = new Employee();
            Create.employee.Id = 1;
            Create.startTime = new DateTime(2018, 12, 19, 12, 27, 12);
            Create.endTime = new DateTime(2018, 12, 19, 22, 27, 12);
            //Act
            var succes = timeRegistrationController.Create(Create);
            //Assert
            Assert.IsTrue(succes);
           
        }

        [TestMethod]
        public void GetTest()
        {
            //Arrange
            DBTimeRegistration timeRegistrationController = new DBTimeRegistration();
            int id = 1;
            var excepted = new TimeRegistartion();
            excepted.Id = 1;
            excepted.startTime = new DateTime(2018, 11, 19, 12, 27, 12);
            excepted.endTime = new DateTime(2018, 11, 19, 22, 27, 12);
            //Act
            var TimeRegistration = timeRegistrationController.Get(id);
            //Assert
            Assert.AreEqual(excepted.Id, TimeRegistration.Id);
            Assert.AreEqual(excepted.startTime, TimeRegistration.startTime);
            Assert.AreEqual(excepted.endTime, TimeRegistration.endTime);
        }
    }
}
