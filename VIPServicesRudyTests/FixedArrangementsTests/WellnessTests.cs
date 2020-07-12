﻿using DomainLibrary.Domain.Interfaces;
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
    public class WellnessTests
    {
        //GetPriceTests
        //GetHoursTests
        [TestMethod]
        public void TestWellnessGetHoursInvalidValuePrice()
        {
            //Arrange = initialisatie obejcten/methodes
            Wellness wellness = new Wellness(null);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 7, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 17, 00, 00);
            int firstHourPrice = 10;
            //Act roept test methode op met ingestelde parameters
            Action act = () => wellness.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            //Assert verifieert of juist
            act.ShouldThrow<InvalidOperationException>();
        }
        [TestMethod]
        public void TestWellnessGetHoursStartDateInRange()
        {
            Wellness wellness = new Wellness(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 11, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 21, 00, 00);
            int firstHourPrice = 10;
            Action act = () => wellness.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldNotThrow();
        }
        [TestMethod]
        public void TestWellnessGetHoursStartDateToSmall()
        {
            Wellness wellness = new Wellness(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 6, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 23, 00, 00);
            int firstHourPrice = 10;
            Action act = () => wellness.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldThrow<ArgumentException>();
        }
        [TestMethod]
        public void TestWellnessGetHoursStartDateToBig()
        {
            Wellness wellness = new Wellness(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 13, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 23, 00, 00);
            int firstHourPrice = 10;
            Action act = () => wellness.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldThrow<ArgumentException>();
        }
        [TestMethod]
        public void TestWellnessGetHoursHourspanToLong()
        {
            Wellness wellness = new Wellness(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 8, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 20, 00, 00);
            int firstHourPrice = 10;
            Action act = () => wellness.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldThrow<ArgumentException>();
        }
        [TestMethod]
        public void TestWellnessGetHoursHourspanToShort()
        {
            Wellness wellness = new Wellness(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 8, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 10, 00, 00);
            int firstHourPrice = 10;
            Action act = () => wellness.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            act.ShouldThrow<ArgumentException>();
        }
        [TestMethod]
        public void TestWellnessGetHoursReturnsCorrectHours()
        {
            Wellness wellness = new Wellness(100);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 8, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 18, 00, 00);
            int firstHourPrice = 10;
            List<IHour> hoursTest = wellness.GetHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            hoursTest[0].Period.ShouldBe(10);
            hoursTest[0].UnitPrice.ShouldBe(100);
        }
    }
}