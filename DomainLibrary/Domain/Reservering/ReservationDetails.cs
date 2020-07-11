using DomainLibrary.Domain.Interfaces;
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
        public ILimousine Limousine { get; }
        public IArrangement Arrangement { get; }

        public ReservationDetails(DateTime reservationDateStart, DateTime reservationDateEnd, Location startLocation, Location arrivalLocation, ILimousine limousine, IArrangement arrangement)
        {
            if (!limousine.IsReservable(reservationDateStart))
                throw new ArgumentException("Between 2 reservations needs to be at least 6 hours of difference");
            if (reservationDateStart.Minute > 0 || reservationDateEnd.Minute > 0)
                throw new ArgumentException("reservationdates need to be hours only");
            ReservationDateStart = reservationDateStart;
            ReservationDateEnd = reservationDateEnd;
            StartLocation = startLocation;
            ArrivalLocation = arrivalLocation;
            Limousine = limousine;
            limousine.LastReservation = reservationDateEnd;
            Arrangement = arrangement;
        }
    }
}
