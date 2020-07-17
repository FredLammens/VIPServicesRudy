using DomainLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(ICategory categorie);
        void RemoveCategory(ICategory categorie);
    }
}
