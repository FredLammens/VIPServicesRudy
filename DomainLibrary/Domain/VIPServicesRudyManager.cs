using DomainLibrary.Domain.Clients;
using DomainLibrary.Domain.Limousines;
using DomainLibrary.Domain.Limousines.HourlyArrangements;
using DomainLibrary.Domain.Reservering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace DomainLibrary.Domain
{
    public class VIPServicesRudyManager
    {
        private readonly IUnitOfWork uow;

        public VIPServicesRudyManager(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void AddReservation(Reservation reservation) 
        {
            //check if reservation is already in it => al gecheckt bij limo reservatie 
            //check of client al in db check of limo al in databank
            if (!uow.Clients.inDataBase(reservation.Client))
                throw new ArgumentException("Client zit nog niet in databank gelieve client eerst toe te voegen.");
            if(!uow.Limousines.inDataBase(reservation.Details.Limousine))
                throw new ArgumentException("Limousine zit nog niet in databank gelieve Limousine eerst toe te voegen.");

            uow.Reservations.AddReservering(reservation);
            uow.Complete();
        }
        public void AddClient(Client client) 
        {
            //check if client is already in it
            if (uow.Clients.inDataBase(client))
                throw new ArgumentException("Client zit al in de databank.");
            uow.Clients.AddClient(client);
            uow.Complete();
        }
        public Client GetClient(int number)
        {
            return uow.Clients.GetClient(number);
        }
        public void AddLimousine(Limousine limo) 
        {
            if (uow.Limousines.inDataBase(limo))
                throw new ArgumentException("Limousine zit al in database.");
            //check limousine enkel vasteArrangementen
            if (limo.FixedArrangements.Count < 3)
                throw new ArgumentException("Limousine moet 3 vaste arrangementen hebben.");
            if (limo.FixedArrangements.OfType<HourlyArrangement>().Any())
                throw new ArgumentException("Limousine mag enkel vasteArrangementen hebben.");
            uow.Limousines.AddLimousine(limo);
            uow.Complete();
        }
        public IEnumerable<Limousine> GetAllLimousine() //Vloot
        {
            return uow.Limousines.GetAllLimousines();
        }
        //----------------------------------------------------Tests-------------------------------------------------
        public IEnumerable<Reservation> getReservations(Client client) 
        {
            return uow.Reservations.GetReservations(client);
        }
        public IEnumerable<Reservation> getReservations(DateTime startDate) 
        {
            return uow.Reservations.GetReservations(startDate);
        }
        public IEnumerable<Client> GetClientsWithName(string name) 
        {
            return uow.Clients.GetClientsWithName(name);
        }
        public IEnumerable<Client> GetClientsWithAdres(string adres) 
        {
            return uow.Clients.GetClientsWithAdres(adres);
        }
        public IEnumerable<Client> GetClientsWithVAT(string vatnumber) 
        {
            return uow.Clients.GetClientsWithVAT(vatnumber);
        }

    }
}
