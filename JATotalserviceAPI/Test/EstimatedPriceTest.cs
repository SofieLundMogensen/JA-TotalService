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
    public class EstimatedPriceTest
    {
        [TestMethod]
        public void CreateTest()
        {
            //Arrange
            DBEstimatedPrice estimatedPrice = new DBEstimatedPrice();
            var create = new EstimatedPrice();
            //create.Id = 666;
            create.estimatedTime = 60;
            create.materials = null;

            //Act
            var sucess = estimatedPrice.Create(create);

            //Assert
            Assert.AreNotEqual(-1, sucess);
        }

        [TestMethod]
        public void GetTest()
        {
            //Arrange
            DBEstimatedPrice estimatedPrice = new DBEstimatedPrice();
            int id = 666;
            var expected = new EstimatedPrice();
            expected.Id = 666;
            expected.estimatedTime = 60;
            expected.materials = null;

            //Act
            var sucess = estimatedPrice.Get(id);

            //Assert
            Assert.AreEqual(expected.Id, sucess.Id);
            Assert.AreEqual(expected.estimatedTime, sucess.estimatedTime);
            Assert.AreEqual(expected.materials, sucess.materials);
        }

        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            DBEstimatedPrice estimatedPrice = new DBEstimatedPrice();
            var update = new EstimatedPrice();
            update.Id = 666;
            update.estimatedTime = 60;
            update.materials = null;

            //Act
            var sucess = estimatedPrice.Update(update);

            //Assert
            Assert.IsTrue(sucess);
        }

        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            DBEstimatedPrice estimatedPrice = new DBEstimatedPrice();
            int id = 666;

            //Act
            estimatedPrice.Delete(id);
            var sucess = estimatedPrice.Get(id);

            //Assert
            Assert.AreEqual(sucess.Id, 0);
            Assert.AreEqual(sucess.estimatedTime, 0);
            Assert.AreEqual(sucess.materials, null);
        }
    }
}
