﻿using DomainLibrary.Domain.Clients;
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
            if(!uow.Limousines.inDataBase(reservation.Details.Limousine))
                throw new ArgumentException("Limousine zit nog niet in databank gelieve Limousine eerst toe te voegen.");

            uow.Reservations.AddReservering(reservation);
            uow.Complete();
        }
        
        public IEnumerable<Limousine> GetAllLimousine() //Vloot
        {
            return uow.Limousines.GetAllLimousines();
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
            return uow.Clients.inDataBase(client);
        }

    }
}
