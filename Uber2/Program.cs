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
            driver1.isFree = false;

            uberContext = new UberDBContext();
            uberContext.Add(customer1);
            uberContext.Add(driver1);

            uberContext.SaveChanges();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}