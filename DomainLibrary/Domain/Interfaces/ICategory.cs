using DomainLibrary.Domain.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Interfaces
{
    public interface ICategory
    {
        public SortedList<int, float> StaffDiscount { get; }
        public CategorieType Name { get; }
    }
}
