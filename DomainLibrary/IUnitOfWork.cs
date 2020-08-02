using DomainLibrary.Repositories;
using System;

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
