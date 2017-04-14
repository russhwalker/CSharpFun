using System;
using CSharpFun.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFun.Test
{
    [TestClass]
    public class ReflectionTests
    {

        [TestMethod]
        public void GetProperties()
        {
            var car = new Car
            {
                VehicleId = 999,
                CarMake = "Ford",
                CarModel = "Ranger"
            };
            var t = car.GetType();

            Assert.AreEqual(999, t.GetProperty("VehicleId").GetValue(car, null));
            Assert.AreEqual("Ford", t.GetProperty("CarMake").GetValue(car, null));
            Assert.AreEqual("Ranger", t.GetProperty("CarModel").GetValue(car, null));
            Assert.AreEqual("Ford Ranger", t.GetProperty("FullMakeModel").GetValue(car, null));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetPropertyExpressionBodyException()
        {
            var car = new Car
            {
                VehicleId = 999,
                CarMake = "Ford",
                CarModel = "Ranger"
            };
            var t = car.GetType();
            Assert.AreEqual("Ford Ranger", t.GetProperty("FullMakeModelExprBody").GetValue(car, null));
        }

    }
}
