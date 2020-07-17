using DomainLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    public interface IClientRepository
    {
        void AddClient(IClient client);
        void RemoveClient(IClient client);
    }
}
