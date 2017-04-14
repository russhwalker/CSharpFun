using System;
using CSharpFun.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFun.Test
{
    [TestClass]
    public class StructEqualityTests
    {

        [TestMethod]
        public void DefaultEqualityIsEqual1()
        {
            var d1 = new OtherTypes.Dog();
            var d2 = new OtherTypes.Dog();

            Assert.IsTrue(object.Equals(d1, d2));
        }

        [TestMethod]
        public void DefaultEqualityIsEqual2()
        {
            var d1 = new OtherTypes.Dog
            {
                Id = 1,
                Name = "John"
            };
            var d2 = new OtherTypes.Dog
            {
                Id = 1,
                Name = "John"
            };

            Assert.IsTrue(object.Equals(d1, d2));
        }

        [TestMethod]
        public void DefaultEqualityIsNotEqual()
        {
            var d1 = new OtherTypes.Dog
            {
                Id = 1,
                Name = "John"
            };
            var d2 = new OtherTypes.Dog
            {
                Id = 2,
                Name = "John"
            };

            Assert.IsFalse(object.Equals(d1, d2));
        }

    }
}
