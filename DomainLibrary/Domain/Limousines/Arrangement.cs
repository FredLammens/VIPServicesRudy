using DomainLibrary.Domain.Limousines.Hours;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLibrary.Domain.Limousines
{
    public abstract class Arrangement
    {
        public abstract List<Hour> GetHours(DateTime reservationDateStart, DateTime reservationDateEndint, int firstHourPrice);
        public abstract int? Price { get; set; }
        [Key]
        public int Id { get; set; }

    }
}
