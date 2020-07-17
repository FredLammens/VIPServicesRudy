using DomainLibrary.Domain.Interfaces;
using DomainLibrary.Domain.Reservering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLibrary.Domain.Client
{
    public class Client : IClient
    {
        [Key]
        public int ClientNumber { get; set; }
        public string Name { get; }
        public string VATNumber { get; }
        public string Adres { get; }
        public ICategory Categorie { get; }

        //reservaties bijhouden 
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public Client(string name, string VATNumber, string adres, ICategory categorie)
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
