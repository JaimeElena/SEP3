using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Uber.Models;
using Uber.Persistence;

namespace Uber.Data
{
    public class SqliteUberService:IUberService
    {
        private UberContext uberContext;

        public SqliteUberService(UberContext uberContext)
        {
            this.uberContext = uberContext;
        }
        
        public async Task<IList<Customer>> GetCustomersAsync()
        {
            return await uberContext.Customers.ToListAsync();
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            EntityEntry<Customer> customerAdd = await uberContext.Customers.AddAsync(customer);
            await uberContext.SaveChangesAsync();
            return customerAdd.Entity;
        }

        public async Task RemoveCustomerAsync(int customerId)
        {
            Customer customerRemove = await uberContext.Customers.FirstAsync(c => c.id == customerId);
            if (customerRemove != null)
            {
                uberContext.Customers.Remove(customerRemove);
                await uberContext.SaveChangesAsync();
            }
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                Customer customerUpdate = await uberContext.Customers.FirstOrDefaultAsync(c => c.id == customer.id);
                customerUpdate.username = customer.username;
                customerUpdate.password = customer.password;
                uberContext.Update(customerUpdate);
                await uberContext.SaveChangesAsync();
                return customerUpdate;
            }
            catch (Exception e)
            {
                throw new Exception($"Did not find customer with id{customer.id}");
            }
        }

        public async Task<IList<Driver>> GetDriversAsync()
        {
            return await uberContext.Drivers.ToListAsync();
        }

        public async Task<Driver> AddDriverAsync(Driver driver)
        {
            EntityEntry<Driver> driverAdd = await uberContext.Drivers.AddAsync(driver);
            await uberContext.SaveChangesAsync();
            return driverAdd.Entity;
        }

        public async Task RemoveDriverAsync(int driverId)
        {
            Driver driverRemove = await uberContext.Drivers.FirstAsync(d => d.id == driverId);
            if (driverRemove != null)
            {
                uberContext.Drivers.Remove(driverRemove);
                await uberContext.SaveChangesAsync();
            }
        }

        public async Task<Driver> UpdateDriverAsync(Driver driver)
        {
            try
            {
                Driver driverUpdate = await uberContext.Drivers.FirstOrDefaultAsync(d => d.id == driver.id);
                driverUpdate.username = driverUpdate.username;
                driverUpdate.password = driverUpdate.password;
                uberContext.Update(driverUpdate);
                await uberContext.SaveChangesAsync();
                return driverUpdate;
            }
            catch (Exception e)
            {
                throw new Exception($"Did not find driver with id{driver.id}");
            }
        }
    }
}