using DomainLibrary.Domain.Clients;
using DomainLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly VIPServicesRudyContext context;
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

        public IEnumerable<Client> GetClientsWithAdres(string adres)
        {
            return context.Clients
                    .Include(c => c.Categorie)
                    .Include(c => c.Reservations)
                    .Where(c => c.Adres == adres);
        }

        public Client GetClient(int number)
        {
            return context.Clients
                .Include(c => c.Categorie)
                .Include(c => c.Reservations)
                .First(c => c.ClientNumber == number);
        }

        public IEnumerable<Client> GetClientsWithName(string name)
        {
            return context.Clients
                    .Include(c => c.Categorie)
                    .Include(c => c.Reservations)
                    .Where(c => c.Name == name);
        }

        public IEnumerable<Client> GetClientsWithVAT(string vatnumber)
        {
            return context.Clients
                    .Include(c => c.Categorie)
                    .Include(c => c.Reservations)
                    .Where(c => c.VATNumber == vatnumber);
        }

        public bool inDataBase(Client client)
        {
            return context.Clients.Any(c => c.Equals(client));
        }

        public IEnumerable<Client> GetClients()
        {
            return context.Clients
                .Include(c => c.Categorie)
                .Include(c => c.Reservations)
                .AsEnumerable();
        }
    }
}
