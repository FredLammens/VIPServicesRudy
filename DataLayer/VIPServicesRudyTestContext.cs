namespace DataLayer
{
    public class VIPServicesRudyTestContext : VIPServicesRudyContext
    {
        public VIPServicesRudyTestContext() : base("Test")
        {

        }
        public VIPServicesRudyTestContext(bool keepExistingDB = false) : base("Test")
        {
            if (keepExistingDB)
                Database.EnsureCreated();
            else
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
    }
}
