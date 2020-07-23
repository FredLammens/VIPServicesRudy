
using DomainLibrary.Domain.Limousines;
using DomainLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Domain
{
    public class Vloot
    {
        public IList<Limousine> Limousines { get; }
        public Vloot()
        {

        }
        public Vloot(IList<Limousine> limousines)
        {
            Limousines = limousines;
        }
        public void AddLimousine(Limousine limousine) 
        {
            Limousines.Add(limousine);
        }
        public void RemoveLimousine(Limousine limousine) 
        {
            Limousines.Remove(limousine);
        }
    }
}
