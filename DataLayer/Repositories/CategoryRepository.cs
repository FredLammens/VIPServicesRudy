using DomainLibrary.Domain.Clients;
using DomainLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private VIPServicesRudyContext context;
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
            return context.Categories.Single(c => c.Name == name);
        }
    }
}
