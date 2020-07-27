using DomainLibrary.Domain.Limousines;
using DomainLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class LimousineRepository : ILimousineRepository
    {
        private VIPServicesRudyContext context;
        public LimousineRepository(VIPServicesRudyContext context)
        {
            this.context = context;
        }

        public void AddLimousine(Limousine limousine)
        {
            context.Limousines.Add(limousine);
        }
        public void AddLimousines(IList<Limousine> limousines) 
        {
            context.Limousines.AddRange(limousines);
        }

        public void RemoveLimousine(int id)
        {
            context.Limousines.Remove(new Limousine() { Id = id });
        }
        public IEnumerable<Limousine> GetAllLimousines() 
        {
            return context.Limousines
                .Include(a => a.FixedArrangements)
                .AsNoTracking()
                .AsEnumerable();
        }
    }
}
