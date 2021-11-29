using Microsoft.EntityFrameworkCore;
using UberDB.Models;

namespace UberDB.Persistence
{
    public class UberContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // name of database
            optionsBuilder.UseSqlite(@"Data Source = D:\UberDB\UberDB\UberDB.db");
        }
    }
}