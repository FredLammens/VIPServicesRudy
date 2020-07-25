
using DomainLibrary.Domain.Limousines;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLibrary.Domain.Reservering
{
    public class ReservationDetails
    {
        [Key]
        public int Id { get; private set; }
        public DateTime ReservationDateStart { get; private set; }
        public DateTime ReservationDateEnd { get; private set; }
        public Location StartLocation { get; private set; }
        public Location ArrivalLocation { get; private set; }
        public Limousine Limousine { get; private set; }
        public Arrangement Arrangement { get; private set; }

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
        public ReservationDetails()
        {

        }
    }
}
