using System.Threading.Tasks;
using UberT1Costumer.Models;

namespace UberT1Costumer.Data
{
    public interface IOrderingService
    {
        Task<Order> RequestVehicle(Order order);
        Task<string> CancelRequest(Order order);
        Task<string> CheckProcess(Order order);
    }
}