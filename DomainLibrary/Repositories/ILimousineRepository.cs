
using DomainLibrary.Domain.Limousines;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    public interface ILimousineRepository
    {
        void AddLimousine(Limousine limousine);
        void AddLimousines(IList<Limousine> limousines);
        IEnumerable<Limousine> GetAllLimousines();
        bool inDataBase(Limousine limo);
        Limousine GetLimousine(int id);
    }
}
