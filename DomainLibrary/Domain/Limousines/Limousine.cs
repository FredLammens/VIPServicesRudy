using DomainLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Limousines
{
    public class Limousine : ILimousine
    {
        public string Name { get; }
        public int FirstHourPrice { get; }
        public List<IArrangement> FixedArrangements { get; }
        public DateTime LastReservation { get; set; }

        public Limousine(string name, int firstHourPrice, List<IArrangement> fixedArrangements)
        {
            Name = name;
            FirstHourPrice = firstHourPrice;
            FixedArrangements = fixedArrangements;
        }

        public bool IsReservable(DateTime reservationDateStart)
        {
            if ((reservationDateStart - LastReservation).Hours < 6)
                return false;
            else
                return true;
        }
    }
}
