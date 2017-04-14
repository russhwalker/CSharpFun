using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFun.Test
{
    [TestClass]
    public class ParallelTests
    {

        [TestMethod]
        public void SequentialVsParallelTest()
        {
            Action<int> waitAndWrite = (i) =>
            {
                Thread.Sleep(100);
                Console.WriteLine($"action executed: {i}");
            };

            var stopWatch = Stopwatch.StartNew();
            for (var i = 0; i < 10; i++)
            {
                waitAndWrite(i);
            }
            stopWatch.Stop();
            var timeSequential = stopWatch.ElapsedMilliseconds;
            Console.WriteLine(timeSequential);

            stopWatch.Restart();
            Parallel.For(0, 10, i =>
            {
                waitAndWrite(i);
            });

            stopWatch.Stop();
            var timeParallel = stopWatch.ElapsedMilliseconds;
            Console.WriteLine(timeParallel);

            Assert.IsTrue(timeSequential > timeParallel);
        }

    }
}
