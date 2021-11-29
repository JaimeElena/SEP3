using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Uber.Data;
using Uber.Models;

namespace Uber.Controllers
{
   
        [ApiController]
        [Route("[controller]")]
        public class CostumerController : ControllerBase
        {
            private ICostumerService costumerService;
            public CostumerController(ICostumerService costumerService)
            {
                this.costumerService = costumerService;
            }

            [HttpGet]
            public async Task<ActionResult<IList<Costumer>>> GetCostumers()
            {
                try
                {
                    IList<Costumer> costumers = await costumerService.GetCostumersAsync();
                    return Ok(costumers);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPost]
            public async Task<ActionResult<Costumer>> AddCostumer(Costumer costumer)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                try
                {
                    Costumer added = await costumerService.AddCostumerAsync(costumer);
                    return Created($"/{added.id}", added);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return StatusCode(500, e.Message);
                }
            }
        }
    
}
