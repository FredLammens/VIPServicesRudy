using DataLayer;
using DomainLibrary;
using DomainLibrary.Domain;

namespace VIPServicesRudy
{
    class Program
    {
        static void Main(string[] args)
        {
            VIPServicesRudyTestContext testcontext = new VIPServicesRudyTestContext();
            IUnitOfWork uow = new UnitOfWork(testcontext);
            Parser.InsertIntoDatabase(uow);
        }
    }
}
