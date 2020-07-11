using DomainLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Limousines.Hours
{
    public class OverUur : IHour
    {
        public int Period { get; }
        public int UnitPrice { get; }
        public static float restHourPercentage = 0.65f;

        public OverUur(int period, int unitPrice)
        {
            Period = period;
            UnitPrice = HelperMethods.RoundtoFive(unitPrice * restHourPercentage);
        }
    }
}
