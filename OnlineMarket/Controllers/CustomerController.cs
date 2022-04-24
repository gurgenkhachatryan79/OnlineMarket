using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineMarket.Dto;
using OnlineMarket.Models;
using OnlineMarket.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<ICustomerService> _logger;

        public CustomerController(ICustomerService customerService,ILogger<ICustomerService> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            try
            {
                var customers = _customerService.GetCustomers();
                if (customers == null)
                {
                    _logger.LogInformation("customer not found");
                    return BadRequest();
                }
                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError("ex:", ex);
                return BadRequest();
            }
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            ValidationNumber.ProductExists(id);
            try
            {
                var customer = await _customerService.GetCustomerId(id);

                if (customer == null)
                {
                    _logger.LogInformation("customer is null");
                    return NotFound();
                }

                return Ok(customer);
            }
            catch (ArgumentOutOfRangeException args)
            {
                return BadRequest(args);
            }
            catch (Exception ex)
            {
                _logger.LogError("ex:", ex);
                return BadRequest();
            }
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerDto customerdto)
        {
            if (id != customerdto.Id)
            {
                _logger.LogInformation("customer Not found ");
                return BadRequest();
            }

            try
            {
                await _customerService.UpdateCustomer(customerdto, id);

            }
            catch (DbUpdateConcurrencyException dbex)
            {
                _logger.LogError("dbex:", dbex);
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("ex:", ex);
                return BadRequest();
            }


            return NoContent();
        }

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CustomerDto customerdto)
        {
            try
            {
                await _customerService.AddCustomer(customerdto);
                return CreatedAtAction("GetCustomer", new { id = customerdto.Id }, customerdto);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _logger.LogError("ex:", ex);
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("ex:", ex);
                return BadRequest();
            }
        }
        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            ValidationNumber.ProductExists(id);
            try
            {
                await _customerService.DeleteCustomer(id);
            }
            catch (ArgumentOutOfRangeException args)
            {
                _logger.LogError("args:", args);
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("ex:", ex);
                return BadRequest();
            }
            return NoContent();
        }
    }
}
