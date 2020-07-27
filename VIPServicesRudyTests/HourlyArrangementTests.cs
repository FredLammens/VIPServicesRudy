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
        public void TestGetPriceEndHoursNighthours()
        {
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 21, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 24, 4, 00, 00);
            HourlyArrangement hourlyArrangement = new HourlyArrangement(10, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            //6 nachturen = 15 , 1 daguur = 10
            hourlyArrangement.Price.ShouldBe(100);
        }
        [TestMethod]
        public void TestGetPriceStartHoursNightHours() 
        {
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 23, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 24, 8, 00, 00);
            HourlyArrangement hourlyArrangement = new HourlyArrangement(10, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            //7 nachturen =15 , 2 daguur = 10
            hourlyArrangement.Price.ShouldBe(120);
        }
        [TestMethod]
        public void TestGetPriceStartDayNightHoursEndDayNightHours() 
        {
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 21, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 24, 7, 00, 00);
            HourlyArrangement hourlyArrangement = new HourlyArrangement(10, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            //8 nachturen =15 2 daguren = 10 + 6.5
            hourlyArrangement.Price.ShouldBe(135);
        }
        [TestMethod]
        public void TestGetPriceOnlyNightHours() 
        {
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 23, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 24, 6, 00, 00);
            HourlyArrangement hourlyArrangement = new HourlyArrangement(10, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            //7 nachturen =15
            hourlyArrangement.Price.ShouldBe(105);
        }
        [TestMethod]
        public void TestGetPriceOnlyDayHours() 
        {
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 9, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 24, 12, 00, 00);
            HourlyArrangement hourlyArrangement = new HourlyArrangement(10, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            //3 daguren 
            hourlyArrangement.Price.ShouldBe(20);
        }

        //CalculateHoursTests

        [TestMethod]
        public void TestCalculateHoursSameDates() 
        {
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 9, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 9, 00, 00);
            Action a = () => new HourlyArrangement(10, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            a.ShouldThrow<ArgumentException>().Message.ShouldBe("Tijdsduur moet minstens 1 uur zijn.");
        }
        [TestMethod]
        public void TestCalculateHoursHourspanToBig() 
        {
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 01, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 13, 00, 00);
            Action a = () => new HourlyArrangement(10, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            a.ShouldThrow<ArgumentException>().Message.ShouldBe("Tijsduur kan maximum 11 uur zijn.");
        }
    }
}
