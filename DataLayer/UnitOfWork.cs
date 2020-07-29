using DataLayer.Repositories;
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
        private readonly VIPServicesRudyContext context;

        public ICategoryRepository Categories { get; private set; }
        public IClientRepository Clients { get; private set; }
        public ILimousineRepository Limousines { get; private set; }
        public IReservationRepository Reservations { get; private set; }
        public UnitOfWork(VIPServicesRudyContext context)
        {
            this.context = context;
            Categories = new CategoryRepository(context);
            Clients = new ClientRepository(context);
            Limousines = new LimousineRepository(context);
            Reservations = new ReservationRepository(context);
        }

        public int Complete()
        {
                return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
