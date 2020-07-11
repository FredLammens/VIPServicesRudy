using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Interfaces
{
    public interface IArrangement
    {
        List<IHour> GetHours(DateTime ReservationDateStart, DateTime ReservationDateEndint, int FirstHourPrice);
        public int? Price { get; }
    }
}
