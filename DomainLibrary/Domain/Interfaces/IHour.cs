using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Interfaces
{
    public interface IHour
    {
        public int Period { get; }
        public int UnitPrice { get; }
    }
}
