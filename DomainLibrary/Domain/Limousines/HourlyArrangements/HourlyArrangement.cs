
using DomainLibrary.Domain.Limousines.Hours;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Limousines.HourlyArrangements
{
    public class HourlyArrangement : Arrangement
    {   //kan ook abstract zijn en met klassen die deze dan implementeren maar enkel 2 en identiek hetzelfde. mss moet dit nog voor continuiteitsredenen
        //herbekijken raar geworden met firsthourprice
        public HourlyArrangementType Type { get; }

        readonly List<Hour> hours;
        static readonly int maxTerm = 11;

        public override int? Price
        {
            get
            {
                int subtotal = 0;
                foreach (Hour hour in hours)
                {
                    subtotal += (hour.UnitPrice * hour.Period);
                }
                return subtotal;
            }
            set 
            {
                Price = value;
            }
        }

        public HourlyArrangement(int firstHourPrice, HourlyArrangementType type, DateTime reservationDateStart, DateTime reservationDateEnd)//reservationstart en eind weg => toevoegen aan limo moet kunnen
        {
            Type = type;
            hours = CalculateHours(reservationDateStart, reservationDateEnd, firstHourPrice);
        }
        public HourlyArrangement()
        {

        }

        public override List<Hour> GetHours(DateTime reservationDateStart, DateTime reservationDateEnd, int firstHourPrice)
        {
            return hours;
        }
        private List<Hour> CalculateHours(DateTime reservationDateStart, DateTime reservationDateEnd, int firstHourPrice)
        {
            List<Hour> hours = new List<Hour>();
            int period = (reservationDateEnd - reservationDateStart).Hours;
            if (period < 1)
                throw new ArgumentException("period between reservationdates must be at least 1 hour");
            if (period > maxTerm)
                throw new ArgumentException($"Hourspan can be maximum {maxTerm} hours");
            //split period in correct times
            int dayPeriod = 0;
            int nightPeriod = 0;
            if (reservationDateStart.Hour < (HoursInfo.nightHourStart.Hours) && reservationDateEnd.Hour > (HoursInfo.nightHourEnd.Hours)) // check allebij ervoor 
            {
                if ((reservationDateStart.Hour == 20 && reservationDateEnd.Hour == 7) || (reservationDateStart.Hour == 21 && reservationDateEnd.Hour == 8) || (reservationDateStart.Hour == 21 && reservationDateEnd.Hour == 7)) //hardcoded kan beter ?
                {
                    dayPeriod = (HoursInfo.nightHourStart.Hours - reservationDateStart.Hour)
                              + (reservationDateEnd.Hour - HoursInfo.nightHourEnd.Hours);
                    nightPeriod = period - dayPeriod;
                }
                else //normal hours
                    dayPeriod = period;
            }
            else if (HelperMethods.TimeInRange(reservationDateStart, HoursInfo.nightHourStart, HoursInfo.nightHourEnd) && HelperMethods.TimeInRange(reservationDateEnd, HoursInfo.nightHourStart, HoursInfo.nightHourEnd)) //beide er in 
            {
                nightPeriod = period;
            }
            else if (HelperMethods.TimeInRange(reservationDateEnd, HoursInfo.nightHourStart, HoursInfo.nightHourEnd)) //einduur er in 
            {
                //start tot eindNAcht = nachturen
                dayPeriod = HoursInfo.nightHourStart.Hours - reservationDateStart.Hour;
                nightPeriod = period - dayPeriod;
            }
            else if (HelperMethods.TimeInRange(reservationDateStart, HoursInfo.nightHourStart, HoursInfo.nightHourEnd)) // startuur er in 
            {
                dayPeriod = reservationDateEnd.Hour - HoursInfo.nightHourEnd.Hours;
                nightPeriod = period - dayPeriod;
            }
            //-----------------------------------------------------------------------------------------
            if (dayPeriod > 0)
            {
                if (dayPeriod == 1)
                    hours.Add(new Hour(HourType.EersteUur, 1, firstHourPrice));
                else
                {
                    hours.Add(new Hour(HourType.EersteUur, 1, firstHourPrice));
                    hours.Add(new Hour(HourType.TweedeUur, dayPeriod - 1, firstHourPrice));
                }
            }
            if (nightPeriod > 0)
            {
                hours.Add(new Hour(HourType.NachtUur,nightPeriod, firstHourPrice));
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
