using Microsoft.EntityFrameworkCore;
using Uber2.Models;

namespace Uber2.Persistence
{
    public class UberDBContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = D:\Uber2\Uber2\UberDB.db");
        }
    }
}