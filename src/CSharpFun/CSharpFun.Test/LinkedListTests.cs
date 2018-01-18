using System;
using System.Collections.Generic;
using CSharpFun.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CSharpFun.Test
{
    [TestClass]
    public class LinkedListTests
    {

        private class Widget
        {
            public int Id { get; set; }
        }

        [TestMethod]
        public void InsertInLinkedList()
        {
            var widgets = new LinkedList<Widget>();
            for (int i = 1; i < 10; i++)
            {
                widgets.AddLast(new Widget { Id = i });
            }
            Assert.AreEqual(9, widgets.Count);

            var newWidget = new Widget { Id = 999 };
            widgets.AddAfter(widgets.First, newWidget);

            Assert.AreEqual(10, widgets.Count);
            Assert.AreEqual(newWidget, widgets.Skip(1).First());
        }

    }
}