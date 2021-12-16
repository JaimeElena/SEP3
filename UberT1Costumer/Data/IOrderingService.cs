using System.Collections.Generic;
using System.Threading.Tasks;
using UberT1Costumer.Models;

namespace UberT1Costumer.Data
{
    public interface IOrderingService
    {
        Task<Order> RequestVehicle(Order order);
        Task<string> CancelRequest(Order order);
        Task<Order> CheckProcess(Order order);
        public Order GetOrder();
        Task<IList<HistoryOrder>> GetHistory(Costumer costumer);
        bool GetHaveOrder();
        void DontHaveOrder();
    }
}