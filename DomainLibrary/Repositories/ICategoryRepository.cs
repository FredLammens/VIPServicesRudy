using DomainLibrary.Domain.Clients;
using System.Collections.Generic;

namespace DomainLibrary.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategories(IList<Category> categories);
        Category GetCategory(CategorieType name);
    }
}
