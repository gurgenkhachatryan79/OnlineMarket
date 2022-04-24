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
    public class ProductController : ControllerBase
    {

        private IProductService _productService;
        private ILogger<ProductController> _logger;
        public ProductController(IProductService productService,ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                var products = _productService.GetProducts();

                if (products == null)
                {
                    _logger.LogInformation("No Product");
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError("exception:",ex);
                return BadRequest();
            }

        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _productService.GetProductById(id);
                if (product == null)
                {
                    _logger.LogInformation("Product not found");
                    return BadRequest("Product not found");
                }
                return product;
            }
            catch (ArgumentOutOfRangeException argex)
            {
                _logger.LogError("argex:", argex);
                return BadRequest(argex);
            }
            catch (Exception ex)
            {
                _logger.LogError("ex:",ex);
                return BadRequest(ex);
            }

        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDto productdto)
        {
            if (id != productdto.Id)
            {
                _logger.LogInformation(" Not  valid Id ");
                return BadRequest();
            }

            try
            {
                await _productService.UpdateProduct(productdto, id);

            }
            catch (DbUpdateConcurrencyException dbex)
            {
                _logger.LogError(dbex, "");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("ex:", ex);
                return BadRequest(ex);
            }


            return NoContent();
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostProduct(ProductDto productdto)
        {
            try
            {
                await _productService.AddProduct(productdto);
                return CreatedAtAction("GetProduct", new { id = productdto.Id }, productdto);
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

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProduct(id);
            }
            catch (ArgumentOutOfRangeException argsex)
            {
                _logger.LogError("argsex:", argsex);
                return BadRequest();
            }
            return NoContent();
        }


    }
}
