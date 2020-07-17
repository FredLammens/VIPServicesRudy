using DomainLibrary.Domain.Interfaces;
using DomainLibrary.Domain.Limousines;
using DomainLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void RemoveLimousine(int id)
        {
            context.Limousines.Remove(new Limousine() { Id = id });
        }
    }
}
