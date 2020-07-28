using DomainLibrary.Domain.Reservering;
using DomainLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public bool InDatabase(Reservation reservation) 
        {
           return context.Reservations.Any(r => r.Equals(reservation));
        }
    }
}
