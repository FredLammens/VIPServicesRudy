using System;

namespace VIPServicesRudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Categorie VIP = new Categorie(new SortedList<int, float>() { { 2, 0.05f } }, CategorieType.vip);
            Client client = new Client("Lammens frederic", "20665650", "Jef De Belderlaan 7", VIP);
            NightLife arrangement = new NightLife(1500);
            HourlyArrangement testarrangement = new HourlyArrangement(210, HourlyArrangementType.Airport, new DateTime(2012, 01, 23, 20, 00, 00), new DateTime(2012, 01, 24, 04, 00, 00));
            Limousine limo = new Limousine("wit", 310, new List<IArrangement>() { new NightLife(1500) });
            ReservationDetails details = new ReservationDetails(new DateTime(2012, 01, 23, 20, 00, 00), new DateTime(2012, 01, 24, 04, 00, 00), Location.Brussel, Location.Gent, limo, arrangement);
            Reservation test = new Reservation(DateTime.Now, "Jef De Belderlaan 7", client, details);
            Console.WriteLine(test.Adres);
            Console.WriteLine(test.PriceCalculation.Total);
            //------------------------------------TestChargedDiscounts-----------------------------------------
            //SortedSet<int> ss = new SortedSet<int>() { 5, 8, 10, 20 };
            //int i = 5;
            //int findHighestBelow = ss.OrderByDescending(x => x).Where(x => x <= i).FirstOrDefault();
            //Console.WriteLine(findHighestBelow);
            //--------------------------------------------------------------------------------------------------
        }
    }
}
