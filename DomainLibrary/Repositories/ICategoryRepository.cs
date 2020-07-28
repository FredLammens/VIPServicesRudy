using DomainLibrary.Domain.Clients;

using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    public interface ICategoryRepository
    { 
        void AddCategories(IList<Category> categories);
        Category GetCategory(CategorieType name);
    }
}
