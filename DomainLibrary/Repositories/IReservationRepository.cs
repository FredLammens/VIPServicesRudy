
using DomainLibrary.Domain.Reservering;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    public interface IReservationRepository
    {
        void AddReservering(Reservation reservation);
        void RemoveReservering(int number);
    }
}
