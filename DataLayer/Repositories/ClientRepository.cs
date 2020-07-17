using DomainLibrary.Domain.Client;
using DomainLibrary.Domain.Interfaces;
using DomainLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private VIPServicesRudyContext context;
        public ClientRepository(VIPServicesRudyContext context)
        {
            this.context = context;
        }

        public void AddClient(Client client)
        {
            context.Clients.Add(client);
        }

        public void RemoveClient(int clientNumber)
        {
            throw new NotImplementedException();
        }
    }
}
