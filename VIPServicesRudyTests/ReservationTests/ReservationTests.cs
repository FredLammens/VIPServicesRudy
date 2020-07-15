using DomainLibrary.Domain.Client;
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
        [TestMethod]
        public void TestPriceCalculationHours() 
        {
            DateTime reservationDateStart = new DateTime(2012, 01, 23, 15, 00, 00);
            DateTime reservationDateEnd = new DateTime(2012, 01, 23, 18, 00, 00);
            IArrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            ILimousine limoTest = new Limousine("FIAT 500", 100, new List<IArrangement>() { });
            ICategorie categorieTestVIP = new Categorie(new SortedList<int, float>() { {2,0.05f},{7,0.075f},{15,0.1f} },CategorieType.vip);
            IClient clientTest = new Client("Tom", "684432685", "Jef De Belderlaan 6",categorieTestVIP);
            PriceCalculation priceTest = new PriceCalculation(arrangement, limoTest, clientTest, reservationDateStart, reservationDateEnd);
            priceTest.Hours[0].Period.ShouldBe(1);
            priceTest.Hours[1].Period.ShouldBe(2);
            priceTest.Hours[0].UnitPrice.ShouldBe(100);
            priceTest.Hours[1].UnitPrice.ShouldBe(65);
        }
        [TestMethod]
        public void TestPriceCalculationSubtotal() 
        {
            DateTime reservationDateStart = new DateTime(2012, 01, 23, 15, 00, 00);
            DateTime reservationDateEnd = new DateTime(2012, 01, 23, 18, 00, 00);
            IArrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            ILimousine limoTest = new Limousine("FIAT 500", 100, new List<IArrangement>() { });
            ICategorie categorieTestVIP = new Categorie(new SortedList<int, float>() { { 2, 0.05f }, { 7, 0.075f }, { 15, 0.1f } }, CategorieType.vip);
            IClient clientTest = new Client("Tom", "684432685", "Jef De Belderlaan 6", categorieTestVIP);
            PriceCalculation priceTest = new PriceCalculation(arrangement, limoTest, clientTest, reservationDateStart, reservationDateEnd);
            priceTest.Subtotal.ShouldBe(230);
        }
        [TestMethod]
        public void TestPriceCalculationChargedDiscountsNoReservations() 
        {
            DateTime reservationDateStart = new DateTime(2012, 01, 23, 15, 00, 00);
            DateTime reservationDateEnd = new DateTime(2012, 01, 23, 18, 00, 00);
            IArrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            ILimousine limoTest = new Limousine("FIAT 500", 100, new List<IArrangement>() { });
            ICategorie categorieTestVIP = new Categorie(new SortedList<int, float>() { { 2, 0.05f }, { 7, 0.075f }, { 15, 0.1f } }, CategorieType.vip);
            IClient clientTest = new Client("Tom", "684432685", "Jef De Belderlaan 6", categorieTestVIP);
            PriceCalculation priceTest = new PriceCalculation(arrangement, limoTest, clientTest, reservationDateStart, reservationDateEnd);
            priceTest.ChargedDiscounts.ShouldBe(0);
        }
        [TestMethod]
        public void TestPriceCalculationChargedDiscountsNullReservation() 
        {
            DateTime reservationDateStart = new DateTime(2012, 01, 23, 15, 00, 00);
            DateTime reservationDateEnd = new DateTime(2012, 01, 23, 18, 00, 00);
            IArrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            ILimousine limoTest = new Limousine("FIAT 500", 100, new List<IArrangement>() { });
            ICategorie categorieTestVIP = new Categorie(new SortedList<int, float>() { { 2, 0.05f }, { 7, 0.075f }, { 15, 0.1f } }, CategorieType.vip);
            IClient clientTest = new Client("Tom", "684432685", "Jef De Belderlaan 6", categorieTestVIP);
            PriceCalculation priceTest = new PriceCalculation(arrangement, limoTest, clientTest, reservationDateStart, reservationDateEnd);
            priceTest.ChargedDiscounts.ShouldBe(0);
        }
        [TestMethod]
        public void TestPriceCalculationChargedDiscountsOneReservation()
        {
            DateTime reservationDateStart = new DateTime(2012, 01, 23, 15, 00, 00);
            DateTime reservationDateEnd = new DateTime(2012, 01, 23, 18, 00, 00);
            IArrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            ILimousine limoTest = new Limousine("FIAT 500", 100, new List<IArrangement>() { });
            ICategorie categorieTestVIP = new Categorie(new SortedList<int, float>() { { 2, 0.05f }, { 7, 0.075f }, { 15, 0.1f } }, CategorieType.vip);
            IClient clientTest = new Client("Tom", "684432685", "Jef De Belderlaan 6", categorieTestVIP);
            //PriceCalculation priceTest = new PriceCalculation(arrangement, limoTest, clientTest, reservationDateStart, reservationDateEnd);
            //kan geen moq met linq expressies gebruiken 
            ReservationDetails detailsTest = new ReservationDetails(reservationDateStart, reservationDateEnd, Location.Gent, Location.Brussel, limoTest, arrangement);
            Reservation _ = new Reservation("bla", clientTest, detailsTest);
            Reservation test2 = new Reservation("bla", clientTest, detailsTest);
            test2.PriceCalculation.ChargedDiscounts.ShouldBe(0);
        }
        [TestMethod]
        public void TestPriceCalculationChargedDiscountsMiddleAmountReservation()
        {
            DateTime reservationDateStart = new DateTime(2012, 01, 23, 15, 00, 00);
            DateTime reservationDateEnd = new DateTime(2012, 01, 23, 18, 00, 00);
            IArrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            ILimousine limoTest = new Limousine("FIAT 500", 100, new List<IArrangement>() { });
            ICategorie categorieTestVIP = new Categorie(new SortedList<int, float>() { { 2, 0.05f }, { 7, 0.075f }, { 15, 0.1f } }, CategorieType.vip);
            IClient clientTest = new Client("Tom", "684432685", "Jef De Belderlaan 6", categorieTestVIP);
            PriceCalculation priceTest = new PriceCalculation(arrangement, limoTest, clientTest, reservationDateStart, reservationDateEnd);

        }
        [TestMethod]
        public void TestPriceCalculationChargedDiscountsMaxAmountReservation()
        {

        }
    }
}
