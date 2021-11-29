using System.Collections.Generic;
using System.Threading.Tasks;
using UberDB.Models;

namespace UberDB.Data
{
    public interface ICustomerService
    {
        Task<IList<Customer>> GetCustomersAsync();
        Task<Customer>   AddCustomerAsync(Customer customer);
        Task   RemoveCustomerAsync(int customerId);
        Task<Customer>   UpdateCustomerAsync(Customer customer);
    }
}