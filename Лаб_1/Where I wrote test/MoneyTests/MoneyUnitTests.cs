using lab1;
using System.Diagnostics;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class MoneyUnitTests
    {
        Stopwatch stopWatch = new Stopwatch();

        [TestMethod]

        public void checkCountWaysForDifferentNumbers()
        {
            stopWatch.Start();

            int cash = 0;
            int actualCountWays;
            int expectedCountWays = 0;

            Money moneyManager = new Money(cash);
            actualCountWays = moneyManager.OddMoney();

            Assert.AreEqual(expectedCountWays, actualCountWays);

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve8: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]

        public void checkCountWaysForNegativeMoney()
        {
            stopWatch.Start();

            int cash = -100;

            Money moneyManager = new Money(cash);
            moneyManager.OddMoney();

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve8: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }

        [TestMethod]

        public void checkCountWaysForALotOfMoney()
        {
            stopWatch.Start();

            int cash = 0;
            int actualCountWays;
            int expectedCountWays = 0;

            ///1
            Money moneyManager = new Money(cash);
            actualCountWays = moneyManager.OddMoney();

            Assert.AreEqual(expectedCountWays, actualCountWays);

            ///2
            cash = 1;
            expectedCountWays = 1;
            Money moneyManager2 = new Money(cash);
            actualCountWays = moneyManager2.OddMoney();

            Assert.AreEqual(expectedCountWays, actualCountWays);

            ///3
            cash = 5;
            expectedCountWays = 2;
            Money moneyManager3 = new Money(cash);
            actualCountWays = moneyManager3.OddMoney();

            Assert.AreEqual(expectedCountWays, actualCountWays);

            ///4
            cash = 20;
            expectedCountWays = 9;
            Money moneyManager4 = new Money(cash);
            actualCountWays = moneyManager4.OddMoney();

            Assert.AreEqual(expectedCountWays, actualCountWays);

            stopWatch.Stop();
            System.Console.WriteLine("CorrectResolve8: " + stopWatch.Elapsed);
            stopWatch.Reset();
        }
    }
}
