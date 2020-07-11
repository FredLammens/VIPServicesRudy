using DomainLibrary.Domain.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Interfaces
{
    public interface ICategorie
    {
        public SortedList<int, float> StaffDiscount { get; }
        public CategorieType Name { get; }
    }
}
