using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RedBullService.Models;
using RedbullService.Data;
using Microsoft.EntityFrameworkCore;

namespace RedBullService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.urunId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Products product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProduct), new { id = product.urunId }, product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Products product)
        {
            if (id != product.urunId || !_context.Products.Any(p => p.urunId == id))
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.urunId == id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
