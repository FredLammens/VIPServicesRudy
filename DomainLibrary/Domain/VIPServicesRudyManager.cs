using DomainLibrary.Domain.Clients;
using DomainLibrary.Domain.Limousines;
using DomainLibrary.Domain.Limousines.HourlyArrangements;
using DomainLibrary.Domain.Reservering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DomainLibrary.Domain
{
    public class VIPServicesRudyManager
    {
        private IUnitOfWork uow;

        public VIPServicesRudyManager(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddCategory(List<Discount> staffDiscount,CategorieType name) //enkel voor inserten
        {
            uow.Categories.AddCategory(new Category(staffDiscount,name));
            uow.Complete();
        }
        public void AddReservation(string adress,Client client,DateTime reservationDateStart,DateTime reservationDateEnd,Location startLocation,Location arrivalLocation,Limousine limousine, Arrangement arrangement) 
        {
            //check if reservation is already in it => in ui fase checken 
            uow.Reservations.AddReservering(new Reservation(adress, client, new ReservationDetails(reservationDateStart, reservationDateEnd, startLocation, arrivalLocation, limousine, arrangement)));
            uow.Complete();
        }
        public void AddClient(string name,string VATNumber,string adres,Category category) 
        {
            //check if client is already in it  => in ui fase checken 
            uow.Clients.AddClient(new Client(name, VATNumber, adres, category));
            uow.Complete();
        }
        public void AddLimousine(string name,int firstHourPrice,List<Arrangement> fixedArrangements) 
        {
            //check limousine enkel vasteArrangementen
            if (fixedArrangements.OfType<HourlyArrangement>().Any())
            {
                throw new ArgumentException("Limousine mag enkel vasteArrangementen hebben");
            }
            uow.Limousines.AddLimousine(new Limousine(name, firstHourPrice, fixedArrangements));
            uow.Complete();
        }
        public void RemoveCategory(CategorieType name)
        {
            uow.Categories.RemoveCategory(name);
            uow.Complete();
        }
        public void RemoveReservation(int number) 
        {
            uow.Reservations.RemoveReservering(number);
        }
        public void RemoveClient(int clientNumber) 
        {
            uow.Clients.RemoveClient(clientNumber);
        }
        public void RemoveLimousine(int Id) 
        {
            uow.Limousines.RemoveLimousine(Id);
        }
        public void GetAllLimousine() 
        {
            uow.Limousines.GetAllLimousines();
        }
    }
}
