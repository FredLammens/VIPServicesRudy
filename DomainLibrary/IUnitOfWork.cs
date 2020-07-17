using DomainLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IClientRepository Clients { get; }
        ILimousineRepository Limousines { get; }
        IReservationRepository Reservations { get; }
        int Complete();

    }
}
