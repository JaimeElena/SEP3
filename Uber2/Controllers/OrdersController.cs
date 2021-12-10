﻿using System;
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

        [HttpGet("GetCompletedOrders")]
        public async Task<ActionResult<IList<Order>>> GetCompletedOrders(string customer)
        {
            IList<Order> completed = await orderService.GetCompletedOrders(customer);
            return Ok(completed);
        }

        [HttpGet("GetPendingOrders")]
        public async Task<ActionResult<IList<Order>>> GetPendingOrders()
        {
            IList<Order> pending = await orderService.GetPendingOrders();
            return Ok(pending);
        }


        [HttpPatch("AcceptOrder")]
        public async Task<ActionResult<Order>> AcceptOrder([FromBody] Order order,string drivername) 
        {
            try
            {
                Order updated = await orderService.EditOrderDriver(order,drivername);
                orderService.EditOrderStatus(order,"Pending");
                return Ok(orderService.SearchOrder(updated.id)); 
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch("DenyOrder")]
        public async Task<ActionResult<Order>> DenyOrder([FromBody] Order order) 
        {
            try
            {
                orderService.EditOrderStatus(order,"Denied");
                return Ok(orderService.SearchOrder(order.id)); 
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
    
    
}