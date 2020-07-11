using DomainLibrary.Domain.Interfaces;
using DomainLibrary.Domain.Reservering;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Client
{
    public class Client : IClient
    {
        public int ClientNumber { get; }
        public string Name { get; }
        public string VATNumber { get; }
        public string Adres { get; }
        public ICategorie Categorie { get; }

        //reservaties bijhouden 
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public Client(string name, string VATNumber, string adres, ICategorie categorie)
        {
            Name = name;
            this.VATNumber = VATNumber;
            Adres = adres;
            Categorie = categorie;
        }
    }
}
