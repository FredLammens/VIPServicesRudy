using DomainLibrary.Domain.Reservering;
using DomainLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private VIPServicesRudyContext context;
        public ReservationRepository(VIPServicesRudyContext context)
        {
            this.context = context;
        }

        public void AddReservering(Reservation reservation)
        {
            context.Reservations.Add(reservation);
        }

        public void RemoveReservering(int number)
        {
            context.Reservations.Remove(new Reservation() { Number = number});
        }
    }
}
