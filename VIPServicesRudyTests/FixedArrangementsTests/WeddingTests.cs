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
    public class WeddingTests
    {
        //Wedding
        [TestMethod]
        public void TestWeddingGetHoursInvalidValuesPrice()
        {
            //Arrange = initialisatie obejcten/methodes
            Wedding wedding = new Wedding(null);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 8, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 18, 00, 00);
            int firstHourPrice = 10;
            //Act roept test methode op met ingestelde parameters
            Action act = () => wedding.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            //Assert verifieert of juist
            act.ShouldThrow<InvalidOperationException>().Message.ShouldBe("Arrangement niet beschikbaar");
        }
        [TestMethod]
        public void TestWeddingGetHoursStartDateInRange()
        {
            Wedding wedding = new Wedding(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 9, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 16, 00, 00);
            int firstHourPrice = 10;
            Action act = () => wedding.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldNotThrow();
        }
        [TestMethod]
        public void TestWeddingGetHoursStartDateToSmall()
        {
            Wedding wedding = new Wedding(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 6, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 13, 00, 00);
            int firstHourPrice = 10;
            Action act = () => wedding.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldThrow<ArgumentException>().Message.ShouldBe("Startreservatie moet tussen 7 uur en 15 uur zitten.");
        }
        [TestMethod]
        public void TestWeddingGetHoursStartDateToBig()
        {
            Wedding wedding = new Wedding(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 17, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 00, 00, 00);
            int firstHourPrice = 10;
            Action act = () => wedding.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldThrow<ArgumentException>().Message.ShouldBe("Startreservatie moet tussen 7 uur en 15 uur zitten."); ;
        }
        [TestMethod]
        public void TestWeddingGetHoursHourspanToSmall()
        {
            Wedding wedding = new Wedding(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 9, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 14, 00, 00);
            int firstHourPrice = 10;
            Action act = () => wedding.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldThrow<ArgumentException>().Message.ShouldBe("Tijdsduur moet minstens 7 uur zijn.");
        }
        [TestMethod]
        public void TestWeddingGetHoursspanToBig()
        {
            Wedding wedding = new Wedding(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 9, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 21, 00, 00);
            int firstHourPrice = 10;
            Action act = () => wedding.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldThrow<ArgumentException>().Message.ShouldBe("Tijdsduur kan maximum 11 uur zijn.");
        }
        [TestMethod]
        public void TestWeddingGetHoursspanInRange()
        {
            Wedding wedding = new Wedding(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 9, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 17, 00, 00);
            int firstHourPrice = 10;
            Action act = () => wedding.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldNotThrow();
        }
        [TestMethod]
        public void TestWeddingGetHoursReturnsCorrectHours() //moet naar boven of naar beneden afgerond of naar dichtsbijzijndste
        {
            int eenheidsprijsTweedeUur = 5;//(10 *0,65 veelvoud van 5)
            Wedding wedding = new Wedding(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 8, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 18, 00, 00);
            int firstHourPrice = 10;
            List<Hour> hours = wedding.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            hours[0].Period.ShouldBe(7);
            hours[0].UnitPrice.ShouldBe(100);
            hours[1].Period.ShouldBe(3);
            hours[1].UnitPrice.ShouldBe(eenheidsprijsTweedeUur);
        }
    }
}
