using DomainLibrary.Domain.Interfaces;
using DomainLibrary.Domain.Limousines.Hours;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Limousines.HourlyArrangements
{
    public class HourlyArrangement : IArrangement
    {   //kan ook abstract zijn en met klassen die deze dan implementeren maar enkel 2 en identiek hetzelfde. mss moet dit nog voor continuiteitsredenen
        //herbekijken raar geworden met firsthourprice
        public HourlyArrangementType Type { get; }

        readonly List<IHour> hours;
        static readonly int maxTerm = 11;

        public int? Price
        {
            get
            {
                int subtotal = 0;
                foreach (IHour hour in hours)
                {
                    subtotal += (hour.UnitPrice * hour.Period);
                }
                return subtotal;
            }
        }

        public HourlyArrangement(int firstHourPrice, HourlyArrangementType type, DateTime reservationDateStart, DateTime reservationDateEnd)//reservationstart en eind weg => toevoegen aan limo moet kunnen
        {
            Type = type;
            hours = CalculateHours(reservationDateStart, reservationDateEnd, firstHourPrice);
        }

        public List<IHour> GetHours(DateTime reservationDateStart, DateTime reservationDateEnd, int firstHourPrice)
        {
            return hours;
        }
        private List<IHour> CalculateHours(DateTime reservationDateStart, DateTime reservationDateEnd, int firstHourPrice)
        {
            List<IHour> hours = new List<IHour>();
            int period = (reservationDateEnd - reservationDateStart).Hours;
            if (period < 1)
                throw new ArgumentException("period between reservationdates must be at least 1 hour");
            if (period > maxTerm)
                throw new ArgumentException($"Hourspan can be maximum {maxTerm} hours");
            //split period in correct times
            int dayPeriod = 0;
            int nightPeriod = 0;
            if (reservationDateStart.Hour < (NachtUur.nightHourStart.Hours) && reservationDateEnd.Hour > (NachtUur.nightHourEnd.Hours)) // check allebij ervoor 
            {
                if ((reservationDateStart.Hour == 20 && reservationDateEnd.Hour == 7) || (reservationDateStart.Hour == 21 && reservationDateEnd.Hour == 8) || (reservationDateStart.Hour == 21 && reservationDateEnd.Hour == 7)) //hardcoded kan beter ?
                {
                    dayPeriod = (NachtUur.nightHourStart.Hours - reservationDateStart.Hour)
                              + (reservationDateEnd.Hour - NachtUur.nightHourEnd.Hours);
                    nightPeriod = period - dayPeriod;
                }
                else //normal hours
                    dayPeriod = period;
            }
            else if (HelperMethods.TimeInRange(reservationDateStart, NachtUur.nightHourStart, NachtUur.nightHourEnd) && HelperMethods.TimeInRange(reservationDateEnd, NachtUur.nightHourStart, NachtUur.nightHourEnd)) //beide er in 
            {
                nightPeriod = period;
            }
            else if (HelperMethods.TimeInRange(reservationDateEnd, NachtUur.nightHourStart, NachtUur.nightHourEnd)) //einduur er in 
            {
                //start tot eindNAcht = nachturen
                dayPeriod = NachtUur.nightHourStart.Hours - reservationDateStart.Hour;
                nightPeriod = period - dayPeriod;
            }
            else if (HelperMethods.TimeInRange(reservationDateStart, NachtUur.nightHourStart, NachtUur.nightHourEnd)) // startuur er in 
            {
                dayPeriod = reservationDateEnd.Hour - NachtUur.nightHourEnd.Hours;
                nightPeriod = period - dayPeriod;
            }
            //-----------------------------------------------------------------------------------------
            if (dayPeriod > 0)
            {
                if (dayPeriod == 1)
                    hours.Add(new EersteUur(1, firstHourPrice));
                else
                {
                    hours.Add(new EersteUur(1, firstHourPrice));
                    hours.Add(new TweedeUur(dayPeriod - 1, firstHourPrice));
                }
            }
            if (nightPeriod > 0)
            {
                hours.Add(new NachtUur(nightPeriod, firstHourPrice));
            }
            return hours;
        }
    }
    public enum HourlyArrangementType
    {
        Business,
        Airport
    }
}
