using DomainLibrary.Domain.Limousines.HourlyArrangements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace VIPServicesRudyTests
{
    [TestClass]
    public class HourlyArrangmentTests
    {
        //getPriceTests
        [TestMethod]
        public void TestGetPrice()
        {
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 21, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 24, 4, 00, 00);
            HourlyArrangement hourlyArrangement = new HourlyArrangement(10, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            //6 nachturen =15 , 1 daguur = 10
            hourlyArrangement.Price.ShouldBe(100);
        }
        //CalculateHoursTests
    }
}
