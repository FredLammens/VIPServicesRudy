using DomainLibrary.Domain.Interfaces;
using DomainLibrary.Domain.Limousines.Hours;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Limousines.FixedArrangements
{
    public class NightLife : IArrangement
    {
        public int? Price { get; }
        static readonly int hourTerm = 7;
        static readonly int maxTerm = 11;
        static readonly TimeSpan startTime = new TimeSpan(20, 0, 0);
        static readonly TimeSpan endTime = new TimeSpan(24, 0, 0);

        public NightLife(int? price)
        {
            Price = price;
        }

        public List<IHour> GetHours(DateTime reservationDateStart, DateTime reservationDateEnd, int firstHourPrice)
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
            List<IHour> hours = new List<IHour>();
            //calculate periods
            if (period == hourTerm)
            {
                hours.Add(new VastePrijs(period, (int)Price));
            }
            else
            {
                hours.Add(new VastePrijs(hourTerm, (int)Price)); //regular hours
                hours.Add(new NachtUur(period - hourTerm, firstHourPrice)); //overtime
            }
            return hours;
        }
    }
}
