using DomainLibrary.Domain.Clients;
using DomainLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly VIPServicesRudyContext context;
        public CategoryRepository(VIPServicesRudyContext context)
        {
            this.context = context;
        }

        public void AddCategories(IList<Category> categories) 
        {
            context.Categories.AddRange(categories);
        }
        public Category GetCategory(CategorieType name) 
        {
            return context.Categories
                .Include(c => c.StaffDiscount)
                .Single(c => c.Name == name);
        }
    }
}
