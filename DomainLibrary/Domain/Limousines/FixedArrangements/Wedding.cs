
using DomainLibrary.Domain.Limousines.Hours;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Limousines.FixedArrangements
{
    public class Wedding : Arrangement
    {
        public override int? Price { get; set; }
        static readonly int hourTerm = 7;
        static readonly int maxTerm = 11;
        static readonly TimeSpan startTime = new TimeSpan(7, 0, 0);
        static readonly TimeSpan endTime = new TimeSpan(15, 0, 0);

        public Wedding(int? price)
        {
            Price = price;
        }
        public Wedding() { }

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
            if (period < hourTerm)
                throw new ArgumentException($"Hourspan needs to be at least {hourTerm} hours");
            if (period > maxTerm)
                throw new ArgumentException($"Hourspan can be maximum {maxTerm} hours");
            //initialize hours 
            List<Hour> hours = new List<Hour>();
            //calculate periods
            if (period == hourTerm)
            {
                hours.Add(new Hour(HourType.VastePrijs,period, (int)Price));
            }
            else
            {
                hours.Add(new Hour(HourType.VastePrijs, hourTerm, (int)Price)); //regular hours
                hours.Add(new Hour(HourType.TweedeUur,period - hourTerm, firstHourPrice)); //overtime
            }
            return hours;
        }
    }
}
