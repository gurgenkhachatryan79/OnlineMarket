using Microsoft.AspNetCore.Mvc;
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
    public class OrderController : ControllerBase
    {
        private IOrderService _orderservice;
        private ILogger<IOrderService> _logger;
        public OrderController(IOrderService orderService,ILogger<IOrderService> logger)
        {
            _orderservice = orderService;
            _logger = logger;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            try
            {
                var orders = _orderservice.GetOrders();
                if (orders == null)
                {
                    _logger.LogInformation("orders null");
                    return NotFound();
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError("ex:", ex);
                return BadRequest();
            }
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            try
            {
                var order = await _orderservice.GetOrderId(id);
                if (order == null)
                {
                    _logger.LogInformation("order not found");
                    return NotFound();
                }
                return Ok(order);
            }
            catch (ArgumentOutOfRangeException argex)
            {
                _logger.LogError("argex:", argex);
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("ex:", ex);
                return BadRequest();
            }
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderDto orderdto)
        {
            if (id != orderdto.Id)
            {
                _logger.LogInformation("Not valid id");
                return BadRequest();
            }
            try
            {
                await _orderservice.UpdateOrder(orderdto, id);
            }
            catch (ArgumentOutOfRangeException argsex)
            {
                _logger.LogError("argsex:", argsex);
                return BadRequest();
            }
            catch (NullReferenceException nex)
            {
                _logger.LogError("nex:", nex);
                return BadRequest();
            }
            catch (Exception ex)
            {

                _logger.LogError("ex:", ex);
                return BadRequest();
            }
            return NoContent();
        }

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderDto orderdto)
        {
            try
            {
                await _orderservice.AddOrder(orderdto);
                return CreatedAtAction("GetOrder", new { id = orderdto.Id }, orderdto);
            }
            catch (ArgumentOutOfRangeException args)
            {
                _logger.LogError("args:",args);
                return BadRequest(args);
            }
            catch (Exception ex)
            {
                _logger.LogError("ex:", ex);
                return BadRequest();
            }



        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                await _orderservice.DeleteOrder(id);
            }
            catch (ArgumentOutOfRangeException args)
            {
                _logger.LogError("args:",args);
                return BadRequest();
            }

            return NoContent();
        }


    }
}
