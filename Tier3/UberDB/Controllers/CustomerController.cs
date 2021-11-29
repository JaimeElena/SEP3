using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UberDB.Data;
using UberDB.Models;

namespace UberDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController:ControllerBase
    {
        private ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Customer>>> GetCustomers([FromQuery] string? username) 
        {
            try
            {
                IList<Customer> customers = await customerService.GetCustomersAsync();
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
                await customerService.RemoveCustomerAsync(Id);
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
                Customer added = await customerService.AddCustomerAsync(customer);
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
                Customer updated = await customerService.UpdateCustomerAsync(customer);
                return Ok(updated); 
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}