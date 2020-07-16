using DomainLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    interface ILimousineRepository
    {
        void AddLimousine(ILimousine limousine);
        void RemoveLimousine(ILimousine limousine);
    }
}
