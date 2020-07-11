using DomainLibrary.Domain.Reservering;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain.Interfaces
{
    public interface IClient
    {
        public int ClientNumber { get; } // EF autogenerate
        public string Name { get; }
        public string VATNumber { get; }
        public string Adres { get; }
        public ICategorie Categorie { get; }
        public List<Reservation> Reservations { get; set; }
    }
}
