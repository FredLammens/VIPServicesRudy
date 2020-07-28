﻿using DomainLibrary.Domain.Limousines;
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

        public IEnumerable<Limousine> GetAllLimousines() 
        {
            return context.Limousines
                .Include(a => a.FixedArrangements)
                .AsNoTracking()
                .AsEnumerable();
        }
        public Limousine GetLimousine(int id) 
        {
            return context.Limousines
                .Include(a => a.FixedArrangements)
                .First(l => l.Id == id);
        }
        public bool inDataBase(Limousine limo) 
        {
            return context.Limousines
                .Any(l => l.Equals(limo));
        }
    }
}
