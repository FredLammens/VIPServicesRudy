using DomainLibrary.Domain.Clients;
using DomainLibrary.Domain.Limousines;
using DomainLibrary.Domain.Limousines.FixedArrangements;
using DomainLibrary.Domain.Limousines.HourlyArrangements;
using DomainLibrary.Domain.Reservering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataLayer
{
    public class VIPServicesRudyContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Limousine> Limousines { get; set; }
        //-----abstract classes
        public DbSet<NightLife> Nightlifes { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<Wellness> Wellnesses { get; set; }
        public DbSet<HourlyArrangement> HourlyArrangements { get; set; }
        //----------------------
        private string connectionString;
        public VIPServicesRudyContext() { }
        public VIPServicesRudyContext(string db="VIPServicesRudy") : base()
        {
            SetConnectionString(db);
        }
        private void SetConnectionString(string db = "VIPServicesRudy") 
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();
            switch (db) 
            {
                case "VIPServicesRudy":
                    connectionString = configuration.GetConnectionString("VIPServicesRudyconnection").ToString();
                    break;
                case "Test":
                    connectionString = configuration.GetConnectionString("VIPServicesRudyTestDbconnection").ToString();
                    break;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (connectionString == null)
                SetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Arrangement>()
                .ToTable("Arrangements")
                .HasDiscriminator<int>("ArrangementType")
                .HasValue<NightLife>(1)
                .HasValue<Wedding>(2)
                .HasValue<Wellness>(3)
                .HasValue<HourlyArrangement>(4);
        }
    }
}
