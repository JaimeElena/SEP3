using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Uber2.Models;
using Uber2.Persistence;

namespace Uber2.Data
{
    public class SqliteOrderService:IOrderService
    {
        UberDBContext uberContext;

        public SqliteOrderService()
        {
            uberContext = new UberDBContext();
        }
        public async Task<IList<Order>> GetOrdersAsync()
        {
            return await uberContext.Orders.ToListAsync();
        }

        public async Task<Order> AddOrder(Order order)
        {
            EntityEntry<Order> orderAdd = await uberContext.Orders.AddAsync(order);
            await uberContext.SaveChangesAsync(); 
            return orderAdd.Entity;
        }

        public async Task<Order> SearchOrder(int id)
        {
            var list = uberContext.Orders;
            foreach (var order in list)
            {
                if (order.id == id)
                {
                    return order;   
                }
            }
            return null;
        }


        public async Task<Order> EditOrderStatus(Order order,string status)
        {
            try
            {
                Order orderUpdate = await uberContext.Orders.FirstOrDefaultAsync(o => o.id == order.id);
                orderUpdate.status = status;
                uberContext.Update(orderUpdate);
                await uberContext.SaveChangesAsync();
                return orderUpdate; 
            }
            catch (Exception e) 
            { 
                throw new Exception($"Did not find order with id{order.id}"); 
            }
        }

        public async Task<IList<Order>> GetCompletedOrders(string customer)
        {
            try
            {
                var all = uberContext.Orders;
                IList<Order> list = new List<Order>();
                foreach (var order in all)
                {
                    if (order.status == "Completed" && order.customer == customer)
                    {
                        list.Add(order);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IList<Order>> GetPendingOrders()
        {
            try
            {
                var all = uberContext.Orders;
                IList<Order> list = new List<Order>();
                foreach (var order in all)
                {
                    if (order.status == "Pending")
                    {
                        list.Add(order);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Order> EditOrderDriver(Order order)
        {
            try
            {
                Order orderUpdate = await uberContext.Orders.FirstOrDefaultAsync(o => o.id == order.id);
                uberContext.Update(orderUpdate);
                await uberContext.SaveChangesAsync();
                return orderUpdate; 
            }
            catch (Exception e) 
            { 
                throw new Exception($"Did not find order with id{order.id}"); 
            };
        }

        public async Task<string> GetCustomerStreetName(Order order)
        {
            Order orderUpdate = await uberContext.Orders.FirstOrDefaultAsync(o => o.id == order.id);
            return orderUpdate.customerStreetName;
        }

        public async Task<string> GetDestinationStreetName(Order order)
        {
            Order orderUpdate = await uberContext.Orders.FirstOrDefaultAsync(o => o.id == order.id);
            return orderUpdate.destinationStreetName;
        }
    }
    }