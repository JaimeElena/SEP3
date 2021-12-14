using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Uber2.Models;
using Uber2.Persistence;

namespace Uber2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (UberDBContext uberContext = new UberDBContext())
            {
                if (!uberContext.Customers.Any()||!uberContext.Drivers.Any())
                {
                    Seed(uberContext);
                }
            }
            CreateHostBuilder(args).Build().Run();
        }
        
        private static void Seed(UberDBContext uberContext)
        {
            Customer customer1 = new Customer();
            Driver driver1 = new Driver();
            Order order1 = new Order();

            order1.customer = "Tim";
            order1.driver = "ABC";
            order1.id = 1;
            order1.status = "Pending";
            order1.customerStreetName = "asdsd";
            order1.destinationStreetName = "fggfgfg";

            uberContext = new UberDBContext();
            //uberContext.Add(customer1);
            //uberContext.Add(driver1);
            uberContext.Add(order1);

            uberContext.SaveChanges();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}