using System;
using CSharpFun.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFun.Test
{
    [TestClass]
    public class TypeTests
    {

        [TestMethod]
        public void GetTypeTest()
        {
            var car = new Car();
            var t = car.GetType();

            Assert.AreEqual("Car", t.Name);
            Assert.AreEqual("CSharpFun.Base", t.Namespace);
            Assert.AreEqual("CSharpFun.Base.Car", t.FullName);
            Assert.AreEqual("CSharpFun.Base.Vehicle", t.BaseType.FullName);
        }

        [TestMethod]
        public void TypeOf()
        {
            var t = typeof(Car);

            Assert.AreEqual("Car", t.Name);
            Assert.AreEqual("CSharpFun.Base", t.Namespace);
            Assert.AreEqual("CSharpFun.Base.Car", t.FullName);
            Assert.AreEqual("CSharpFun.Base.Vehicle", t.BaseType.FullName);
        }
        
    }
}
