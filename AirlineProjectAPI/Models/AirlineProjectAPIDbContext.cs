using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Transactions;
using Microsoft.Win32;

namespace AirlineProjectAPI.Models
{
    public class AirlineProjectAPIDbContext : DbContext
    {
        public DbSet<Register> Register { get; set; }
        public DbSet<Routes> Routes { get; set; }
        public DbSet<Flight> Flight { get; set; }

        public DbSet<Booking> Booking { get; set; }

        // public AirlineProjectAPIDbContext() : base() { }

        //        public AirlineProjectAPIDbContext(DbContextOptions<AirlineProjectAPIDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Airline_DB;Integrated Security=True;");

            }
        }

    }
}
