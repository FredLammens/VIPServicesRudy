using DomainLibrary.Domain.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainLibrary.Domain.Reservering
{
    public class Reservation
    {
        public DateTime ReservationDate { get; private set; } = DateTime.Now;
        [Key]
        public int Number { get; set; } // met EF autogenerate
        public string Adres { get; private set; }
        public Client Client { get; private set; }
        public ReservationDetails Details { get; private set; }
        public PriceCalculation PriceCalculation { get; private set; }
        public Reservation(string adres, Client client, ReservationDetails details)
        {
            PriceCalculation = new PriceCalculation(details.Arrangement, details.Limousine, client, details.ReservationDateStart, details.ReservationDateEnd);
            Details = details;
            Adres = adres;
            Client = client;
            Client.Reservations.Add(this);
        }
        public Reservation() { }

        public override bool Equals(object obj)
        {
            return obj is Reservation reservation &&
                   ReservationDate == reservation.ReservationDate &&
                   Adres == reservation.Adres &&
                   EqualityComparer<Client>.Default.Equals(Client, reservation.Client) &&
                   EqualityComparer<ReservationDetails>.Default.Equals(Details, reservation.Details);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ReservationDate, Adres, Client, Details);
        }

        public override string ToString()
        {
            return "Reservatie: \n" +
                "\nClient: \n" +
                "===================================\n" +
                $"{Client}\n" +
                "\nInfo Reservering\n" +
                "===================================\n" +
                $"Adres waar limousine verwacht wordt: {Adres}\n{Details}\n" +
                "\nPrijsCalculatie: " +
                "===================================\n" +
                $"{PriceCalculation}" +
                "===================================\n";
        }
    }
}
