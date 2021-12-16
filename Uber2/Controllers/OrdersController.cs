using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uber2.Data;
using Uber2.Models;

namespace Uber2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class OrdersController:ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Order>>> GetCustomerOrders([FromQuery] string? username) 
        {
            try
            {
                IList<Order> orders = await orderService.GetOrdersAsync();
                if (username != null)
                {
                    orders = orders.Where(order => order.customer == username).ToList();
                }
                return Ok(orders);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("SearchOrderByID")]
        [Route("{id:int}")]
        public async Task<ActionResult<Order>> GetOrderById([FromQuery] int? id)
        {
            int idcopy = id.Value;
            Order order = await orderService.SearchOrder(idcopy);
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> AddOrder([FromBody] Order order) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Order added = await orderService.AddOrder(order);
                if (added.Equals(true))
                {
                    Console.WriteLine("Add Order Successful!");
                    return added;
                }
                return Created($"/{added.id}",added);
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch("EditStatus")]
        public async Task<ActionResult<Order>> UpdateOrder([FromBody] Order order,string status) 
        {
            try
            {
                Order updated = await orderService.EditOrderStatus(order,status);
                return Ok(orderService.SearchOrder(updated.id)); 
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetHistoryOrders")]
        [Route("{customer}")]
        public async Task<ActionResult<IList<Order>>> GetHistoryOrders([FromQuery] string? customer)
        {
            IList<Order> completed = await orderService.GetHistoryOrders(customer);
            return Ok(completed);
        }

        [HttpGet("GetPendingOrders")]
        public async Task<ActionResult<IList<Order>>> GetPendingOrders()
        {
            IList<Order> pending = await orderService.GetPendingOrders();
            return Ok(pending);
        }


        [HttpPatch("AcceptOrder")]
        public async Task<ActionResult<Order>> AcceptOrder([FromBody] Order order) 
        {
            try
            {
                Order update = await orderService.EditOrderStatus(order, "Accepted");
                return Ok(orderService.SearchOrder(update.id)); 
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch("CompleteOrder")]
        public async Task<ActionResult<Order>> CompleteOrder([FromBody] Order order)
        {
            try
            {
                Order update = await orderService.EditOrderStatus(order, "Completed");
                return Ok(orderService.SearchOrder(update.id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch("DenyOrder")]
        public async Task<ActionResult<Order>> DenyOrder([FromBody] Order order) 
        {
            try
            {
                Order update = await orderService.EditOrderStatus(order,"Denied");
                return Ok(orderService.SearchOrder(update.id)); 
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch("CancelOrder")]
        public async Task<ActionResult<Order>> CancelOrder([FromBody] Order order) 
        {
            try
            {
                Order update = await orderService.EditOrderStatus(order,"Canceled");
                return Ok(orderService.SearchOrder(update.id)); 
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteOrder([FromRoute]int id)
        {
            try 
            {
                    await orderService.DeleteOrder(id);
                    return Ok();
                    
            } catch (Exception e) 
            {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
            }
        }
        }
    }