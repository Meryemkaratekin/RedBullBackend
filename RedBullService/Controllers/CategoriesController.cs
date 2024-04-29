using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RedbullService.Data;
using RedbullService.Models;
using Microsoft.EntityFrameworkCore;

namespace RedbullService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.kategoriId == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST: api/Categories
        [HttpPost]
        public IActionResult CreateCategory([FromBody] Categories category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Categories.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCategory), new { id = category.kategoriId }, category);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Categories category)
        {
            if (id != category.kategoriId || !_context.Categories.Any(c => c.kategoriId == id))
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.kategoriId == id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
