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
        public List<IArrangement> Arrangements { get; }
        public DateTime LastReservation { get; set; }

        public Limousine(string name, int firstHourPrice, List<IArrangement> arrangements)
        {
            Name = name;
            FirstHourPrice = firstHourPrice;
            Arrangements = arrangements;
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
