
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DomainLibrary.Domain.Clients
{
    public class Category
    {
        //[NotMapped]
        //public SortedList<int, float> StaffDiscount { get; }
        public List<Discount> StaffDiscount { get; private set; }

        [Key]
        public CategorieType Name { get; set; }

        public Category(List<Discount> staffDiscount, CategorieType name)
        {         
            StaffDiscount = staffDiscount.OrderBy(x => x.Aantal).ToList();
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
