﻿
using DomainLibrary.Domain.Limousines.Hours;
using System;
using System.Collections.Generic;

namespace DomainLibrary.Domain.Limousines.HourlyArrangements
{
    public class HourlyArrangement : Arrangement
    {
        public HourlyArrangementType Type { get; }

        public List<Hour> Hours { get; private set; }
        static readonly int maxTerm = 11;

        public override int? Price { get; set; }

        public HourlyArrangement(int firstHourPrice, HourlyArrangementType type, DateTime reservationDateStart, DateTime reservationDateEnd)
        {
            Type = type;
            Hours = CalculateHours(reservationDateStart, reservationDateEnd, firstHourPrice);
            int subtotal = 0;
            foreach (Hour hour in Hours)
            {
                subtotal += (hour.UnitPrice * hour.Period);
            }
            Price = subtotal;

        }
        public HourlyArrangement() { }

        public override List<Hour> GetHours(DateTime reservationDateStart, DateTime reservationDateEnd, int firstHourPrice)
        {
            return Hours;
        }
        private List<Hour> CalculateHours(DateTime reservationDateStart, DateTime reservationDateEnd, int firstHourPrice)
        {
            List<Hour> hours = new List<Hour>();
            int period = (int)(reservationDateEnd - reservationDateStart).TotalHours;
            if (period < 1)
                throw new ArgumentException("Tijdsduur moet minstens 1 uur zijn.");
            if (period > maxTerm)
                throw new ArgumentException($"Tijsduur kan maximum {maxTerm} uur zijn.");
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
                hours.Add(new Hour(HourType.NachtUur, nightPeriod, firstHourPrice));
            }
            return hours;
        }

        public override string ToString()
        {
            return $"{Type}";
        }
    }
    public enum HourlyArrangementType
    {
        Business,
        Airport
    }
}
