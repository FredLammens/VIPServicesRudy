using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DomainLibrary.Domain.Limousines
{
    public class Limousine
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; private set; }
        public int FirstHourPrice { get; private set; }
        public List<Arrangement> FixedArrangements { get; private set; }
        public DateTime LastReservation { get; set; }

        public Limousine(string name, int firstHourPrice, List<Arrangement> fixedArrangements)
        {
            Name = name;
            FirstHourPrice = firstHourPrice;
            FixedArrangements = fixedArrangements.OrderByDescending(a => a.GetType().ToString()).ToList();
        }
        public Limousine() { }

        public bool IsReservable(DateTime reservationDateStart)
        {
            if ((reservationDateStart - LastReservation).Hours < 6 && (reservationDateStart - LastReservation).Hours > 0)
                return false;
            else
                return true;
        }

        public override bool Equals(object obj)
        {
            return obj is Limousine limousine &&
                   Name == limousine.Name &&
                   FirstHourPrice == limousine.FirstHourPrice;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, FirstHourPrice);
        }

        public override string ToString()
        {
            return $"Limousine: \nNaam: {Name}\nEersteUurPrijs: {FirstHourPrice}";
        }
    }
}
