using DomainLibrary.Domain.Clients;
using System.Collections.Generic;

namespace DomainLibrary.Repositories
{
    public interface IClientRepository
    {
        void AddClient(Client client);
        void AddClients(IList<Client> clients);
        Client GetClient(int ID);
        IEnumerable<Client> GetClients();
        bool inDataBase(Client client);
    }
}
