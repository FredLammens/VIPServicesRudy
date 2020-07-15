using DomainLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLibrary.Domain.Reservering
{
    public class PriceCalculation
    {
        public List<IHour> Hours { get; }
        public int Subtotal { get; }
        private readonly float vatPercentage = 0.06f;
        public Decimal ChargedDiscounts { get; }
        public Decimal TotalExclusiveVAT { get; }
        public Decimal VATAmount { get; }
        public Decimal Total { get; }
        public PriceCalculation(IArrangement arrangement, ILimousine limo, IClient client, DateTime reservationDateStart, DateTime reservationDateEnd)
        {
            Hours = arrangement.GetHours(reservationDateStart, reservationDateEnd, limo.FirstHourPrice);
            Subtotal = (int)arrangement.Price;
            ChargedDiscounts = CalculateChargedDiscounts(Subtotal, client);
            TotalExclusiveVAT = Subtotal - ChargedDiscounts;
            VATAmount = TotalExclusiveVAT * (Decimal)vatPercentage;
            Total = TotalExclusiveVAT + VATAmount;


        }
        private Decimal CalculateChargedDiscounts(int subtotal, IClient client)
        {
            //check if client has made a reservation in the year
            int year = DateTime.Now.Year;
            if (client.Reservations.Count == 0)
                return 0;
            int amountLoaned = client.Reservations.Count(r => r.Details.ReservationDateStart.Year == year);
            //return calculated discount 
            if (client.Categorie.StaffDiscount.Equals(null))
                return 0;
            else
            {
                IList<int> keys = client.Categorie.StaffDiscount.Keys;
                int key = keys.OrderByDescending(x => x).Where(x => x <= amountLoaned).FirstOrDefault();
                if (key == 0)
                    return 0;
                else
                    return (decimal)(subtotal * client.Categorie.StaffDiscount[key]);
            }
        }
    }
}
