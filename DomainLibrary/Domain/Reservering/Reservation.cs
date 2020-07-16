using DomainLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLibrary.Domain.Reservering
{
    public class Reservation
    {
        public DateTime ReservationDate { get; } = DateTime.Now;
        [Key]
        public int Number { get; set; } // met EF autogenerate
        public string Adres { get; }
        public IClient Client { get; }
        public ReservationDetails Details { get; }
        public PriceCalculation PriceCalculation { get; }
        public Reservation(string adres, IClient client, ReservationDetails details)
        {
            PriceCalculation = new PriceCalculation(details.Arrangement, details.Limousine, client, details.ReservationDateStart, details.ReservationDateEnd);
            Details = details;
            Adres = adres;
            Client = client;
            Client.Reservations.Add(this);
        }
    }
}
