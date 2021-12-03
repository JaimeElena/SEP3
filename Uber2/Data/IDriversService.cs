using System.Collections.Generic;
using System.Threading.Tasks;
using Uber2.Models;

namespace Uber2.Data
{
    public interface IDriversService
    {
        Task<IList<Driver>> GetDriversAsync();
        Task<Driver>   RegisterDriverAsync(Driver driver);
        Task   RemoveDriverAsync(int driverId);
        Task<Driver>   EditDriverInfoAsync(Driver driver);

        Task<Driver> Login(string username, string password);

        Task Logout(string username);
        
        Task<Driver> SearchDriver(string username);
    }
}