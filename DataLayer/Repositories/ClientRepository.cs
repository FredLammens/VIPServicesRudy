using DomainLibrary.Domain.Clients;
using DomainLibrary.Repositories;
using System.Collections;
using System.Collections.Generic;

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
        public void RemoveClient(int clientNumber)
        {
            context.Clients.Remove(new Client() { ClientNumber = clientNumber });
        }
    }
}
