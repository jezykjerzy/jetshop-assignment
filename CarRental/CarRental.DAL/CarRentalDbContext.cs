using CarRental.DAL.Model;
using CarRental.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarRental.DAL
{
    public class CarRentalDbContext : DbContext
    {

        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options):base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarCategory> Categories { get; set; }

        public string DbPath { get; private set; }


        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=CarRentalDb;Trusted_Connection=true;MultipleActiveResultSets=True");
    }
}
