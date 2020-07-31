using DomainLibrary.Domain.Clients;
using DomainLibrary.Domain.Limousines;
using DomainLibrary.Domain.Limousines.Hours;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DomainLibrary.Domain.Reservering
{
    public class PriceCalculation
    {
        [Key]
        public int Id { get; private set; }
        public List<Hour> Hours { get; private set; }
        public int Subtotal { get; private set; }
        private readonly float vatPercentage = 0.06f;
        public Decimal ChargedDiscounts { get; private set; }
        public Decimal TotalExclusiveVAT { get; private set; }
        public Decimal VATAmount { get; private set; }
        public Decimal Total { get; private set; }
        public PriceCalculation(Arrangement arrangement, Limousine limo, Client client, DateTime reservationDateStart, DateTime reservationDateEnd)
        {
            Hours = arrangement.GetHours(reservationDateStart, reservationDateEnd, limo.FirstHourPrice);
            Subtotal = (int)arrangement.Price;
            ChargedDiscounts = CalculateChargedDiscounts(Subtotal, client);
            TotalExclusiveVAT = Subtotal - ChargedDiscounts;
            VATAmount = TotalExclusiveVAT * (Decimal)vatPercentage;
            Total = TotalExclusiveVAT + VATAmount;
        }
        public PriceCalculation() { }
        private Decimal CalculateChargedDiscounts(int subtotal, Client client) // eventueel herbekijken Sortedlist nogo EF
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
                List<int> keys = client.Categorie.StaffDiscount.Select(x => x.Aantal).ToList();
                int key = keys.OrderByDescending(x => x).Where(x => x <= amountLoaned).FirstOrDefault();
                if (key == 0)
                    return 0;
                else
                    return (decimal)(subtotal * client.Categorie.StaffDiscount.Where(x => x.Aantal == key).FirstOrDefault().Korting);
            }
        }

        public override string ToString()
        {
            string hours = "uren: \n";
            foreach (Hour hour in Hours)
            {
                hours += $"uur: {hour.HourType} duratie: {hour.Period} eenheidsprijs: {hour.UnitPrice}\n";
            }
            return $"PriceCalculation:\n{hours}\nSubtotaal: {Subtotal}\nKorting: {ChargedDiscounts}\nTotaal exclusief BTW: {TotalExclusiveVAT}\nBTW: {VATAmount}\nTotaal: {Total}\n";
        }
    }
}
