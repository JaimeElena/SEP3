using System.Collections.Generic;
using System.Threading.Tasks;
using Uber2.Models;

namespace Uber2.Data
{
    public class SqliteOrderService:IOrderService
    {
        public async Task<IList<Order>> GetOrdersAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Order> SearchOrder(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Location> GetFromLocation()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Location> GetToLocation()
        {
            throw new System.NotImplementedException();
        }
    }
}