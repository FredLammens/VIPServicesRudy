using DomainLibrary.Domain.Limousines.Hours;
using System;
using System.Collections.Generic;

namespace DomainLibrary.Domain.Limousines.FixedArrangements
{
    public class NightLife : Arrangement
    {
        public override int? Price { get; set; }
        static readonly int hourTerm = 7;
        static readonly int maxTerm = 11;
        static readonly TimeSpan startTime = new TimeSpan(20, 0, 0);
        static readonly TimeSpan endTime = new TimeSpan(24, 0, 0);

        public NightLife(int? price)
        {
            Price = price;
        }
        public NightLife() { }

        public override List<Hour> GetHours(DateTime reservationDateStart, DateTime reservationDateEnd, int firstHourPrice)
        {
            //check if price is not null
            if (!Price.HasValue)
                throw new InvalidOperationException("Arrangement niet beschikbaar");
            //check if in between right hours
            if (!HelperMethods.TimeInRange(reservationDateStart, startTime, endTime))
                throw new ArgumentException($"Startreservatie moet tussen {startTime.Hours} uur en {endTime.Hours} uur zitten.");//startReservationdate must be between {startTime} and {endTime}
            //check if reservation is in hourterm
            int period = (reservationDateEnd - reservationDateStart).Hours;
            if (period < hourTerm)
                throw new ArgumentException($"Tijdsduur moet minstens {hourTerm} uur zijn.");
            if (period > maxTerm)
                throw new ArgumentException($"Tijdsduur kan maximum {maxTerm} uur zijn.");
            //initialize hours 
            List<Hour> hours = new List<Hour>();
            //calculate periods
            if (period == hourTerm)
            {
                hours.Add(new Hour(HourType.VastePrijs,period, (int)Price));
            }
            else
            {
                hours.Add(new Hour(HourType.VastePrijs,hourTerm, (int)Price)); //regular hours
                hours.Add(new Hour(HourType.NachtUur,period - hourTerm, firstHourPrice)); //overtime
            }
            return hours;
        }

        public override string ToString()
        {
            return "NightLife";
        }
    }
}
