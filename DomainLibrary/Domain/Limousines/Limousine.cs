using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainLibrary.Domain.Limousines
{
    public class Limousine
    {
        [Key]
        public int Id { get; set; }//added for db
        public string Name { get; }
        public int FirstHourPrice { get; }
        public List<Arrangement> FixedArrangements { get; }
        public DateTime LastReservation { get; set; }

        public Limousine(string name, int firstHourPrice, List<Arrangement> fixedArrangements)
        {
            Name = name;
            FirstHourPrice = firstHourPrice;
            FixedArrangements = fixedArrangements;
        }
        public Limousine()
        {

        }

        public bool IsReservable(DateTime reservationDateStart)
        {
            if ((reservationDateStart - LastReservation).Hours < 6)
                return false;
            else
                return true;
        }
        public override bool Equals(object obj)
        {
            return obj is Limousine limousine &&
                   Id == limousine.Id &&
                   Name == limousine.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }

    }
}
