using DomainLibrary.Domain.Clients;

using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    public interface IClientRepository
    {
        void AddClient(Client client);
        void AddClients(IList<Client> clients);
        Client GetClient(int ID);
        bool inDataBase(Client client);
    }
}
