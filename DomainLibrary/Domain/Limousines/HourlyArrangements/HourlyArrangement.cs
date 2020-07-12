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

        public List<IHour> GetHours(DateTime ReservationDateStart, DateTime ReservationDateEnd, int FirstHourPrice)
        {
            return hours;
        }
        private List<IHour> CalculateHours(DateTime ReservationDateStart, DateTime ReservationDateEnd, int FirstHourPrice)
        {
            List<IHour> hours = new List<IHour>();
            int period = (ReservationDateEnd - ReservationDateStart).Hours;
            if (period < 1)
                throw new ArgumentException("period between reservationdates must be at least 1 hour");
            if (period > maxTerm)
                throw new ArgumentException($"Hourspan can be maximum {maxTerm} hours");
            //split period in correct times
            int dayPeriod = 0;
            int nightPeriod = 0;
            if (ReservationDateStart.Hour < (NachtUur.nightHourStart.Hours) && ReservationDateEnd.Hour > (NachtUur.nightHourEnd.Hours)) // check allebij ervoor 
            {
                if ((ReservationDateStart.Hour == 20 && ReservationDateEnd.Hour == 7) || (ReservationDateStart.Hour == 21 && ReservationDateEnd.Hour == 8) || (ReservationDateStart.Hour == 21 && ReservationDateEnd.Hour == 7)) //hardcoded kan beter ?
                {
                    dayPeriod = (NachtUur.nightHourStart.Hours - ReservationDateStart.Hour)
                              + (ReservationDateEnd.Hour - NachtUur.nightHourEnd.Hours);
                    nightPeriod = period - dayPeriod;
                }
                else //normal hours
                    dayPeriod = period;
            }
            else if (HelperMethods.TimeInRange(ReservationDateStart, NachtUur.nightHourStart, NachtUur.nightHourEnd) && HelperMethods.TimeInRange(ReservationDateEnd, NachtUur.nightHourStart, NachtUur.nightHourEnd)) //beide er in 
            {
                nightPeriod = period;
            }
            else if (HelperMethods.TimeInRange(ReservationDateEnd, NachtUur.nightHourStart, NachtUur.nightHourEnd)) //einduur er in 
            {
                //start tot eindNAcht = nachturen
                dayPeriod = NachtUur.nightHourStart.Hours - ReservationDateStart.Hour;
                nightPeriod = period - dayPeriod;
            }
            else if (HelperMethods.TimeInRange(ReservationDateStart, NachtUur.nightHourStart, NachtUur.nightHourEnd)) // startuur er in 
            {
                dayPeriod = ReservationDateEnd.Hour - NachtUur.nightHourEnd.Hours;
                nightPeriod = period - dayPeriod;
            }
            //-----------------------------------------------------------------------------------------
            if (dayPeriod > 0)
            {
                if (dayPeriod == 1)
                    hours.Add(new EersteUur(1, FirstHourPrice));
                else
                {
                    hours.Add(new EersteUur(1, FirstHourPrice));
                    hours.Add(new TweedeUur(dayPeriod - 1, FirstHourPrice));
                }
            }
            if (nightPeriod > 0)
            {
                hours.Add(new NachtUur(nightPeriod, FirstHourPrice));
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
