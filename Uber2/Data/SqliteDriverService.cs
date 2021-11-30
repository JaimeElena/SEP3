using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Uber2.Models;
using Uber2.Persistence;

namespace Uber2.Data
{
    public class SqliteDriverService:IDriversService
    {
        UberDBContext uberContext;

        public SqliteDriverService()
        {
            uberContext = new UberDBContext();
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