using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uber.Data;
using Uber.Models;

namespace Uber.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UberController:ControllerBase
    {
        private IUberService uberService;

        public UberController(IUberService uberService)
        {
            this.uberService = uberService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Customer>>> GetCustomers([FromQuery] string? username) 
        {
            try
            {
                IList<Customer> customers = await uberService.GetCustomersAsync();
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
                await uberService.RemoveCustomerAsync(Id);
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
                Customer added = await uberService.AddCustomerAsync(customer);
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
                Customer updated = await uberService.UpdateCustomerAsync(customer);
                return Ok(updated); 
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Driver>>> GetDrivers([FromQuery] string? username) 
        {
            try
            {
                IList<Driver> drivers = await uberService.GetDriversAsync();
                if (username != null)
                {
                    drivers = drivers.Where(driver => driver.username == username).ToList();
                }
                return Ok(drivers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<ActionResult> DeleteDriver([FromRoute] int Id) 
        {
            try
            {
                await uberService.RemoveDriverAsync(Id);
                return Ok();
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Customer>> AddDriver([FromBody] Driver driver) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Driver added = await uberService.AddDriverAsync(driver);
                return Created($"/{added.id}",added);
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        [Route("{Id:int}")]
        public async Task<ActionResult<Customer>> UpdateDriver([FromBody] Driver driver) 
        {
            try
            {
                Driver updated = await uberService.UpdateDriverAsync(driver);
                return Ok(updated); 
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}