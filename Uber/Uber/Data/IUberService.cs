using System.Collections.Generic;
using System.Threading.Tasks;
using Uber.Models;

namespace Uber.Data
{
    public interface IUberService
    {
        Task<IList<Customer>> GetCustomersAsync();
        Task<Customer>   AddCustomerAsync(Customer customer);
        Task   RemoveCustomerAsync(int customerId);
        Task<Customer>   UpdateCustomerAsync(Customer customer);
        
        Task<IList<Driver>> GetDriversAsync();
        Task<Driver>   AddDriverAsync(Driver driver);
        Task   RemoveDriverAsync(int driverId);
        Task<Driver>   UpdateDriverAsync(Driver driver);
    }
}