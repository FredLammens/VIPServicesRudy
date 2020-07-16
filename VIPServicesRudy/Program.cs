using DomainLibrary.Domain.Client;
using DomainLibrary.Domain.Interfaces;
using DomainLibrary.Domain.Limousines;
using DomainLibrary.Domain.Limousines.FixedArrangements;
using DomainLibrary.Domain.Limousines.HourlyArrangements;
using DomainLibrary.Domain.Reservering;
using System;
using System.Collections.Generic;

namespace VIPServicesRudy
{
    class Program
    {
        static void Main(string[] args)
        {
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Categorie VIP = new Categorie(new SortedList<int, float>() { { 2, 0.05f } }, CategorieType.vip);
            //Client client = new Client("Lammens frederic", "20665650", "Jef De Belderlaan 7", VIP);
            //NightLife arrangement = new NightLife(1500);
            //HourlyArrangement testarrangement = new HourlyArrangement(210, HourlyArrangementType.Airport, new DateTime(2012, 01, 23, 20, 00, 00), new DateTime(2012, 01, 24, 04, 00, 00));
            //Limousine limo = new Limousine("witte volvo", 310, new List<IArrangement>() { new NightLife(1500) });
            //ReservationDetails details = new ReservationDetails(new DateTime(2012, 01, 23, 20, 00, 00), new DateTime(2012, 01, 24, 04, 00, 00), Location.Brussel, Location.Gent, limo, arrangement);
            //Reservation test = new Reservation("Jef De Belderlaan 7", client, details);
            ////--------------------------------------------------------------------------------------------------------------------------------------------------------------
            //DateTime reservationDateStart = new DateTime(2012, 01, 23, 15, 00, 00);
            //DateTime reservationDateEnd = new DateTime(2012, 01, 23, 18, 00, 00);
            //IArrangement arrangementje = new HourlyArrangement(100, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
            //ILimousine limoTest = new Limousine("FIAT 500", 100, new List<IArrangement>() { });
            //ICategorie categorieTestVIP = new Categorie(new SortedList<int, float>() { { 2, 0.05f }, { 7, 0.075f }, { 15, 0.1f } }, CategorieType.vip);
            //IClient clientTest = new Client("Tom", "684432685", "Jef De Belderlaan 6", categorieTestVIP);
            //ReservationDetails detailsTest = new ReservationDetails(reservationDateStart, reservationDateEnd, Location.Gent, Location.Brussel, limoTest, arrangementje);
            //Reservation test2 = new Reservation("bla", clientTest, detailsTest);
            //------------------------------------TestChargedDiscounts------------------------------------------------------------------------------------------------------
            //SortedSet<int> ss = new SortedSet<int>() { 5, 8, 10, 20 };
            //int i = 5;
            //int findHighestBelow = ss.OrderByDescending(x => x).Where(x => x <= i).FirstOrDefault();
            //Console.WriteLine(findHighestBelow);
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        }
    }
}
