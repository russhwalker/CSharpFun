using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFun.Base.Store;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFun.Test
{
    [TestClass]
    public class LinqTests
    {

        //private Tuple<List<Customer>, List<Order>> GetCustomersAndOrders()
        //{
        //    var customers = new List<Customer>();
        //    var orders = new List<Order>();

        //    var random = new Random();

        //    for (var i = 1; i < 10; i++)
        //    {
        //        customers.Add(new Customer
        //        {
        //            CustomerId = i,
        //            FirstName = $"John{i}",
        //            LastName = $"Doe{i}"
        //        });

        //        var orderCount = random.Next(1, 6);
        //        for (var j = 1; j < orderCount; j++)
        //        {
        //            orders.Add(new Order
        //            {
        //                CustomerId = i,
        //                OrderId = int.Parse($"{i}{j}"),
        //                OrderDate = new DateTime(2000, 1, j)
        //            });
        //        }
        //    }

        //    return Tuple.Create(customers, orders);
        //}

        private IEnumerable<Customer> GetCustomers(int count)
        {
            for (var i = 1; i <= count; i++)
            {
                yield return new Customer
                {
                    CustomerId = i,
                    FirstName = $"John{i}",
                    LastName = $"Doe{i}"
                };
            }
        }

        private IEnumerable<CustomerAddress> GetCustomerAddresses(int count)
        {
            for (var i = 1; i <= count; i++)
            {
                if (i % 3 == 0)
                {
                    continue;
                }
                yield return new CustomerAddress
                {
                    CustomerId = i,
                    Address = $"{i} Main Street"
                };
            }
        }

        [TestMethod]
        public void LinqJoin1()
        {
            var customers = GetCustomers(100);
            var addresses = GetCustomerAddresses(100);

            var q = from c in customers
                join a in addresses on c.CustomerId equals a.CustomerId
                select new
                {
                    CustomerId = c.CustomerId,
                    Address = a.Address
                };

        }

    }
}
