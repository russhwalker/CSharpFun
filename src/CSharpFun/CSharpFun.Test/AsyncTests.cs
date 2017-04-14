using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using CSharpFun.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFun.Test
{
    [TestClass]
    public class AsyncTests
    {

        [TestMethod]
        public void SyncCallsDelayed()
        {
            var repo = new VehicleRepository();

            var stopWatch = Stopwatch.StartNew();

            var vehicles1 = repo.GetLongRunningVehicles(1000);
            var vehicles2 = repo.GetLongRunningVehicles(2000);
            var vehicles3 = repo.GetLongRunningVehicles(1000);

            stopWatch.Stop();

            //Sync calls should wait on each other to complete, total should be over 4 seconds
            Console.WriteLine(stopWatch.ElapsedMilliseconds);
            Assert.IsTrue(stopWatch.ElapsedMilliseconds >= 4000);
        }

        [TestMethod]
        public void AsyncCallsDelayed()
        {
            var repo = new VehicleRepository();

            var stopWatch = Stopwatch.StartNew();

            var vehiclesTask1 = repo.GetLongRunningVehiclesAsync(1000);
            var vehiclesTask2 = repo.GetLongRunningVehiclesAsync(2000);
            var vehiclesTask3 = repo.GetLongRunningVehiclesAsync(1000);
            var vehiclesTask4 = repo.GetLongRunningVehiclesAsync(1000);
            var vehiclesTask5 = repo.GetLongRunningVehiclesAsync(1000);

            var vehicles1 = vehiclesTask1.Result;
            var vehicles2 = vehiclesTask2.Result;
            var vehicles3 = vehiclesTask3.Result;
            var vehicles4 = vehiclesTask4.Result;
            var vehicles5 = vehiclesTask5.Result;

            stopWatch.Stop();

            //Longest task was 2 seconds, all of these should complete in right over 2 seconds
            Console.WriteLine(stopWatch.ElapsedMilliseconds);
            Assert.IsTrue(stopWatch.ElapsedMilliseconds >= 2000 && stopWatch.ElapsedMilliseconds < 2100);
        }

        [TestMethod]
        public void AsyncCallsDelayedWithWaitAll()
        {
            var repo = new VehicleRepository();

            var stopWatch = Stopwatch.StartNew();

            var vehiclesTask1 = repo.GetLongRunningVehiclesAsync(1000);
            var vehiclesTask2 = repo.GetLongRunningVehiclesAsync(2000);
            var vehiclesTask3 = repo.GetLongRunningVehiclesAsync(1000);
            var vehiclesTask4 = repo.GetLongRunningVehiclesAsync(1000);
            var vehiclesTask5 = repo.GetLongRunningVehiclesAsync(1000);

            Task.WaitAll(vehiclesTask1, vehiclesTask2, vehiclesTask3, vehiclesTask4, vehiclesTask5);

            stopWatch.Stop();

            //Longest task was 2 seconds, all of these should complete in right over 2 seconds
            Console.WriteLine(stopWatch.ElapsedMilliseconds);
            Assert.IsTrue(stopWatch.ElapsedMilliseconds >= 2000 && stopWatch.ElapsedMilliseconds < 2100);
        }

        //[TestMethod]
        //public void AsyncCallsCancelationToken()
        //{
        //    var repo = new VehicleRepository();

        //    var cancellationTokenSource = new CancellationTokenSource();

        //    var stopWatch = Stopwatch.StartNew();

        //    var vehiclesTask1 = repo.GetLongRunningVehiclesAsync(1000, cancellationTokenSource.Token);
        //    var vehiclesTask2 = repo.GetLongRunningVehiclesAsync(2000, cancellationTokenSource.Token);
        //    var vehiclesTask3 = repo.GetLongRunningVehiclesAsync(1000, cancellationTokenSource.Token);
        //    var vehiclesTask4 = repo.GetLongRunningVehiclesAsync(1000, cancellationTokenSource.Token);
        //    var vehiclesTask5 = repo.GetLongRunningVehiclesAsync(1000, cancellationTokenSource.Token);

        //    Task.WaitAll(vehiclesTask1, vehiclesTask2, vehiclesTask3, vehiclesTask4, vehiclesTask5);

        //    stopWatch.Stop();

        //    //Longest task was 2 seconds, all of these should complete in right over 2 seconds
        //    Console.WriteLine(stopWatch.ElapsedMilliseconds);
        //    Assert.IsTrue(stopWatch.ElapsedMilliseconds >= 2000 && stopWatch.ElapsedMilliseconds < 2100);
        //}

    }
}
