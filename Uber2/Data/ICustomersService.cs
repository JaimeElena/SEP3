using System.Collections.Generic;
using System.Threading.Tasks;
using Uber2.Models;

namespace Uber2.Data
{
    public interface ICustomersService
    {
        Task<IList<Customer>> GetCustomersAsync();
        Task<Customer>   RegisterCustomerAsync(Customer customer);
        Task   RemoveCustomerAsync(int customerId);
        Task<Customer>   EditCustomerInfoAsync(Customer customer);

        Task Login(string username, string password);

        Task<Customer> SearchCustomer(string username);
        
    }
}