using DomainLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Client
{
    public class Categorie : ICategorie
    {
        public SortedList<int, float> StaffDiscount { get; }
        public CategorieType Name { get; }

        public Categorie(SortedList<int, float> staffDiscount, CategorieType name)
        {
            StaffDiscount = staffDiscount;
            Name = name;
        }
    }
    public enum CategorieType
    {
        particulier,
        organisatie,
        vip,
        concertpromotor,
        huwelijksplanner,
        evenementenbureau
    }
}
