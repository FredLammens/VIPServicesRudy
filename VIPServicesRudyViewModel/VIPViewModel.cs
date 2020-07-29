using System;
using DataLayer;
using DomainLibrary;
using DomainLibrary.Domain;

namespace VIPServicesRudyViewModel
{
    public class VIPViewModel
    {
        VIPServicesRudyManager manager = new VIPServicesRudyManager(new UnitOfWork(new VIPServicesRudyContext()));

    }
}
