using DomainLibrary.Domain.Interfaces;
using DomainLibrary.Domain.Limousines;
using DomainLibrary.Domain.Limousines.HourlyArrangements;
using DomainLibrary.Domain.Reservering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace VIPServicesRudyTests
{
    [TestClass]
    public class ReservationTests
    {
        //reservationdetails
        [TestMethod]
        public void TestReservationDetailsLimousineNotReady() 
        {
            ILimousine limoTest = new Limousine("FIAT 500", 100, new List<IArrangement>() { });
            DateTime reservationDateStart = new DateTime(2012, 01, 23,12,00,00);
            DateTime reservationDateEnd = new DateTime(2012, 01, 23,18,00,00);
            IArrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            ReservationDetails detailsTest = new ReservationDetails(reservationDateStart,reservationDateEnd,Location.Gent,Location.Brussel,limoTest,arrangement);
            DateTime reservationDateStartNext = new DateTime(2012, 01, 23, 20, 00, 00);
            DateTime reservationDateEndNext = new DateTime(2012, 01, 24, 5, 00, 00);
            Action a = () => new ReservationDetails(reservationDateStartNext, reservationDateEndNext, Location.Charleroi, Location.Brussel, limoTest, arrangement);
            a.ShouldThrow<ArgumentException>();
        }
        [TestMethod]
        public void TestReservationDetailsDatesNotHoursOnly() 
        {
            ILimousine limoTest = new Limousine("FIAT 500", 100, new List<IArrangement>() { });
            DateTime reservationDateStart = new DateTime(2012, 01, 23, 12, 15, 00);
            DateTime reservationDateEnd = new DateTime(2012, 01, 23, 18, 00, 00);
            IArrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            Action a = () => new ReservationDetails(reservationDateStart, reservationDateEnd, Location.Gent, Location.Brussel, limoTest, arrangement);
            a.ShouldThrow<ArgumentException>();
        }
        //PriceCalculations
    }
}
