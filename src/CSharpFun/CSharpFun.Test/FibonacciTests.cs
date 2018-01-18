using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFun.Test.Other
{
    [TestClass]
    public class FibonacciTests
    {

        private int GetNth(int index)
        {
            var result = 0;
            var previous = 0;
            var current = 1;
            for (var i = 0; i < index; i++)
            {
                result = previous + current;
                previous = current;
                current = result;
            }
            return result;
        }

        [TestMethod]
        public void GetFibonaccis()
        {
            Assert.AreEqual(0, GetNth(0));
            Assert.AreEqual(1, GetNth(1));
            Assert.AreEqual(2, GetNth(2));
            Assert.AreEqual(3, GetNth(3));
            Assert.AreEqual(5, GetNth(4));
            Assert.AreEqual(8, GetNth(5));
        }

    }
}
