
using DomainLibrary.Domain.Reservering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLibrary.Domain.Clients
{
    public class Client
    {
        [Key]
        public int ClientNumber { get; set; }
        public string Name { get; private set; } //naam en achternaam 
        public string VATNumber { get; private set; }
        public string Adres { get; private set; }
        public Category Categorie { get; private set; }

        //reservaties bijhouden 
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public Client(string name, string VATNumber, string adres, Category categorie)
        {
            Name = name;
            this.VATNumber = VATNumber;
            Adres = adres;
            Categorie = categorie;
        }
        public Client() { }

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   Name == client.Name &&
                   VATNumber == client.VATNumber &&
                   Adres == client.Adres;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, VATNumber, Adres);
        }

        public override string ToString()
        {
            return $"Client: {Name} \nAdres: {Adres} \nBTWnummer: {VATNumber} \nCategorie: {Categorie.Name}";
        }
    }
}
