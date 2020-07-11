using DomainLibrary.Domain.Interfaces;
using DomainLibrary.Domain.Limousines.FixedArrangements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace VIPServicesRudyTests.FixedArrangementsTests
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
            act.ShouldThrow<InvalidOperationException>();
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
            act.ShouldThrow<ArgumentException>();
        }
        [TestMethod]
        public void TestWeddingGetHoursStartDateToBig()
        {
            Wedding wedding = new Wedding(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 17, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 00, 00, 00);
            int firstHourPrice = 10;
            Action act = () => wedding.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldThrow<ArgumentException>();
        }
        [TestMethod]
        public void TestWeddingGetHoursHourspanToSmall()
        {
            Wedding wedding = new Wedding(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 9, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 14, 00, 00);
            int firstHourPrice = 10;
            Action act = () => wedding.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldThrow<ArgumentException>();
        }
        [TestMethod]
        public void TestWeddingGetHoursspanToBig()
        {
            Wedding wedding = new Wedding(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 9, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 21, 00, 00);
            int firstHourPrice = 10;
            Action act = () => wedding.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldThrow<ArgumentException>();
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
            List<IHour> hours = wedding.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            hours[0].Period.ShouldBe(7);
            hours[0].UnitPrice.ShouldBe(100);
            hours[1].Period.ShouldBe(3);
            hours[1].UnitPrice.ShouldBe(eenheidsprijsTweedeUur);
        }
    }
}
