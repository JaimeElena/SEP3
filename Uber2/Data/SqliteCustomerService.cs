using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Uber2.Models;
using Uber2.Persistence;

namespace Uber2.Data
{
    public class SqliteCustomerService:ICustomersService
    {
        UberDBContext uberContext;

        public SqliteCustomerService()
        {
            uberContext = new UberDBContext();
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
                customerUpdate.birthday = customer.birthday;
                customerUpdate.firstname = customer.firstname;
                customerUpdate.secondname = customer.secondname;
                customerUpdate.sex = customer.sex;
                uberContext.Update(customerUpdate);
                await uberContext.SaveChangesAsync();
                return customerUpdate;
            }
            catch (Exception e)
            {
                throw new Exception($"Did not find customer with id{customer.id}");
            }
        }
    }
}