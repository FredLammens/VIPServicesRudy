﻿
using DomainLibrary.Domain.Limousines;
using System;
using System.ComponentModel.DataAnnotations;

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
                throw new ArgumentException("Tussen 2 reservaties moet er minstens 6 uur verschil zijn.");
            if (reservationDateStart.Minute > 0 || reservationDateEnd.Minute > 0)
                throw new ArgumentException("Reservatiedatums mogen enkel uren bevatten.");
            ReservationDateStart = reservationDateStart;
            ReservationDateEnd = reservationDateEnd;
            StartLocation = startLocation;
            ArrivalLocation = arrivalLocation;
            limousine.LastReservation = reservationDateEnd;
            Limousine = limousine;
            Arrangement = arrangement;
        }
        public ReservationDetails() { }

        public override string ToString()
        {
            return $"Startdatum: {ReservationDateStart}\nEinddatum: {ReservationDateEnd}\nStartLocatie: {StartLocation}\nAankomstLocatie: {ArrivalLocation}\nLimousine: {Limousine}\n{Arrangement}";
        }
    }
}
