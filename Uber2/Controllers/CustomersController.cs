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
    public class CustomersController:ControllerBase
    {
        private readonly ICustomersService customersService;

        public CustomersController(ICustomersService customersService)
        {
            this.customersService = customersService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Customer>>> GetCustomers([FromQuery] string? username) 
        {
            try
            {
                IList<Customer> customers = await customersService.GetCustomersAsync();
                if (username != null)
                {
                    customers = customers.Where(customer => customer.username == username).ToList();
                }
                return Ok(customers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute] int Id) 
        {
            try
            {
                await customersService.RemoveCustomerAsync(Id);
                return Ok();
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer([FromBody] Customer customer) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Customer added = await customersService.RegisterCustomerAsync(customer);
                return Created($"/{added.id}",added);
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        [Route("{Id:int}")]
        public async Task<ActionResult<Customer>> UpdateCustomer([FromBody] Customer customer) 
        {
            try
            {
                Customer updated = await customersService.UpdateCustomerAsync(customer);
                return Ok(updated); 
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}