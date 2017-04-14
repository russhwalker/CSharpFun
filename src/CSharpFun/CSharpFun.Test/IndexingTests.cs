using System;
using System.Collections.Generic;
using CSharpFun.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFun.Test
{
    [TestClass]
    public class IndexingTests
    {

        [TestMethod]
        public void ValidIndex()
        {
            var vehicles = new List<Vehicle>
            {
                VehicleFactory.Create<Car>(1),
                VehicleFactory.Create<GolfCart>(2),
            };
            var garage = new Garage(vehicles);

            Assert.IsInstanceOfType(garage[0], typeof(Car));
            Assert.IsInstanceOfType(garage[1], typeof(GolfCart));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InValidIndexWithException()
        {
            var vehicles = new List<Vehicle>
            {
                VehicleFactory.Create<Car>(1),
                VehicleFactory.Create<GolfCart>(2),
            };
            var garage = new Garage(vehicles);
            var vehicle = garage[2];
        }

    }
}
