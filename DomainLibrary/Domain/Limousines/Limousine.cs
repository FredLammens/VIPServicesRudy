using DomainLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLibrary.Domain.Limousines
{
    public class Limousine : ILimousine
    {
        [Key]
        public int Id { get; set; }//added for db
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
    }
}
