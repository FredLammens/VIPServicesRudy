using DomainLibrary;
using DomainLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private VIPServicesRudyContext context;

        public ICategoryRepository Categories { get; private set; }
        public IClientRepository Clients { get; private set; }
        public ILimousineRepository Limousines { get; private set; }
        public IReservationRepository Reservations { get; private set; }
        public UnitOfWork(VIPServicesRudyContext context)
        {
            this.context = context;
            Categories = new 
        }
    }
}
