using DomainLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Limousines.Hours
{
    public class TweedeUur : IHour
    {
        public int Period { get; }
        public int UnitPrice { get; }
        public static float secondHourPercentage = 0.65f;

        public TweedeUur(int period, int unitPrice)
        {
            Period = period;
            UnitPrice = HelperMethods.RoundtoFive(unitPrice * secondHourPercentage);
        }
    }
}
