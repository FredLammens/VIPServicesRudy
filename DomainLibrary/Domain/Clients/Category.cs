﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLibrary.Domain.Clients
{
    public class Category
    {
        public SortedList<int, float> StaffDiscount { get; }

        [Key]
        public CategorieType Name { get; set; }

        public Category(SortedList<int, float> staffDiscount, CategorieType name)
        {
            StaffDiscount = staffDiscount;
            Name = name;
        }
        public Category() { }
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