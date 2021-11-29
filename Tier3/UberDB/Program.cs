using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UberDB.Models;
using UberDB.Persistence;

namespace UberDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (UberContext uberContext = new UberContext())
            {
                if (!uberContext.Customers.Any()||!uberContext.Drivers.Any())
                {
                    Seed(uberContext);
                }
            }
            CreateHostBuilder(args).Build().Run();
        }
        
        private static void Seed(UberContext uberContext)
        {
            Customer customer1 = new Customer();
            Driver driver1 = new Driver();

            customer1.id = 1;
            customer1.username = "Buger King";
            customer1.password = "asdasda232323";
            customer1.firstname = "Siyu";
            customer1.secondname = "Xia";
            customer1.birthday = "2001.04.02";
            customer1.sex = "M";

            driver1.id = 1;
            driver1.username = "Tim";
            driver1.password = "ADDrtrt2324";
            
            uberContext = new UberContext();
            uberContext.Add(customer1);
            uberContext.Add(driver1);

            uberContext.SaveChanges();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}