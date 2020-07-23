using DomainLibrary.Domain.Clients;
using DomainLibrary.Repositories;

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
            context.Clients.Remove(new Client() { ClientNumber = clientNumber });
        }
    }
}
