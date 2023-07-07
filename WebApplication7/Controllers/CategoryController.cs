using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var categories = _dbContext.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult<Category> CreateCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            var existingCategory = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            // Update the properties of the existing category
            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;

            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
