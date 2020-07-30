
using DomainLibrary.Domain.Clients;
using DomainLibrary.Domain.Reservering;
using System;
using System.Collections.Generic;

namespace DomainLibrary.Repositories
{
    public interface IReservationRepository
    {
        void AddReservering(Reservation reservation);
        bool InDatabase(Reservation reservation);
        IEnumerable<Reservation> GetReservations(DateTime startDate);
        IEnumerable<Reservation> GetReservations(Client client);
        IEnumerable<Reservation> GetReservations();
    }
}
