using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_IntroToEntityFramework
{
    //Entities
    class Client
    {
        //Primary Key namig : Id, id, ID, EntityName + Id
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        //Relationship type 
        public ICollection<Flight> Flights { get; set; }
    }
    class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassangers { get; set; }
        //Relationship type 
        public ICollection<Flight> Flights { get; set; }
    }
    class Flight
    {
        public int Id { get; set; }
        public string ArrivalCity { get; set; }
        public string DeparturelCity { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DeparturelTime { get; set; }
        //Foreign key : RelatedEntityName + RelatedEntityPrimaryKeyName
        public int AirplaneId { get; set; }
        //Relationship type 
        public Airplane Airplane { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
    internal class AirplaneDbContext : DbContext
    {
        public AirplaneDbContext()
        {
            this.Database.EnsureCreated();
        }
        //Collections
        //Airplanes
        //Clients
        //Flights
        public DbSet<Client> Clients { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3HG9UVT\SQLEXPRESS;
                                            Initial Catalog = NewDatabaseAirplane2;
                                            Integrated Security=True;
                                            Connect Timeout=2;Encrypt=False;
                                            TrustServerCertificate=False;
                                            ApplicationIntent=ReadWrite;
                                            MultiSubnetFailover=False");
        }
    }
}
