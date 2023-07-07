using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _dbContext.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var existingProduct = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            // Update the properties of the existing product
            existingProduct.Name = product.Name;
            existingProduct.Category = product.Category;
            existingProduct.Quantity = product.Quantity;
            existingProduct.Price = product.Price;

            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
