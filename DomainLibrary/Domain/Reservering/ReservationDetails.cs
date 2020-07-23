
using DomainLibrary.Domain.Limousines;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Reservering
{
    public class ReservationDetails
    {
        public DateTime ReservationDateStart { get; }
        public DateTime ReservationDateEnd { get; }
        public Location StartLocation { get; }
        public Location ArrivalLocation { get; }
        public Limousine Limousine { get; }
        public Arrangement Arrangement { get; }

        public ReservationDetails(DateTime reservationDateStart, DateTime reservationDateEnd, Location startLocation, Location arrivalLocation, Limousine limousine, Arrangement arrangement)
        {
            if (!limousine.IsReservable(reservationDateStart))
                throw new ArgumentException("Between 2 reservations needs to be at least 6 hours of difference");
            if (reservationDateStart.Minute > 0 || reservationDateEnd.Minute > 0)
                throw new ArgumentException("reservationdates need to be hours only");
            ReservationDateStart = reservationDateStart;
            ReservationDateEnd = reservationDateEnd;
            StartLocation = startLocation;
            ArrivalLocation = arrivalLocation;
            limousine.LastReservation = reservationDateEnd;
            Limousine = limousine;
            Arrangement = arrangement;
        }
    }
}
