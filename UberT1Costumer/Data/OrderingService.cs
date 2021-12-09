using UberT1Costumer.Models;
using UberT1Costumer.Services;

namespace UberT1Costumer.Data
{
    public class OrderingService:IOrderingService
    {
        public Order RequestVehicle(Order order)
        {
            return ClientController.getInstance().RequestVehicle(order);
        }

        public Order CancelRequest(Order order)
        {
            return ClientController.getInstance().CancelRequest(order);
        }
    }
}