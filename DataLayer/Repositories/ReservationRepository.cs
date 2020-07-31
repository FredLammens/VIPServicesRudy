using DomainLibrary.Domain.Clients;
using DomainLibrary.Domain.Reservering;
using DomainLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly VIPServicesRudyContext context;
        public ReservationRepository(VIPServicesRudyContext context)
        {
            this.context = context;
        }

        public void AddReservering(Reservation reservation)
        {
            context.Reservations.Add(reservation);
        }
        public bool InDatabase(Reservation reservation)
        {
            return context.Reservations.Any(r => r.Equals(reservation));
        }
        //resservatie opzoeken op klant/datum 
        public IEnumerable<Reservation> GetReservations(Client client)
        {
            return context.Reservations
                .Include(r => r.Client)
                .Include(r => r.Details)
                .Include(r => r.PriceCalculation)
                .Where(r => r.Client.Equals(client));
        }
        public IEnumerable<Reservation> GetReservations(DateTime startDate)
        {
            return context.Reservations
                .Include(r => r.Client)
                .Include(r => r.Details)
                .Include(r => r.PriceCalculation)
                .Where(r => r.Details.ReservationDateStart == startDate);
        }

        public IEnumerable<Reservation> GetReservations()
        {
            return context.Reservations
                .Include(r => r.Client)
                .Include(r => r.Details)
                .Include(r => r.PriceCalculation)
                .AsEnumerable();
        }
    }
}
