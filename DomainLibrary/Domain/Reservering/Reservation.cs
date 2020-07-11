using DomainLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Reservering
{
    public class Reservation
    {
        public DateTime ReservationDate { get; }
        public int Number { get; } // met EF autogenerate
        public string Adres { get; }
        public IClient Client { get; }
        public ReservationDetails Details { get; }
        public PriceCalculation PriceCalculation { get; }
        public Reservation(DateTime reservationDate, string adres, IClient client, ReservationDetails details)
        {
            ReservationDate = reservationDate;
            Adres = adres;
            Client = client;
            client.Reservations.Add(this);
            Details = details;
            PriceCalculation = new PriceCalculation(Details.Arrangement, details.Limousine, Client, details.ReservationDateStart, details.ReservationDateEnd);
        }
    }
}
