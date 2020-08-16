using DomainLibrary.Domain.Clients;
using DomainLibrary.Domain.Limousines;
using DomainLibrary.Domain.Reservering;
using System;
using System.Collections.Generic;

namespace DomainLibrary.Domain
{
    public class VIPServicesRudyManager
    {
        private readonly IUnitOfWork uow;

        public VIPServicesRudyManager(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // -> al verwerkt in toevoegen reservatie
        //public void AddClient(Client client)
        //{
        //    uow.Clients.AddClient(client);
        //}
        //public void AddLimousine(Limousine limo)
        //{
        //    uow.Limousines.AddLimousine(limo);
        //}

        public void AddReservation(Reservation reservation)
        {
            //check if reservation is already in it => al gecheckt bij limo reservatie 
            if (!uow.Limousines.InDataBase(reservation.Details.Limousine))
                throw new ArgumentException("Limousine zit nog niet in databank gelieve Limousine eerst toe te voegen.");

            uow.Reservations.AddReservering(reservation);
            uow.Complete();
        }
        public IEnumerable<Limousine> GetLimousines()
        {
            return uow.Limousines.GetLimousines();
        }

        public IEnumerable<Client> GetClients()
        {
            return uow.Clients.GetClients();
        }
        public IEnumerable<Reservation> GetReservations()
        {
            return uow.Reservations.GetReservations();
        }
        public Category GetCategory(CategorieType type)
        {
            return uow.Categories.GetCategory(type);
        }
        public bool IsClientInDatabase(Client client)
        {
            return uow.Clients.InDataBase(client);
        }

    }
}
