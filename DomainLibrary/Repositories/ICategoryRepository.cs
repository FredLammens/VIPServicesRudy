using DomainLibrary.Domain.Clients;

using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(Category categorie);
        void RemoveCategory(CategorieType name);
    }
}
