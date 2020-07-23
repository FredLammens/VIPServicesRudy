using DomainLibrary.Domain.Clients;
using DomainLibrary.Repositories;
using System;
using System.Collections.Generic;
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

        public void AddCategory(Category categorie)
        {
            context.Categories.Add(categorie);
        }

        public void RemoveCategory(CategorieType name)
        {
            context.Categories.Remove(new Category() { Name = name });
        }
    }
}
