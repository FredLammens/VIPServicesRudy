using DomainLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Limousines.Hours
{
    public class NachtUur : IHour
    {
        public int Period { get; }
        public int UnitPrice { get; }
        public static float nightHourPercentage = 1.40f;
        public static TimeSpan nightHourStart = new TimeSpan(22, 00, 00);
        public static TimeSpan nightHourEnd = new TimeSpan(06, 00, 00);//7u not included so 6

        public NachtUur(int period, int unitPrice)
        {
            Period = period;
            UnitPrice = HelperMethods.RoundtoFive(unitPrice * nightHourPercentage);
        }
    }
}
