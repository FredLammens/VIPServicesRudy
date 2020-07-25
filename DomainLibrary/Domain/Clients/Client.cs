
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
        public string Name { get; private set; }
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
        public Client()
        {

        }
    }
}
