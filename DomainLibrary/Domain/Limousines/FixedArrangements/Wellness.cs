
using DomainLibrary.Domain.Limousines.Hours;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Limousines.FixedArrangements
{
    public class Wellness : Arrangement
    {
        public override int? Price { get; set; }
        static readonly int hourTerm = 10;
        static readonly TimeSpan startTime = new TimeSpan(7, 0, 0);
        static readonly TimeSpan endTime = new TimeSpan(12, 0, 0);

        public Wellness(int? price)
        {
            Price = price;
        }
        public Wellness()
        {

        }

        public override List<Hour> GetHours(DateTime reservationDateStart, DateTime reservationDateEnd, int firstHourPrice)
        {
            //check if price is not null
            if (!Price.HasValue)
                throw new InvalidOperationException("arrangement not available");
            //check if in between right hours
            if (!HelperMethods.TimeInRange(reservationDateStart, startTime, endTime))
                throw new ArgumentException($"startReservationdate must be between {startTime} and {endTime}");
            //check if reservation is in hourterm
            int period = (reservationDateEnd - reservationDateStart).Hours;
            if (period != hourTerm)
                throw new ArgumentException($"Hourspan needs to be {hourTerm} hours");
            //return hours
            return new List<Hour>() { new Hour(HourType.VastePrijs, period, (int)Price) };
        }
    }
}
