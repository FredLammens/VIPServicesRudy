
using DomainLibrary.Domain.Limousines;
using System.Collections.Generic;

namespace DomainLibrary.Repositories
{
    public interface ILimousineRepository
    {
       // void AddLimousine(Limousine limousine);
        void AddLimousines(IList<Limousine> limousines);
        IEnumerable<Limousine> GetLimousines();
        bool InDataBase(Limousine limo);
        Limousine GetLimousine(int id);
    }
}
