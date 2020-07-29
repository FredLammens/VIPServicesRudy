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
        IEnumerable<Client> GetClientsWithName(string name);
        IEnumerable<Client> GetClientsWithVAT(string vatnumber);
        IEnumerable<Client> GetClientsWithAdres(string adres);
        bool inDataBase(Client client);
    }
}
