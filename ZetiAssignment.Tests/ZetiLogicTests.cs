using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ZetiAssignment.Tests
{
    [TestClass]
    public class ZetiLogicTests
    {
        private ZetiAssignment.MVC.Logic.ZetiLogic Logic;
        public ZetiLogicTests()
        {
            Logic = new MVC.Logic.ZetiLogic();
        }


        [TestMethod]
        public void ResultIsConstantForASetPeriod()
        {
            var FromDate = new DateTime(2021, 02, 01, 00, 00, 00);
            var ToDate = new DateTime(2021, 02, 28, 23, 59, 00);


            var result = Logic.GetBillForPeriod(FromDate, ToDate).Result;

            Assert.AreEqual(2100.4487259167186, result.TotalMileage);
        }

        [TestMethod]
        public void CustomerNameIsEscapedCorrectly()
        {
            var FromDate = new DateTime(2021, 02, 01, 00, 00, 00);
            var ToDate = new DateTime(2021, 02, 28, 23, 59, 00);


            var result = Logic.GetBillForPeriod(FromDate, ToDate).Result;

            Assert.AreEqual("Bob's Taxis", result.Customer);
        }
    }
}
