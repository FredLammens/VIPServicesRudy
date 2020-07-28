using DomainLibrary.Domain.Clients;
using DomainLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        public void AddClients(IList<Client> clients) 
        {
            context.Clients.AddRange(clients);
        }

        public Client GetClient(int number)
        {
            return context.Clients
                .First(c => c.ClientNumber == number);
        }
        public bool inDataBase(Client client) 
        {
            return context.Clients.Any(c => c.Equals(client));
        }
    }
}
