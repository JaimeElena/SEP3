using UberT1Costumer.Models;

namespace UberT1Costumer.Data
{
    public interface IOrderingService
    {
        public Order RequestVehicle(Order order);
        public string CancelRequest(Order order);
        public string CheckProcess(Order order);
    }
}