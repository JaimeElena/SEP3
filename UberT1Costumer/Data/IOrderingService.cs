using UberT1Costumer.Models;

namespace UberT1Costumer.Data
{
    public interface IOrderingService
    {
        public Order RequestVehicle(Order order);
        public Order CancelRequest(Order order);
    }
}