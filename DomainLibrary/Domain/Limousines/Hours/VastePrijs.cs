using DomainLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Limousines.Hours
{
    public class VastePrijs : IHour
    {
        public int Period { get; }
        public int UnitPrice { get; }

        public VastePrijs(int period, int unitPrice)
        {
            Period = period;
            UnitPrice = unitPrice;
        }
    }
}
