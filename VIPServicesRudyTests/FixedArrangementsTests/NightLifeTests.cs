using DomainLibrary.Domain.Limousines.FixedArrangements;
using DomainLibrary.Domain.Limousines.Hours;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;

namespace VIPServicesRudyTests
{
    //gepaste messages moeten nog gecontroleerd worden !
    [TestClass]
    public class NightLifeTests
    {
        [TestMethod]
        public void TestWellnessGetHoursInvalidValuePrice()
        {
            //Arrange = initialisatie obejcten/methodes
            NightLife nightlife = new NightLife(null);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 21, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 24, 4, 00, 00);
            int firstHourPrice = 10;
            //Act roept test methode op met ingestelde parameters
            Action act = () => nightlife.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            //Assert verifieert of juist
            act.ShouldThrow<InvalidOperationException>().Message.ShouldBe("Arrangement niet beschikbaar");
        }
        [TestMethod]
        public void TestNightLifeStartDateInRange()
        {
            NightLife nightlife = new NightLife(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 21, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 24, 6, 00, 00);
            int firstHourPrice = 10;
            Action act = () => nightlife.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldNotThrow();
        }
        [TestMethod]
        public void TestNightLifeStartDateToSmall()
        {
            NightLife nightlife = new NightLife(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 18, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 24, 1, 00, 00);
            int firstHourPrice = 10;
            Action act = () => nightlife.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldThrow<ArgumentException>().Message.ShouldBe("Startreservatie moet tussen 20 uur en 0 uur zitten.");
        }
        [TestMethod]
        public void TestNightLifeStartDateToBig()
        {
            NightLife nightlife = new NightLife(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 2, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 9, 00, 00);
            int firstHourPrice = 10;
            Action act = () => nightlife.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldThrow<ArgumentException>().Message.ShouldBe("Startreservatie moet tussen 20 uur en 0 uur zitten.");
        }
        [TestMethod]
        public void TestNightLifeHourspanToSmall()
        {
            NightLife nightlife = new NightLife(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 22, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 24, 2, 00, 00);
            int firstHourPrice = 10;
            Action act = () => nightlife.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldThrow<ArgumentException>().Message.ShouldBe("Tijdsduur moet minstens 7 uur zijn.");
        }
        [TestMethod]
        public void TestNightLifeHourspanToBig()
        {
            NightLife nightlife = new NightLife(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 22, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 24, 11, 00, 00);
            int firstHourPrice = 10;
            Action act = () => nightlife.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldThrow<ArgumentException>().Message.ShouldBe("Tijdsduur kan maximum 11 uur zijn.");
        }

        [TestMethod]
        public void TestNightLifeReturnsCorrectHours()
        {
            NightLife nightlife = new NightLife(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 21, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 24, 6, 00, 00);
            int firstHourPrice = 10;
            List<Hour> hours = nightlife.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            hours[0].Period.ShouldBe(7);
            hours[0].UnitPrice.ShouldBe(100);
            hours[1].Period.ShouldBe(2);
            hours[1].UnitPrice.ShouldBe(15);
        }
    }
}
