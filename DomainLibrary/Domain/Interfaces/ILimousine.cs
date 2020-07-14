using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Interfaces
{
    public interface ILimousine
    {
        public string Name { get; }
        public int FirstHourPrice { get; }
        public List<IArrangement> FixedArrangements { get; }
        public DateTime LastReservation { get; set; }
        public bool IsReservable(DateTime reservationDateStart);
    }
}
