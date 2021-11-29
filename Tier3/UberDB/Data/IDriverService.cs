using System.Collections.Generic;
using System.Threading.Tasks;
using UberDB.Models;

namespace UberDB.Data
{
    public interface IDriverService
    {
        Task<IList<Driver>> GetDriversAsync();
        Task<Driver>   AddDriverAsync(Driver driver);
        Task   RemoveDriverAsync(int driverId);
        Task<Driver>   UpdateDriverAsync(Driver driver);
    }
}