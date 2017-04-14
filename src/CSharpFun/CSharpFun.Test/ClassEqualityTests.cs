using System;
using CSharpFun.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFun.Test
{
    [TestClass]
    public class ClassEqualityTests
    {

        [TestMethod]
        public void DefaultOperatorIsNotEqual()
        {
            var car1 = new Car();
            var car2 = new Car();

            Assert.IsFalse(car1 == car2);
        }

        [TestMethod]
        public void DefaultEqualsIsNotEqual()
        {
            var car1 = new Car();
            var car2 = new Car();

            Assert.IsFalse(object.Equals(car1, car2));
        }

        [TestMethod]
        public void DefaultReferenceIsNotEqual()
        {
            var car1 = new Car();
            var car2 = new Car();

            Assert.IsFalse(object.ReferenceEquals(car1, car2));
        }

        [TestMethod]
        public void CustomEqualsOperatorIsNotEqual()
        {
            var p1 = new Person();
            var p2 = new Person();

            //False because we overloaded the Equals, not the operator
            Assert.IsFalse(p1 == p2);
        }

        [TestMethod]
        public void CustomEqualsIsEqual()
        {
            var p1 = new Person();
            var p2 = new Person();

            Assert.IsTrue(object.Equals(p1, p2));
        }

        [TestMethod]
        public void CustomEqualsReferenceIsNotEqual()
        {
            var p1 = new Person();
            var p2 = new Person();

            Assert.IsFalse(object.ReferenceEquals(p1, p2));
        }

    }
}
