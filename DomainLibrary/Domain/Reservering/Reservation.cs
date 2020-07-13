using DomainLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Reservering
{
    public class Reservation
    {
        public DateTime ReservationDate { get; } = DateTime.Now;
        public int Number { get; } // met EF autogenerate
        public string Adres { get; }
        public IClient Client { get; }
        public ReservationDetails Details { get; }
        public PriceCalculation PriceCalculation { get; }
        public Reservation(string adres, IClient client, ReservationDetails details)
        {
            Details = details;
            PriceCalculation = new PriceCalculation(Details.Arrangement, Details.Limousine, Client, Details.ReservationDateStart, Details.ReservationDateEnd);
            Adres = adres;
            Client = client;
            Client.Reservations.Add(this);
        }
    }
}
