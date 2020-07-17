using DomainLibrary;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private VIPServicesRudyContext context;
        public UnitOfWork(VIPServicesRudyContext context)
        {
            this.context = context;
            
        }
    }
}
