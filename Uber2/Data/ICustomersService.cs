using System.Collections.Generic;
using System.Threading.Tasks;
using Uber2.Models;

namespace Uber2.Data
{
    public interface ICustomersService
    {
        Task<IList<Customer>> GetCustomersAsync();
        Task<Customer>   AddCustomerAsync(Customer customer);
        Task   RemoveCustomerAsync(int customerId);
        Task<Customer>   UpdateCustomerAsync(Customer customer);
    }
}