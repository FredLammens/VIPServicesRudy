
using DomainLibrary.Domain.Client;
using DomainLibrary.Domain.Limousines;
using DomainLibrary.Domain.Reservering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DataLayer
{
    public class VIPServicesRudyContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Limousine> Limousines { get; set; }
        private string connectionString;
        public VIPServicesRudyContext()
        {

        }
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
    }
}
