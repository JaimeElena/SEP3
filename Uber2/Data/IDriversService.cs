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
        Task<Driver>   UpdateDriverAsync(Driver driver);

        Task Login(string username, string password);
        
        Task<Driver> SearchDriver(string username);
    }
}