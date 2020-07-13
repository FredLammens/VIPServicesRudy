using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Interfaces
{
    public interface IArrangement
    {
        List<IHour> GetHours(DateTime reservationDateStart, DateTime reservationDateEndint, int firstHourPrice);
        public int? Price { get; }
    }
}
