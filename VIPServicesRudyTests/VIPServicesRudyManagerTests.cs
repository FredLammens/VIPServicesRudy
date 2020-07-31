using DataLayer;
using DomainLibrary.Domain;
using DomainLibrary.Domain.Clients;
using DomainLibrary.Domain.Limousines;
using DomainLibrary.Domain.Limousines.FixedArrangements;
using DomainLibrary.Domain.Limousines.HourlyArrangements;
using DomainLibrary.Domain.Reservering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VIPServicesRudyTests
{
    [TestClass]
    public class VIPServicesRudyManagerTests
    {
        [TestMethod]
        public void TestRudyManagerAddClient()
        {
            UnitOfWork uow = new UnitOfWork(new VIPServicesRudyTestContext(false));
            VIPServicesRudyManager m = new VIPServicesRudyManager(uow);
            Parser.InitTestDatabase(uow);
            Client clientTest = new Client("Tom", "684432685", "Jef De Belderlaan 6", uow.Categories.GetCategory(CategorieType.vip));
            m.AddClient(clientTest);
            uow.Clients.inDataBase(clientTest).ShouldBeTrue();
        }

        [TestMethod]
        public void TestRudyManagerAddClientAlreadyInDatabase()
        {
            UnitOfWork uow = new UnitOfWork(new VIPServicesRudyTestContext(true));
            VIPServicesRudyManager m = new VIPServicesRudyManager(uow);
            Client clientTest = uow.Clients.GetClient(1);
            Action act = () => m.AddClient(clientTest);
            act.ShouldThrow<ArgumentException>().Message.ShouldBe("Client zit al in de databank.");
        }
        [TestMethod]
        public void TestRudyManagerAddLimousine()
        {
            UnitOfWork uow = new UnitOfWork(new VIPServicesRudyTestContext(true));
            VIPServicesRudyManager m = new VIPServicesRudyManager(uow);
            Limousine limo = new Limousine("RickRolled", 200, new List<Arrangement>() { new NightLife(200), new Wedding(100), new Wellness(20) });
            m.AddLimousine(limo);
            uow.Limousines.inDataBase(limo).ShouldBeTrue();
        }
        [TestMethod]
        public void TestRudyManagerAddLimousineAlreadyInDatabase() 
        {
            UnitOfWork uow = new UnitOfWork(new VIPServicesRudyTestContext(true));
            VIPServicesRudyManager m = new VIPServicesRudyManager(uow);
            Limousine limo = uow.Limousines.GetLimousine(2);
            Action act = () =>  m.AddLimousine(limo);
            act.ShouldThrow<ArgumentException>().Message.ShouldBe("Limousine zit al in database.");
        }
        [TestMethod]
        public void TestRudyManagerAddLimousineWithHourlyArrangements()
        {
            UnitOfWork uow = new UnitOfWork(new VIPServicesRudyTestContext(true));
            VIPServicesRudyManager m = new VIPServicesRudyManager(uow);
            Limousine limo = new Limousine("trol", 200, new List<Arrangement>() { new HourlyArrangement(200,HourlyArrangementType.Airport,DateTime.Now,DateTime.Now.AddHours(5)), new Wedding(100), new Wellness(20) });
            Action act = () => m.AddLimousine(limo);
            act.ShouldThrow<ArgumentException>().Message.ShouldBe("Limousine mag enkel vasteArrangementen hebben.");
        }
        [TestMethod]
        public void TestRudyManagerAddLimousineOneArrangement() 
        {
            UnitOfWork uow = new UnitOfWork(new VIPServicesRudyTestContext(true));
            VIPServicesRudyManager m = new VIPServicesRudyManager(uow);
            Limousine limo = new Limousine("trol", 200, new List<Arrangement>() { new HourlyArrangement(200, HourlyArrangementType.Airport, DateTime.Now, DateTime.Now.AddHours(5)) });
            Action act = () => m.AddLimousine(limo);
            act.ShouldThrow<ArgumentException>().Message.ShouldBe("Limousine moet 3 vaste arrangementen hebben.");
        }
        [TestMethod]
        public void TestRudyManagerGetAllLimousine() 
        {
            UnitOfWork uow = new UnitOfWork(new VIPServicesRudyTestContext(true));
            VIPServicesRudyManager m = new VIPServicesRudyManager(uow);
            List<Limousine> limos = m.GetAllLimousine().ToList();
            limos.Count.ShouldBe(21);
        }
        [TestMethod]
        public void TestRudyManagerAddReservation()
        {
            UnitOfWork uow = new UnitOfWork(new VIPServicesRudyTestContext(true));
            VIPServicesRudyManager m = new VIPServicesRudyManager(uow);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 15, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 18, 00, 00);
            Limousine limoTest = uow.Limousines.GetLimousine(2);
            Client clientTest = uow.Clients.GetClient(2);
            Arrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            Reservation test = new Reservation("Kerkstraat 45", clientTest, new ReservationDetails(reservationDateStart, reservationDateEnd, Location.Gent, Location.Brussel, limoTest, arrangement));
            m.AddReservation(test);
            uow.Reservations.InDatabase(test).ShouldBeTrue();
        }
        [TestMethod]
        public void TestRudyManagerAddReservationClientNotInDatabase()
        {
            UnitOfWork uow = new UnitOfWork(new VIPServicesRudyTestContext(true));
            VIPServicesRudyManager m = new VIPServicesRudyManager(uow);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 15, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 18, 00, 00);
            Limousine limoTest = uow.Limousines.GetLimousine(2);
            Client clientTest = new Client("Kek", "684432685", "Jef De Belderlaan 6", uow.Categories.GetCategory(CategorieType.huwelijksplanner));
            Arrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            Reservation test = new Reservation("Kerkstraat 45", clientTest, new ReservationDetails(reservationDateStart.AddDays(1), reservationDateEnd.AddDays(1), Location.Gent, Location.Brussel, limoTest, arrangement));
            Action act = () => m.AddReservation(test);
            act.ShouldThrow<ArgumentException>().Message.ShouldBe("Client zit nog niet in databank gelieve client eerst toe te voegen.");
        }
        [TestMethod]
        public void TestRudyManagerAddReservationLimousineNotInDatabase()
        {
            UnitOfWork uow = new UnitOfWork(new VIPServicesRudyTestContext(true));
            VIPServicesRudyManager m = new VIPServicesRudyManager(uow);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 15, 00, 00);
            DateTime reservationDateEnd = new DateTime(2020, 01, 23, 18, 00, 00);
            Limousine limoTest = new Limousine("FIAT 500", 100, new List<Arrangement>() { });
            Client clientTest = uow.Clients.GetClient(3);
            Arrangement arrangement = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            Reservation test = new Reservation("Kerkstraat 45", clientTest, new ReservationDetails(reservationDateStart, reservationDateEnd, Location.Gent, Location.Brussel, limoTest, arrangement));
            Action act = () => m.AddReservation(test);
            act.ShouldThrow<ArgumentException>().Message.ShouldBe("Limousine zit nog niet in databank gelieve Limousine eerst toe te voegen.");
        }
        [TestMethod]
        public void TestRudyManagerGetReservationswithClient() 
        {
            UnitOfWork uow = new UnitOfWork(new VIPServicesRudyTestContext(true));
            VIPServicesRudyManager m = new VIPServicesRudyManager(uow);
            Client clientTest = uow.Clients.GetClient(2);
            m.getReservationsClient(clientTest).Count().ShouldBe(1);
        }
        [TestMethod]
        public void TestRudyManagerGetReservationswithStartDate() 
        {
            UnitOfWork uow = new UnitOfWork(new VIPServicesRudyTestContext(true));
            VIPServicesRudyManager m = new VIPServicesRudyManager(uow);
            DateTime reservationDateStart = new DateTime(2020, 01, 23, 15, 00, 00);
            m.getReservationsDate(reservationDateStart).Count().ShouldBe(1);
        }
        [TestMethod]
        public void TestRudyManagerGetClientsWithName() 
        {
            UnitOfWork uow = new UnitOfWork(new VIPServicesRudyTestContext(true));
            VIPServicesRudyManager m = new VIPServicesRudyManager(uow);
            List<Client> test = m.GetClientsWithName("Het Witte Paard").ToList();
            test.Count.ShouldBe(1);
        }
        [TestMethod]
        public void TestRudyManagerGetClientsWithAdres() 
        {
            UnitOfWork uow = new UnitOfWork(new VIPServicesRudyTestContext(true));
            VIPServicesRudyManager m = new VIPServicesRudyManager(uow);
            List<Client> test = m.GetClientsWithAdres("Vluchtweg 18 - Lievegem").ToList();
            test.Count.ShouldBe(1);
        }
        [TestMethod]
        public void TestRudyManagerGetClientsWithVAT() 
        {
            UnitOfWork uow = new UnitOfWork(new VIPServicesRudyTestContext(true));
            VIPServicesRudyManager m = new VIPServicesRudyManager(uow);
            List<Client> test = m.GetClientsWithVAT("BE8765432019").ToList();
            test.Count.ShouldBe(1);
        }
    }
}
