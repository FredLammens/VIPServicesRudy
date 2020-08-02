using DomainLibrary.Domain.Clients;
using DomainLibrary.Domain.Limousines;
using DomainLibrary.Domain.Limousines.HourlyArrangements;
using DomainLibrary.Domain.Reservering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;

namespace VIPServicesRudyTests
{
    [TestClass]
    public class ReservationTests
    {
        //reservationdetails
        [TestMethod]
        public void TestReservationDetailsLimousineNotReady()
        {
            Limousine limoTest = new Limousine("FIAT 500", 100, new List<Arrangement>() { });
            DateTime reservationDateStart = new DateTime(2012, 01, 23, 12, 00, 00);
            DateTime reservationDateEnd = new DateTime(2012, 01, 23, 18, 00, 00);
            Arrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            ReservationDetails detailsTest = new ReservationDetails(reservationDateStart, reservationDateEnd, Location.Gent, Location.Brussel, limoTest, arrangement);
            DateTime reservationDateStartNext = new DateTime(2012, 01, 23, 20, 00, 00);
            DateTime reservationDateEndNext = new DateTime(2012, 01, 24, 5, 00, 00);
            Action a = () => new ReservationDetails(reservationDateStartNext, reservationDateEndNext, Location.Charleroi, Location.Brussel, limoTest, arrangement);
            a.ShouldThrow<ArgumentException>().Message.ShouldBe("Tussen 2 reservaties moet er minstens 6 uur verschil zijn.");
        }
        [TestMethod]
        public void TestReservationDetailsDatesNotHoursOnly()
        {
            Limousine limoTest = new Limousine("FIAT 500", 100, new List<Arrangement>() { });
            DateTime reservationDateStart = new DateTime(2012, 01, 23, 12, 15, 00);
            DateTime reservationDateEnd = new DateTime(2012, 01, 23, 18, 00, 00);
            Arrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            Action a = () => new ReservationDetails(reservationDateStart, reservationDateEnd, Location.Gent, Location.Brussel, limoTest, arrangement);
            a.ShouldThrow<ArgumentException>().Message.ShouldBe("Reservatiedatums mogen enkel uren bevatten.");
        }
        //PriceCalculations
        [TestMethod]
        public void TestPriceCalculationHours()
        {
            DateTime reservationDateStart = new DateTime(2012, 01, 23, 15, 00, 00);
            DateTime reservationDateEnd = new DateTime(2012, 01, 23, 18, 00, 00);
            Arrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            Limousine limoTest = new Limousine("FIAT 500", 100, new List<Arrangement>() { });
            List<Discount> vip = new List<Discount>() { new Discount(2, 0.05f), new Discount(7, 0.075f), new Discount(15, 0.1f) };
            Category categorieTestVIP = new Category(vip, CategorieType.vip);
            Client clientTest = new Client("Tom", "684432685", "Jef De Belderlaan 6", categorieTestVIP);
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
            Arrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            Limousine limoTest = new Limousine("FIAT 500", 100, new List<Arrangement>() { });
            List<Discount> vip = new List<Discount>() { new Discount(2, 0.05f), new Discount(7, 0.075f), new Discount(15, 0.1f) };
            Category categorieTestVIP = new Category(vip, CategorieType.vip);
            Client clientTest = new Client("Tom", "684432685", "Jef De Belderlaan 6", categorieTestVIP);
            PriceCalculation priceTest = new PriceCalculation(arrangement, limoTest, clientTest, reservationDateStart, reservationDateEnd);
            priceTest.Subtotal.ShouldBe(230);
        }
        [TestMethod]
        public void TestPriceCalculationChargedDiscountsNoReservations()
        {
            DateTime reservationDateStart = new DateTime(2012, 01, 23, 15, 00, 00);
            DateTime reservationDateEnd = new DateTime(2012, 01, 23, 18, 00, 00);
            Arrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            Limousine limoTest = new Limousine("FIAT 500", 100, new List<Arrangement>() { });
            List<Discount> vip = new List<Discount>() { new Discount(2, 0.05f), new Discount(7, 0.075f), new Discount(15, 0.1f) };
            Category categorieTestVIP = new Category(vip, CategorieType.vip);
            Client clientTest = new Client("Tom", "684432685", "Jef De Belderlaan 6", categorieTestVIP);
            PriceCalculation priceTest = new PriceCalculation(arrangement, limoTest, clientTest, reservationDateStart, reservationDateEnd);
            priceTest.ChargedDiscounts.ShouldBe(0);
        }
        [TestMethod]
        public void TestPriceCalculationChargedDiscountsOneReservation()
        {
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 15, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 18, 00, 00);
            Arrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            Limousine limoTest = new Limousine("FIAT 500", 100, new List<Arrangement>() { });
            List<Discount> vip = new List<Discount>() { new Discount(2, 0.05f), new Discount(7, 0.075f), new Discount(15, 0.1f) };
            Category categorieTestVIP = new Category(vip, CategorieType.vip);
            Client clientTest = new Client("Tom", "684432685", "Jef De Belderlaan 6", categorieTestVIP);
            Reservation test = new Reservation("Kerkstraat 45", clientTest, new ReservationDetails(reservationDateStart, reservationDateEnd, Location.Gent, Location.Brussel, limoTest, arrangement));
            test.PriceCalculation.ChargedDiscounts.ShouldBe(0);
        }
        [TestMethod]
        public void TestPriceCalculationChargedDiscountsMiddleAmountReservation()
        {
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 15, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 18, 00, 00);
            Arrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            Limousine limoTest = new Limousine("FIAT 500", 100, new List<Arrangement>() { });
            List<Discount> vip = new List<Discount>() { new Discount(2, 0.05f), new Discount(7, 0.075f), new Discount(15, 0.1f) };
            Category categorieTestVIP = new Category(vip, CategorieType.vip);
            Client clientTest = new Client("Tom", "684432685", "Jef De Belderlaan 6", categorieTestVIP);
            _ = new Reservation("Kerkstraat 45", clientTest, new ReservationDetails(reservationDateStart, reservationDateEnd, Location.Gent, Location.Brussel, limoTest, arrangement));
            _ = new Reservation("Kerkstraat 45", clientTest, new ReservationDetails(reservationDateStart.AddDays(1), reservationDateEnd.AddDays(1), Location.Gent, Location.Brussel, limoTest, arrangement));
            Reservation test = new Reservation("Kerkstraat 45", clientTest, new ReservationDetails(reservationDateStart.AddDays(2), reservationDateEnd.AddDays(2), Location.Gent, Location.Brussel, limoTest, arrangement));
            test.PriceCalculation.ChargedDiscounts.ShouldBe(11.5m);//5%
        }
        [TestMethod]
        public void TestPriceCalculationChargedDiscountsMaxAmountReservation()
        {
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 15, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 18, 00, 00);
            Arrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            Limousine limoTest = new Limousine("FIAT 500", 100, new List<Arrangement>() { });
            List<Discount> vip = new List<Discount>() { new Discount(2, 0.05f), new Discount(7, 0.075f), new Discount(15, 0.1f) };
            Category categorieTestVIP = new Category(vip, CategorieType.vip);
            Client clientTest = new Client("Tom", "684432685", "Jef De Belderlaan 6", categorieTestVIP);
            _ = new Reservation("Kerkstraat 45", clientTest, new ReservationDetails(reservationDateStart, reservationDateEnd, Location.Gent, Location.Brussel, limoTest, arrangement));
            _ = new Reservation("Kerkstraat 45", clientTest, new ReservationDetails(reservationDateStart.AddDays(1), reservationDateEnd.AddDays(1), Location.Gent, Location.Brussel, limoTest, arrangement));
            _ = new Reservation("Kerkstraat 45", clientTest, new ReservationDetails(reservationDateStart.AddDays(2), reservationDateEnd.AddDays(1), Location.Gent, Location.Brussel, limoTest, arrangement));
            _ = new Reservation("Kerkstraat 45", clientTest, new ReservationDetails(reservationDateStart.AddDays(3), reservationDateEnd.AddDays(1), Location.Gent, Location.Brussel, limoTest, arrangement));
            _ = new Reservation("Kerkstraat 45", clientTest, new ReservationDetails(reservationDateStart.AddDays(4), reservationDateEnd.AddDays(1), Location.Gent, Location.Brussel, limoTest, arrangement));
            _ = new Reservation("Kerkstraat 45", clientTest, new ReservationDetails(reservationDateStart.AddDays(5), reservationDateEnd.AddDays(1), Location.Gent, Location.Brussel, limoTest, arrangement));

            _ = new Reservation("Kerkstraat 45", clientTest, new ReservationDetails(reservationDateStart.AddDays(6), reservationDateEnd.AddDays(1), Location.Gent, Location.Brussel, limoTest, arrangement));
            Reservation test = new Reservation("Kerkstraat 45", clientTest, new ReservationDetails(reservationDateStart.AddDays(7), reservationDateEnd.AddDays(2), Location.Gent, Location.Brussel, limoTest, arrangement));
            test.PriceCalculation.ChargedDiscounts.ShouldBe(17.25m);//7.5%
        }
    }
}
