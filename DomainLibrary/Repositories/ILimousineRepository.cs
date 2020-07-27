
using DomainLibrary.Domain.Limousines;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    public interface ILimousineRepository
    {
        void AddLimousine(Limousine limousine);
        void RemoveLimousine(int Id);
        IEnumerable<Limousine> GetAllLimousines();
    }
}
